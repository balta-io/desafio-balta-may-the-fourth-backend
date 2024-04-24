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
