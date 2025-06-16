✅ Tarefas - Gerenciador de Tarefas com .NET e Blazor
Projeto de gerenciamento de tarefas desenvolvido com arquitetura em camadas utilizando .NET 8, Blazor WebAssembly, Minimal APIs e MudBlazor.

🔧 Tecnologias Utilizadas
.NET 8

Blazor WebAssembly

Minimal APIs (ASP.NET Core)

Entity Framework Core

SQLServer

MudBlazor

📁 Estrutura do Projeto
bash
Copiar
Editar
/Tarefas
│
├── Tarefas.Core              # Camada de domínio
│   ├── Models                # Entidades principais 
│   ├── Handlers              # Interfaces compartilhadas (front e back)
│   ├── Requests              # Dados de entrada das APIs
│   └── Responses             # Dados de saída das APIs
│
├── Tarefas.Api               # Backend com Minimal APIs
│   ├── Endpoints             # Endpoints RESTful
│   ├── Data                  # Contexto do EF Core (SQLServer)
│   └── Program.cs            # Inicialização do backend
│
└── Tarefas.Web               # Frontend com Blazor WebAssembly
    ├── Pages                 # Páginas da aplicação (MudBlazor)
    ├── Handlers              # Consumo das APIs
    └── Program.cs            # Inicialização do Blazor
✨ Funcionalidades
✅ Criar, editar, excluir tarefas

📋 Visualização em tempo real com layout responsivo

🔍 Filtros por status (pendente, em andamento, concluída)

📅 Organização por data

☁️ Backend leve com Minimal APIs + SQLServer

💅 Interface moderna com MudBlazor

▶️ Como Executar
Pré-requisitos
.NET 8 SDK

SQLite

Editor (Visual Studio ou VS Code)

Passos
bash
Copiar
Editar
# Clone o repositório
git clone https://github.com/meselmiasMarques/TaskApp.git

# Execute o backend
cd Tarefas.Api
dotnet run

# Em outro terminal, execute o frontend
cd ../Tarefas.Web
dotnet run
🧠 Conceitos Aplicados
🧱 Arquitetura em camadas (Core, Api, Web)

🔁 Compartilhamento de Models e DTOs entre front e back

🌐 Comunicação com APIs via HttpClient

🧩 Uso de interfaces genéricas (IHandler) para padronizar requisições

🎨 UI responsiva com MudBlazor

📌 Melhorias Futuras
 Autenticação de usuário

 Deploy com Docker ou Azure

 Sistema de notificações (ex: MudSnackbar)



