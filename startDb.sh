docker run --rm --env "TZ=Europe/Oslo" --name mariadb -p 3306:3306/tcp -v "$(pwd)/database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:latest
