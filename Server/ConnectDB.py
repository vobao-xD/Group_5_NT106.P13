import pyodbc

def connect_to_sql_server():
    conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
                          'SERVER=DESKTOP-EO0FOFG;'
                          'DATABASE=bus_server_prod;'
                          'Trusted_Connection=yes;')
    return conn