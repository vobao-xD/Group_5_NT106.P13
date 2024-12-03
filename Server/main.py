import ConnectDB
import listen_n_send


connector = ConnectDB.ConnectDB()

sql_res = ConnectDB.connector.GetUserName('abc','123')

listen_n_send.send(ConnectDB.JSONOutput(sql_res))