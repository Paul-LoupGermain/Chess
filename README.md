<p align="center">
<h1 align="center">🌟 Chess 🌟</h1>
<p align="center"><Développement d’un jeu d’échec revisité en C# avec une base de donné MySQL.


Development of a chess game in C# with a MySQL database.
The objective is to deepen our knowledge of C# and MySQL to create a chess game with a connection to a database to be able to connect and record the score of the games made.

<p align="center">
<a href="https://github.com/Paul-LoupGermain/Chess/stargazers" title="Stars">
<img src="https://img.shields.io/github/stars/Paul-LoupGermain/Chess?label=Stars&logo=Github&style=flat-square" alt="<repo-title> Stars"/>
</a>
<a href="https://github.com/Paul-LoupGermain/Chess/issues" title="Issues">
<img src="https://img.shields.io/github/issues/Paul-LoupGermain/Chess?label=Issues&logo=Github&style=flat-square" alt="<repo-title> Issues"/>
</a>
<a href="https://github.com/Paul-LoupGermain/Chess/fork" title="Forks">
<img src="https://img.shields.io/github/forks/Paul-LoupGermain/Chess?label=Forks&logo=Github&style=flat-square" alt="Project Initiator Forks"/>
</a>
<a href="https://github.com/Paul-LoupGermain/Chess/pulls" title="Pull Requests">
<img src="https://img.shields.io/github/issues-pr/Paul-LoupGermain/Chess?label=Pull%20Requests&logo=Github&style=flat-square" alt="<repo-title> Pull Requests"/>
</a>
<a href="https://github.com/Paul-LoupGermain/Chess/pulls" title="Repo Size">
<img src="https://img.shields.io/github/repo-size/Paul-LoupGermain/Chess?label=Repo%20Size&logo=Github&style=flat-square" alt="<repo-title> Repo Size"/>
</a>
<a href="https://open.vscode.dev/Paul-LoupGermain/Chess" title="Open in VSCode">
<img src="https://img.shields.io/badge/Open%20in%20VSCode-%23007ACC?label=Code&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAC00lEQVQYGX3BX2iVZRwH8O/ze//t/NkcRzdXmzZzLLYMmyVJUFQgzkQoqOsgAtNu6jK6kqjbIqOErrrTCBUUbBTYuZCMoDE0FZLp3DpnZ9s55313znmf/89TEV1JfT5s6uIG5LlvsPTdKViK8fCzr2H8wGEw1UIpNqgUYkRx38Bajqorb08ateWT62l+NrtxBSH+R0KAdhhbaelqp7X26MTTE9ix58UzG83u+7/l9Q9DEMHKHE4JoNiHf0UEKIvH1zh+lMZsC+ME3ZzDt4FiUtz75NE3viXvDYpbx44AHkjXwShAQIBx7PkGD37NtdsWBAzWGihtYD2QtXsQxkmienu+9MRzl3Yf++wylQaLulWHIXolU76qjI8DBmil0drkn/qocFkbCwsGrbQilXUUz3vo3/PS7PiJL38pPDL10eb68nllHQIiGGfxe231BI1MvlceHk2lyGG9h/UeoSzoZ0i507Kx8mYyMjHth3ZOiz9uIehs+F5x63xN0Tvh0Ni13dMz4Fw8ZJwHwPA30k0JsVF/26SNW7ybQQgBN/wY9OCOzsp89ZD44etro4NbkFQi5FwY4xmMB4wHSDY5XCc7bZr3pmy2CksRFO/CVMb7KzMH5yLbPXDv/CmkLQkqlENjPYwFjAUoSsTPNqRjtjwc5XcXbvZuXv3YxmWoTsrCkcl9Q299/pMqDR9fnDsDFoc14xms97Deg0yaxDpWkKwwl9XW9qulGx9Abr6qPQPP2jCSozJ7/IuuCz9p318aZFEC4wHjAdK9ZEaz3lGh9CxjcR4UBwDevmDT5Re0gxZSw0gBjEy+y7V72ToGbTwsi2JigYMz/hJjACP8I0xAqld1zTtPaa1aCgGMFHCMYB3ASgOwCBLCXxhjeEBYANP5dVe/vddysSh9ABcVgP4IPG8vNL7/6vUQ/8kDcR+YyFf04sIMje6q6t5msnrl6kmRpWf1/ev4E5Tbl9R3VUZRAAAAAElFTkSuQmCC&style=flat-square" alt="Open in VSCode"/>
</a>
<a href="https://github.dev/Paul-LoupGermain/Chess" title="Open in VSCode Web">
<img src="https://img.shields.io/badge/Open%20in%20VSCode%20Web-%23007ACC?label=Code&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAC00lEQVQYGX3BX2iVZRwH8O/ze//t/NkcRzdXmzZzLLYMmyVJUFQgzkQoqOsgAtNu6jK6kqjbIqOErrrTCBUUbBTYuZCMoDE0FZLp3DpnZ9s55313znmf/89TEV1JfT5s6uIG5LlvsPTdKViK8fCzr2H8wGEw1UIpNqgUYkRx38Bajqorb08ateWT62l+NrtxBSH+R0KAdhhbaelqp7X26MTTE9ix58UzG83u+7/l9Q9DEMHKHE4JoNiHf0UEKIvH1zh+lMZsC+ME3ZzDt4FiUtz75NE3viXvDYpbx44AHkjXwShAQIBx7PkGD37NtdsWBAzWGihtYD2QtXsQxkmienu+9MRzl3Yf++wylQaLulWHIXolU76qjI8DBmil0drkn/qocFkbCwsGrbQilXUUz3vo3/PS7PiJL38pPDL10eb68nllHQIiGGfxe231BI1MvlceHk2lyGG9h/UeoSzoZ0i507Kx8mYyMjHth3ZOiz9uIehs+F5x63xN0Tvh0Ni13dMz4Fw8ZJwHwPA30k0JsVF/26SNW7ybQQgBN/wY9OCOzsp89ZD44etro4NbkFQi5FwY4xmMB4wHSDY5XCc7bZr3pmy2CksRFO/CVMb7KzMH5yLbPXDv/CmkLQkqlENjPYwFjAUoSsTPNqRjtjwc5XcXbvZuXv3YxmWoTsrCkcl9Q299/pMqDR9fnDsDFoc14xms97Deg0yaxDpWkKwwl9XW9qulGx9Abr6qPQPP2jCSozJ7/IuuCz9p318aZFEC4wHjAdK9ZEaz3lGh9CxjcR4UBwDevmDT5Re0gxZSw0gBjEy+y7V72ToGbTwsi2JigYMz/hJjACP8I0xAqld1zTtPaa1aCgGMFHCMYB3ASgOwCBLCXxhjeEBYANP5dVe/vddysSh9ABcVgP4IPG8vNL7/6vUQ/8kDcR+YyFf04sIMje6q6t5msnrl6kmRpWf1/ev4E5Tbl9R3VUZRAAAAAElFTkSuQmCC&style=flat-square" alt="Open in VSCode Web"/>
</a>
</p>
<!-- <p align="center"><img src="./assets/images/main.gif" alt="<repo-title>"/></p> -->

