import logging
from fastapi import FastAPI, HTTPException
import pyodbc
from ConnectDB import connect_to_sql_server
from models_for_server import *
from pydantic import BaseModel

app = FastAPI()

@app.post("/create_user/")
def create_user(user: User):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()
        cursor.execute("EXEC prod_create_user ?, ?, ?, ?, ?", user.username, user.password, user.fullname, user.email, user.userroleid)
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

class LoginRequest(BaseModel):
    username: str
    password: str

@app.post("/login/")
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
            return {
                "UserId": user_id,
                "FullName": fullname,
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
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/userinfo/")
def user_info(login: LoginRequest):
    try:
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
            return {
                "UserId": user_id,
                "FullName": fullname,
                "UserEmail": user_email,
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
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")

@app.post("/ticketinfo/")
def user_info(ticketinfo: TicketInfoReq):
    try:
        conn = connect_to_sql_server()
        cursor = conn.cursor()

        cursor.execute("EXEC prod_get_ticket_by_id ?", ticketinfo.customerid)
        row = cursor.fetchone()
        conn.commit()
        cursor.close()
        conn.close()

        if row:
            ticket_id = row[0]
            number_of_ticket = row[1]
            time_ticket_avai = row[2]
            type_of_ticket = row[3]
            season_id = row[4]
            is_active = row[5]
            customer_id = row[6]
            return {
                "TicketId": ticket_id,
                "NumberOfTicket": number_of_ticket,
                "TimeTicketAvailable": time_ticket_avai,
                "TypeOfTicket": type_of_ticket,
                "SeasonId": season_id,
                "IsActive": is_active,
                "CustomerId": customer_id
            }
        else:
            raise HTTPException(status_code=401, detail="Invalid username or password")

    except pyodbc.Error as e:
        logging.error(f"Database error: {e}")
        raise HTTPException(status_code=500, detail=f"Database error: {e}")
    except Exception as e:
        logging.error(f"Unexpected error: {e}")
        raise HTTPException(status_code=500, detail=f"Unexpected error: {e}")
