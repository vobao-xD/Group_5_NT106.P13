from fastapi import FastAPI, HTTPException, Depends, Query
from fastapi.responses import HTMLResponse
from datetime import datetime, timedelta
from Ultilities import *
from Ultilities import *
from Models import *
import logging
import hashlib
import pyodbc
import httpx
import hmac
import uuid
import jwt

app = FastAPI()

@app.post("/create_payment", tags=['Payment'])
async def create_payment(request : MomoRequest):
    # Khai bao cac thong so can thiet
    endpoint = "https://test-payment.momo.vn/v2/gateway/api/create"
    redirectUrl = f"http://{ServerIP}:8002/payment/redirect"
    ipnUrl = f"http://{ServerIP}:8002/payment/redirect"
    secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz"
    accessKey = "F8BBA842ECF85"
    partnerCode = "MOMO"
    order_id = str(uuid.uuid4())
    requestId = str(uuid.uuid4())
    orderInfo = request.trip_name + " ; " + request.booked_seat + " ; " + str(request.trip_id) + " ; " + str(request.user_id) + " ; " + request.license_plate + " ; " + request.email
    list_seat = request.booked_seat.strip().split(" ")
    amount = str(int(TripPrice[request.trip_name]) * len(list_seat))
    extraData = ""
    partnerName = "MoMo Payment"
    requestType = "payWithMethod"
    storeId = "G5 Bus Line"
    autoCapture = True
    lang = "vi"
    rawSignature = f"accessKey={accessKey}&amount={amount}&extraData={extraData}&ipnUrl={ipnUrl}" \
                   f"&orderId={order_id}&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={redirectUrl}" \
                   f"&requestId={requestId}&requestType={requestType}"
    h = hmac.new(bytes(secretKey, 'utf-8'), bytes(rawSignature, 'utf-8'), hashlib.sha256)
    signature = h.hexdigest()

    # Data send to momo
    data = {
        'partnerCode': partnerCode,
        'orderId': order_id,
        'partnerName': partnerName,
        'storeId': storeId,
        'ipnUrl': ipnUrl,
        'amount': amount,
        'lang': lang,
        'requestType': requestType,
        'redirectUrl': redirectUrl,
        'autoCapture': autoCapture,
        'orderInfo': orderInfo,
        'requestId': requestId,
        'extraData': extraData,
        'signature': signature
    }

    try:
        async with httpx.AsyncClient() as client:
            response = await client.post(endpoint, json=data)
            response.raise_for_status()
            return response.json()
    except httpx.HTTPStatusError as e:
        raise HTTPException(status_code=e.response.status_code, detail=f"Fail to get payment link: {e.response.text}")
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Payment API failed: {str(e)}")

@app.get("/payment/redirect", tags=['Payment'], response_class = HTMLResponse)
async def payment_redirect(partnerCode: str, orderId: str, requestId: str, amount: str, orderInfo: str, 
        orderType: str, transId: str, resultCode: str, message: str, payType: str,
        responseTime: str, extraData: str, signature: str):
    # Phan tich du lieu
    parts = orderInfo.split(";")
    trip_name = parts[0].strip()
    booked_seat = parts[1].strip()
    trip_id = int(parts[2].strip())
    user_id = int(parts[3])
    license_plate = parts[4].strip()
    email = parts[5].strip()
    number_of_seat = len(parts[1].strip().split(" "))
    price = TripPrice[trip_name] * number_of_seat
    endpoint = f"http://{ServerIP}:8002/payment/success"
    
    # Data send to other API
    request = {
        "num_of_seat" : number_of_seat,
        "trip_id" : trip_id,
        "user_id" : user_id,
        "price" : price,
        "license_plate" : license_plate,
        "seat_list" : booked_seat,
        "trip_name" : trip_name,
        "email" : email
    }

    try:
        async with httpx.AsyncClient() as client:
            response = await client.post(endpoint, json=request)
            response.raise_for_status()
        return successHTML
    except httpx.HTTPStatusError as e:
        raise HTTPException(status_code=e.response.status_code, detail=f"Failed to redirect: {e.response.text}")
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Unexpected error: {str(e)}")

