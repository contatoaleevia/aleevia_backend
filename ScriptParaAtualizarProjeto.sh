#Script para atualizar o projeto criado por (luiz fellipe)

#Atualiza o repositorio git
git pull

#Mostra o Hash do ultimo commit feito 
git rev-parse HEAD

#Para o container
docker stop backend-aleevia

#Destroi o container antigo
docker rm backend-aleevia

#Apaga a imagem
docker rmi backend-aleevia

#Faz o Build da nova imagem
docker build -f docker/Dockerfile-Homolog -t backend-aleevia .

#Constroi o novo container
docker run --restart unless-stopped --name backend-aleevia -d -p 7086:7086 --env-file ./.env backend-aleevia

#Lista os containers ativos 
docker ps -a