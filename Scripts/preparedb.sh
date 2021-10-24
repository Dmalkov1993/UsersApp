psql -a -U postgres -c 'create database sso'
psql -a -U postgres -d sso -f /docker-entrypoint-initdb.d/Scripts/InitConfigContext.sql
psql -a -U postgres -d sso -f /docker-entrypoint-initdb.d/Scripts/InitSystemContext.sql
psql -a -U postgres -c 'create database unit1'
psql -a -U postgres -d unit1 -f /docker-entrypoint-initdb.d/Scripts/InitSystemContext.sql
psql -a -U postgres -d unit1 -f /docker-entrypoint-initdb.d/Scripts/InitBusinessContext.sql