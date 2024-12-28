import secrets
import pyodbc
import json
from fastapi import Depends, HTTPException
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials, OAuth2PasswordBearer
import jwt
from fastapi import FastAPI, HTTPException, Depends
from fastapi.security import OAuth2PasswordBearer, HTTPAuthorizationCredentials, HTTPBearer
from typing import List
from Ultilities import *
from urllib.parse import unquote
from pydantic import BaseModel
from Models import *
import logging
import pyodbc
import jwt
import secrets

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

def generate_secret_key():
    return secrets.token_hex(32)

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")
secret_key = generate_secret_key()

def connect_to_sql_server():
    conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
                          'SERVER=localhost;'
                          'DATABASE=Bus_server_prod;'
                          'Trusted_Connection=yes;')
    return conn

def JSONOutput(jsondata) -> str:
    output: str = json.dumps(jsondata, indent=3)
    return output

def verify_token(credentials: HTTPAuthorizationCredentials = Depends(HTTPBearer())):
    try:
        payload = jwt.decode(credentials.credentials, secret_key, algorithms=["HS256"])
        return payload
    except jwt.ExpiredSignatureError:
        raise HTTPException(status_code=401, detail="Token has expired")
    except jwt.InvalidTokenError:
        raise HTTPException(status_code=401, detail="Invalid token")

def GetTrip(depart: str, arrive: str, departdate: str) -> list | None:
        listTrips = []
        try:
            Cursor = connect_to_sql_server().cursor()

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
    
