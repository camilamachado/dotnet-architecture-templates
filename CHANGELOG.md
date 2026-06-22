# 📜 Changelog

Todas as alterações relevantes do ArchForge serão documentadas neste arquivo.

Este projeto segue os princípios do Versionamento Semântico (SemVer) e a estrutura recomendada pelo Keep a Changelog.

## 🚧 Unreleased

### ✨ Adicionado

- A definir.

### 🔄 Alterado

- A definir.

### 🐛 Corrigido

- A definir.

## 🚀 1.0.0 - 2026-06-21

### ✨ Adicionado

- Suporte a múltiplos templates: Implementação de catálogo interno e comando de listagem de templates na CLI.
- Novo template `minimal-api-worker` Estrutura baseada em Clean Architecture combinando uma Minimal API e um Worker Service para processamento em background.
- Integração com Mensageria: Configuração do Worker Service com exemplo prático de publicação/envio de eventos utilizando MassTransit.
- Preparação para o NuGet: Configuração final de metadados, logo oficial e ajustes no README para publicação do pacote da CLI como .NET Global Tool pública.

### 🔄 Alterado

- Otimização de Queries: Ajustes finos no uso de `AsNoTracking` nas consultas do Entity Framework Core para melhor performance.

## 🚀 0.1.0 - 2026-06-17

Primeira versão pública do ArchForge.

### ✨ Adicionado

- CLI distribuída como .NET Global Tool.
- Comandos `new` e `version`.
- Template Minimal API baseado em Clean Architecture.
- Estrutura em camadas (Api, Application, Domain, Infrastructure, IoC e SharedKernel).
- CQRS com MediatR.
- FluentValidation.
- Entity Framework Core.
- Migrations de exemplo.
- Projetos de testes unitários e integração.
- Estrutura inicial de documentação (ADRs, Diagramas, Linguagem Ubíqua e Postman Collection).
- Workflow GitHub Actions para execução automática dos testes unitários em Pull Requests.
- Geração de cobertura de código utilizando Coverlet.
