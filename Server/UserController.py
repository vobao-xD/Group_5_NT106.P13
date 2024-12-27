import logging
from datetime import datetime, timedelta
from fastapi import FastAPI, HTTPException, Depends, Query
from fastapi.security import OAuth2PasswordBearer, HTTPAuthorizationCredentials, HTTPBearer
import pyodbc
import jwt
from typing import Optional, List
from ConnectDB import connect_to_sql_server
from models_for_server import *
import secrets
from urllib.parse import unquote
from pydantic import BaseModel


def generate_secret_key():
    return secrets.token_hex(32)

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")
secret_key = generate_secret_key()
print(secret_key)

def verify_token(credentials: HTTPAuthorizationCredentials = Depends(HTTPBearer())):
    try:
        payload = jwt.decode(credentials.credentials, secret_key, algorithms=["HS256"])
        return payload
    except jwt.ExpiredSignatureError:
        raise HTTPException(status_code=401, detail="Token has expired")
    except jwt.InvalidTokenError:
        raise HTTPException(status_code=401, detail="Invalid token")

tags_metadata = [
    {
        "name": "users",
        "description": "Operations with users. The **login** logic is also here.",
    },
    {
        "name": "items",
        "description": "Manage items. So _fancy_ they have their own docs.",
        "externalDocs": {
            "description": "Items external docs",
            "url": "https://fastapi.tiangolo.com/",
        },
    },
]


app = FastAPI(
    openapi_tags=tags_metadata
)

@app.post("/create_user/", tags=['users'])
def create_user(user: User):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute("EXEC prod_create_user ?, ?, ?, ?, ?", user.username, user.password, user.fullname, user.email, 3)
        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()
        logging.info(f"Stored procedure executed successfully: {row}")

        if row:
            logging.info(f"Result: {row[0]}")
            return {"Id": row[0], "Message": row[1]}  # JSON string returned by SQL Server
        else:
            logging.warning("No result returned from the stored procedure.")
            raise HTTPException(status_code=400, detail="No result returned from the stored procedure.")
    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/forget_password", tags=['users'])
def forget_password(req: ForgetPasswordReq):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute("EXEC prod_forget_password ?, ?", req.email, req.password)

        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()
        logging.info(f"Stored procedure executed successfully: {row}")

        if row:
            logging.info(f"Result: {row[0]}")
            return {"Id": row[0], "Message": row[1]}  # JSON string returned by SQL Server
        else:
            logging.warning("No result returned from the stored procedure.")
            raise HTTPException(status_code=400, detail="No result returned from the stored procedure.")
    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")


@app.post("/create_trip/", tags=['trips'])
def create_trip(trip: Trip):
    try:
        # Kết nối tới SQL Server
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        # Gọi stored procedure với tham số từ đối tượng trip
        cursor.execute(
            "EXEC prod_create_trip ?, ?, ?, ?, ?, ?, ?",
            trip.plate,
            trip.seat_num,
            1,
            trip.depart_location,
            trip.arrive_location,
            trip.depart_time,
            1,
        )

        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()
        logging.info(f"Stored procedure executed successfully: {row}")

        if row:
            logging.info(f"Result: {row[0]}")
            return {"Id": row[0], "Message": row[1]}  # JSON string returned by SQL Server
        else:
            logging.warning("No result returned from the stored procedure.")
            raise HTTPException(status_code=400, detail="No result returned from the stored procedure.")
    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/update_password", tags=['users'])
def update_password_v(req: UpdatePasswordReq, token: dict = Depends(verify_token)):
    try:
        token_username = token.get("username")
        if token_username != req.username:
            raise HTTPException(status_code=403, detail="Token does not match username")

        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute("EXEC prod_update_password ?, ?", req.username, req.password)
        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()
        logging.info(f"Stored procedure executed successfully: {row}")

        if row:
            logging.info(f"Result: {row[0]}")
            return {"Id": row[0], "Message": row[1]}  # JSON string returned by SQL Server
        else:
            logging.warning("No result returned from the stored procedure.")
            raise HTTPException(status_code=400, detail="No result returned from the stored procedure.")

        logging.info(f"Stored procedure executed successfully: {row}")
        if row:
            return {"Id": row[0], "Message": row[1]}
        else:
            logging.warning("No result returned from the stored procedure.")
            raise HTTPException(
                status_code=400, detail="No result returned from the stored procedure."
            )
    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/login/", tags=['users'])
