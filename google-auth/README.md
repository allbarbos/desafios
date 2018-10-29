# 2-Step Verification with Google Authenticator

O cliente solicita que autenticação de uma determinada API seja realizada com segundo fator de autenticação através do Google Authenticator, veja como funciona: https://www.youtube.com/watch?v=mVIxzH4EWmA

### Requisitos:

1. Criar funções para gerar e validar as chaves do Google Authenticator
2. Implementação em Java ou JavaScript
3. Para JavaScript:  
  a. Usar ES5 e rodar no browser  
  b. Não usar código no backend  
4. Para Java:  
  a. Não usar biblioteca de terceiros, exceto se embutir os binários no classpath. Não ter dependencia com external jars.  
  b. Empacotar no formato JAR  

### Subir servidor web
Abra o terminal, execute ***docker-compose up --build*** e acesse ***http://localhost:8080***

### Gerar QR Code
Acesse ***http://localhost:8080/qrcode***, digite seu e-mail e gere o QR Code.
