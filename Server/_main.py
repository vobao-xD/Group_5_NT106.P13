from Controllers import *
from Ultilities import ServerIP

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host=ServerIP, port=8002)
