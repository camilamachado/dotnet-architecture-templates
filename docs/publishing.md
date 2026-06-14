# 🚀 Publicando uma Nova Versão da CLI

Este repositório utiliza **GitHub Actions** para publicar automaticamente novas versões do **ArchForge CLI** no NuGet como uma **.NET Global Tool**.

## 1. Atualize a versão da CLI

Antes de criar uma nova release, consulte a estratégia de versionamento:

👉 [Versionamento](./versioning.md)

Edite o arquivo:

```text
src/ArchForge.Cli/ArchForge.Cli.csproj
```

Atualizando a propriedade:

```xml
<Version>1.0.0</Version>
```

> Para versões de pré-lançamento utilize o padrão:
>
> ```xml
> <Version>1.1.0-preview.1</Version>
> ```

## 2. Atualize o Changelog

Registre as alterações da nova versão no arquivo:

```text
CHANGELOG.md
```

## 3. Commit das alterações

```bash
git add .
git commit -m "📦 build(cli): gerar versão 1.0.0"
```

## 4. Criar uma tag

A tag deve corresponder à versão publicada.

```bash
git tag v1.0.0
```

Exemplo para versões preview:

```bash
git tag v1.1.0-preview.1
```

## 5. Enviar para o GitHub

```bash
git push
git push --tags
```

## 6. Aguardar a publicação

Após o envio da tag, o GitHub Actions executará automaticamente:

- 🔄 Restore
- 🏗️ Build
- 📦 Pack
- 🚀 Publicação no NuGet

A nova versão ficará disponível em:

👉 https://www.nuget.org/packages/ArchForge.Cli

> A indexação do NuGet pode levar alguns minutos após a publicação. Normalmente a nova versão aparece entre **1 e 10 minutos** após a conclusão do workflow.

## 📥 Instalando a CLI publicada

Após a publicação, qualquer usuário poderá instalar a ferramenta com:

```bash
dotnet tool install --global ArchForge.Cli
```

Ou instalar uma versão específica:

```bash
dotnet tool install --global ArchForge.Cli --version 1.0.0
```

## 🔄 Atualizando a CLI

Usuários que já possuem a ferramenta instalada podem atualizá-la com:

```bash
dotnet tool update --global ArchForge.Cli
```

Ou para uma versão específica:

```bash
dotnet tool update --global ArchForge.Cli --version 1.1.0
```

## ✅ Validando a instalação

Após a instalação ou atualização:

```bash
arch-forge --version
```

Saída esperada:

```text
ArchForge versão 1.0.0
```

## 🎯 Fluxo resumido

```bash
# Atualizar versão no csproj

git add .
git commit -m "📦 build(cli): gerar versão 1.0.0"

git tag v1.0.0

git push
git push --tags
```

Após o push da tag, a publicação acontece automaticamente.
