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


class Trip(BaseModel):
    plate: str
    seat_num: int
    bus_status_id: int
    depart_location: str
    arrive_location: str
    depart_time: str  # ISO 8601 format (e.g., "2024-12-25T15:00:00")
    trip_status_id: int