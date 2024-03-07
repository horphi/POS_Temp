docker network rm cerzen

docker network create cerzen
docker-compose -f docker-compose.infrastructure.yml up -d

docker logs -f mssqlDb_container
