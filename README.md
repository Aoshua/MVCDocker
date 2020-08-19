I am attempting to integrate Docker with a .Net Core MVC project within a Visual Studio environment as seamlessly as possible.

## Quick Run-Down:
1. Make MVC Project with Docker Support
2. Ensure that NuGet Packages install correctly
3. Right click project, select -> add -> Container Orchestrator Support
4. Add database service to services in docker-compose.yml
![Database Service](images/database_service.PNG)
5. Set up context (file and in startup)
6. Add connection string to appsettings.json (the server is the name of your DB container)
![Connection String](images/connection_string.PNG)

## Notes:
- Simply closing the program, running `docker-compose down`, or stopping the containers does not loose the data added to the database. But running `docker system prune` does.
- Obviously pulling down this project will not pull down any new information I add to the database. To get new info added, one would need to get on the server and create a new backup file then replace the backup file in the Database directory (with the same name).
- To explore a container: `docker exec -it [container_name] bash`
- To create a backup database file in a docker container: `docker exec -it MVCDocker_DB /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Buster0524" -Q "BACKUP DATABASE [db_name] TO DISK =  N'/var/opt/mssql/backup/[backup_file_name]' WITH NOFORMAT, NOINIT, NAME = '[db_name]', SKIP, NOREWIND, NOUNLOAD, STATS = 10"`
- To restore a database in a docker container: `docker exec -it MVCDocker_DB /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Buster0524" -Q "RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/Mvc_Docker_Db.bak'"`
