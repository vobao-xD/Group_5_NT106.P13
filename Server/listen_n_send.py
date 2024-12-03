

#Listen and send


import pip
import socket

def install(package: str) -> None:
    if hasattr(pip, 'main'):
        pip.main(['install', package])
    else:
        pip._internal.main(['install', package])


host = "127.0.0.1"
port: int = 5000

def listen() -> None:
    with (socket.socket(socket.AF_INET, socket.SOCK_STREAM)) as s:
        s.bind((host, port))
        s.listen()
        conn, addr = s.accept()
        recv = ""
        with conn:
            while True:
                data = conn.recv(1024)
                recv = recv + data.decode()
                if not data: break
            print(str(recv))


def send(message: str) -> None:
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((host, port))
        s.sendall(str.encode(message))
  

