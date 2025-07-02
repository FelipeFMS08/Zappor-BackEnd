# ⚡ Zappor

**Zappor** é um sistema de gestão para pequenos negócios, em desenvolvimento com Domain Driven Design e tecnologias modernas.

> Repositório oficial do backend — API REST em ASP.NET Core 8 com suporte a autenticação JWT e operações de CRUD.

---

## 📌 Funcionalidades implementadas

- ✅ Projeto estruturado em **Camadas**: Domain, Application, Infrastructure, API
- ✅ Autenticação JWT com login de usuário
- ✅ Persistência com Entity Framework Core e SQL (Azure)
- ✅ CRUD completo de produtos:
  - Criar, listar, buscar por ID, atualizar e deletar
  - Endpoints protegidos por autenticação
- ✅ Documentação interativa com Swagger
- ✅ Deploy em ambiente Azure (em progresso)

---

## 🛠️ Tecnologias utilizadas

- **.NET 8**
- **C#**
- **Entity Framework Core**
- **ASP.NET Core Web API**
- **JWT (JSON Web Tokens)**
- **Swagger (Swashbuckle)**
- **Azure SQL (Cloud)**
- **Arquitetura limpa** (Domain Driven Design)

---

## ▶️ Como rodar localmente

### Pré-requisitos:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server local ou string de conexão para Azure
- Visual Studio ou VS Code

### Clonando o repositório:

```bash
git clone https://github.com/seu-usuario/zappor-backend.git
cd zappor-backend
