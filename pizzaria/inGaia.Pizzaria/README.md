# inGaia 

### Como executar  
Clonar o projeto, abrir o ***Package Manager Console***, restaurar os pacotes e executar(F5)  

### Design  
***Presentation:*** Camada que conterá as aplicações/serviços - Neste caso apenas o site  
***Application:*** Criado para concentar e orquestar o domínio, assim toda inteligência de como executar algo fica nesta camada, possibilitando que outras aplicações/serviços possam compartilhar códigos - Caso a inteligência estivesse na Controller não seria possível o compartilhamento.  
***Domain:*** Concentar as regras de negócios no domínio para que não fiquem espalhadas em várias partes do projeto, mantendo a linguagem ubíqua e facilitando a manutenção.  
***IoC:*** Foi utilizado o Unity para reduzir o acoplamento entre camadas e facilitar na parte de testes.  