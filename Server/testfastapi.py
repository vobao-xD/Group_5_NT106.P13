from fastapi import FastAPI, Query, HTTPException
from typing import Optional
import ConnectDB
import uvicorn
from pydantic import BaseModel
import sv_model

app = FastAPI()



#@app.post("/register")


@app.get("/auth/login/{usr}")
async def Login(usr: str, pwd: str):
    print(usr + " " + pwd)
    return ConnectDB.ConnectDB.GetUserName(ConnectDB.ConnectDB, usr, pwd)
    
        


#@app.get("/trips")


@app.get("/trips/{date}")
async def GetTrip(date: str, dpt: int, arr: int):
    return ConnectDB.ConnectDB.GetTrip(ConnectDB.ConnectDB, dpt, arr, date)



@app.get("/trips")
async def GetAllTrip(
    from_location: str = Query(..., alias="from", description="Departure location"),
    to_location: str = Query(..., alias="to", description="Arrival location"),
    from_time: str = Query(..., alias="fromTime", description="Departure time"),
    to_time: Optional[str] = Query(None, alias="toTime", description="Return time"),
    is_return: Optional[bool] =  Query(False, alias = "isReturn", description="Indicates if the ticket is round-trip"),
    ticket_count: Optional[int] = Query(1,alias="ticketCount",  ge=1, description="Number of tickets to book")
):
    return ConnectDB.ConnectDB.GetTrip(ConnectDB.ConnectDB, from_location, to_location, from_time, to_time)




@app.get("/tickets/{usr}")
async def GetTicket(usr: str, tick: int):
    return ConnectDB.ConnectDB.GetTicket(ConnectDB.ConnectDB, usr, tick)

#@app.get("/trips/{trip_id}/seats")


#@app.get("")



#if __name__ == "__main__":
#    uvicorn.run(app, host = "127.0.0.1", port = 8000)
