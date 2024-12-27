from pydantic import BaseModel

# Trả về thông tin khi đăng nhập thành công
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


class ForgetPasswordReq(BaseModel):
    email: str
    password: str

class UpdatePasswordReq(BaseModel):
    username: str
    password: str

class Trip(BaseModel):
    plate: str
    seat_num: int
    bus_status_id: int
    depart_location: str
    arrive_location: str
    depart_time: str  # ISO 8601 format (e.g., "2024-12-25T15:00:00")
    trip_status_id: int


