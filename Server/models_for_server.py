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