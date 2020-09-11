docker build . --no-cache -t andrekirst/okr-docker-docker-compose-api:v1 -f .\API\Dockerfile
docker push andrekirst/okr-docker-docker-compose-api:v1

docker build . --no-cache -t andrekirst/okr-docker-docker-compose-ui:v1 -f .\API\Dockerfile
docker push andrekirst/okr-docker-docker-compose-ui:v1