<p align="center">
    <a href="https://github.com/Paul-LoupGermain/Chess" title="Chess">📂 Repo</a>
    ·
    <a href="https://github.com/Paul-LoupGermain/Chess/issues/new/choose" title="🐛Report Bug/🎊Request Feature">🚀 Got Issue</a>
</p>

## 🚀 Features

- [x] feature/pawn
- [x] feature/firstPlayer
- [x] feature/eatPawn
- [x] feature/tower
- [x] feature/bishop
- [x] feature/secondPlayer
- [x] feature/king
- [x] feature/queen
- [x] feature/knightChess
- [x] feature/checkMate

## 🎊 Future Updates


- [ ] feature/sqlLogin&Scores

## 🦋 Prerequisite

- Visual Studio Entreprise 17.3.1
    .Net Desktop
- DotNet Framework 4.8.04084
- MySql.Data 8.0.31 // Manage NuGet Packages
- HeidiSql
- MySql Server 8.0

## 🛠️ Installation Steps

1. Clone the repository

```Bash
git clone https://github.com/Paul-LoupGermain/Chess.git
```

2. Install Visual Studio Entreprise, HeidiSql & SqlServer

- [Visual Studio Entreprise](https://visualstudio.microsoft.com/fr/vs/enterprise/)
- [HeidiSql](https://www.heidisql.com/download.php)
- [SqlServer](https://www.microsoft.com/de-de/sql-server/sql-server-downloads)

3. Execute CreateDataBase.sql


## 📐 Architecture

- [Use Case](https://github.com/Paul-LoupGermain/Chess/blob/main/Docs/UseCase.drawio.png)
- [Class Diagram](https://github.com/Paul-LoupGermain/Chess/blob/main/Docs/Class%20Diagram%20Chess.png)
- [MCD](https://github.com/Paul-LoupGermain/Chess/blob/main/Docs/MCD-Chess.png)
- [MLD](https://github.com/Paul-LoupGermain/Chess/blob/main/Docs/MLD-Chess.png)
- [Flowchart](https://github.com/Paul-LoupGermain/Chess/blob/main/Docs/diagramme%20de%20flux%20Chess.pdf)

- [Doc Chess](https://github.com/Paul-LoupGermain/Chess/blob/main/Documentation/Rendu/Documentation-Chess.pdf)


## 👷 Built with

- [Amos Le Coq](https://github.com/AmosLeCoq)


<h2 align="center">🤝 Support</h2>

<p align="center">🎀 Contributions (<a href="https://guides.github.com/introduction/flow" title="GitHub flow">GitHub Flow</a>), 🔥 issues, and 🥮 feature requests are most welcome!</p>

<p align="center">💙 If you like this project, Give it a ⭐ and Share it with friends!</p>

<p align="center">Made with <repo-lang> & ❤️ in Switzerland</p>
