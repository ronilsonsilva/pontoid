# Requisitos do Projeto

# • 1º Objetivo:
Modelar um banco de dados simples, no qual deverá possuir no mínimo três tabelas e de preferência do tipo self-contained.
A primeira tabela irá armazenar as informações da Escola: Nome e Código INEP.
A segunda tabela será responsável por armazenar as informações das Turmas: Descrição, Série e turno
Já a terceira tabela será responsável por armazenar as informações do Aluno:  Nome, Data de Nascimento e CPF

# • 2º Objetivo:
Desenvolver em C# (ASP.NET Core preferencialmente) uma API REST, fornecendo as operações CRUD para as tabelas modeladas. É desejável que a camada de persistência utilize o Entity Framework.
# • 3º Objetivo:
Desenvolver um aplicativo Web MVC, SIMPLES, que faça as operações básicas modeladas, acessando os endpoints da API desenvolvida, para alimentar o banco de dados.

# Link da API: https://escolaapi.azurewebsites.net/swagger
# Link da Aplicação Web: https://adminescola.azurewebsites.net

# Como executar a aplicação
No visual studio, abrir o pakage manager console, selecione o projeto PontoID.Data.Context como alvo, e execute o comando: Update-Database
Certifique de ter definido uma string de conexão válida, e um banco de dados Postgres, no arquivo de configuração da API
