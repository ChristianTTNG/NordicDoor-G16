@echo off

:: Kill running instance of container
docker kill nordicdoors

:: Builds image specified in Dockerfile
docker image build -t nordicdoor .

:: Starts container with web application and maps port 80 (ext) to 80 (internal)
docker container run --rm -it -d --name nordicdoor --publish 80:80 nordicdoor

echo.
echo "Link: http://localhost:80/"
echo.

pause
