# Simple API GraphQL - Movies Catalog

Esta � uma API GraphQL desenvolvida em .NET Core e MySQL, projetada para fornecer dados relacionados a filmes e categorias.

## Configura��o

Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado em sua m�quina.

1. Clone este reposit�rio:

   ```
   git clone https://github.com/tallesvini/Movie_GraphQL_Api.git
   ```

2. Acesse o diret�rio do projeto:

   ```
   cd nome-do-repositorio
   ```

3. Abra o arquivo `program.cs` e configure as informa��es de conex�o com o banco de dados MySQL:

   ```json
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;initial catalog=ProductsApi;Uid=root"
      },
   ```

4. Execute as migra��es para criar as tabelas no banco de dados:

   ```
   dotnet ef database update
   ```

5. Inicie o servidor:

   ```
   dotnet run
   ```

A API estar� dispon�vel em `http://localhost:5000`.

## Requisitos de Sistema

- .NET Core SDK 3.1 ou superior.

# Persist�ncias:

## Create:

### 1. Cria��o de Category:
   
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
        "name": "A��o"
    }
}
```

##### Exemplo de retorno:
``` json
{"data":{"categoryMutation":{"addCategory":{"id":1,"name":"A��o"}}}}
```

### 2. Cria��o de Movie: 
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
        "name": "Velozes & Furiosos: Desafio em T�quio.",
        "description": "O filme destaca a cultura automotiva japonesa e � conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
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
                "name": "Velozes & Furiosos: Desafio em T�quio.",
                "description": "O filme destaca a cultura automotiva japonesa e � conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                "category": [
                    {
                        "id": 1,
                        "name": "A��o"
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
        "name": "A��o Policial"
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
                "name": "A��o Policial"
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
        "name": "Velozes & Furiosos: Desafio em T�quio.",
        "description": "O filme destaca a cultura automotiva japonesa e � conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes. * Trecho Incluido via update *",
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
                "name": "Velozes & Furiosos: Desafio em T�quio.",
                "description": "O filme destaca a cultura automotiva japonesa e � conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes. * Trecho Incluido via update *",
                "releasedYear": "2006-11-08",
                "category": [
                    {
                        "id": 1,
                        "name": "A��o Policial"
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
                    "name": "A��o Policial"
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
                    "name": "Velozes & Furiosos: Desafio em T�quio.",
                    "description": "O filme destaca a cultura automotiva japonesa e � conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                    "category": [
                        {
                            "id": 1,
                            "name": "A��o Policial"
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
                "name": "A��o Policial",
                "movies": [
                    {
                        "id": 1,
                        "name": "Velozes & Furiosos: Desafio em T�quio.",
                        "description": "O filme destaca a cultura automotiva japonesa e � conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes."
                    }
                ]
            }
        }
    }
}
```

## Como Contribuir

Se voc� deseja contribuir para este projeto, siga as etapas abaixo:

1. Fa�a um fork deste reposit�rio e clone-o em sua m�quina local.
2. Crie um novo branch para suas altera��es: `git checkout -b minha-branch`.
3. Realize as altera��es desejadas e commit-as: `git commit -m 'Minhas altera��es'`.
4. Envie suas altera��es para o branch principal do reposit�rio forkado: `git push origin minha-branch`.
5. Abra um pull request no reposit�rio original, descrevendo as altera��es propostas.

## Licen�a

Este projeto est� licenciado sob a **MIT License**.