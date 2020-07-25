1: docker-compose.yaml up -d

2: @FOR /f "tokens=*" %i IN ('docker-machine env') DO @%i

docker ps

docker-machine ip

