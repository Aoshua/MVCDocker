FROM microsoft/mssql-server-linux

ENV MSSQL_SA_PASSWORD=101MyPass101
ENV ACCEPT_EULA=Y

COPY Database/Mvc_Docker_Db.bak /var/opt/mssql/backup/Mvc_Docker_Db.bak
COPY Database/restore.sql restore.sql
RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P '101MyPass101' -d master -i restore.sql