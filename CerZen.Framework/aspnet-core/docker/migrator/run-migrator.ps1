docker-compose -f docker-compose.migrator.yml up -d
docker logs -f cerzenmigrator_container
docker container rm cerzenmigrator_container