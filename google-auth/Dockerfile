FROM node:10.10-alpine
ADD ./src /work
WORKDIR /work
RUN npm install http-server -g
CMD ["http-server"]