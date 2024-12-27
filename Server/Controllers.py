from sqlalchemy.orm import Session
from urllib.parse import unquote
from datetime import datetime, timedelta
from fastapi import FastAPI, HTTPException, Depends, Query
from fastapi.security import OAuth2PasswordBearer, HTTPAuthorizationCredentials, HTTPBearer
from typing import Optional, List
from pydantic import BaseModel
from Models import *
import jwt
from Ultilities import *
import logging
import pyodbc
import secrets
import json
import requests
import hmac
import uuid
import hashlib

app = FastAPI()

@app.post("/create_payment/")
async def create_payment(order_id: str, client_amount: int):
    endpoint = "https://test-payment.momo.vn/v2/gateway/api/create"
    partnerCode = "MOMO"
    accessKey = "F8BBA842ECF85"
    secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz"
    orderInfo = "pay with MoMo"
    redirectUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b"
    ipnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b"
    amount = "50000"
    orderId = str(uuid.uuid4())
    requestId = str(uuid.uuid4())
    requestType = "captureWallet"
    extraData = ""  # pass empty value or Encode base64 JsonString

    payload = {
        'partnerCode': partnerCode,
        'partnerName': "Test",
        'storeId': "MomoTestStore",
        'requestId': requestId,
        'amount': amount,
        'orderId': orderId,
        'orderInfo': orderInfo,
        'redirectUrl': redirectUrl,
        'ipnUrl': ipnUrl,
        'lang': "vi",
        'extraData': extraData,
        'requestType': requestType,
        'signature': signature
    } 

    rawSignature = "accessKey=" + accessKey + "&amount=" + amount + "&extraData=" + extraData + "&ipnUrl=" + ipnUrl + "&orderId=" + orderId + "&orderInfo=" + orderInfo + "&partnerCode=" + partnerCode + "&redirectUrl=" + redirectUrl + "&requestId=" + requestId + "&requestType=" + requestType
    h = hmac.new(bytes(secretKey, 'ascii'), bytes(rawSignature, 'ascii'), hashlib.sha256)
    signature = h.hexdigest()

    response = requests.post(endpoint, json=payload)
    if response.status_code == 200:
        return response.json()
    else:
        raise HTTPException(status_code=500, detail="Payment API failed")

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
def update_seat_to_booked(req: SelSeat):
    try:

        conn = connect_to_sql_server()
        cursor = conn.cursor()

        
        cursor.execute("EXEC prod_update_seat_to_booked ?, ? ", req.seat, req.plate)
        cursor.nextset()

        row = cursor.fetchone()

        conn.commit()
        cursor.close()
        conn.close()

        if row:
            return { "Id": row[0], "Message": row[1] }
        else:
            return { "Id": -1, "Message": "Invalid Seat or Seat already reserved" }

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

        