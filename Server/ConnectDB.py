import pyodbc

con = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
                      'SERVER=DESKTOP-R273SF4;'
                      'DATABASE=bus_server_prod;'
                      'Trusted_Connection=yes;')
    
print(con)