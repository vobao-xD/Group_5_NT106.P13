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
import json

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



def JSONOutput(jsondata) -> str:
    output: str = json.dumps(jsondata, indent=3)
    return output

class ConnectDB:

    #def __init__(self):
    Connector = pyodbc.connect("Driver={ODBC Driver 17 for SQL Server};"
                                "Server=localhost;"
                                "Database=bus_server_prod;"
                                "Trusted_Connection=yes;")
    
    @staticmethod
    def GetUserInfo(self, usr: str, pwd: str) -> dict | None:
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute("Exec GetUserInfo @usr = ?, @pwd = ?", (usr, pwd))
            row = Cursor.fetchone()
            if not row:
                return None
            return {
                "UserID": row[0],
                "Username": row[1],
                "Full Name": row[3],
                "Email": row[4],
                "User Type": row[5]
            }
        except Exception as e:
            print(str(e))
            return None
        finally:
            if Cursor: 
                Cursor.close()
    
    #@staticmethod
    def GetTrip(self, depart: str, arrive: str, departdate: str, returndate: str, isreturn: bool = True) -> list | None:
        listTrips = []
        try:
            Cursor = self.Connector.cursor()
            if isreturn == True:               
                Cursor.execute("EXEC GetTripR @depart = ?, @arrive = ?, @departdate = ?, @returndate = ?", (unquote(depart), unquote(arrive), unquote(departdate), unquote(returndate)))
            else:
                Cursor.execute("EXEC GetTrip @depart = ?, @arrive = ?, @departdate = ?", (unquote(depart), unquote(arrive), unquote(departdate)))         
            
            if Cursor.rowcount == 0:
                print('Trip not found')
                return None
            else:
                print('Success')

        except Exception as e:
            print(str(e))
            return None
        rows = Cursor.fetchall()
        if rows:
            for row in rows:
                listTrips.append({"TripID": row[0], "TripName": row[1], "DepartLocation": row[2], "ArrivalLocation": row[3], "DepartureDate": row[4].strftime('%d/%m/%Y %H:%M:%S'), "Status": row[5], "Plate": row[6], "Price":row[7]})
        return listTrips
    
    #@staticmethod
    def GetTicket(self, username: str, ticketid: int) -> list:
        listTickets = []
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"""SELECT TicketId, UserFullName, Trips.TripName, DepartTime, SeatNumber, TicketTypeName, TotalPrice FROM Tickets
                                INNER JOIN Trips ON Trips.TripId = Tickets.TripId
                                INNER JOIN TicketType ON TicketType.TicketTypeId = Tickets.TicketTypeId
                                INNER JOIN Users ON Users.UserId = Tickets.UserID
                                WHERE UserName = '{username}' AND Tickets.TicketId = {ticketid}""")
            if Cursor.rowcount == 0:
                print('Ticket or user not found')
                return []
            else:
                print('Success')
        except Exception as e:
            print(str(e))
            return []
        rows = Cursor.fetchall()
        if rows:
            for row in rows:
                listTickets.append({"TicketID": row[0], "FullName": row[1], "TripName": row[2], "DepartTime": row[3].strftime('%d/%m/%Y %H:%M:%S'), "SeatNumber": row[4], "TicketType": row[5], "TotalPrice": int(row[6])})
        return listTickets
        

    def GetFeedBack(self, fbid: int):
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"SELECT FeedbackId, UserName, Description_ FROM UserFeedback INNER JOIN Users ON UserFeedback.UserId = Users.UserId WHERE FeedbackId = {fbid}")
            if Cursor.rowcount == 0:
                print('Feedback not found')
                return ()
            else:
                print('Success')
        except Exception as e:
            print(str(e))
            return ()
        
        row = Cursor.fetchone()

        return {"FeedbackID": row[0], "UserName": row[1], "Content": row[2]}
    

    def GetAvailableTicket(self):
        pass
    
    def GetUnavailableSeat(self,plate: str) -> list | None:
        listSeat: list = []
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"EXEC GetUnavailableSeat @plate = ?", unquote(plate))
            if Cursor.rowcount == 0:
                print('Plate number not found')
                return listSeat
            else:
                print('Success')
        except Exception as e:
            print(str(e))
            return
        seats = Cursor.fetchall()
        for seat in seats:
            listSeat.append(seat[0])
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
        
from fastapi import FastAPI, Query, HTTPException
from typing import Optional, List
from pydantic import BaseModel
import ConnectDB

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
    ticket_count: Optional[int] = Query(1, alias="ticketCount", ge=1, description="Number of tickets to book")
):
    return ConnectDB.ConnectDB.GetTrip(ConnectDB.ConnectDB, from_location, to_location, from_time, to_time, is_return)

@app.get("/seats", tags=['items'])
async def GetUnavailableSeat(
    plate: str = Query(..., alias="plate")
):
    return ConnectDB.ConnectDB.GetUnavailableSeat(ConnectDB.ConnectDB,plate)


@app.get("/tickets/{usr}", tags=['items'])
async def GetTicket(usr: str, tick: int):
    return ConnectDB.ConnectDB.GetTicket(ConnectDB.ConnectDB, usr, tick)
