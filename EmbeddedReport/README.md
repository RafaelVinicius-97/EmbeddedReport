# API para embedamento de relatório do PowerBI

Essa API foi construída com o intuito de realizar somente a autenticação necessária para embedar relatórios do PowerBI em qualquer sistema Web.
O retorno da API, caso não ocorra nenhum erro, será uma objeto em json com os tokens para realizar o embedamento.

### Observações importantes:
Para que a autenticação seja realizada você precisa preencher as informações do objeto AzureEmbed dentro do arquivo appsettings.json.