# Pizzaria - C#

Somos uma pizzaria e precisamos de uma aplicação web para gerir nosso negócio. Nossa especialidade é a venda de pizzas, de modo que algumas são opções de cardápio e outras podem conter ingredientes personalizados.


A seguir, apresentamos as listas de massas e ingredientes disponíveis:

| Massas        | Vales    |
| ------------- |:--------:|
| Fina          | R$ 11,00 |
| Pan           | R$ 12,00 |
| Tradicional   | R$ 10,00 |


| INGREDIENTES | VALORES |
|--------------|---------|
| Calabresa    | R$8,00  |
| Pepperoni    | R$13,00 |
| Palmito      | R$9,00  |
| Ovo          | R$3,00  |
| Cebola       | R$5,00  |
| Queijo       | R$8,00  |
| Ervilha      | R$ 4.00 |
| Presunto     | R$ 6.00 |
| Tomate       | R$5,00  |

Segue as opções de cardápio e seus respectivos ingredientes:

| PIZZAS     | INGREDIENTES                                                                |
|------------|-----------------------------------------------------------------------------|
| Marguerita | Massa tradicional, queijo, tomate e manjericão                              |
| Calabresa  | Massa fina, calabresa, tomate e queijo                                      |
| Portuguesa | Massa tradicional, ovo, tomate, cebola, queijo, palmito, presunto e ervilha |
| Pepperoni  | Massa pan, pepperoni, queijo e tomate.                                      |

O valor de cada opção do cardápio é dado pela soma dos ingredientes que compõem a pizza. Além destas opções, o cliente pode personalizar sua pizza e escolher os ingredientes que desejar. Nesse caso, o preço da pizza também será calculado pela soma dos ingredientes. É obrigatória a escolha de um tipo de massa.

A taxa de entrega é de R$ 6,00 para qualquer região. 

Os valores dos ingredientes são alterados com frequência e não gastaríamos que isso influenciasse nos testes automatizados.

Existe uma exceção à regra para o cálculo de preço, quando a pizza pertencer à uma promoção. A seguir, apresentamos a lista de promoções e suas respectivas regras de negócio:

| PROMOÇÕES       | REGRA DE NEGÓCIO                                                                                 |
|-----------------|--------------------------------------------------------------------------------------------------|
| Vegetariana     | Se a pizza não contiver calabresa, pepperoni e presunto ganha 10% de desconto.                   |
| Carnívora       | Se a pizza contiver os 3 tipos de carne (Pepperoni, Presunto e Calabresa) ganha 20% de desconto. |
| Taxa de entrega | Se o pedido for feito em segunda, terça ou quarta feira, a taxa de entrega é grátis.             |
| Grande Pedido   | No pedido de 4 pizzas juntas a pizza com menor valor é grátis.                                   |

### CRITÉRIOS DE APRESENTAÇÃO DO PROJETO

O projeto deve ser entregue atendendo aos seguintes critérios
O server-side deve ser desenvolvido em C# (.NET) ou Javascript (NodeJS).
O client-side deve ser desenvolvido em HTML e JavaScript.
Deve possuir cobertura de testes automatizados para os seguintes pontos: Valor das pizzas do cardápio, regra para cálculo de preço e promoções.
Não é necessário se preocupar com a autenticação dos usuários.
Não é necessário persistir os dados em um banco, pode fazer armazenamento em memória.

### ENTREGÁVEIS

Você deve entregar o projeto de acordo com os requisitos mínimos. O diferencial não é obrigatória a entrega.

#### Mínimo
Implementação dos requisitos;
Instruções para executar.
Relatório de justificativas para escolha do design de código;
Instruções para executar;

#### Diferencial
Os testes automatizados devem ser executados por algum modelo de integração contínua;
O ambiente de execução da aplicação deve possuir um HTTP Proxying com nginx, redirecimendo as requisições da porta 80 para o server-side.
Ambiente virtualizado em Docker com scripts para execução do projeto.