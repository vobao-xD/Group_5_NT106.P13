import pyodbc

con = pyodbc.connect("Driver={SQL Server};"
                      "Server=HackerLord;"
                      "Database=Test;"
                      "Trusted_Connection=yes;")
    
print(con)