def login_user(login: LoginRequest):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_check_login ?, ?", login.username, login.password)
        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()

        if row:
            user_id = row[0]
            fullname = row[1]
            logging.info(f"User {login.username} authenticated successfully.")
            token = jwt.encode({
                'user_id': user_id,
                'username': login.username,
                'exp': datetime.utcnow() + timedelta(hours=1)
            }, secret_key, algorithm="HS256")
            return {
                "UserId": user_id,
                "FullName": fullname,
                "Message": "Login successful",
                "TokenType": "Bearer",
                "AccessToken": token
            }
        else:
            logging.warning(f"Invalid login attempt for user: {login.username}")
            raise HTTPException(status_code=401, detail="Invalid username or password")

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.get("/getlistcustomer", tags=['users'])
def get_list_customer(userroleid: int = Query(..., description="ID of the user role")):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_all_customer ?", userroleid)
        rows = cursor.fetchall()
        conn.commit()
        cursor.close()
        conn.close()

        customers = []
        for row in rows:
            customer = {
                "UserId": row[0],
                "FullName": row[2],
                "UserName": row[1],
                "UserRoleId": row[4],
                "UserEmail": row[3]
            }
            customers.append(customer)
        return customers

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.get("/getSeatBooked", tags=['bus'])
def get_list_bus(busid: int = Query(..., description="BusId of that Bus"),
                isbook: int = Query(..., description="Booked status of that seat")):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_seat_booked ?, ?", busid, isbook)

        rows = cursor.fetchall()
        conn.commit()
        cursor.close()
        conn.close()

        buses = []
        for row in rows:
            bus = {
                "LicensePlate": row[0],
                "SeatName": row[1],
                "IsBook": row[2],
                "SeatId": row[3]
            }
            buses.append(bus)
        return buses

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.get("/getAllBus", tags=['bus'])
def get_list_customer():
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_all_bus")
        rows = cursor.fetchall()
        conn.commit()
        cursor.close()
        conn.close()

        customers = []
        for row in rows:
            customer = {
                "BusId": row[0],
                "LicensePlate": row[1],
                "SeatNum": row[2],
                "BusStatusId": row[3]
            }
            customers.append(customer)
        return customers

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.get("/getAllTrip", tags=['trip'])
def get_all_trip():
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_all_trip")
        rows = cursor.fetchall()
        conn.commit()
        cursor.close()
        conn.close()

        trips = []
        for row in rows:
            trip = {
                "TripId": row[0],
                "Plate": row[1],
                "DepartLocation": row[2],
                "ArriveLocation": row[3],
                "DepartTime": row[4],
                "TripStatusId": row[5],
                "TripStatusName": row[6]
            }
            trips.append(trip)
        return trips

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/userinfo/", tags=['users'])
def user_info(login: LoginRequest, token: dict = Depends(verify_token)):
    try:
        token_username = token.get("username")
        if token_username != login.username:
            raise HTTPException(status_code=403, detail="Token does not match username")

        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_user_by_pass ?, ?", login.username, login.password)
        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()

        if row:
            user_id = row[0]
            fullname = row[1]
            user_email = row[2]
            user_role_id = row[3]
            return {
                "UserId": user_id,
                "FullName": fullname,
                "UserEmail": user_email,
                "UserRoleId": user_role_id,
                "Message": "Login successful"
            }
        else:
            logging.warning(f"Invalid login attempt for user: {login.username}")
            raise HTTPException(status_code=401, detail="Invalid username or password")

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")@app.post("/userinfo/", tags=['users'])

@app.post("/updateVipCustomer", tags=['users'])
def user_info(req: UpdateVIPReq):
    try:

        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_update_customer_vip ?", req.userid)
        cursor.nextset()

        row = cursor.fetchone()

        conn.commit()
        cursor.close()
        conn.close()

        if row:
            return { "Id": row[0], "Message": row[1] }
        else:
            return { "Id": -1, "Message": "Invalid UserId" }

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/updateSeatToBooked", tags=['Bus'])
def update_seat_to_booked(req: UpdateSeatToBookedReq):
    try:

        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_update_seat_to_booked ?", req.seatid)
        cursor.nextset()

        row = cursor.fetchone()

        conn.commit()
        cursor.close()
        conn.close()

        if row:
            return { "Id": row[0], "Message": row[1] }
        else:
            return { "Id": -1, "Message": "Invalid SeatId" }

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/updateRegularCustomer", tags=['users'])
def user_info(req: UpdateVIPReq):
    try:

        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_update_customer_regular ?", req.userid)
        cursor.nextset()

        row = cursor.fetchone()

        conn.commit()
        cursor.close()
        conn.close()

        if row:
            return { "Id": row[0], "Message": row[1] }
        else:
            return { "Id": -1, "Message": "Invalid UserId" }

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/ticketinfo/", tags=['users'])
def user_info(ticketinfo: TicketInfoReq):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_ticket_by_id ?", ticketinfo.ticketId)
        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()

        if row:
            if row[0] == -1:
                return {"Status": -1, "Message": row[1]}

            trip_id = row[0]
            trip_name = row[1]
            plate_number = row[2]
            return {
                "TripId": trip_id,
                "TripName": trip_name,
                "PlateNumber": plate_number
            }
        else:
            raise HTTPException(status_code=401, detail="Invalid username or password")

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")


