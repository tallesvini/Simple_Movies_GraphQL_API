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
        "name": "Suspense Sobrenatural"
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "categoryMutation": {
            "addCategory": {
                "id": 9,
                "name": "Suspense Sobrenatural"
            }
        }
    }
}
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
            releasedYear
            director
            rating
            review
            duration
            trailer
            poster
            countryOfOrigin
            language
            keywords    
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
        "name": "Interestelar",
        "releasedYear": "2014",
        "description": "Após ver a Terra consumindo boa parte de suas reservas naturais, um grupo de astronautas recebe a missão de verificar possíveis planetas para receberem a população mundial, possibilitando a continuação da espécie. Cooper (Matthew McConaughey) é chamado para liderar o grupo e aceita a missão sabendo que pode nunca mais ver os filhos. Ao lado de Brand (Anne Hathaway), Jenkins (Marlon Sanders) e Doyle (Wes Bentley), ele seguirá em busca de uma nova casa. Com o passar dos anos, sua filha Murph (Mackenzie Foy e Jessica Chastain) investirá numa própria jornada para também tentar salvar a população do planeta.",
        "director": "Christopher Nolan",
        "rating": "14",
        "review": "4.6",
        "duration": "2h49min",
        "trailer": "https://youtu.be/hHBsKHVLAYc?si=6XsHPgXEEEcHfjJ_",
        "poster": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQmyAQu2hcbYkaBGOpDuU17xTTGILMFl4m0VfdMXI-sQ&s",
        "countryOfOrigin": "United States of America",
        "language": "English",
        "keywords": "Ação, Science, Fiction",
        "categoryId": 8
    }
}
```

##### Exemplo de retorno:
``` json
{
    "data": {
        "movieMutation": {
            "addMovie": {
                {
                    "id": 13,
                    "name": "Interestelar",
                    "releasedYear": "2014",
                    "description": "Após ver a Terra consumindo boa parte de suas reservas naturais, um grupo de astronautas recebe a missão de verificar possíveis planetas para receberem a população mundial, possibilitando a continuação da espécie. Cooper (Matthew McConaughey) é chamado para liderar o grupo e aceita a missão sabendo que pode nunca mais ver os filhos. Ao lado de Brand (Anne Hathaway), Jenkins (Marlon Sanders) e Doyle (Wes Bentley), ele seguirá em busca de uma nova casa. Com o passar dos anos, sua filha Murph (Mackenzie Foy e Jessica Chastain) investirá numa própria jornada para também tentar salvar a população do planeta.",
                    "director": "Christopher Nolan",
                    "cast": "Matthew McConaughey, Anne Hathaway, Michael Caine",
                    "rating": "14",
                    "review": "4.6",
                    "duration": "2h49min",
                    "trailer": "https://youtu.be/hHBsKHVLAYc?si=6XsHPgXEEEcHfjJ_",
                    "poster": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQmyAQu2hcbYkaBGOpDuU17xTTGILMFl4m0VfdMXI-sQ&s",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Ação, Science, Fiction",
                    "category": {
                        "id": 8,
                        "name": "Ficção"
                    }
                }
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
            director
            rating
            review
            duration
            trailer
            poster
            countryOfOrigin
            language
            keywords    
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
        "name": "Velozes & Furiosos: Desafio em Tóquio",
        "releasedYear": "2006",
        "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
        "director": "Justin Lin",
        "cast": "",
        "rating": "16",
        "review": "4.5",
        "duration": "1h44min",
        "trailer": "https://youtu.be/dmeFOEcnTBU?si=I122C0yauHn3uXQb",
        "poster": "https://br.web.img2.acsta.net/pictures/210/383/21038387_20130909201408304.jpg",
        "countryOfOrigin": "United States of America",
        "language": "English",
        "keywords": "Ação, Policial",
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
                "name": "Velozes & Furiosos: Desafio em Tóquio",
                "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                "releasedYear": "2006",
                "director": "Justin Lin",
                "rating": "16",
                "review": "4.5",
                "duration": "1h44min",
                "trailer": "https://youtu.be/dmeFOEcnTBU?si=I122C0yauHn3uXQb",
                "poster": "https://br.web.img2.acsta.net/pictures/210/383/21038387_20130909201408304.jpg",
                "countryOfOrigin": "United States of America",
                "language": "English",
                "keywords": "Ação, Policial",
                "category": {
                    "id": 1,
                    "name": "Ação"
                }
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
            name,
            movies {
                id,
                name,
                releasedYear,
                description,
                director
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
            "categories": [
                {
                    "id": 1,
                    "name": "Ação",
                    "movies": [
                        {
                            "id": 1,
                            "name": "Velozes & Furiosos: Desafio em Tóquio.",
                            "releasedYear": "2006",
                            "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                            "director": "Justin Lin"
                        },
                        {
                            "id": 3,
                            "name": "Aquaman 2: O Reino Perdido",
                            "releasedYear": "2023",
                            "description": "Aquaman 2 é a sequência do filme Aquaman de 2018, que acompanha Arthur Curry (Jason Momoa), o filho do humano Tom Curry (Temuera Morrison) com a atlante Atlanna (Nicole Kidman). Ele cresce com a vivência de um humano e as capacidades metahumanas de um atlante. Nesta sequência, depois de não conseguir derrotar o rei dos mares pela primeira vez, Arraia Negra (Yahya Abdul-Mateen II) utiliza o poder do mítico Tridente Negro para liberar uma força antiga e maligna. Na tentativa de proteger Atlântida e o resto do mundo, Aquaman deve forjar uma aliança incômoda com um aliado improvável e deixar as diferenças de lado para evitar uma devastação irreversível.",
                            "director": "James Wan"
                        },
                        {
                            "id": 12,
                            "name": "Malcolm X",
                            "releasedYear": "1993",
                            "description": "Biografia do famoso líder afro-americano (Denzel Washington) que teve o pai, um pastor, assassinado pela Klu Klux Klan e sua mãe internada por insanidade. Ele foi um malandro de rua e enquanto esteve preso descobriu o islamismo. Malcolm faz sua conversão religiosa como um discípulo messiânico de Elijah Mohammed (Al Freeman Jr.). Ele se torna um fervoroso orador do movimento e se casa com Betty Shabazz (Angela Bassett). Malcolm X ora uma doutrina de ódio contra o homem branco até que, anos mais tarde, quando fez uma peregrinação à Meca abranda suas convicções. Foi nesta época que se converteu ao original islamismo e se tornou um Sunni Muslim, mudando o nome para El-Hajj Malik Al-Shabazz, mas o esforço de quebrar o rígido dogma da Nação Islã teve trágicos resultados.",
                            "director": "Spike Lee"
                        }
                    ]
                },
                {
                    "id": 2,
                    "name": "Terror",
                    "movies": [
                        {
                            "id": 2,
                            "name": "O Mal que nos Habita",
                            "releasedYear": "2024",
                            "description": "O Mal Que nos Habita é um filme argentino de terror dirigido por Demián Rugna (Aterrorizados, The Last Gateway). A trama se passa em uma pacata cidade do interior, onde dois irmãos encontram um corpo mutilado perto de sua propriedade e se reúnem com os moradores locais para investigarem o ocorrido. Eles acabam descobrindo que o homem encontrado está infectado pelo diabo e está prestes a dar a luz a um demônio real. Desesperados, os habitantes tentam escapar do local antes que o ser maligno venha à terra, mas o tempo parece não estar a seu favor e o caos é instaurado por completo.",
                            "director": "Demián Rugna"
                        }
                    ]
                },
                {
                    "id": 3,
                    "name": "Comédia/Comédia Infantil",
                    "movies": [
                        {
                            "id": 4,
                            "name": "Turma da Mônica Jovem: Reflexos do Medo",
                            "releasedYear": "2024",
                            "description": "Baseado nos quadrinhos clássicos de Maurício de Sousa, Turma da Mônica Jovem: Reflexos do Medo traz os amigos em uma nova aventura, agora na adolescência. Em uma nova escola e agora no ensino médio, o primeiro dia de aula já reservava uma surpresa: os amigos Mônica (Sophia Valverde), Cebola (Xande Valois), Magali (Bianca Paiva), Cascão (Theo Salomão) e Milena (Carol Roberto) descobrem que o Museu do Limoeiro será leiloado. A turma decide se unir em uma missão para tentar salvá-lo, e enquanto investigam o que está acontecendo, eles não demoram muito para perceber que podem estar lidando com uma ameaça muito maior do que imaginam. Marcando uma nova fase na vida dos amigos que estão juntos desde a infância, agora eles compartilham os medos e as inseguranças que surgem na adolescência em uma trama que mistura aventura e suspense, mas sem perder o jeitinho de sempre.",
                            "director": "Mauricio Eça"
                        },
                        {
                            "id": 5,
                            "name": "Deadpool",
                            "releasedYear": "2016",
                            "description": "Ex-militar e mercenário, Wade Wilson (Ryan Reynolds) é diagnosticado com câncer em estado terminal, porém encontra uma possibilidade de cura em uma sinistra experiência científica. Recuperado, com poderes e um incomum senso de humor, ele torna-se Deadpool e busca vingança contra o homem que destruiu sua vida.",
                            "director": "Tim Miller"
                        },
                        {
                            "id": 6,
                            "name": "Mamonas Assassinas - O Filme",
                            "releasedYear": "2023",
                            "description": "Mamonas Assassinas - O Filme acompanha a trajetória de Dinho (Ruy Brissac), Júlio (Robson Lima), Bento (Alberto Hinoto), Sérgio (Rhener Freitas) e Samuel (Adriano Tunes) que, juntos, formaram um dos grupos mais inesperados e inicialmente desacreditados pelo grande público, os Mamonas Assassinas. Provando-se um sucesso estrondoso em um curtíssimo espaço de tempo, o quinteto precisou de muitas tentativas frustradas para conseguir mostrar que podia ser a próxima grande banda do Brasil.",
                            "director": "Edson Spinello"
                        }
                    ]
                },
                {
                    "id": 4,
                    "name": "Fantasia",
                    "movies": [
                        {
                            "id": 7,
                            "name": "Wonka",
                            "releasedYear": "2023",
                            "description": "Wonka é uma comédia musical baseada no clássico livro A Fantástica Fábrica de Chocolate, do autor britânico Roald Dahl. O filme mostra as origens da história do jovem Willy Wonka (interpretado por Timothée Chalamet), que apareceu nos cinemas pela primeira vez na produção de 1971 e, mais tarde, ganhou um remake estrelado por Johnny Depp em 2005. Antes de se tornar a mente brilhante por trás da maior fábrica de chocolate do mundo, Willy precisou enfrentar vários obstáculos. Cheio de ideias e determinado a mudar o mundo, o jovem Wonka embarca em uma aventura para espalhar alegria através de seu delecioso chocolate. Nela, ele acabou conhecendo o seu fiel e icônico assistente, Oompa Loompa (interpretado por Hugh Grant), que o ajudar a ir contra todas as probabilidades para se tornar o maior chocolatier já visto. Mostrando que as melhores coisas da vida começam com um sonho, o filme mistura magia, música, caos, afeição e muito humor.",
                            "director": "Paul King"
                        }
                    ]
                },
                {
                    "id": 5,
                    "name": "Suspense",
                    "movies": [
                        {
                            "id": 8,
                            "name": "Oppenheimer",
                            "releasedYear": "2023",
                            "description": "Oppenheimer é um filme histórico de drama dirigido por Christopher Nolan e baseado no livro biográfico vencedor do Prêmio Pulitzer, Prometeu Americano: O Triunfo e a Tragédia de J. Robert Oppenheimer, escrito por Kai Bird e Martin J. Sherwin. Ambientado na Segunda Guerra Mundial, o longa acompanha a vida de J. Robert Oppenheimer (Cillian Murphy), físico teórico da Universidade da Califórnia e diretor do Laboratório de Los Alamos durante o Projeto Manhattan - que tinha a missão de projetar e construir as primeiras bombas atômicas. A trama acompanha o físico e um grupo formado por outros cientistas ao longo do processo de desenvolvimento da arma nuclear que foi responsável pelas tragédias nas cidades de Hiroshima e Nagasaki, no Japão, em 1945. Além de Cillian, o elenco também traz nomes como Emily Blunt, Matt Damon, Robert Downey Jr., Florence Pugh, Gary Oldman, Jack Quaid, Gustaf Skarsgård, Rami Malek e Kenneth Branagh.",
                            "director": "Christopher Nolan"
                        }
                    ]
                },
                {
                    "id": 6,
                    "name": "Policial",
                    "movies": [
                        {
                            "id": 9,
                            "name": "O Poderoso Chefão",
                            "releasedYear": "1972",
                            "description": "Don Vito Corleone (Marlon Brando) é o chefe de uma família de Nova York que está feliz, pois Connie (Talia Shire), sua filha, se casou com Carlo (Gianni Russo). Porém, durante a festa, Bonasera (Salvatore Corsitto) é visto no escritório de Don Corleone pedindo justiça, vingança na verdade contra membros de uma quadrilha, que espancaram barbaramente sua filha por ela ter se recusado a fazer sexo para preservar a honra. Vito discute, mas os argumentos de Bonasera o sensibilizam e ele promete que os homens, que maltrataram a filha de Bonasera não serão mortos, pois ela também não foi, mas serão severamente castigados. Vito porém deixa claro que ele pode chamar Bonasera algum dia para devolver o favor. Do lado de fora, no meio da festa, está o terceiro filho de Vito, Michael (Al Pacino), um capitão da marinha muito decorado que há pouco voltou da 2ª Guerra Mundial. Universitário educado, sensível e perceptivo, ele quase não é notado pela maioria dos presentes, com exceção de uma namorada da faculdade, Kay Adams (Diane Keaton), que não tem descendência italiana mas que ele ama. Em contrapartida há alguém que é bem notado, Johnny Fontane (Al Martino), um cantor de baladas românticas que provoca gritos entre as jovens que beiram a histeria. Don Corleone já o tinha ajudado, quando Johnny ainda estava em começo de carreira e estava preso por um contrato com o líder de uma grande banda, mas a carreira de Johnny deslanchou e ele queria fazer uma carreira solo. Por ser seu padrinho Vito foi procurar o líder da banda e ofereceu 10 mil dólares para deixar Johnny sair, mas teve o pedido recusado. Assim, no dia seguinte Vito voltou acompanhado por Luca Brasi (Lenny Montana), um capanga, e após uma hora ele assinou a liberação por apenas mil dólares, mas havia um detalhe: nas negociações Luca colocou uma arma na cabeça do líder da banda. Agora, no meio da alegria da festa, Johnny quer falar algo sério com Vito, pois precisa conseguir o principal papel em um filme para levantar sua carreira, mas o chefe do estúdio, Jack Woltz (John Marley), nem pensa em contratá-lo. Nervoso, Johnny começa a chorar e Vito, irritado, o esbofeteia, mas promete que ele conseguirá o almejado papel. Enquanto a festa continua acontecendo, Don Corleone comunica a Tom Hagen (Robert Duvall), seu filho adotivo que atua como conselheiro, que Carlo terá um emprego mas nada muito importante, e que os negócios não devem ser discutidos na sua frente. Os verdadeiros problemas começam para Vito quando Sollozzo (Al Lettieri), um gângster que tem apoio de uma família rival, encabeçada por Phillip Tattaglia (Victor Rendina) e seu filho Bruno (Tony Giorgio). Sollozzo, em uma reunião com Vito, Sonny e outros, conta para a família que ele pretende estabelecer um grande esquema de vendas de narcóticos em Nova York, mas exige permissão e proteção política de Vito para agir. Don Corleone odeia esta idéia, pois está satisfeito em operar com jogo, mulheres e proteção, mas isto será apenas a ponta do iceberg de uma mortal luta entre as famílias",
                            "director": "Francis Ford Coppola"
                        }
                    ]
                },
                {
                    "id": 7,
                    "name": "Romance",
                    "movies": [
                        {
                            "id": 10,
                            "name": "Cinquenta Tons de Cinza",
                            "releasedYear": "2015",
                            "description": "Em Cinquenta Tons de Cinza, Dakota Johnson vive Anastasia Steele, uma estudante de literatura de 21 anos, romântica e virgem. Um dia, ela precisa entrevistar para o jornal da faculdade o jovem bilionário Christian Grey (Jamie Dornan). Nasce, então, uma complexa relação entre ambos: com a descoberta amorosa e sexual, Anastasia conhece os prazeres do sadomasoquismo, tornando-se o objeto de submissão do sádico Grey.",
                            "director": "Sam Taylor-Johnson"
                        }
                    ]
                },
                {
                    "id": 8,
                    "name": "Ficção",
                    "movies": [
                        {
                            "id": 13,
                            "name": "Interestelar",
                            "releasedYear": "2014",
                            "description": "Após ver a Terra consumindo boa parte de suas reservas naturais, um grupo de astronautas recebe a missão de verificar possíveis planetas para receberem a população mundial, possibilitando a continuação da espécie. Cooper (Matthew McConaughey) é chamado para liderar o grupo e aceita a missão sabendo que pode nunca mais ver os filhos. Ao lado de Brand (Anne Hathaway), Jenkins (Marlon Sanders) e Doyle (Wes Bentley), ele seguirá em busca de uma nova casa. Com o passar dos anos, sua filha Murph (Mackenzie Foy e Jessica Chastain) investirá numa própria jornada para também tentar salvar a população do planeta.",
                            "director": "Christopher Nolan"
                        }
                    ]
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
            id,
            name,
            releasedYear,
            description,
            director,
            cast,
            rating,
            review,
            duration,
            trailer,
            poster,
            countryOfOrigin
            language,
            keywords,
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
                    "releasedYear": "2006",
                    "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                    "director": "Justin Lin",
                    "cast": "",
                    "rating": "16",
                    "review": "4.5",
                    "duration": "1h44min",
                    "trailer": "https://youtu.be/dmeFOEcnTBU?si=I122C0yauHn3uXQb",
                    "poster": "https://br.web.img2.acsta.net/pictures/210/383/21038387_20130909201408304.jpg",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Ação, Policial",
                    "category": {
                        "id": 1,
                        "name": "Ação"
                    }
                },
                {
                    "id": 2,
                    "name": "O Mal que nos Habita",
                    "releasedYear": "2024",
                    "description": "O Mal Que nos Habita é um filme argentino de terror dirigido por Demián Rugna (Aterrorizados, The Last Gateway). A trama se passa em uma pacata cidade do interior, onde dois irmãos encontram um corpo mutilado perto de sua propriedade e se reúnem com os moradores locais para investigarem o ocorrido. Eles acabam descobrindo que o homem encontrado está infectado pelo diabo e está prestes a dar a luz a um demônio real. Desesperados, os habitantes tentam escapar do local antes que o ser maligno venha à terra, mas o tempo parece não estar a seu favor e o caos é instaurado por completo.",
                    "director": "Demián Rugna",
                    "cast": "",
                    "rating": "16",
                    "review": "3.5",
                    "duration": "1h40min",
                    "trailer": "https://youtu.be/DpQVlxLl158?si=EugAh7A-KganY6yf",
                    "poster": "https://maceioshopping.com/app/uploads/2024/01/MV5BNDg1ZjAwM2MtMjk3MS00MzRkLThhNzItOThmMGRmNTc0NjAzXkEyXkFqcGdeQXVyNzAwMjU2MTY@._V1_.jpg",
                    "countryOfOrigin": "Argentina",
                    "language": "Spanish",
                    "keywords": "Terror, Suspense",
                    "category": {
                        "id": 2,
                        "name": "Terror"
                    }
                },
                {
                    "id": 3,
                    "name": "Aquaman 2: O Reino Perdido",
                    "releasedYear": "2023",
                    "description": "Aquaman 2 é a sequência do filme Aquaman de 2018, que acompanha Arthur Curry (Jason Momoa), o filho do humano Tom Curry (Temuera Morrison) com a atlante Atlanna (Nicole Kidman). Ele cresce com a vivência de um humano e as capacidades metahumanas de um atlante. Nesta sequência, depois de não conseguir derrotar o rei dos mares pela primeira vez, Arraia Negra (Yahya Abdul-Mateen II) utiliza o poder do mítico Tridente Negro para liberar uma força antiga e maligna. Na tentativa de proteger Atlântida e o resto do mundo, Aquaman deve forjar uma aliança incômoda com um aliado improvável e deixar as diferenças de lado para evitar uma devastação irreversível.",
                    "director": "James Wan",
                    "cast": "",
                    "rating": "14",
                    "review": "4.0",
                    "duration": "1h55min",
                    "trailer": "https://youtu.be/rPBjB65NV_c?si=ETMerbu1flLw9FdO",
                    "poster": "https://br.web.img2.acsta.net/pictures/23/12/11/14/39/2389191.png",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Action, Sea",
                    "category": {
                        "id": 1,
                        "name": "Ação"
                    }
                },
                {
                    "id": 4,
                    "name": "Turma da Mônica Jovem: Reflexos do Medo",
                    "releasedYear": "2024",
                    "description": "Baseado nos quadrinhos clássicos de Maurício de Sousa, Turma da Mônica Jovem: Reflexos do Medo traz os amigos em uma nova aventura, agora na adolescência. Em uma nova escola e agora no ensino médio, o primeiro dia de aula já reservava uma surpresa: os amigos Mônica (Sophia Valverde), Cebola (Xande Valois), Magali (Bianca Paiva), Cascão (Theo Salomão) e Milena (Carol Roberto) descobrem que o Museu do Limoeiro será leiloado. A turma decide se unir em uma missão para tentar salvá-lo, e enquanto investigam o que está acontecendo, eles não demoram muito para perceber que podem estar lidando com uma ameaça muito maior do que imaginam. Marcando uma nova fase na vida dos amigos que estão juntos desde a infância, agora eles compartilham os medos e as inseguranças que surgem na adolescência em uma trama que mistura aventura e suspense, mas sem perder o jeitinho de sempre.",
                    "director": "Mauricio Eça",
                    "cast": "",
                    "rating": "10",
                    "review": "2.6",
                    "duration": "1h35min",
                    "trailer": "https://youtu.be/SJL9F2oWn5M?si=e4U0ZTqgoDMc6fOY",
                    "poster": "https://br.web.img3.acsta.net/c_310_420/pictures/23/11/17/19/54/0373651.jpg",
                    "countryOfOrigin": "Brazil",
                    "language": "Portuguese",
                    "keywords": "Comedia, Novel",
                    "category": {
                        "id": 3,
                        "name": "Comédia Infantil"
                    }
                },
                {
                    "id": 5,
                    "name": "Deadpool",
                    "releasedYear": "2016",
                    "description": "Ex-militar e mercenário, Wade Wilson (Ryan Reynolds) é diagnosticado com câncer em estado terminal, porém encontra uma possibilidade de cura em uma sinistra experiência científica. Recuperado, com poderes e um incomum senso de humor, ele torna-se Deadpool e busca vingança contra o homem que destruiu sua vida.",
                    "director": "Tim Miller",
                    "cast": "",
                    "rating": "16",
                    "review": "4.5",
                    "duration": "2h11min",
                    "trailer": "https://youtu.be/Q9X-bAE8KTc?si=9hmbOCuHlJuzkWVv",
                    "poster": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSV7yE_lIcaeMfr-S60rCkR8lEzhC57TLUJ6FJSdMNTBA&s",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Action, Adventures",
                    "category": {
                        "id": 3,
                        "name": "Comédia Infantil"
                    }
                },
                {
                    "id": 6,
                    "name": "Mamonas Assassinas - O Filme",
                    "releasedYear": "2023",
                    "description": "Mamonas Assassinas - O Filme acompanha a trajetória de Dinho (Ruy Brissac), Júlio (Robson Lima), Bento (Alberto Hinoto), Sérgio (Rhener Freitas) e Samuel (Adriano Tunes) que, juntos, formaram um dos grupos mais inesperados e inicialmente desacreditados pelo grande público, os Mamonas Assassinas. Provando-se um sucesso estrondoso em um curtíssimo espaço de tempo, o quinteto precisou de muitas tentativas frustradas para conseguir mostrar que podia ser a próxima grande banda do Brasil.",
                    "director": "Edson Spinello",
                    "cast": "",
                    "rating": "12",
                    "review": "3.5",
                    "duration": "1h44min",
                    "trailer": "https://youtu.be/--l0YXLEZqY?si=It1p4d_IDpgHiRjj",
                    "poster": "https://br.web.img3.acsta.net/pictures/23/11/21/20/36/2271496.png",
                    "countryOfOrigin": "Brazil",
                    "language": "Portuguese",
                    "keywords": "Comedia, Bibliografia",
                    "category": {
                        "id": 3,
                        "name": "Comédia Infantil"
                    }
                },
                {
                    "id": 7,
                    "name": "Wonka",
                    "releasedYear": "2023",
                    "description": "Wonka é uma comédia musical baseada no clássico livro A Fantástica Fábrica de Chocolate, do autor britânico Roald Dahl. O filme mostra as origens da história do jovem Willy Wonka (interpretado por Timothée Chalamet), que apareceu nos cinemas pela primeira vez na produção de 1971 e, mais tarde, ganhou um remake estrelado por Johnny Depp em 2005. Antes de se tornar a mente brilhante por trás da maior fábrica de chocolate do mundo, Willy precisou enfrentar vários obstáculos. Cheio de ideias e determinado a mudar o mundo, o jovem Wonka embarca em uma aventura para espalhar alegria através de seu delecioso chocolate. Nela, ele acabou conhecendo o seu fiel e icônico assistente, Oompa Loompa (interpretado por Hugh Grant), que o ajudar a ir contra todas as probabilidades para se tornar o maior chocolatier já visto. Mostrando que as melhores coisas da vida começam com um sonho, o filme mistura magia, música, caos, afeição e muito humor.",
                    "director": "Paul King",
                    "cast": "",
                    "rating": "10",
                    "review": "4.0",
                    "duration": "1h33min",
                    "trailer": "https://youtu.be/8Hpz6B4FODM?si=xNJDd3AxHOCohmTG",
                    "poster": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgrpJHgvWORNyT1jkveQT7icVu9yMOKy3xsj9qnF-DOg&s",
                    "countryOfOrigin": "United Kingdom",
                    "language": "English",
                    "keywords": "Comedy, Musical",
                    "category": {
                        "id": 4,
                        "name": "Fantasia"
                    }
                },
                {
                    "id": 8,
                    "name": "Oppenheimer",
                    "releasedYear": "2023",
                    "description": "Oppenheimer é um filme histórico de drama dirigido por Christopher Nolan e baseado no livro biográfico vencedor do Prêmio Pulitzer, Prometeu Americano: O Triunfo e a Tragédia de J. Robert Oppenheimer, escrito por Kai Bird e Martin J. Sherwin. Ambientado na Segunda Guerra Mundial, o longa acompanha a vida de J. Robert Oppenheimer (Cillian Murphy), físico teórico da Universidade da Califórnia e diretor do Laboratório de Los Alamos durante o Projeto Manhattan - que tinha a missão de projetar e construir as primeiras bombas atômicas. A trama acompanha o físico e um grupo formado por outros cientistas ao longo do processo de desenvolvimento da arma nuclear que foi responsável pelas tragédias nas cidades de Hiroshima e Nagasaki, no Japão, em 1945. Além de Cillian, o elenco também traz nomes como Emily Blunt, Matt Damon, Robert Downey Jr., Florence Pugh, Gary Oldman, Jack Quaid, Gustaf Skarsgård, Rami Malek e Kenneth Branagh.",
                    "director": "Christopher Nolan",
                    "cast": "",
                    "rating": "16",
                    "review": "4.5",
                    "duration": "3h01min",
                    "trailer": "https://youtu.be/F3OxA9Cz17A?si=dC-IQQFoP5DdCmYb",
                    "poster": "https://br.web.img2.acsta.net/pictures/23/05/08/10/29/0695770.jpg",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Biopic, Histórico, Suspense",
                    "category": {
                        "id": 5,
                        "name": "Suspense"
                    }
                },
                {
                    "id": 9,
                    "name": "O Poderoso Chefão",
                    "releasedYear": "1972",
                    "description": "Don Vito Corleone (Marlon Brando) é o chefe de uma família de Nova York que está feliz, pois Connie (Talia Shire), sua filha, se casou com Carlo (Gianni Russo). Porém, durante a festa, Bonasera (Salvatore Corsitto) é visto no escritório de Don Corleone pedindo justiça, vingança na verdade contra membros de uma quadrilha, que espancaram barbaramente sua filha por ela ter se recusado a fazer sexo para preservar a honra. Vito discute, mas os argumentos de Bonasera o sensibilizam e ele promete que os homens, que maltrataram a filha de Bonasera não serão mortos, pois ela também não foi, mas serão severamente castigados. Vito porém deixa claro que ele pode chamar Bonasera algum dia para devolver o favor. Do lado de fora, no meio da festa, está o terceiro filho de Vito, Michael (Al Pacino), um capitão da marinha muito decorado que há pouco voltou da 2ª Guerra Mundial. Universitário educado, sensível e perceptivo, ele quase não é notado pela maioria dos presentes, com exceção de uma namorada da faculdade, Kay Adams (Diane Keaton), que não tem descendência italiana mas que ele ama. Em contrapartida há alguém que é bem notado, Johnny Fontane (Al Martino), um cantor de baladas românticas que provoca gritos entre as jovens que beiram a histeria. Don Corleone já o tinha ajudado, quando Johnny ainda estava em começo de carreira e estava preso por um contrato com o líder de uma grande banda, mas a carreira de Johnny deslanchou e ele queria fazer uma carreira solo. Por ser seu padrinho Vito foi procurar o líder da banda e ofereceu 10 mil dólares para deixar Johnny sair, mas teve o pedido recusado. Assim, no dia seguinte Vito voltou acompanhado por Luca Brasi (Lenny Montana), um capanga, e após uma hora ele assinou a liberação por apenas mil dólares, mas havia um detalhe: nas negociações Luca colocou uma arma na cabeça do líder da banda. Agora, no meio da alegria da festa, Johnny quer falar algo sério com Vito, pois precisa conseguir o principal papel em um filme para levantar sua carreira, mas o chefe do estúdio, Jack Woltz (John Marley), nem pensa em contratá-lo. Nervoso, Johnny começa a chorar e Vito, irritado, o esbofeteia, mas promete que ele conseguirá o almejado papel. Enquanto a festa continua acontecendo, Don Corleone comunica a Tom Hagen (Robert Duvall), seu filho adotivo que atua como conselheiro, que Carlo terá um emprego mas nada muito importante, e que os negócios não devem ser discutidos na sua frente. Os verdadeiros problemas começam para Vito quando Sollozzo (Al Lettieri), um gângster que tem apoio de uma família rival, encabeçada por Phillip Tattaglia (Victor Rendina) e seu filho Bruno (Tony Giorgio). Sollozzo, em uma reunião com Vito, Sonny e outros, conta para a família que ele pretende estabelecer um grande esquema de vendas de narcóticos em Nova York, mas exige permissão e proteção política de Vito para agir. Don Corleone odeia esta idéia, pois está satisfeito em operar com jogo, mulheres e proteção, mas isto será apenas a ponta do iceberg de uma mortal luta entre as famílias",
                    "director": "Francis Ford Coppola",
                    "cast": "",
                    "rating": "16",
                    "review": "4.8",
                    "duration": "3h25min",
                    "trailer": "https://youtu.be/SaHZHU-44XA?si=MPIF0TxMkG-1-GXN",
                    "poster": "https://br.web.img3.acsta.net/medias/nmedia/18/90/93/20/20120876.jpg",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Ação, Mafia",
                    "category": {
                        "id": 6,
                        "name": "Policial"
                    }
                },
                {
                    "id": 10,
                    "name": "Cinquenta Tons de Cinza",
                    "releasedYear": "2015",
                    "description": "Em Cinquenta Tons de Cinza, Dakota Johnson vive Anastasia Steele, uma estudante de literatura de 21 anos, romântica e virgem. Um dia, ela precisa entrevistar para o jornal da faculdade o jovem bilionário Christian Grey (Jamie Dornan). Nasce, então, uma complexa relação entre ambos: com a descoberta amorosa e sexual, Anastasia conhece os prazeres do sadomasoquismo, tornando-se o objeto de submissão do sádico Grey.",
                    "director": "Sam Taylor-Johnson",
                    "cast": "",
                    "rating": "18",
                    "review": "3.2",
                    "duration": "1h44min",
                    "trailer": "https://youtu.be/DEwIt4amgq4?si=3xmyMd_CE78tz9CF",
                    "poster": "https://br.web.img2.acsta.net/pictures/14/11/14/13/47/211678.jpg",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Sexy, Romance",
                    "category": {
                        "id": 7,
                        "name": "Romance"
                    }
                },
                {
                    "id": 12,
                    "name": "Malcolm X",
                    "releasedYear": "1993",
                    "description": "Biografia do famoso líder afro-americano (Denzel Washington) que teve o pai, um pastor, assassinado pela Klu Klux Klan e sua mãe internada por insanidade. Ele foi um malandro de rua e enquanto esteve preso descobriu o islamismo. Malcolm faz sua conversão religiosa como um discípulo messiânico de Elijah Mohammed (Al Freeman Jr.). Ele se torna um fervoroso orador do movimento e se casa com Betty Shabazz (Angela Bassett). Malcolm X ora uma doutrina de ódio contra o homem branco até que, anos mais tarde, quando fez uma peregrinação à Meca abranda suas convicções. Foi nesta época que se converteu ao original islamismo e se tornou um Sunni Muslim, mudando o nome para El-Hajj Malik Al-Shabazz, mas o esforço de quebrar o rígido dogma da Nação Islã teve trágicos resultados.",
                    "director": "Spike Lee",
                    "cast": "",
                    "rating": "14",
                    "review": "4.0",
                    "duration": "3h21min",
                    "trailer": "https://youtu.be/sx4sEvhYeVE?si=0Jo025rKEqEah6aV",
                    "poster": "https://m.media-amazon.com/images/M/MV5BZDkzOTFmMTUtMmI2OS00MDE4LTg5YTUtODMwNDMzNmI5OGYwL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Ação, Bibliogragia",
                    "category": {
                        "id": 1,
                        "name": "Ação"
                    }
                },
                {
                    "id": 13,
                    "name": "Interestelar",
                    "releasedYear": "2014",
                    "description": "Após ver a Terra consumindo boa parte de suas reservas naturais, um grupo de astronautas recebe a missão de verificar possíveis planetas para receberem a população mundial, possibilitando a continuação da espécie. Cooper (Matthew McConaughey) é chamado para liderar o grupo e aceita a missão sabendo que pode nunca mais ver os filhos. Ao lado de Brand (Anne Hathaway), Jenkins (Marlon Sanders) e Doyle (Wes Bentley), ele seguirá em busca de uma nova casa. Com o passar dos anos, sua filha Murph (Mackenzie Foy e Jessica Chastain) investirá numa própria jornada para também tentar salvar a população do planeta.",
                    "director": "Christopher Nolan",
                    "cast": "Matthew McConaughey, Anne Hathaway, Michael Caine",
                    "rating": "14",
                    "review": "4.6",
                    "duration": "2h49min",
                    "trailer": "https://youtu.be/hHBsKHVLAYc?si=6XsHPgXEEEcHfjJ_",
                    "poster": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQmyAQu2hcbYkaBGOpDuU17xTTGILMFl4m0VfdMXI-sQ&s",
                    "countryOfOrigin": "United States of America",
                    "language": "English",
                    "keywords": "Ação, Science, Fiction",
                    "category": {
                        "id": 8,
                        "name": "Ficção"
                    }
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
            name,
            movies {
                id,
                name,
                releasedYear,
                description,
                director
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
                "name": "Ação",
                "movies": [
                    {
                        "id": 1,
                        "name": "Velozes & Furiosos: Desafio em Tóquio.",
                        "releasedYear": "2006",
                        "description": "O filme destaca a cultura automotiva japonesa e é conhecido por suas cenas de corrida espetaculares e efeitos visuais impressionantes.",
                        "director": "Justin Lin"
                    },
                    {
                        "id": 3,
                        "name": "Aquaman 2: O Reino Perdido",
                        "releasedYear": "2023",
                        "description": "Aquaman 2 é a sequência do filme Aquaman de 2018, que acompanha Arthur Curry (Jason Momoa), o filho do humano Tom Curry (Temuera Morrison) com a atlante Atlanna (Nicole Kidman). Ele cresce com a vivência de um humano e as capacidades metahumanas de um atlante. Nesta sequência, depois de não conseguir derrotar o rei dos mares pela primeira vez, Arraia Negra (Yahya Abdul-Mateen II) utiliza o poder do mítico Tridente Negro para liberar uma força antiga e maligna. Na tentativa de proteger Atlântida e o resto do mundo, Aquaman deve forjar uma aliança incômoda com um aliado improvável e deixar as diferenças de lado para evitar uma devastação irreversível.",
                        "director": "James Wan"
                    },
                    {
                        "id": 12,
                        "name": "Malcolm X",
                        "releasedYear": "1993",
                        "description": "Biografia do famoso líder afro-americano (Denzel Washington) que teve o pai, um pastor, assassinado pela Klu Klux Klan e sua mãe internada por insanidade. Ele foi um malandro de rua e enquanto esteve preso descobriu o islamismo. Malcolm faz sua conversão religiosa como um discípulo messiânico de Elijah Mohammed (Al Freeman Jr.). Ele se torna um fervoroso orador do movimento e se casa com Betty Shabazz (Angela Bassett). Malcolm X ora uma doutrina de ódio contra o homem branco até que, anos mais tarde, quando fez uma peregrinação à Meca abranda suas convicções. Foi nesta época que se converteu ao original islamismo e se tornou um Sunni Muslim, mudando o nome para El-Hajj Malik Al-Shabazz, mas o esforço de quebrar o rígido dogma da Nação Islã teve trágicos resultados.",
                        "director": "Spike Lee"
                    }
                ]
            }
        }
    }
}
```

### 2. GetById de Movie: 
#### POST - GetById Movie: /graphql

##### Payload:
```
query {
    movieQuery {
        movie(id: 13) {
            id,
            name,
            releasedYear,
            description,
            director,
            cast,
            rating,
            review,
            duration,
            trailer,
            poster,
            countryOfOrigin
            language,
            keywords,
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
            "movie": {
                "id": 13,
                "name": "Interestelar",
                "releasedYear": "2014",
                "description": "Após ver a Terra consumindo boa parte de suas reservas naturais, um grupo de astronautas recebe a missão de verificar possíveis planetas para receberem a população mundial, possibilitando a continuação da espécie. Cooper (Matthew McConaughey) é chamado para liderar o grupo e aceita a missão sabendo que pode nunca mais ver os filhos. Ao lado de Brand (Anne Hathaway), Jenkins (Marlon Sanders) e Doyle (Wes Bentley), ele seguirá em busca de uma nova casa. Com o passar dos anos, sua filha Murph (Mackenzie Foy e Jessica Chastain) investirá numa própria jornada para também tentar salvar a população do planeta.",
                "director": "Christopher Nolan",
                "cast": "Matthew McConaughey, Anne Hathaway, Michael Caine",
                "rating": "14",
                "review": "4.6",
                "duration": "2h49min",
                "trailer": "https://youtu.be/hHBsKHVLAYc?si=6XsHPgXEEEcHfjJ_",
                "poster": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQmyAQu2hcbYkaBGOpDuU17xTTGILMFl4m0VfdMXI-sQ&s",
                "countryOfOrigin": "United States of America",
                "language": "English",
                "keywords": "Ação, Science, Fiction",
                "category": {
                    "id": 8,
                    "name": "Ficção"
                }
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
