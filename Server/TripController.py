
#Connect to DB

import pyodbc

from datetime import datetime
import json
from typing import Optional, List
from urllib.parse import unquote


def JSONOutput(jsondata) -> str:
    output: str = json.dumps(jsondata, indent=3)
    return output

class ConnectDB:

    #def __init__(self):
    Connector = pyodbc.connect("Driver={ODBC Driver 17 for SQL Server};"
                                "Server=localhost;"
                                "Database=Bus_server_prod;"
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


app = FastAPI()

@app.get("/trips")
async def GetAllTrip(
    from_location: str = Query(..., alias="from", description="Departure location"),
    to_location: str = Query(..., alias="to", description="Arrival location"),
    from_time: str = Query(..., alias="fromTime", description="Departure time"),
    to_time: Optional[str] = Query(None, alias="toTime", description="Return time"),
    is_return: Optional[bool] =  Query(False, alias="isReturn", description="Indicates if the ticket is round-trip"),
    ticket_count: Optional[int] = Query(1, alias="ticketCount", ge=1, description="Number of tickets to book")
):
    return ConnectDB.ConnectDB.GetTrip(ConnectDB.ConnectDB, from_location, to_location, from_time, to_time, is_return)

@app.get("/seats")
async def GetUnavailableSeat(
    plate: str = Query(..., alias="plate")
):
    return ConnectDB.ConnectDB.GetUnavailableSeat(ConnectDB.ConnectDB,plate)


@app.get("/tickets/{usr}")
async def GetTicket(usr: str, tick: int):
    return ConnectDB.ConnectDB.GetTicket(ConnectDB.ConnectDB, usr, tick)


