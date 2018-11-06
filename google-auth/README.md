# 2-Step Verification with Google Authenticator

O cliente solicita que autenticação de uma determinada API seja realizada com segundo fator de autenticação através do Google Authenticator, veja como funciona: https://www.youtube.com/watch?v=mVIxzH4EWmA

### Requisitos:

1. Criar funções para gerar e validar as chaves do Google Authenticator
2. Implementação em JavaScript  
  a. Usar ES5 e rodar no browser  
  b. Não usar código no backend

---

### Subir servidor web
Abra o terminal, execute ***docker-compose up --build*** e acesse ***http://localhost:8080***

### Gerar QR Code
Acesse ***http://localhost:8080/qrcode***, digite seu e-mail e gere o QR Code.

### Algoritmo
**TOTP (Time-Based One-Time Password)**: Definido pela RFC6238, o qual utiliza um algoritmo de Hash (HMAC) e o UNIX EPOCH para gerar uma sequência de números que mudam depois de um tempo determinado e são responsáveis por autenticar o usuário junto ao sistema. O tempo no TOTP funciona a partir do UNIX EPOCH, que nada mais é que um sistema que define a quantidade de segundos contados desde as 00 horas UTC do dia 1 de janeiro de 1970.
