
#Connect to DB

import pyodbc
from sqlalchemy.orm import Session
from datetime import datetime
import json
from sqlalchemy import Column, Integer, String
from sqlalchemy.ext.declarative import declarative_base

'''
Base = declarative_base()

# Đăng nhập và đăng ký
class UserDB(Base):
    __tablename__ = "Users"
    
    id = Column(Integer, primary_key=True, index=True)
    username = Column(String, unique=True, index=True)
    email = Column(String, unique=True, index=True)
    password_hash = Column(String)

'''


'''
class UserController:
    @staticmethod
    def get_user_by_id(user_id: int):
        db: Session = Session()
        user = db.query(UserDB).filter(UserDB.id == user_id).first()
        db.close()
        return user

    @staticmethod
    def get_all_users():
        db: Session = Session()
        users = db.query(UserDB).all()
        db.close()
        return users

'''


def JSONOutput(jsondata) -> str:
    output: str = json.dumps(jsondata, indent=3)
    return output

class ConnectDB:

    def __init__(self):
        self.Connector = pyodbc.connect("Driver={ODBC Driver 17 for SQL Server};"
                                "Server=localhost;"
                                "Database=bus_server_prod;"
                                "Trusted_Connection=yes;")
    
    def GetUserName(self, usr: str, pwd: str) -> dict:
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"SELECT * FROM Users WHERE UserName = '{usr}' AND UserPwd = '{pwd}'")
            if Cursor.rowcount == 0:
                print('Username not found or wrong password')
                return ()
            else:
                print('Success')
        except Exception as e:
            print(str(e))
            return ()
        
        row = Cursor.fetchone()

        return {"UserID": row[0], "Username": row[1], "Full Name": row[3], "Phone": row[4], "Email": row[5]}
    
    def GetTrip(self, depart: int, arrive: int, date: str) -> list:
        listTrips = []
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"""SELECT TripId, TripName, Depart.LocationName, Arrive.LocationName, DepartTime, TripStatusName, PlateNumber FROM Trips
                            INNER JOIN Cars ON Trips.CarId = Cars.CarID
                            INNER JOIN Locations AS Depart ON Trips.DepartLocation = Depart.LocationId
                            INNER JOIN Locations AS Arrive ON Trips.ArriveLocation = Arrive.LocationId
                            INNER JOIN TripStatus ON Trips.TripStatusId = TripStatus.TripStatusId
                            WHERE DepartLocation = {depart} AND ArriveLocation = {arrive} AND DepartTime = '{date}'""")
            if Cursor.rowcount == 0:
                print('Trip not found')
                return []
            else:
                print('Success')
        except Exception as e:
            print(str(e))
            return []
        rows = Cursor.fetchall()
        if rows:
            for row in rows:
                listTrips.append({"TripID": row[0], "TripName": row[1], "DepartLocation": row[2], "ArrivalLocation": row[3], "DepartureDate": row[4].strftime('%d/%m/%Y %H:%M:%S'), "Status": row[5], "Plate": row[6]})
        return listTrips
    
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
        pass
    


connector = ConnectDB()
