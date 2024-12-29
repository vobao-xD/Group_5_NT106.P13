from pydantic import BaseModel
from sqlalchemy.ext.declarative import declarative_base
from typing import List

Base = declarative_base()

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
    UserEmail: str
    TicketId: int

class LoginRequest(BaseModel):
    username: str
    password: str

class UpdateVIPReq(BaseModel):
    userid: int

class SelSeat(BaseModel):
    seat: str
    plate: str

class Trip(BaseModel):
    plate: str
    seat_num: int
    bus_status_id: int
    depart_location: str
    arrive_location: str
    depart_time: str  # ISO 8601 format (e.g., "2024-12-25T15:00:00")
    trip_status_id: int

class Reserve(BaseModel):
    UserId: int
    TripId: int
    Plate: str
    SeatId: List[str]

class PaymentRequest(BaseModel):
    num_of_seat: int
    trip_id: int
    user_id: int
    price: float
    license_plate: str
    seat_list: str
    trip_name: str
    email: str

class MomoRequest(BaseModel):
    trip_name : str
    booked_seat : str
    trip_id : int
    user_id : int
    license_plate : str
    email : str

class ForgetPasswordReq(BaseModel):
    email: str
    password: str