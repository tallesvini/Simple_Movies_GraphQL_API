# Simple API GraphQL - Movies Catalog

Esta é uma API GraphQL desenvolvida em .NET Core e MySQL, projetada para fornecer dados relacionados a filmes e categorias.

## Configuração

Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

1. Clone este repositório:

   ```
   git clone https://github.com/tallesvini/Movie_GraphQL_Api.git
   ```

2. Acesse o diretório do projeto:

   ```
   cd nome-do-repositorio
   ```

3. Abra o arquivo `program.cs` e configure as informações de conexão com o banco de dados MySQL:

   ```json
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;initial catalog=ProductsApi;Uid=root"
      },
   ```

4. Execute as migrações para criar as tabelas no banco de dados:

   ```
   dotnet ef database update
   ```

5. Inicie o servidor:

   ```
   dotnet run
   ```

A API estará disponível em `http://localhost:5000`.

## Requisitos de Sistema

- .NET Core SDK 3.1 ou superior.

# Persistências:

## Create:

### 1. Criação de Category:
   
#### POST - Create Category: /graphql

##### Mutation:
``` 
mutation Category($category: CategoryInput!) {
    categoryMutation{
        addCategory(category: $category) {
            id
            name
        }
    }
}
```

##### Payload:
``` json
{
    "category": {
        "id": 1,
        "name": "Ação"
    }
}
```

##### Exemplo de retorno:
``` json
{"data":{"categoryMutation":{"addCategory":{"id":1,"name":"Ação"}}}}
```

### 2. Criação de Movie: 
#### POST - Create Movie: /graphql

##### Mutation:
``` 
mutation Movies($movie: MovieInput!) {
    movieMutation{
        addMovie(movie: $movie) {
            id
            name
            description 
            category {
                id
                name
            }
        }
    }
}
```

##### Payload:
``` json
{
    "movie": {
        "id": 1,
        "name": "Velozes & Furiosos: Desafio em Tóquio.",
        "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
        "categoryId": 1
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "movieMutation": {
            "addMovie": {
                "id": 1,
                "name": "Velozes & Furiosos: Desafio em Tóquio.",
                "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                "category": [
                    {
                        "id": 1,
                        "name": "Ação"
                    }
                ]
            }
        }
    }
}
```
## Update:

### 1. Update de Category: 
#### POST - Update Category: /graphql

##### Mutation:
``` 
mutation Category($category: CategoryUpdate!) {
    categoryMutation {
        updateCategory(category: $category) {
            id
            name
        }
    }
}
```

##### Payload:
``` json
{
    "category": {
        "id": 1,
        "name": "Ação Policial"
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "categoryMutation": {
            "updateCategory": {
                "id": 1,
                "name": "Ação Policial"
            }
        }
    }
}
```

### 2. Update de Movie: 
#### POST - Update Movie: /graphql

##### Mutation:
``` 
mutation Movie($movie: MovieUpdate!) {
    movieMutation {
        updateMovie(movie: $movie) {
            id
            name
            description 
            releasedYear
            category {
                id
                name
            }
        }
    }
}
```

##### Payload:
``` json
{
    "movie": {
        "id": 1,
        "name": "Velozes & Furiosos: Desafio em Tóquio.",
        "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes. * Trecho Incluido via update *",
        "releasedYear": "11-08-2006",
        "categoryId": 1
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "movieMutation": {
            "updateMovie": {
                "id": 1,
                "name": "Velozes & Furiosos: Desafio em Tóquio.",
                "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes. * Trecho Incluido via update *",
                "releasedYear": "2006-11-08",
                "category": [
                    {
                        "id": 1,
                        "name": "Ação Policial"
                    }
                ]
            }
        }
    }
}
```

## Delete:

### 1. Delete de Category: 
#### POST - Delete Category: /graphql

##### Mutation:
``` 
mutation Category($category: CategoryDelete!) {
    categoryMutation {
        deleteCategory(category: $category) {
            id
        }
    }
}
```

##### Payload:
``` json
{
    "category": {
        "id": 1
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "categoryMutation": {
            "deleteCategory": {
                "id": 1
            }
        }
    }
}
```

### 2. Delete de Movie: 
#### POST - Delete Movie: /graphql

##### Mutation:
``` 
mutation Movie($movie: MovieDelete!) {
    movieMutation {
        deleteMovie(movie: $movie) {
            id
        }
    }
}
```

##### Payload:
``` json
{
    "movie": {
        "id": 1
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "movieMutation": {
            "deleteMovie": {
                "id": 1
            }
        }
    }
}
```

# Consultas:

## GetAll:

### 1. GetAll de Category: 
#### POST - GetAll Categories: /graphql

##### Payload:
```
query {
    categoryQuery {
        categories {
            id,
            name
        }
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "categoryQuery": {
            "categories": [
                {
                    "id": 1,
                    "name": "Ação Policial"
                }
            ]
        }
    }
}
```

### 2. GetAll de Movie: 
#### POST - GetAll Movies: /graphql

##### Payload:
```
query {
    movieQuery {
        movies {
            id
            name
            description 
            category {
                id
                name
            }
        }
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "movieQuery": {
            "movies": [
                {
                    "id": 1,
                    "name": "Velozes & Furiosos: Desafio em Tóquio.",
                    "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                    "category": [
                        {
                            "id": 1,
                            "name": "Ação Policial"
                        }
                    ]
                }
            ]
        }
    }
}
```

## GetById:

### 1. GetById de Category: 
#### POST - GetById Category: /graphql

##### Payload:
```
query {
    categoryQuery {
        category(id: 1) {
            id,
            name
            movies {
                id
                name
                description 
            }
        }
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "categoryQuery": {
            "category": {
                "id": 1,
                "name": "Ação Policial",
                "movies": [
                    {
                        "id": 1,
                        "name": "Velozes & Furiosos: Desafio em Tóquio.",
                        "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes."
                    }
                ]
            }
        }
    }
}
```

## Como Contribuir

Se você deseja contribuir para este projeto, siga as etapas abaixo:

1. Faça um fork deste repositório e clone-o em sua máquina local.
2. Crie um novo branch para suas alterações: `git checkout -b minha-branch`.
3. Realize as alterações desejadas e commit-as: `git commit -m 'Minhas alterações'`.
4. Envie suas alterações para o branch principal do repositório forkado: `git push origin minha-branch`.
5. Abra um pull request no repositório original, descrevendo as alterações propostas.

## Licença

Este projeto está licenciado sob a **MIT License**.
