
#Connect to DB

import pyodbc
from datetime import datetime
import json


def JSONOutput(jsondata) -> str:
    output: str = json.dumps(jsondata, indent=3)
    return output

class ConnectDB:

    def __init__(self):
        self.Connector = pyodbc.connect("Driver={ODBC Driver 17 for SQL Server};"
                                "Server=LAPTOP-U5EI0GI8;"
                                "Database=bus_server_prod;"
                                "Trusted_Connection=yes;")
    

    def Test(self):
        Cursor = self.Connector.cursor()
        Cursor.execute(f"SELECT * FROM _User_ WHERE UserName = 'abc' AND UserPwd = '123'")
        print(Cursor.fetchall())


    def GetUserName(self, usr: str, pwd: str) -> dict:
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"SELECT * FROM _User_ WHERE UserName = '{usr}' AND UserPwd = '{pwd}'")
            if Cursor.rowcount == 0:
                print('Username not found or wrong password')
                return ()
            else:
                print('Success')
        except Exception as e:
            print(str(e))
            return ()
        
        row = Cursor.fetchone()

        return {"UserID": row[0], "UserName": row[1], "Phone": row[3]}
    


    def GetTrip(self, depart: str, arrive: str, date: str) -> list:
        listTrips = []
        try:
            Cursor = self.Connector.cursor()
            Cursor.execute(f"SELECT * FROM Trip WHERE DepartLocation = '{depart}' AND ArriveLocation = '{arrive}' AND DepartDate = '{date}'")
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
                listTrips.append({"TripID": row[0], "TripName": row[1], "DepartLocation": row[2], "ArrivalLocation": row[3], "DepartureDate": row[4].strftime('%d/%m/%Y %H:%M:%S'), "Status": row[6], "CarID": row[7]})
        return listTrips


connector = ConnectDB()

#print(connector.GetUserName('abc','123'))




y = JSONOutput(connector.GetUserName('abc','123'))
print(y)