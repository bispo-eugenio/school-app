# School App🎒
Projeto backend com front-end acoplado internamente utilizando arquivos estáticos no `wwwroot`. 

# About📚
O projeto consiste em uma web api de gerenciamento de escola focado em CRUDs e lógica simples de gerenciamento de aulas. 

# Feature🛠️
- CRUD em cada entidade, como Classroom, Teacher, Student, SubjectMatter, etc.
- Camadas de abstrações, como Repository, Services e Controllers.
- AutoMapper interno
- Validações 
- Conexão com banco de dados mysql
- Dockerfile simples
- Validação com jwt 

## Comments 📝
- Para realizar a migração para o banco de dados é necessário criar um arquivo `.env` com as variáveis de ambientes necessárias. (obs: tem um arquivo `.env.example` para guiar a criação do `.env`);
- Para entrar no sistema você precisa realizar o **login** na pagina inicial encontrada `./` do servidor local/núvem;
- Caso não tenha um login, é necessário fazer um **cadastro** que se encontra na mesma rota.
- Caso aconteça algum problema de rota dentro do projeto, você pode alterar as constants definidas no constants.js
