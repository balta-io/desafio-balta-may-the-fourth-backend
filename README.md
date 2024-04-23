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

## 🎖️ Desafio
**May the Fourth** é a quarta edição dos **Desafios .NET** realizados pelo [balta.io](https://balta.io). Durante esta jornada, fizemos parte do batalhão backend onde unimos forças para entregar um API em celebração ao dia de Star Wars, com dados referente do universo.

## 📱 Projeto

//Abrir Swagger ou Postman

## ⚙️ Tecnologias
* C# 12
* .NET 8
* ASP.NET
* Azure

## 📌 Arquitetura e Infraestrutura
* Minimal APIs
* Clean Architecture
* Repository Pattern
* Mediator Pattern

## 🥋 Skills Desenvolvidas
* Comunicação
* Trabalho em Equipe
* Networking
* Resolução de problemas
* Conhecimento técnico

## 🧪 Como testar o projeto
Para rodar o projeto de forma local, primeiro sera necessário subir um banco de dados. Para subir um banco da forma mais fácil, iremos precisar utilizar o Docker, que é uma ferramenta para conteinirização.
- Baixar o docker
```
https://www.docker.com/products/docker-desktop/
```

Com o Docker baixando, vamos criar um container do SqlServer
//Subir Docker com SqlServer


Precisaremos também instalar o CLI do EF utlizando o seguinte comando no terminal:
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

## 🎯 Endpoints

### Film
- SearchAll  - Responsavel por listar todos os filmes
```
https://localhost:7288/api/v1/film
```
**Response**
```json

```

### Person
- SearchAll - Responsável por listar todos os personagens

### Planet
- SearchAll - Responsável por listar todos os planetas
- Create - Responsável por criar um planeta


### Species


### Starship
- SearchAll - Responsável por listar todos as naves
- Create - Responsável por criar uma nave

### Vehicle


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

# 💜 Participe
Quer participar dos próximos desafios? Junte-se a [maior comunidade .NET do Brasil 🇧🇷 💜](https://balta.io/discord)
