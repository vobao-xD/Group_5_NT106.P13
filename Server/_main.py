import logging
from fastapi import FastAPI, HTTPException
import pyodbc
from pydantic import BaseModel

app = FastAPI()

def connect_to_sql_server():
    conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
                          'SERVER=DESKTOP-R273SF4;'
                          'DATABASE=bus_server_prod;'
                          'Trusted_Connection=yes;')
    return conn

class User(BaseModel):
    username: str
    password: str
    fullname: str
    email: str
    userroleid: int

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


if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="127.0.0.1", port=8002)
