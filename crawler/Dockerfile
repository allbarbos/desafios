FROM python:3.6-slim
ADD ./src /work
WORKDIR /work
RUN apt-get update && apt-get install gcc -y
RUN pip install requests beautifulsoup4
CMD ["python","-u","main.py"]