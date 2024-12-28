@app.get("/getlistcustomer", tags=['users'])
async def get_list_customer(userroleid: int = Query(..., description="ID of the user role")):
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
async def get_list_bus(busid: int = Query(..., description="BusId of that Bus"),
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
async def get_list_customer():
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
async def get_all_trip():
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
async def user_info(login: LoginRequest, token: dict = Depends(verify_token)):
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
async def user_info(req: UpdateVIPReq):
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
async def update_seat_to_booked(req: UpdateSeatToBookedReq):
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
async def user_info(req: UpdateVIPReq):
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
async def user_info(ticketinfo: TicketInfoReq):
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

