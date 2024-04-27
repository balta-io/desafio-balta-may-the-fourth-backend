<hr>
<div align=center>
    <a href="https://balta.io/">
        <img src="https://baltaio.blob.core.windows.net/static/images/dark/balta-logo.svg" width="250"/>
        <hr>
    </a>
</div>

<div align=center>
    <img src="https://github.com/balta-io/desafio-balta-may-the-fourth-backend/assets/965305/880fab7e-3998-4a0d-98ad-1d6ffc11298b"/>
    <hr>
</div>

1. <a href="#desafio">Desafio</a><br>
2. <a href="#participantes">Participantes</a><br>
3. <a href="#tecnologias">Tecnologias</a><br>
4. <a href="#arquitetura">Arquiteturas e Infraestrutura</a><br>
5. <a href="#skills">Skills Desenvolvidas</a><br>
6. <a href="#testes">Como testar o projeto</a><br>
7. <a href="#endpoints">Endpoints</a><br>
8. <a href="#participe">Participe</a><br>

---

<section id="desafio"> </section>

## 🎖️ Desafio
**May the Fourth** é um projeto desenvolvido como parte dos **Desafios .NET**, uma iniciativa realizada pela plataforma [balta.io](https://balta.io). Nesta edição, integrantes do "Batalhão backend" se uniram para criar uma API em homenagem ao universo de Star Wars, em celebração ao Dia de Star Wars (May the 4th).

## 📱 Projeto

Esta API proporciona uma plataforma para consulta, cadastro, remoção e atualização de dados relacionados ao vasto universo de Star Wars. Os dados disponíveis incluem informações sobre Filmes, Personagens, Naves, Veículos, Planetas e Espécies, permitindo aos desenvolvedores explorar e interagir com diversos aspectos do universo fictício de Star Wars.

<section id="participantes"> </section>

## 💂‍Participantes

**Capitão:** Igor Santiago \
<img src="https://avatars.githubusercontent.com/u/99906642?v=4" width="150"/>
<div style="display: inline_block;">
    <a href="https://www.linkedin.com/in/igorsantiago" target="_blank"><img src="https://skillicons.dev/icons?i=linkedin"></a> 
    <a href="https://github.com/igorsantiiago" target="_blank"><img src="https://skillicons.dev/icons?i=github"></a> 
</div>
<br>

**Soldado:** Eduardo Freitas \
<img src="https://avatars.githubusercontent.com/u/13337819?v=4" width="150"/>
<div style="display: inline_block;">
    <a href="https://www.linkedin.com/in/eduardo-freitas-ehff/" target="_blank"><img src="https://skillicons.dev/icons?i=linkedin"></a> 
    <a href="https://github.com/eduardoboca" target="_blank"><img src="https://skillicons.dev/icons?i=github"></a> 
</div>
<br>

**Soldado:** Erik Coelho \
<img src="https://avatars.githubusercontent.com/u/79767115?v=4" width="150"/>
<div style="display: inline_block;">
    <a href="https://www.linkedin.com/in/erik-coelho-56121318b/" target="_blank"><img src="https://skillicons.dev/icons?i=linkedin"></a> 
    <a href="https://github.com/ErikCoelho" target="_blank"><img src="https://skillicons.dev/icons?i=github"></a> 
</div>
<br>

**Soldado:**  Everson Rezende \
<img src="https://avatars.githubusercontent.com/u/61418106?v=4" width="150"/>
<div style="display: inline_block;">
    <a href="https://www.linkedin.com/in/eversonrezende/" target="_blank"><img src="https://skillicons.dev/icons?i=linkedin"></a> 
    <a href="https://github.com/eversonrezende" target="_blank"><img src="https://skillicons.dev/icons?i=github"></a> 
</div>
<br>

**Soldado:** Lucas Mikó \
<img src="https://avatars.githubusercontent.com/u/63825231?v=4" width="150"/>
<div style="display: inline_block;">
    <a href="https://www.linkedin.com/in/lucasmiko/" target="_blank"><img src="https://skillicons.dev/icons?i=linkedin"></a> 
    <a href="https://github.com/lucasmiko" target="_blank"><img src="https://skillicons.dev/icons?i=github"></a> 
</div>

<section id="tecnologias"> </section>

## ⚙️ Tecnologias
* C# 12
* .NET 8
* ASP.NET
* Azure

<section id="arquitetura"> </section>

## 📌 Arquitetura e Infraestrutura
* Minimal APIs
* Clean Architecture
* Repository Pattern
* Mediator Pattern

### **Módulos**
Adotamos a estratégia de dividir o sistema em módulos independentes, cada um com uma função específica e claramente definida, seguindo os princípios da Clean Architecture. Essa abordagem promove clareza do código e facilita a expansão e a evolução da aplicação ao longo do tempo, garantindo que cada parte do sistema mantenha sua responsabilidade definida.
- **MayTheFourth.Core**\
Seguindo os princípios da Clean Architecture, o Core contém a lógica de negócios e as entidades principais da aplicação. Aqui são definidos os modelos de dados, serviços e operações essenciais para o funcionamento da API, mantendo-se independente de detalhes de implementação externos.
- **MayTheFourth.Infra**\
Responsável por fornecer implementações concretas de acesso ao banco de dados, seguindo o padrão Repository Pattern. 
Este módulo fornece implementações das interfaces de serviços criadas no Core, assim, possibilitando a interação com o banco de dados de forma desacoplada, promovendo a separação de responsabilidades e facilitando a substituição de tecnologias de armazenamento de dados.
- **MayTheFourth.Api**\
Responsável por expor os endpoints da API e gerenciar as requisições HTTP dos clientes. Atua como a interface externa da aplicação,seguindo o padrão de arquitetura de API Restful.
- **MayTheFourth.Tests**\
Conjunto de testes unitários

<section id="skills"> </section>

## 🥋 Skills Desenvolvidas
* Comunicação
* Trabalho em Equipe
* Networking
* Resolução de problemas
* Conhecimento técnico

<section id="testes"> </section>

## 🧪 Como testar o projeto
Para rodar o projeto de forma local, primeiro sera necessário subir um banco de dados. Para subir um banco da forma mais fácil, iremos precisar utilizar o Docker, que é uma ferramenta para conteinirização.
- Baixar o docker
```
https://www.docker.com/products/docker-desktop/
```

Com o Docker baixando, vamos criar um container do SqlServer. No seu terminal, insira o seguinte comando:
```bash
docker pull mcr.microsoft.com/mssql/server
```

Agora precisaremos executar o sqlserver com o docker.

#### WSL2
```bash
docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```

#### Mac M1
```bash
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sqlserver mcr.microsoft.com/azure-sql-edge
```


Além do Docker com SqlServer, precisaremos também instalar o CLI do EF utlizando o seguinte comando no terminal:
```
dotnet tool install — global dotnet-ef
```

Agora, com o container e o CLI do EF prontos, vamos gerar os migrations atualizados do banco de dados e inicializar o projetto
```
dotnet ef migrations add GitHubMigrattion
```
```
dotnet ef database update
```
```
dotnet watch run
```

Agora que estamos com a API rodando, podemos fazer requisições necessárias utilizando um headless browser como o Postman e os Endpoints descritos no próximo tópico.

<br>

<section id="endpoints"> </section>

## 🎯 Endpoints

### 🎬 Film
#### 🟢 SearchAll  - Responsavel por listar todos os filmes
```
https://localhost:7288/api/v1/film
```

**Response**
```json
{
    "data": {
        "films": [
            {
                "id": "745f8223-d2b4-4993-9244-046d21a8749c",
                "title": "The Force Awakens",
                "slug": "the-force-awakens",
                "director": "J. J. Abrams",
                "releaseDate": "2015-12-11T00:00:00"
            },
            ...
            {
                "id": "8e5603df-b22a-449d-8810-a67cff57edd5",
                "title": "The Empire Strikes Back",
                "slug": "the-empire-strikes-back",
                "director": "Irvin Kershner",
                "releaseDate": "1980-05-17T00:00:00"
            }
        ],
        "totalRecords": 7
    },
    "message": "Lista de filmes encontrada",
    "status": 200,
    "isSuccess": true
}
```
#### 🟢 SearchById or SearchBySlug - Responsavel por listar um filme específico
```
https://localhost:7288/api/v1/film/{ID_FILM}
https://localhost:7288/api/v1/film/slug/{SLUG_FILM}
```

**Response**
```json
"data": {
        "filmDetails": {
            "id": "745f8223-d2b4-4993-9244-046d21a8749c",
            "title": "The Force Awakens",
            "slug": "the-force-awakens",
            "episodeId": 7,
            "openingCrawl": "Luke Skywalker has vanished.\r\nIn his absence, the sinister\r\nFIRST ORDER has risen from\r\nthe ashes of the Empire\r\nand will not rest until\r\nSkywalker, the last Jedi,\r\nhas been destroyed.\r\n \r\nWith the support of the\r\nREPUBLIC, General Leia Organa\r\nleads a brave RESISTANCE.\r\nShe is desperate to find her\r\nbrother Luke and gain his\r\nhelp in restoring peace and\r\njustice to the galaxy.\r\n \r\nLeia has sent her most daring\r\npilot on a secret mission\r\nto Jakku, where an old ally\r\nhas discovered a clue to\r\nLuke's whereabouts....",
            "director": "J. J. Abrams",
            "producer": "Kathleen Kennedy, J. J. Abrams, Bryan Burk",
            "releaseDate": "2015-12-11T00:00:00",
            "created": "2015-04-17T06:51:30.503",
            "edited": "2015-12-17T14:31:47.617",
            "speciesList": [
                {
                    "id": "fde47de1-e141-414b-8b90-9c571489c48c",
                    "name": "Human",
                    "slug": "human",
                    "classification": "mammal",
                    "designation": "sentient",
                    "language": "Galactic Basic"
                },
                ...
            ],
            "starships": [
                {
                    "id": "859f4e7b-efbe-4d10-9130-18c6a7203a8a",
                    "name": "X-wing",
                    "slug": "x-wing",
                    "model": "T-70 X-wing",
                    "manufacturer": "Incom Corporation"
                },
                ...
            ],
            "vehicles": [],
            "characters": [
                {
                    "id": "53d5e65c-d583-42a1-bbb0-1380163cdceb",
                    "name": "Captain Phasma",
                    "slug": "captain-phasma",
                    "birthYear": "unknown",
                    "gender": "female",
                    "homeworldId": "1862ac9e-89b7-432f-86e7-1651748215b9"
                },
                ...
            ],
            "planets": [
                {
                    "id": "d94fb3d2-2b28-4eb0-bafa-c50fa4efc2e0",
                    "name": "Jakku",
                    "slug": "jakku",
                    "gravity": "unknown",
                    "population": 0,
                    "climate": "unknown"
                }
            ]
        }
    },
    "message": "Filme encontrado com sucesso.",
    "status": 200,
    "isSuccess": true
}
```

### 🧔Person
#### 🟢 SearchAll - Responsável por listar todos os personagens
```
https://localhost:7288/api/v1/people
```

**Response**

```json
{
    "data": {
        "people": [
            {
                "id": "f7edce7b-a267-467c-870d-020585dcd09c",
                "name": "Shmi Skywalker",
                "slug": "shmi-skywalker",
                "birthYear": "72BBY",
                "gender": "female",
                "homeworldId": "a17f9b44-b872-42b3-975a-477bba1f634e"
            },
            ...
            {
                "id": "1fddf440-6960-48c2-b50d-fa3e5fabf96d",
                "name": "Ackbar",
                "slug": "ackbar",
                "birthYear": "41BBY",
                "gender": "male",
                "homeworldId": "aedbf9f4-1e05-42aa-b2ef-ff7496f8f738"
            }
        ]
    },
    "message": "Lista de personagens encontrada",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢 SearchById or SearchBySlug - Responsável por buscar um personagem específico
```
https://localhost:7288/api/v1/people/{ID_PEOPLE}
https://localhost:7288/api/v1/people/slug/{SLUG_PEOPLE}
```
**Response**

```json
{
    "data": {
        "personDetails": {
            "id": "f92db2f2-4c0a-43c6-9f6a-16e2567c9d9d",
            "name": "Yoda",
            "slug": "yoda",
            "birthYear": "896BBY",
            "eyeColor": "brown",
            "gender": "male",
            "hairColor": "white",
            "height": 66,
            "mass": "17",
            "skinColor": "green",
            "created": "2014-12-15T12:26:01.043",
            "edited": "2014-12-20T21:17:50.347",
            "homeworld": null,
            "homeworldId": "1862ac9e-89b7-432f-86e7-1651748215b9",
            "films": [
                {
                    "id": "90c6bb7c-848a-4396-b139-19dab5a6ee08",
                    "title": "Revenge of the Sith",
                    "slug": "revenge-of-the-sith",
                    "director": "George Lucas",
                    "releaseDate": "2005-05-19T00:00:00"
                },
                ...
                {
                    "id": "8e5603df-b22a-449d-8810-a67cff57edd5",
                    "title": "The Empire Strikes Back",
                    "slug": "the-empire-strikes-back",
                    "director": "Irvin Kershner",
                    "releaseDate": "1980-05-17T00:00:00"
                }
            ],
            "species": [
                {
                    "id": "30382a49-a538-4caa-b83f-daa245755e86",
                    "name": "Yoda's species",
                    "slug": "yoda's-species",
                    "classification": "mammal",
                    "designation": "sentient",
                    "language": "Galactic basic"
                }
            ],
            "starships": [],
            "vehicles": []
        }
    },
    "message": "Personagem encontrado com sucesso.",
    "status": 200,
    "isSuccess": true
}
```

### 🌍 Planet
#### 🟢SearchAll - Responsável por listar todos os planetas
```
https://localhost:7288/api/v1/planets
```

**Response**
```json
{
    "data": {
        "planetList": [
            {
                "id": "28b1b0c5-5adf-4de1-a3b1-02b992dd129b",
                "name": "Serenno",
                "slug": "serenno",
                "gravity": "unknown",
                "population": 0,
                "climate": "unknown"
            },
            ...
            {
                "id": "aedbf9f4-1e05-42aa-b2ef-ff7496f8f738",
                "name": "Mon Cala",
                "slug": "mon-cala",
                "gravity": "1",
                "population": 0,
                "climate": "temperate"
            }
        ]
    },
    "message": "Uma lista de planetas foi encontrado.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢SearchById ou SearchBySlug - Responsável por buscar um planeta específico
```
https://localhost:7288/api/v1/planets/{ID_PLANET}
https://localhost:7288/api/v1/planets/slug/{SLUG_PLANET}
```

**Response**
```json
{
    "data": {
        "planetDetails": {
            "id": "e89b78c7-4a59-4c23-bc9c-e4d8e1c53395",
            "name": "Alderaan",
            "slug": "alderaan",
            "diameter": 12500,
            "rotationPeriod": 24,
            "orbitalPeriod": 364,
            "gravity": "1 standard",
            "population": 364,
            "climate": "temperate",
            "terrain": "grasslands, mountains",
            "surfaceWater": "40",
            "created": "2014-12-10T11:35:48.48",
            "edited": "2014-12-20T20:58:18.42",
            "residents": [
                {
                    "id": "22ea3a14-ca57-4bd6-b999-1ed97155a3fb",
                    "name": "Raymus Antilles",
                    "slug": "raymus-antilles",
                    "birthYear": "unknown",
                    "gender": "male",
                    "homeworldId": "e89b78c7-4a59-4c23-bc9c-e4d8e1c53395"
                },
                ...
                {
                    "id": "0d971961-8fe1-4514-a7e0-c9fb99480c9f",
                    "name": "Bail Prestor Organa",
                    "slug": "bail-prestor-organa",
                    "birthYear": "67BBY",
                    "gender": "male",
                    "homeworldId": "e89b78c7-4a59-4c23-bc9c-e4d8e1c53395"
                }
            ],
            "films": [
                {
                    "id": "90c6bb7c-848a-4396-b139-19dab5a6ee08",
                    "title": "Revenge of the Sith",
                    "slug": "revenge-of-the-sith",
                    "director": "George Lucas",
                    "releaseDate": "2005-05-19T00:00:00"
                },
                ...
            ]
        }
    },
    "message": "Planeta encontrado com sucesso.",
    "status": 200,
    "isSuccess": true
}
```

### 👽 Species

#### 🟢SearchAll - Responsável por listar todas as espécies

```
https://localhost:7288/api/v1/species
```

**Response**
```json
{
    "data": {
        "speciesList": [
            {
                "id": "52bb822b-6ce1-43a8-9f2f-001c7cb16444",
                "name": "Kel Dor",
                "slug": "kel-dor",
                "classification": "unknown",
                "designation": "sentient",
                "language": "Kel Dor"
            },
            ...
            {
                "id": "943c8b74-1d93-4818-a231-f1dfa0251279",
                "name": "Droid",
                "slug": "droid",
                "classification": "artificial",
                "designation": "sentient",
                "language": "n/a"
            }
        ]
    },
    "message": "Lista de espécies encontrada.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢SearchById ou SearchBySlug - Responsável por buscar uma espécies específica

```
https://localhost:7288/api/v1/{ID_SPECIES}
https://localhost:7288/api/v1/slug/{SLUG_SPECIES}
```

**Response**
```json
{
    "data": {
        "species": {
            "id": "943c8b74-1d93-4818-a231-f1dfa0251279",
            "name": "Droid",
            "slug": "droid",
            "classification": "artificial",
            "designation": "sentient",
            "averageHeight": 0,
            "averageLifespan": 0,
            "eyeColors": "n/a",
            "hairColors": "n/a",
            "skinColors": "n/a",
            "language": "n/a",
            "created": "2014-12-10T15:16:16.26",
            "edited": "2014-12-20T21:36:42.14",
            "homeworld": null,
            "homeworldId": null,
            "people": [
                {
                    "id": "94bc23c3-f0b1-45b1-a15b-3814b84cea4f",
                    "name": "BB8",
                    "slug": "bb8",
                    "birthYear": "unknown",
                    "gender": "none",
                    "homeworldId": "1862ac9e-89b7-432f-86e7-1651748215b9"
                },
                ...
                {
                    "id": "2ab3ca5e-6f59-4e91-b400-d21832ffc5c2",
                    "name": "C-3PO",
                    "slug": "c-3po",
                    "birthYear": "112BBY",
                    "gender": "n/a",
                    "homeworldId": "a17f9b44-b872-42b3-975a-477bba1f634e"
                }
            ],
            "films": [
                {
                    "id": "745f8223-d2b4-4993-9244-046d21a8749c",
                    "title": "The Force Awakens",
                    "slug": "the-force-awakens",
                    "director": "J. J. Abrams",
                    "releaseDate": "2015-12-11T00:00:00"
                },
                ...
                {
                    "id": "8e5603df-b22a-449d-8810-a67cff57edd5",
                    "title": "The Empire Strikes Back",
                    "slug": "the-empire-strikes-back",
                    "director": "Irvin Kershner",
                    "releaseDate": "1980-05-17T00:00:00"
                }
            ]
        }
    },
    "message": "Espécie encontrada com sucesso.",
    "status": 200,
    "isSuccess": true
}
```

### 🚀 Starship
#### 🟢SearchAll - Responsável por listar todos as naves

```
https://localhost:7288/api/v1/starships
```

**Response**
```json
{
    "data": {
        "starshipList": [
            {
                "id": "aaf03230-fdf0-464e-911b-060d684d9560",
                "name": "Rebel transport",
                "slug": "rebel-transport",
                "model": "GR-75 medium transport",
                "manufacturer": "Gallofree Yards, Inc."
            },
            ...
            {
                "id": "05cb6071-2791-408c-923e-ff9a360998fc",
                "name": "Sentinel-class landing craft",
                "slug": "sentinel-class-landing-craft",
                "model": "Sentinel-class landing craft",
                "manufacturer": "Sienar Fleet Systems, Cyngus Spaceworks"
            }
        ]
    },
    "message": "Lista de naves encontrada.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢SearchById ou SearchBySlug- Responsável por buscar uma nave específica

```
https://localhost:7288/api/v1/starships/{ID_STARSHIP}
https://localhost:7288/api/v1/starships/slug/{SLUG_STARSHIP}
```

**Response**
```json
{
    "data": {
        "starshipDetails": {
            "id": "9e139ee1-e939-426b-894d-78018dee1e8f",
            "name": "Millennium Falcon",
            "slug": "millennium-falcon",
            "model": "YT-1300 light freighter",
            "starshipClass": "Light freighter",
            "manufacturer": "Corellian Engineering Corporation",
            "costInCredits": 100000,
            "length": 3437,
            "crew": 4,
            "passengers": 6,
            "maxAtmospheringSpeed": 1050,
            "hyperdriveRating": "0.5",
            "mglt": "75",
            "cargoCapacity": 100000,
            "consumables": "2 months",
            "created": "2014-12-10T16:59:45.093",
            "edited": "2014-12-20T21:23:49.88",
            "films": [
                {
                    "id": "745f8223-d2b4-4993-9244-046d21a8749c",
                    "title": "The Force Awakens",
                    "slug": "the-force-awakens",
                    "director": "J. J. Abrams",
                    "releaseDate": "2015-12-11T00:00:00"
                },
                ...
                {
                    "id": "8e5603df-b22a-449d-8810-a67cff57edd5",
                    "title": "The Empire Strikes Back",
                    "slug": "the-empire-strikes-back",
                    "director": "Irvin Kershner",
                    "releaseDate": "1980-05-17T00:00:00"
                }
            ],
            "pilots": [
                {
                    "id": "3f5a28ac-7f8a-4d14-930e-1d6e89b0af02",
                    "name": "Chewbacca",
                    "slug": "chewbacca",
                    "birthYear": "200BBY",
                    "gender": "male",
                    "homeworldId": "bbea8e8a-a13b-46b9-a6bc-be2067ab2771"
                },
                ...
                {
                    "id": "e35fe588-66f9-45f6-9a66-788d04418b82",
                    "name": "Han Solo",
                    "slug": "han-solo",
                    "birthYear": "29BBY",
                    "gender": "male",
                    "homeworldId": "933e4126-fa4d-44e4-9f61-cea2d0a4e821"
                }
            ]
        }
    },
    "message": "Nave encontrada.",
    "status": 200,
    "isSuccess": true
}
```

### 🚗 Vehicle

#### 🟢 SearchAll - Responsável por listar todos os veículos
```
https://localhost:7288/api/v1/vehicles
```

**Response**
```json
{
    "data": {
        "vehicles": [
            {
                "id": "067b6e7a-8087-42d4-8773-00bfe37a9d94",
                "name": "Sail barge",
                "slug": "sail-barge",
                "model": "Modified Luxury Sail Barge",
                "manufacturer": "Ubrikkian Industries Custom Vehicle Division"
            },
            ...
            {
                "id": "8872566c-c3eb-4466-acd7-f4871d2c9757",
                "name": "Armored Assault Tank",
                "slug": "armored-assault-tank",
                "model": "Armoured Assault Tank",
                "manufacturer": "Baktoid Armor Workshop"
            }
        ],
        "totalRecords": 39
    },
    "message": "Lista de veículos encontrada.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢 SearchById ou SearchBySlug- Responsável por buscar um veículo específico
```
https://localhost:7288/api/v1/vehicles/{ID_VEHICLE}
https://localhost:7288/api/v1/vehicles/slug/{SLUG_VEHICLE}
```

**Response**
```json
{
    "data": {
        "vehicleDetails": {
            "id": "8872566c-c3eb-4466-acd7-f4871d2c9757",
            "name": "Armored Assault Tank",
            "slug": "armored-assault-tank",
            "model": "Armoured Assault Tank",
            "vehicleClass": "repulsorcraft",
            "manufacturer": "Baktoid Armor Workshop",
            "length": 0,
            "costInCredits": 0,
            "crew": "4",
            "passengers": 6,
            "maxAtmospheringSpeed": 55,
            "cargoCapacity": 0,
            "consumables": "unknown",
            "created": "2014-12-19T17:13:29.8",
            "edited": "2014-12-20T21:30:21.703",
            "films": [
                {
                    "id": "65ffc367-0ee4-4730-b061-85f8bef589e9",
                    "title": "The Phantom Menace",
                    "slug": "the-phantom-menace",
                    "director": "George Lucas",
                    "releaseDate": "1999-05-19T00:00:00"
                }
            ],
            "pilots": []
        }
    },
    "message": "Veículo encontrado.",
    "status": 200,
    "isSuccess": true
}
```

<section id="participe"> </section>

# 💜 Participe
Quer participar dos próximos desafios? Junte-se a [maior comunidade .NET do Brasil 🇧🇷 💜](https://balta.io/discord)
