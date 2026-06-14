# 📦 Política de Versionamento

O ArchForge segue o padrão de **Versionamento Semântico (Semantic Versioning — SemVer)** para garantir previsibilidade na evolução da CLI e dos templates gerados.

Formato adotado:

```text
MAJOR.MINOR.PATCH
```

Exemplo:

```text
1.2.0
```

# 🎯 O que significa cada número?

## 🔴 MAJOR

Incrementado quando houver mudanças incompatíveis com versões anteriores (_breaking changes_).

Essas alterações normalmente impactam a estrutura dos projetos gerados ou exigem adaptações manuais por parte dos usuários.

### Exemplos

- Alteração da arquitetura base dos templates
- Mudança na estrutura de diretórios
- Alteração das dependências entre camadas
- Atualização de versão do .NET que introduza incompatibilidades
- Substituição de bibliotecas centrais da solução

### Cenários práticos

```text
1.x.x → 2.0.0
```

- Migração de Controllers para Minimal APIs
- Substituição do padrão CQRS utilizado
- Reestruturação completa da solução

## 🟡 MINOR

Incrementado quando novos recursos são adicionados de forma compatível com versões anteriores.

O objetivo é expandir as capacidades da ferramenta sem quebrar o comportamento já existente.

### Exemplos

- Novos templates
- Novos comandos da CLI
- Integrações opcionais
- Recursos arquiteturais adicionais

### Cenários práticos

```text
1.2.x → 1.3.0
```

- Inclusão de template Worker Service
- Integração opcional com Redis
- Inclusão de OpenTelemetry
- Health Checks configurados automaticamente

## 🟢 PATCH

Incrementado para correções e melhorias que não alteram o comportamento esperado dos templates ou da CLI.

### Exemplos

- Correção de bugs
- Ajustes de configuração
- Atualização de dependências
- Melhorias na documentação
- Correções em templates existentes

### Cenários práticos

```text
1.2.0 → 1.2.1
```

- Correção de namespaces gerados incorretamente
- Ajuste em arquivos de configuração
- Atualização de pacotes NuGet

# ⚠️ O que é considerado uma Breaking Change?

Uma mudança é considerada incompatível quando o usuário precisa realizar alguma ação manual para continuar utilizando a ferramenta ou os projetos gerados.

Alguns exemplos:

- Alteração da estrutura de pastas
- Mudança nos contratos públicos
- Remoção de funcionalidades existentes
- Mudança significativa na arquitetura gerada
- Alteração do fluxo de desenvolvimento esperado

Sempre que uma breaking change ocorrer, a versão **MAJOR** será incrementada.

# 🚀 Estratégia de Releases

Cada versão publicada segue algumas diretrizes:

- Todas as releases são identificadas através de tags no Git
- Cada release possui um changelog detalhando as alterações
- Novos recursos são adicionados apenas à versão principal mais recente
- Versões anteriores recebem apenas correções críticas, quando necessário

Exemplo:

```text
v1.0.0
v1.1.0
v1.2.0
v2.0.0
```

# 🧪 Versões Preview

Durante o desenvolvimento de novas funcionalidades, poderão ser publicadas versões de pré-lançamento.

Exemplo:

```text
1.0.0-preview.1
1.0.0-preview.2
1.0.0-rc.1
1.0.0
```

Essas versões permitem validar recursos antes da publicação oficial.

# 🏗️ Evolução dos Templates

Os templates do ArchForge são opinativos e evoluem continuamente para refletir as melhores práticas do ecossistema .NET.

Essa evolução pode incluir:

- Novos padrões arquiteturais
- Melhorias de organização
- Atualizações do ecossistema .NET
- Recursos voltados à observabilidade
- Aprimoramentos de produtividade
- Boas práticas de mercado

O objetivo é manter um equilíbrio saudável entre **estabilidade**, **consistência** e **evolução tecnológica**, garantindo que novos projetos já nasçam alinhados às práticas modernas de desenvolvimento.
