FROM postgres:11.3

COPY ./InitDataBase ./docker-entrypoint-initdb.d/Scripts
COPY ./preparedb.sh ./docker-entrypoint-initdb.d