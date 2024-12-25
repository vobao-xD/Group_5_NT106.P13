from pydantic import BaseModel
from sqlalchemy import Column, Integer, String
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class UserDB(Base):
    __tablename__ = "Users"
    id = Column(Integer, primary_key=True, index=True)
    username = Column(String, unique=True, index=True)
    email = Column(String, unique=True, index=True)
    password_hash = Column(String)

class UserOut(BaseModel):
    id: int
    username: str
    email: str
    
class User(BaseModel):
    username: str
    password: str
    fullname: str
    email: str
    userroleid: int

class TicketInfoReq(BaseModel):
    userId: str

class LoginRequest(BaseModel):
    username: str
    password: str

class UpdateVIPReq(BaseModel):
    userid: int

class UpdateSeatToBookedReq(BaseModel):
    seatid: int