@app.post("/payment/success", tags=['Payment'])
async def save_ticket(request : PaymentRequest):
    conn = connect_to_sql_server()
    cursor = conn.cursor()
    try:
        cursor.execute("""
        EXEC prod_insert_tickets 
            @NumOfSeat = ?, 
            @TripId = ?, 
            @UserId = ?, 
            @Price = ?, 
            @LicensePlate = ?, 
            @SeatList = ?
        """, 
        (request.num_of_seat, request.trip_id, request.user_id, request.price, request.license_plate, request.seat_list))
        conn.commit()
        cursor.execute(
            "SELECT TicketID FROM Ticket WHERE NumOfSeat = ? AND TripId = ? AND UserId = ? AND Price = ?", 
            (request.num_of_seat, request.trip_id, request.user_id, request.price)
        )
        ticket_id = cursor.fetchone()[0]
        conn.commit()
        return {"message": "Ticket(s) successfully booked."}
    except Exception as e:
        conn.rollback()
        raise HTTPException(status_code=400, detail=str(e))
    finally:
        cursor.close()
        conn.close()
        email_subject = "Xác nhận đặt vé thành công"
        email_content = f"""
            <!DOCTYPE html>
            <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>Xác nhận đặt vé thành công</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f3f4f6;
                        margin: 0;
                        padding: 0;
                    }}
                    .email-container {{
                        max-width: 600px;
                        margin: 40px auto;
                        background: #ffffff;
                        border: 1px solid #e5e7eb;
                        border-radius: 12px;
                        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                        overflow: hidden;
                    }}
                    .email-header {{
                        background: #4CAF50;
                        color: #ffffff;
                        text-align: center;
                        padding: 20px;
                    }}
                    .email-header h2 {{
                        margin: 0;
                        font-size: 24px;
                    }}
                    .email-body {{
                        padding: 20px;
                        color: #333333;
                        line-height: 1.6;
                    }}
                    .email-body p {{
                        margin: 10px 0;
                    }}
                    .email-body ul {{
                        list-style: none;
                        padding: 0;
                        margin: 10px 0;
                    }}
                    .email-body ul li {{
                        margin: 8px 0;
                        font-size: 16px;
                    }}
                    .email-body ul li strong {{
                        color: #4CAF50;
                    }}
                    .email-footer {{
                        text-align: center;
                        padding: 15px;
                        background: #f9fafb;
                        color: #666666;
                        font-size: 14px;
                        border-top: 1px solid #e5e7eb;
                    }}
                </style>
            </head>
            <body>
                <div class="email-container">
                    <div class="email-header">
                        <h2>Xác nhận đặt vé thành công</h2>
                    </div>
                    <div class="email-body">
                        <p><li><strong>Xin chào,</strong></li></p>
                        <p><li><strong>Bạn đã đặt vé thành công với thông tin như sau:</strong></li></p>
                        <ul>
                            <li><strong>Mã vé: {ticket_id}</strong></li>
                            <li><strong>Chuyến đi: {request.trip_name}</strong></li>
                            <li><strong>Số ghế: {request.seat_list}</strong></li>
                            <li><strong>Biển số xe: {request.license_plate}</strong></li>
                            <li><strong>Giá vé: {request.price:.2f} VND</strong></li>
                            <li><strong>Số lượng ghế: {request.num_of_seat}</strong></li>
                        </ul>
                        <p><li><strong>Cảm ơn bạn đã sử dụng dịch vụ của Bus G5!</strong></li></p>
                    </div>
                    <div class="email-footer">
                        <p>Bus Ticket Booking System</p>
                    </div>
                </div>
            </body>
            </html>"""
        send_email(request.email, email_subject, email_content)

@app.get("/trips", tags=['items'])
async def GetAllTrip(
    from_location: str = Query(..., alias="from", description="Departure location"),
    to_location: str = Query(..., alias="to", description="Arrival location"),
    from_time: str = Query(..., alias="fromTime", description="Departure time")
    ): 
    return GetTrip(from_location, to_location, from_time)

@app.get("/seats", tags=['SeatSeat'])
async def GetUnavailSeat(
    busid: int = Query(..., alias="busid"),
    isbook: int = Query(..., alias="isbook")
    ):
    return GetUnavailableSeat(busid,isbook)

@app.post("/create_user/", tags=['User'])
async def create_user(user: User):
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

@app.post("/login/", tags=['User'])
async def login_user(login: LoginRequest):
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
    
@app.get("/getlistcustomer", tags=['User'])
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

@app.get("/getSeatBooked", tags=['Bus'])
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

@app.get("/getAllBus", tags=['Bus'])
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

@app.post("/userinfo/", tags=['User'])
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

@app.post("/updateVipCustomer", tags=['User'])
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
async def update_seat_to_booked(req: SelSeat):
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

@app.post("/updateRegularCustomer", tags=['Users'])
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

@app.post("/ticket_info/", tags=['Users'])
def user_info(ticketinfo: TicketInfoReq):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute(
            "EXEC prod_get_ticket_by_id @UserEmail = ?, @TicketId = ?", 
            ticketinfo.UserEmail, 
            ticketinfo.TicketId
        )
        rows = cursor.fetchall()
        conn.commit()

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail="Database error occurred.")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail="Unexpected server error.")
    finally:
        if 'cursor' in locals():
            cursor.close()
        if 'conn' in locals():
            conn.close()

    if rows:
        if rows[0][0] == -1:
            return {"ErrorResponse" : -1}

        # Tạo dictionary chứa thông tin vé
        ticket_info = {
            "TicketId": rows[0][0],
            "TripId": rows[0][1],
            "PlateNumber": rows[0][2],
            "DepartLocation": rows[0][3],
            "ArriveLocation": rows[0][4],
            "DepartTime": rows[0][5],
            "UserFullName": rows[0][6]
        }

        seat_list = [row[7] for row in rows if row[7] is not None]
        ticket_info["SeatList"] = seat_list

        return ticket_info

    # Nếu rows rỗng, trả về lỗi 404
    raise HTTPException(status_code=404, detail="Ticket not found or you don't have permission to access it.")

@app.post("/create_trip/", tags=['Trip'])
async def create_trip(trip: Trip):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute(
            "EXEC prod_create_trip ?, ?, ?, ?, ?, ?, ?",
            trip.plate,
            trip.seat_num,
            1,
            trip.depart_location,
            trip.arrive_location,
            trip.depart_time,
            1,
        )

        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()

        logging.info(f"Stored procedure executed successfully: {row}")
        if row:
            return {"Id": row[0], "Message": row[1]}
        else:
            logging.warning("No result returned from the stored procedure.")
            raise HTTPException(
                status_code=400, detail="No result returned from the stored procedure."
            )
    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")
    
@app.get("/getAllTrip", tags=['Trip'])
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

@app.post("/forget_password", tags=['users'])
def forget_password(req: ForgetPasswordReq):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute("EXEC prod_forget_password ?, ?", req.email, req.password)

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