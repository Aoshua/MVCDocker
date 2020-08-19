I am attempting to integrate Docker with a .Net Core MVC project within a Visual Studio environment as seamlessly as possible.

## Set-Up:
1. Make MVC Project with Docker Support
1. Ensure that NuGet Packages install correctly
1. Right click project, select -> add -> Container Orchestrator Support
1. Add database service to services in docker-compose.yml
   1. On line 9 I set the name of the service
   1. Line 13 shows where to look for the Dockerfile which contains more specific information to create the MVCDocker_DB container.
   1. ![Database Service](https://github.com/Aoshua/MVCDocker/blob/master/images/database_service.png)
1. Set up context (file and in startup)
1. Add connection string to appsettings.json (the server is the name of your DB container)
   1. Note that the server name matches the container name.
   1. ![Connection String](https://github.com/Aoshua/MVCDocker/blob/master/images/connection_string.png)

## Notes:
- Simply closing the program, running `docker-compose down`, or stopping the containers does not loose the data added to the database. But running `docker system prune` does.
- Obviously pulling down this project will not pull down any new information I add to the database. To get new info added, one would need to get on the server and create a new backup file then replace the backup file in the Database directory (with the same name).
- To explore a container: `docker exec -it [container_name] bash`
- To create a backup database file in a docker container: `docker exec -it MVCDocker_DB /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Buster0524" -Q "BACKUP DATABASE [db_name] TO DISK =  N'/var/opt/mssql/backup/[backup_file_name]' WITH NOFORMAT, NOINIT, NAME = '[db_name]', SKIP, NOREWIND, NOUNLOAD, STATS = 10"`
- To restore a database in a docker container: `docker exec -it MVCDocker_DB /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Buster0524" -Q "RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/Mvc_Docker_Db.bak'"`
