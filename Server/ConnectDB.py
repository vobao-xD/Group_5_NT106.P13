
#Connect to DB

import pyodbc

from datetime import datetime
import json
from urllib.parse import unquote





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
    


#connector = ConnectDB()

#print(connector.GetUserName('abc','123'))




#y = JSONOutput(connector.GetTrip('B', 'A', '2024-06-20', '2024-01-10'))
#print(y)