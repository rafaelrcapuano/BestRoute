# Rota de Viagem

> Exemplo de uma aplicação responsável por obter a melhor rota de viagem, utilizando C# e .NET Core 3.1.

## O que é?

- A partir de um arquivo entrada, busca a melhor rota a ser seguida em uma viagem.

- Possui uma aplicação em console para a consulta das rotas.

- Contém também uma API, que além de possibilitar a consulta, permite a inserção de novas rotas.

- Inspirada em conceitos do **Clean Architecture**, a ideia é exemplificar um projeto que facilite a manutenção do código, além da implementação de novas funcionalidades. O objetivo é seguir as práticas do SOLID, em conjunto com a injeção de dependência, para a separação das classes.

- Possui a seguinte estrutura:

    **BestRoute.Api** => API para entrada e saída dos dados.    

    **BestRoute.Application** => Responsável por executar a regra de negócio. Os dados de entrada da API (requests) são validados e convertidos nas entidades de domínio. Logo depois, são retornados os valores que devem ser expostos (responses).

    **BestRoute.Console.App** => Console para consulta dos dados.
	
	**BestRoute.Domain** => Representa o domínio da aplicação, ou seja, as entidades essenciais para o negócio. A ideia é que não sofra nenhuma interferência de frameworks.
	
	**BestRoute.Infra.CrossCutting** => Aqui acontece a configuração da injeção de dependência para as demais camadas.

    **BestRoute.Infra.Data** => Estrutura para leitura e gravação do arquivo de entrada.

    **BestRoute.Tests** => Testes unitários da aplicação.

## Requisitos

- Precisamos da versão 3.1 do .NET Core. O download pode ser realizado [aqui](https://dotnet.microsoft.com/download/dotnet/3.1).

- Utilizando o terminal de sua preferência, confirme se a instalação foi concluída com sucesso:

    ![dotnet-version](attachments/dotnet-version.png)

- Devemos também fornecer um arquivo de entrada, responsável por armazenar as rotas, com os seus locais de partida e destino, e suas respectivas distâncias. Um exemplo pode ser encontrado em *\attachments\input-routes.csv*:

    ```
    SP,RJ,20
    RJ,MG,10
    SP,DF,150
    SP,MG,40
    SP,PE,112
    PE,DF,10
    MG,PE,40
    ```