![Arquitetura .NET](https://img.shields.io/badge/Área-Arquitetura%20.NET-purple)
![.NET](https://img.shields.io/badge/.NET-10.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

# 🏗️ ArchForge

CLI para geração de projetos .NET padronizados.

O objetivo do ArchForge é acelerar a criação de novos serviços, eliminando tarefas repetitivas de configuração e fornecendo uma estrutura consistente e pronta para evolução.

## 📑 Sumário

- [🚀 Instalação](#-instalação)
- [⚡ Comandos Disponíveis](#-comandos-disponíveis)
- [🛠️ Desenvolvimento Local](#️-desenvolvimento-local)
- [🔄 Atualizando a CLI](#-atualizando-a-cli)
- [👤 Autora](#-autora)

# 🚀 Instalação

### Via NuGet

```bash
dotnet tool install --global ArchForge.Cli
```

### Atualização

```bash
dotnet tool update --global ArchForge.Cli
```

# ⚡ Comandos Disponíveis

### Exibir ajuda

```bash
arch-forge --help
```

### Exibir versão

```bash
arch-forge version
```

### Criar novo projeto

```bash
arch-forge new MeuServico
```

# 🛠️ Desenvolvimento Local

Caso esteja contribuindo com o ArchForge ou testando alterações localmente.

### 1. Remover versão instalada

```bash
dotnet tool uninstall --global ArchForge.Cli
```

### 2. Gerar pacote NuGet

```bash
dotnet pack src/ArchForge.Cli -c Release
```

O pacote será criado em:

```text
src/ArchForge.Cli/bin/Release
```

### 3. Instalar localmente

```bash
dotnet tool install --global ArchForge.Cli --version 0.1.0-preview.1 --add-source ./src/ArchForge.Cli/bin/Release
```

### 4. Validar instalação

```bash
arch-forge version
```

# 🔄 Atualizando a CLI

Após alterar o código:

### Gerar novo pacote

```bash
dotnet pack src/ArchForge.Cli -c Release
```

### Atualizar instalação local

```bash
dotnet tool update --global ArchForge.Cli --version 0.1.0-preview.2 --add-source ./src/ArchForge.Cli/bin/Release
```

> Atualize sempre o campo `<Version>` no arquivo `.csproj`.

# 👤 Autora

**Camila Melo Machado**\
Pós-Graduação em Arquitetura .NET — FIAP

# ⭐ Contribuindo

Contribuições são bem-vindas.

Caso encontre bugs, tenha sugestões de melhorias ou queira adicionar novos templates, fique à vontade para abrir uma issue ou enviar um Pull Request.

# 📜 Licença

Este projeto está licenciado sob a licença MIT.
