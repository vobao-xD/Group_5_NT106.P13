from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials, OAuth2PasswordBearer
from fastapi.security import OAuth2PasswordBearer, HTTPAuthorizationCredentials, HTTPBearer
from email.mime.multipart import MIMEMultipart
from fastapi import HTTPException, Depends
from fastapi import Depends, HTTPException
from email.mime.text import MIMEText
from urllib.parse import unquote
from typing import List
from Ultilities import *
from Models import *
import logging
import secrets
import smtplib
import pyodbc
import json
import jwt

TripPrice: dict[str, int] = {
    "TP.HCM - Hà Nội" : 1000000, "Hà Nội - TP.HCM" : 1000000, 
    "TP.HCM - Cần Thơ" : 500000, "Cần Thơ - TP.HCM" : 500000,
    "TP.HCM - Đà Nẵng" : 750000, "Đà Nẵng - TP.HCM" : 750000,
    "Hà Nội - Cần Thơ" : 1250000, "Cần Thơ - Hà Nội": 1250000,
    "Hà Nội - Đà Nẵng" : 750000, "Đà Nẵng - Hà Nội" : 750000,
    "Hà Nội - Huế" : 600000, "Huế - Hà Nội" : 600000,
    "Cần Thơ - Đà Nẵng" : 500000, "Đà Nẵng - Cần Thơ" : 500000,
    "Cần Thơ - Huế" : 600000, "Huế - Cần Thơ" : 600000,
    "Đà Nẵng - Huế" : 250000, "Huế - Đà Nẵng" : 250000 
}

successHTML = """
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Booking Success</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background: linear-gradient(to bottom right, #4caf50, #81c784);
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            color: #fff;
        }

        .container {
            text-align: center;
            background: rgba(0, 0, 0, 0.8);
            padding: 20px 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            max-width: 400px;
        }

        .container h1 {
            font-size: 2rem;
            margin-bottom: 20px;
            color: #4caf50;
        }

        .container p {
            font-size: 1rem;
            margin-bottom: 15px;
        }

        .details {
            background: rgba(255, 255, 255, 0.1);
            border: 1px solid rgba(255, 255, 255, 0.2);
            padding: 15px;
            border-radius: 5px;
            margin-top: 15px;
        }

        .details p {
            margin: 5px 0;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            background: #4caf50;
            color: #fff;
            text-decoration: none;
            border-radius: 5px;
            font-weight: bold;
            margin-top: 15px;
            transition: background 0.3s;
        }

        .btn:hover {
            background: #388e3c;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Booking Successful!</h1>
        <p>Thank you for booking with us. Check your email for your ticket infomation!</p>
    </div>
</body>
</html>
"""

def send_email(to_email: str, subject: str, html_content: str):
    sender_email = "khoibaochien@gmail.com"
    sender_password = "krti dtle hdjb exew"
    message = MIMEMultipart()
    message["From"] = sender_email
    message["To"] = to_email
    message["Subject"] = subject
    message.attach(MIMEText(html_content, "html"))
    try:
        with smtplib.SMTP("smtp.gmail.com", 587) as server:
            server.starttls()
            server.login(sender_email, sender_password) 
            server.sendmail(sender_email, to_email, message.as_string())
    except Exception as e:
        raise HTTPException(status_code=500, detail="Failed to send email.")

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


