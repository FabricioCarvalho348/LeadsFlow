<div>
    <p align="center">
      <img src="https://img.shields.io/badge/Lead-Flow-yellow" height="130" alt="student-flow-api">
    </p>
</div>

![Status de Desenvolvimento](https://img.shields.io/badge/Status-Concluido-green)

## Tecnologias Utilizadas

- C#

- .NET 8.0

- Angular 19.2.9

- SQL Server

## Funcionalidades

- Cadastrar, alterar, deletar e listar leads.

- Frontend lista os leads cadastrados pelo status "New" que são os leads que estão na guia 'Invited' e 
  'Accepted' que são os leads que estão na guia 'Accepted'.

- Conversa entre Backend e Frontend

## Requisição

- Para cadastrar um lead
```
POST http://localhost:5015/api/leads
```

- Exemplo para cadastrar:

```json
{
  "contactFirstName": "Pete",
  "contactLastName": "Craig",
  "contactPhone": "5023509035",
  "contactEmail": "another.fake@hipmail.com",
  "suburb": "Woolooware 2230",
  "category": "Interior Painters",
  "description": "There is a two story building at the front of the main house that's about 10x5 that would like to convert into self contained living area.",
  "price": 550
}
```

## Como executar o projeto em sua máquina

1. Instale alguma das IDEs para o desenvolvimento .NET, temos o Rider e o Visual Studio
   <br>[link para o Rider](https://www.jetbrains.com/pt-br/rider/)
   <br>[link para o Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)

2. Instale a versão do .NET 8.0.12 no link abaixo

[.NET 8.0.12](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

3. Instale o SQL Server na sua máquina

[Site oficial do SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

4. Clone o repositório, no Git Bash digite o comando:

```
git clone git@github.com:FabricioCarvalho348/LeadsFlow.git
```

5. Dentro do projeto "LeadFlow.Api" tem dois arquivos appsettings.json e appsettings.Development.json coloque sua conexão do SQL Server no campo correspondente

```
 Server=localhost\SQLEXPRESS;Database={NOME_DO_BANCO_DE_DADOS};User Id={USERNAME_SQLSERVER};Password={SUA_SENHA_DO_SQLSERVER};Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;
```

Observação: no "localhost\SQLEXPRESS" você pode colocar o nome da sua instância do SQL Server, caso não tenha uma instância padrão.

6. Instalar o EF Tools

```
dotnet tool install --global dotnet-ef
```

7. Subir as migrações pelo prompt

```
dotnet ef database update --project ./LeadsFlow.Infrastructure --startup-project ./LeadsFlow.Api
```

8. Executar o backend, clique no botão RUN na sua IDE

Execução do Frontend:

Verifique se você tem o Node.js instalado na sua máquina, caso não tenha, instale a versão LTS no link abaixo:
[Node.js LTS](https://nodejs.org/en/download/)

9. Execute esses comandos no terminal para verificar se o NPM e o NodeJS foram instalados corretamente:
```
node -v
npm -v
```

Caso não tenha o NPM instalado, instale o NPM com o seguinte comando:

```
npm install -g npm
```

10. Para instalar o Angular CLI, execute o seguinte comando no terminal:

```
npm install -g @angular/cli
```

11. Após a instalação, execute o comando:

```
ng serve
```

12. Após a execução do comando, acesse o navegador e digite o seguinte endereço:

```
http://localhost:4200/
```