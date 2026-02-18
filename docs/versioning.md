# Versionamento

Este repositório segue o padrão de **Versionamento Semântico (SemVer)**.

Formato:

MAJOR.MINOR.PATCH

Exemplo:
1.2.0

## Regras de Versionamento

### MAJOR

Incrementado quando houver:

- Mudança estrutural na arquitetura base dos templates
- Alteração nas regras de dependência entre camadas
- Atualização de versão LTS do .NET que cause breaking changes
- Mudanças que exijam adaptação manual nos projetos gerados

Exemplo:

- Alteração da estrutura de pastas
- Substituição de biblioteca central (ex: MediatR por outro padrão)

### MINOR

Incrementado quando houver:

- Inclusão de novos templates
- Adição de novos recursos opcionais
- Integração com novas tecnologias (ex: Redis, OpenTelemetry, Aspire)
- Melhorias arquiteturais compatíveis com versões anteriores

Exemplo:

- Novo template de Worker
- Inclusão opcional de HealthChecks

### PATCH

Incrementado quando houver:

- Correções de bugs
- Ajustes de configuração
- Atualização de dependências sem impacto estrutural
- Correção de documentação

## Breaking Changes

Uma mudança é considerada breaking change quando:

- Exige modificação manual no projeto gerado
- Altera estrutura de diretórios
- Muda contratos públicos ou padrões arquiteturais
- Remove funcionalidades existentes

Sempre que ocorrer uma breaking change, a versão MAJOR será incrementada.

## Estratégia de Releases

- As versões serão marcadas com tags no Git.
- Cada release conterá um CHANGELOG descrevendo as alterações.
- Apenas a versão major mais recente receberá melhorias contínuas.
- Versões anteriores receberão apenas correções críticas, quando aplicável.

## Evolução dos Templates

Os templates deste repositório são opinativos e podem evoluir ao longo do tempo para refletir:

- Boas práticas modernas de arquitetura
- Atualizações do ecossistema .NET
- Melhorias em escalabilidade e organização

O objetivo é manter equilíbrio entre estabilidade e evolução arquitetural.
