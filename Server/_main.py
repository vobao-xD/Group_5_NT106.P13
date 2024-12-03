from fastapi import FastAPI


app = FastAPI()


@app.post("/register")


@app.post("/login")


@app.get("/trips")


@app.get("/trips/{trip_id}")


@app.get("/trips/{trip_id}/seats")


@app.get("")



if __name__ == "__main__":
    import uvicorn

    uvicorn.run(app, host = "127.0.0.1", port = 8000)