# Desafio_Roman
Repositório dedicado aos trabalhos do "Desafio Roman" do curso de Desenvolvimento de Sistemas da Escola SENAI de Informática


# Back end
## Requisitos do projeto
- dotnet 5
- SqlServer
- Sql Server Management Studio
- Visual Studio

## Configurações antes de rodar o projeto
1. Entrar no Management Studio e Executar os scripts na ordem DDL-DML que estão no diretório BD
2. No arquivo RomanContext alterar a string de conexão na linha 34 para as configurações do seu Sql Server através do Visual Studio
3. Para executar o projeto, Execute o comando `dotnet run` no terminal da pasta `Back_end/Projeto_Roman.WebApi/Projeto_Roman.WebApi`
4. Acesse no browser o endereço `http://localhost:5000/swagger/index.html`
