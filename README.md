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
2. <a href="#tecnologias">Tecnologias</a><br>
3. <a href="#arquitetura">Arquiteturas e Infraestrutura</a><br>
4. <a href="#skills">Skills Desenvolvidas</a><br>
5. <a href="#testes">Como testar o projeto</a><br>
6. <a href="#endpoints">Endpoints</a><br>
7. <a href="#participantes">Participantes</a><br>
8. <a href="#participe">Participe</a><br>

---

<section id="desafio"> </section>

## 🎖️ Desafio
**May the Fourth** é a quarta edição dos **Desafios .NET** realizados pelo [balta.io](https://balta.io). Durante esta jornada, fizemos parte do batalhão backend onde unimos forças para entregar um API em celebração ao dia de Star Wars, com dados referente do universo.

A API fornece a possibilidade de fazer consultas, cadastros, remoções e atualizações dos dados. Os tipos de dados disponíveis são: Filmes, Personagens, Naves, Veículos, Planetas e Espécies. 

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

Agora, com o container e o CLI do EF prontos, vamos criar o banco e inicializar a API

```
dotnet ef database update
```
```
dotnet watch run
```

Agora que estamos com a API rodando, podemos fazer requisições necessárias utilizando um headless browser como o Postman e os Endpoints descritos no próximo tópico.

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
                "id": "bf26860b-b5e6-413f-b8ae-47a01da2f507",
                "title": "The Phantom Menace",
                "director": "George Lucas",
                "releaseDate": "1999-05-19T00:00:00"
            },
            ...
            {
                "id": "3cac0850-1577-4f1b-b6b4-f339dcdc468a",
                "title": "Return of the Jedi",
                "director": "Richard Marquand",
                "releaseDate": "1983-05-25T00:00:00"
            }
        ]
    },
    "message": "Lista de filmes encontrada",
    "status": 200,
    "isSuccess": true
}
```
#### 🟢 SearchById  - Responsavel por listar um filme específico
```
https://localhost:7288/api/v1/film/{ID_FILM}
```

**Response**
```json
    "data": {
        "filmDetails": {
            "id": "bf26860b-b5e6-413f-b8ae-47a01da2f507",
            "title": "The Phantom Menace",
            "episodeId": 1,
            "openingCrawl": "Turmoil has engulfed the\r\nGalactic Republic. The taxation\r\nof trade routes to outlying star\r\nsystems is in dispute.\r\n\r\nHoping to resolve the matter\r\nwith a blockade of deadly\r\nbattleships, the greedy Trade\r\nFederation has stopped all\r\nshipping to the small planet\r\nof Naboo.\r\n\r\nWhile the Congress of the\r\nRepublic endlessly debates\r\nthis alarming chain of events,\r\nthe Supreme Chancellor has\r\nsecretly dispatched two Jedi\r\nKnights, the guardians of\r\npeace and justice in the\r\ngalaxy, to settle the conflict....",
            "director": "George Lucas",
            "producer": "Rick McCallum",
            "releaseDate": "1999-05-19T00:00:00",
            "created": "2014-12-19T16:52:55.74",
            "edited": "2014-12-20T10:54:07.217",
            "speciesList": [
            ...
            ],
            "starships": [
            ...
            ],
            "vehicles": [
            ...
            ],
            "characters": [
            ...
            ],
            "planets": [
            ...
            ],
        }
    "message": "Filme encontrado com sucesso.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟡 Create - Responsável por criar um filme
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔴 Delete - Responsável por deletar um filme
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔵 Update - Responsável por atualizar um filme
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

---

### 🧔Person
#### 🟢 SearchAll - Responsável por listar todos os personagens
```
https://localhost:7288/api/v1/people
```

**Response**

```json
    "data": {
        "people": [
            {
                "id": "5f4c1202-17e1-49dc-81c7-0fa534273655",
                "name": "Quarsh Panaka",
                "birthYear": "62BBY",
                "gender": "male",
                "homeworldId": "31e83947-3a28-4720-886b-d38cb05fa22e"
            },
            ...
            {
                "id": "b79a015d-5610-4d1d-a557-ff36bcaf6aff",
                "name": "Leia Organa",
                "birthYear": "19BBY",
                "gender": "female",
                "homeworldId": "8193b17f-cd25-4574-b466-bbe807e032f5"
            }
        ]
    },
    "message": "Lista de personagens encontrada",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢 SearchById - Responsável por buscar um personagem específico
```
https://localhost:7288/api/v1/people/{ID_PEOPLE}
```
**Response**

```json
"data": {
        "personDetail": {
            "id": "5f4c1202-17e1-49dc-81c7-0fa534273655",
            "name": "Quarsh Panaka",
            "birthYear": "62BBY",
            "eyeColor": "brown",
            "gender": "male",
            "hairColor": "black",
            "height": 183,
            "mass": "unknown",
            "skinColor": "dark",
            "created": "2014-12-19T17:55:43.347",
            "edited": "2014-12-20T21:17:50.4",
            "homeworld": null,
            "homeworldId": "31e83947-3a28-4720-886b-d38cb05fa22e",
            "films": [
                {
                    "id": "bf26860b-b5e6-413f-b8ae-47a01da2f507",
                    "title": "The Phantom Menace",
                    "director": "George Lucas",
                    "releaseDate": "1999-05-19T00:00:00"
                }
            ],
            "species": [
                {
                    "id": "cf30a6f1-5fef-418a-8ec3-fce820099745",
                    "name": "Human",
                    "classification": "mammal",
                    "designation": "sentient",
                    "language": "Galactic Basic",
                    "homeworldId": "fa0320f0-0588-492b-84df-0af98d35915d"
                }
            ],
            "starships": [],
            "vehicles": []
        }
    },
    "message": "Personagem encontrado.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟡 Create - Responsável por criar uma pessoa
```
https://localhost:7288/api/v1/people/create
```

**Curl**
```json

```

**Response**
```json

```

#### 🔴 Delete - Responsável por deletar uma pessoa
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔵 Update - Responsável por atualizar uma pessoa
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

---

### 🌍 Planet
#### 🟢SearchAll - Responsável por listar todos os planetas
```
https://localhost:7288/api/v1/planets
```

**Response**
```json
    "data": {
        "planetList": [
            {
                "id": "24e2beaa-edee-406b-8ffc-0a9169cdacfd",
                "name": "Mon Cala",
                "gravity": "1",
                "population": 0,
                "climate": "temperate"
            },
            ...
            {
                "id": "2262348f-2393-47ee-bb33-ff50a6b9a3d3",
                "name": "Kashyyyk",
                "gravity": "1 standard",
                "population": 381,
                "climate": "tropical"
            }
        ]
    },
    "message": "Uma lista de planetas foi encontrado.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢SearchById - Responsável por buscar um planeta específico
```
https://localhost:7288/api/v1/planets/{ID_PLANET}
```

**Response**
```json
    "data": {
        "planet": {
            "id": "24e2beaa-edee-406b-8ffc-0a9169cdacfd",
            "name": "Mon Cala",
            "diameter": 11030,
            "rotationPeriod": 21,
            "orbitalPeriod": 398,
            "gravity": "1",
            "population": 0,
            "climate": "temperate",
            "terrain": "oceans, reefs, islands",
            "surfaceWater": "100",
            "created": "2014-12-18T11:07:01.793",
            "edited": "2014-12-20T20:58:18.47",
            "residents": [
                {
                    "id": "79992019-c6d0-485b-aeb4-df2de730b9fe",
                    "name": "Ackbar",
                    "birthYear": "41BBY",
                    "gender": "male",
                    "homeworldId": "24e2beaa-edee-406b-8ffc-0a9169cdacfd"
                }
            ],
            "films": []
        }
    },
    "message": "Planeta encontrado com sucesso.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟡 Create - Responsável por criar um planeta

```
https://localhost:7288/api/v1/planets/create
```

**Curl**
```json

```

**Response**
```json

```

#### 🔴 Delete - Responsável por deletar um planeta
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔵 Update - Responsável por atualizar um planeta
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

---

### 👽 Species

#### 🟢SearchAll - Responsável por listar todas as espécies

```
https://localhost:7288/api/v1/
```

**Response**
```json

```

#### 🟢SearchById - Responsável por buscar uma espécies específica

```
https://localhost:7288/api/v1/
```

**Response**
```json

```


#### 🟡 Create - Responsável por criar uma espécie
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔴 Delete - Responsável por deletar uma espécie
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔵 Update - Responsável por atualizar uma espécie
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

---

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
                "id": "01bbe16b-ef40-422d-b25b-184c18568c86",
                "name": "Millennium Falcon",
                "model": "YT-1300 light freighter",
                "manufacturer": "Corellian Engineering Corporation"
            },
            ...
            {
                "id": "ca50c044-732a-49a5-9c6b-fa4b8c237071",
                "name": "Trade Federation cruiser",
                "model": "Providence-class carrier/destroyer",
                "manufacturer": "Rendili StarDrive, Free Dac Volunteers Engineering corps."
            }
        ]
    },
    "message": "Lista de naves encontrada.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟢SearchById - Responsável por buscar uma nave específica

