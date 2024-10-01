# fiap.hackaton.health-med.api
Repositório destinado à aplicação do projeto Health&amp;Med (Hackaton da FIAP)

## Execução

### AWS (Academy)

TODO

### CLI

O projeto pode ser executado utilizando o Docker.
Para iniciar a aplicação e banco de dados separadamente, siga os passos abaixo.

Para subir o BD local, o recomendado é utilizar o Docker e executar o seguinte comando:
```shell
docker run --rm --name pg-healthmed-docker -e POSTGRES_PASSWORD=docker -e POSTGRES_DB=healthmed_db -d -p 5432:5432 postgres
```

Obs.: A *connection string* do BD local já está configurada corretamente no arquivo *launchSettings.json*. Contudo, espera-se que as credenciais da AWS sejam incluídas no arquivo, para o funcionamento com o Amazon SQS.

No arquivo `launchSettings.json`, preencher as seguintes variáveis, com as credenciais do AWS (Academy):
```json
{
  "AmazonSettings__AccessKey": "",
  "AmazonSettings__SecretKey": "",
  "AmazonSettings__SessionToken": ""
}
```

Inicie a Aplicação (API):
```shell
dotnet run --project .\src\Drivers\API\API.csproj
```

Swagger UI da API: `http://localhost:5001/swagger` (***Recomendado para testar as chamadas aos endpoints***)

Caso seja necessário derrubar o BD local, basta executar:

```shell
docker container kill pg-healthmed-docker
```