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


    @staticmethod
    def get_user_by_id(user_id: int):
        db: Session = SessionLocal()
        user = db.query(UserDB).filter(UserDB.id == user_id).first()
        db.close()
        return user

    @staticmethod
    def get_all_users():
        db: Session = SessionLocal()
        users = db.query(UserDB).all()
        db.close()
        return users

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

    #@staticmethod
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
    
    #@staticmethod
    def GetAvailableTicket(self):
        pass
    
    #@staticmethod
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
    
    #@staticmethod
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
    }, ]