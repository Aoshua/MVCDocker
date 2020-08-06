RESTORE DATABASE Mvc_Docker_Db 
FROM DISK='/var/opt/mssql/backup/Mvc_Docker_Db.bak' 
WITH MOVE 'Mvc_Docker_Db' TO '/var/opt/mssql/data/Mvc_Docker_Db.mdf', 
MOVE 'Mvc_Docker_Db_log' TO '/var/opt/mssql/data/Mvc_Docker_Db_log.ldf'