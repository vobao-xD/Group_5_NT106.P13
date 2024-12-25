import secrets
import pyodbc
import json
from fastapi import Depends, HTTPException
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials, OAuth2PasswordBearer
import jwt

def generate_secret_key():
    return secrets.token_hex(32)

def connect_to_sql_server():
    conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
                          'SERVER=localhost;'
                          'DATABASE=Bus_server_prod;'
                          'Trusted_Connection=yes;')
    return conn

def JSONOutput(jsondata) -> str:
    output: str = json.dumps(jsondata, indent=3)
    return output

def verify_token(credentials: HTTPAuthorizationCredentials = Depends(HTTPBearer())):
    try:
        payload = jwt.decode(credentials.credentials, secret_key, algorithms=["HS256"])
        return payload
    except jwt.ExpiredSignatureError:
        raise HTTPException(status_code=401, detail="Token has expired")
    except jwt.InvalidTokenError:
        raise HTTPException(status_code=401, detail="Invalid token")

def print_secret_key():
    oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")
    secret_key = generate_secret_key()
    print(secret_key)
    return

def hello():
    pass