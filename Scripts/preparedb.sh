psql -a -U postgres -c 'create database UsersApp'
psql -a -U postgres -d usersapp -f /docker-entrypoint-initdb.d/Scripts/InitDataBase.sql