```
https://localhost:7288/api/v1/starships/{ID_STARSHIP}
```

**Response**
```json
{
    "data": {
        "starshipDetails": {
            "id": "01bbe16b-ef40-422d-b25b-184c18568c86",
            "name": "Millennium Falcon",
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
                    "id": "8358d097-960a-4a97-a7cd-6ed74fade9a7",
                    "title": "The Empire Strikes Back",
                    "director": "Irvin Kershner",
                    "releaseDate": "1980-05-17T00:00:00"
                },
                ...
                {
                    "id": "3cac0850-1577-4f1b-b6b4-f339dcdc468a",
                    "title": "Return of the Jedi",
                    "director": "Richard Marquand",
                    "releaseDate": "1983-05-25T00:00:00"
                }
            ],
            "pilots": [
                {
                    "id": "ae26b00b-7909-4c4f-8416-2700a576ccf3",
                    "name": "Lando Calrissian",
                    "birthYear": "31BBY",
                    "gender": "male",
                    "homeworldId": "687d30ea-3488-4e1d-b76d-82c4cd321ae9"
                },
                ...
                {
                    "id": "2c5683ca-9008-41cd-afb4-b90d8d62bc2a",
                    "name": "Han Solo",
                    "birthYear": "29BBY",
                    "gender": "male",
                    "homeworldId": "c0562cc5-3d5b-47d0-b541-191376b1e92d"
                }
            ]
        }
    },
    "message": "Nave encontrada.",
    "status": 200,
    "isSuccess": true
}
```

#### 🟡 Create - Responsável por criar uma nave

```
https://localhost:7288/api/v1/starships/create
```

**Curl**
```json

```

**Response**
```json

```

#### 🔴 Delete - Responsável por deletar uma nave
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔵 Update - Responsável por atualizar uma nave
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

---

### 🚗 Vehicle

#### 🟢 SearchAll - Responsável por listar todos os veículos
```
https://localhost:7288/api/v1/
```

**Response**
```json

```

#### 🟢 SearchById - Responsável por buscar um veículo específico
```
https://localhost:7288/api/v1/
```

**Response**
```json

```

#### 🟡 Create - Responsável por criar um veículo
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔴 Delete - Responsável por deletar um veículo
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

#### 🔵 Update - Responsável por atualizar um veículo
```
https://localhost:7288/api/v1/
```

**Curl**
```json

```

**Response**
```json

```

---

<section id="participantes"> </section>

# 💂‍Participantes

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
<br>

<section id="participe"> </section>

# 💜 Participe
Quer participar dos próximos desafios? Junte-se a [maior comunidade .NET do Brasil 🇧🇷 💜](https://balta.io/discord)