def GetTrip(depart: str, arrive: str, departdate: str, returndate: str, isreturn: bool = True) -> list | None:
        listTrips = []
        try:
            Cursor = connect_to_sql_server().cursor()
            if isreturn == True:               
                Cursor.execute("EXEC prod_get_trip_return @depart = ?, @arrive = ?, @departtime = ?, @returntime = ?", (unquote(depart), unquote(arrive), unquote(departdate), unquote(returndate)))
            else:
                Cursor.execute("EXEC prod_get_trip_noreturn @depart = ?, @arrive = ?, @departtime = ?", (unquote(depart), unquote(arrive), unquote(departdate)))
            
            if Cursor.rowcount == 0:
                print('Trip not found')
                return None
            else:
                print('Success')
        except pyodbc.Error as e:
            logging.error(f"Database error: {e}")
            raise HTTPException(status_code=500, detail=f"Database error: {e}")
        except Exception as e:
            logging.error(f"Unexpected error: {e}")
            raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")
        except Exception as e:
            print(str(e))
            return None
        rows = Cursor.fetchall()
        if rows:
            for row in rows:
                listTrips.append({"TripID": row[0], "BusId": row[1],"Plate": row[5] ,"DepartLocation": row[2], "ArrivalLocation": row[3], "DepartureDate": row[4].strftime('%d/%m/%Y %H:%M:%S') })
        return listTrips
        
def GetUnavailableSeat(busid: int, isbook: int) -> list | None:
        listSeat: list = []
        try:
            Cursor = connect_to_sql_server().cursor()
            Cursor.execute(f"EXEC prod_get_seat_booked @busid = ?, @isbook = ?", busid, isbook)
            if Cursor.rowcount == 0:
                print('BusID not found')
                return listSeat
            else:
                print('Success')
        except pyodbc.Error as e:
            logging.error(f"Database error: {e}")
            raise HTTPException(status_code=500, detail=f"Database error: {e}")
        except Exception as e:
            logging.error(f"Unexpected error: {e}")
            raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")
        seats = Cursor.fetchall()
        if len(seats) == 0: print('No seat available.'); return listSeat
        for seat in seats:
            listSeat.append({"Plate": seat[0], "SeatName": seat[1], "IsBook": seat[2], "SeatId": seat[3]})
        return listSeat
    
def PostReserve(self, userid: int, tripid: int, plate: str, seatid: List):
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"EXEC AddSeats @userid = ?,@tripid = ? , @plate = ?,@seatid=?", unquote(userid), tripid, plate, seatid)
            if Cursor.rowcount == 0:
                print('Unable to execute command')
                return 
            else:
                print('Execute complete')
        except pyodbc.Error as e:
            print(str(e))
        except Exception as e:
            print(str(e))
            return

class Reserve(BaseModel):
    UserId: int
    TripId: int
    Plate: str
    SeatId: List[str]

@app.get("/trips", tags=['items'])
async def GetAllTrip(
    from_location: str = Query(..., alias="from", description="Departure location"),
    to_location: str = Query(..., alias="to", description="Arrival location"),
    from_time: str = Query(..., alias="fromTime", description="Departure time"),
    to_time: Optional[str] = Query(None, alias="toTime", description="Return time"),
    is_return: Optional[bool] =  Query(False, alias="isReturn", description="Indicates if the ticket is round-trip"),
):
    return GetTrip(from_location, to_location, from_time, to_time, is_return)

@app.get("/seats", tags=['items'])
async def GetUnavailSeat(
    busid: int = Query(..., alias="busid"),
    isbook: int = Query(..., alias="isbook")
):
    return GetUnavailableSeat(busid,isbook)

