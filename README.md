```
# API ASP.NET 6 com Autenticação JWT

Esta é uma API ASP.NET 6 que implementa autenticação JWT (JSON Web Tokens) para permitir a autenticação e autorização de usuários.

## Funcionalidades

- Registro de novos usuários com validações de email e senha.
- Autenticação de usuários com geração de tokens JWT.
- Rotas protegidas que requerem autenticação para acesso.

## Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Configuração

1. Clone este repositório para sua máquina local:

   ```bash
   git clone https://github.com/seu-usuario/sua-api.git
   ```

2. Abra o projeto no Visual Studio ou no Visual Studio Code.

3. Configure a conexão do banco de dados no arquivo `appsettings.json`:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "sua-connection-string"
   }
   ```

4. Configure as chaves JWT no arquivo `appsettings.json`:

   ```json
   "JWT": {
       "Secret": "sua-chave-secreta",
       "ValidIssuer": "emissor-do-token",
       "ValidAudience": "público-alvo-do-token"
   }
   ```

## Executando a Aplicação

1. No terminal, navegue até o diretório do projeto:

   ```bash
   cd Caminho/Para/Seu/Projeto
   ```

2. Execute o comando para iniciar a aplicação:

   ```bash
   dotnet run
   ```

A aplicação será iniciada e estará disponível em `https://localhost:5001` por padrão.

## Rotas

- **POST** `/api/auth/Entrar`: Autentica um usuário e gera um token JWT.
- **POST** `/api/auth/novo-usuario`: Registra um novo usuário.

## Contribuição

Contribuições são bem-vindas! Se você encontrar um problema ou quiser adicionar uma nova funcionalidade, fique à vontade para criar um pull request.

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
```
```


