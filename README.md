# access-management-app

> Gerenciamento de acessos realizados na plataforma. 

## Web Reference

ASP.NET MVC 5 Razor .NET Framework 4.8.1

## Application/Domain/Data Reference

- Class Library .NET Standard 2.0
- Dapper 2.1.24
- System.Data.SqlClient 4.8.5

## Database

- LocalDB do SQL Server Express

## Rodar local

**Pre requisitos**
- SDK do .NET Framework 4.8.1;
- Um editor de código .NET ou IDE (por exemplo, VS Code com o plugin C#, Visual Studio ou JetBrains Rider);
- LocalDB do SQL Server Express, que pode ser instalado a partir do próprio Visual Studio;

**Database**
1. Conectar no base de dados LocalDB do SQL Server Express;
2. Executar scripts disponibilizados em [database](https://github.com/anderson-araujo-cavalcante/access-management-app/tree/main/database) na seguinte ordem: 1 create-initial.sql e 2 create-procedures.sql;
Neste momento irá criar o banco de dados, as tabelas e as procedures necessárias para rodar a aplicação.

**Web**
1. Executar a aplicação através do visual studio;
1. No navegador acessar a url ```https://localhost:44393/user``` e realizar o cadastro de um novo usuário:

![image](https://github.com/anderson-araujo-cavalcante/access-management-app/assets/133878123/6453e2e7-36f9-4676-864b-91e5d07e1522)

1. Após cadastro realizado acessar url ```https://localhost:44393/``` e fazer login com o usuário criado anteriormente:

![image](https://github.com/anderson-araujo-cavalcante/access-management-app/assets/133878123/09544890-09b6-4e7e-94e6-1977576be9cc)

2. Com login feito será direcionado para a View de Acessos realizados:

![image](https://github.com/anderson-araujo-cavalcante/access-management-app/assets/133878123/f7335c9d-c5e8-4780-b48a-717056bf9b65)

## Tarefas Realizadas

 :white_check_mark: finalizado
 
 :construction: em andamento

- Crie as duas Tabelas abaixo no Banco de Dados: :white_check_mark:
- Crie uma Arquitetura em camadas de forma que as Aplicações acima não tenham acesso direto ao Banco de Dados e que as Regras de Negócio fiquem centralizadas:  :white_check_mark:
- Crie Entidades para representar os seus Objetos do Banco de Dados. :white_check_mark:
- Crie pelo menos uma camada de Repositório de Dados e uma de Aplicação para centralizar as validações e demais regras de negócio. Mas fique à vontade para demonstrar seu conhecimento criando mais camadas... o Uso de DDD será bem avaliado. :white_check_mark:
- Crie Interfaces para definir os Métodos dos CRUD's. :white_check_mark:
- Para acesso ao Banco de Dados, utilize ADO.Net. Uso do Dapper será permitido. Não utilizar Entity Framework. :white_check_mark:
- Crie pelo menos duas Stored Procedures para realizar ações no Banco de Dados, sendo uma para Inclusão e a outra para seleção de Dados. :white_check_mark:
- Crie uma Aplicação Web utilizando Asp.Net MVC que tenha as seguintes Views abaixo:  :white_check_mark:
- View de Login :white_check_mark:
- View para Visualização dos Acessos realizados :white_check_mark:
- View para Cadastro de Usuários  :white_check_mark:
- Crie uma View para realização de Login utilizando Bootstrap e faça uma pequena estilização utilizando CSS para dar uma aparência mais elegante para a sua Tela. :construction:
- Crie as devidas validações para informar o Usuário quando os dados de Login não forem informados ou estiverem incorretos.  :white_check_mark:
- A aplicação deverá gerar um Registro de Acesso na Tabela LogAcesso, incluindo o IP do Usuário sempre que o mesmo realizar o Login.  :white_check_mark:
- Ao realizar o Login com dados válidos, o Usuário deverá ser direcionado para a View de Acessos realizados. :white_check_mark:
- Quando o Usuário estiver logado, ele deverá visualizar um Header que será comum para todas as demais Views da Aplicação. Este Header deverá ter uma Cor de Fundo de sua escolha, onde o nome da Aplicação (escolha um nome) deverá ser exibido em destaque no lado esquerdo.  :white_check_mark:
- No lado direito exiba o Nome do Usuário logado e um Avatar contendo a Letra inicial do Nome do Usuário. :construction:
- Crie uma opção para o Usuário realizar o Logoff. :construction:
- Não utilize Bootstrap, ou seja, use CSS puro para a estilização do Header, inclusive com o Avatar em forma de Círculo. :construction:
- Adicione também ao Header os atalhos abaixo em forma de Link: :white_check_mark:
- Acessos - para acessar a View de Acessos realizados :white_check_mark:
- Usuários - para acessar o Cadastro de Usuários :white_check_mark:
- Crie uma View para exibir uma Listagem de Acessos realizados. :white_check_mark:
- A Listagem poderá ser feita como preferir e deverá exibir os dados abaixo: :white_check_mark:
- Data/Hora Acesso :white_check_mark:
- Nome do Usuário :white_check_mark:
- Endereço IP :white_check_mark:
- Crie um Filtro em forma de Combo, onde ao selecionarmos um Usuário, seja exibido somente os dados de Acesso do Usuário selecionado, ordenados por Data/Hora de Acesso. :construction:
- Adicione uma opção para que seja possível exportar os dados Filtrados para XML, onde o usuário poderá selecionar o diretório onde deseja gerar o XML. O XML deverá conter as Tags com as mesmas informações da Listagem. :construction:
- Logo após a Listagem, ainda na mesma View, crie um "Gráfico de Linhas" utilizando qualquer biblioteca de sua escolha para exibir a quantidade de Acessos por Hora. :white_check_mark:
- O Gráfico deverá mostrar os Horários de 00:00 até as 23:59 com intervalos de uma Hora Ex: 01:00, 02:00, 03:00, etc com as suas respectivas quantidades de Acessos. Se o Usuário realizou o Login as 10:35, a Aplicação deverá contabilizar o acesso no Horário das 10:00. :white_check_mark:
- Crie uma View para que seja possível cadastrar os Usuários que irão acessar a Aplicação: :white_check_mark:
- Desenvolva o CRUD completo, ou seja, Inclusão, Listagem, Edição e Exclusão. :white_check_mark:
- Deverá existir uma Validação para que a Senha seja válida: :white_check_mark:
- Possuir 10 ou mais caracteres :white_check_mark:
- Possuir ao menos 1 dígito numérico :white_check_mark:
- Possuir ao menos 1 letra minúscula :white_check_mark:
- Possuir ao menos 1 letra maiúscula :white_check_mark:
- Possuir ao menos 1 dos caracteres especiais a seguir: !@#$%^&*()-+ :white_check_mark:
- Não possuir caracteres repetidos :white_check_mark:
- Não possuir espaços em branco :white_check_mark:
- A Senha deverá ser criptografada antes de ser salva no Banco de Dados. :white_check_mark:

## Próximos passos

- Criar uma API REST/JSON utilizando Asp.Net Web API
 
