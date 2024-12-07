from pydantic import BaseModel

# Đăng nhập
class UserLogin(BaseModel):
    username: str
    password: str

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