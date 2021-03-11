# CopaFilmes

Representa uma solução para um Campeonato de Filmes fictício,composto de um projeto de backend, API RESTful, escrito em dotnet core 3.1, e um projeto de front end escrito em angular 11.

## Para executar a aplicação será necessário baixar os projetos de frontend e de backend, e executar os dois projetos dentro da IDE

- https://github.com/marcos-cruz/CopaApi.git - projeto de backend

- https://github.com/marcos-cruz/CopaApp.git - projeto de frontend

## Instruções para executar o projeto de Backend

- Baixar o projeto de backend CopaFilmes (este projeto)

- Baixar o projeto de frontend CopaApp

- Abrir este projeto de backend no Visual Studio Community ou Professional

- Executar o build da solution

- Certificar-se que o projeto de Api (Bigai.CopaFilmes.Api) esta setado como projeto startup

- Presione F5 para rodar a aplicação

Será aberto no browser default a documentação da API no endereço `https://localhost:44368/swagger/index.html`

## Instruções para executar o projeto de Frontend

- Abrir o Command prompt

- Ir até a pasta onde foi baixado o projeto de frontend.

- Digite `code .` e pressione enter

- Clique em Terminal e em seguida new Terminal. Se preferir pressione simultaneamente `Ctrl + Shift + ' `

- No terminal digite `ng serve --proxy-config proxy.conf.js` e pressione enter

- Abra uma nova guia no browser e digite `http://localhost:4200/` e pressione enter
