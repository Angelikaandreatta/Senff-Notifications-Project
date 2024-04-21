# Microservice de Notificações
Este microservice é uma API desenvolvida para facilitar o disparo de notificações via SMS, WhatsApp e/ou E-mail. Ele é construído utilizando o framework .NET Core 6.0 e adota uma arquitetura flexível para atender às necessidades do projeto.

### Introdução
O objetivo principal deste microservice é oferecer uma solução centralizada para o envio de notificações para os clientes de uma empresa. Ele permite que os usuários se cadastrem, autentiquem-se e solicitem o envio de notificações por meio de diferentes canais de comunicação.

### Funcionalidades Principais
##### Autenticação de Usuários: 
O microservice oferece um sistema de cadastro e autenticação de usuários, garantindo que apenas usuários autorizados possam utilizar o serviço.
##### Gerenciamento de Empresas: 
Cada usuário está associado a uma empresa cadastrada, facilitando a gestão e organização das notificações.
##### Rastreamento de Solicitações: 
Todas as solicitações de envio de notificações são registradas, permitindo o rastreamento do usuário que fez a solicitação, juntamente com informações como IP e data/hora do envio.
##### Rate Limiting Personalizado: 
Implementa um sistema de rate limiting personalizado com base nos contratos de serviço assinados pelas empresas clientes. Isso garante que os limites de uso sejam respeitados e evita abusos no sistema.
##### Integração com Parceiros: 
Possibilita a integração com pelo menos 2 parceiros diferentes para o envio de notificações. Isso oferece flexibilidade e redundância no sistema, garantindo que as notificações sejam entregues de forma confiável.

### Tecnologias Utilizadas
- .NET 6.0
- JWT para autenticação
- Banco de dados Sql Server

### Contribuição
Contribuições são bem-vindas! Se você encontrar algum bug, tiver alguma sugestão de melhoria ou desejar contribuir com código, sinta-se à vontade para abrir uma issue ou enviar um pull request.
