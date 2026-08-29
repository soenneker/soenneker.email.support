[![](https://img.shields.io/nuget/v/soenneker.email.support.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.support/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.support/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.email.support/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.email.support.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.support/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.support/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.email.support/actions/workflows/codeql.yml)

# Soenneker.Email.Support

A utility that allows for quick access to support email sending.

## Install

```bash
dotnet add package Soenneker.Email.Support
```

## Quick start

```csharp
using Soenneker.Email.Support.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddEmailSupportUtilAsSingleton();
```

Adds `IEmailSupportUtil` as a singleton service.

## What you get

- `IEmailSupportUtil` — A utility that allows for quick access to support email sending.
- `EmailSupportUtilRegistrar` — A utility that allows for quick access to support email sending.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IEmailSupportUtil.Send(subject, bodyHtml, cancellationToken)` | Sends email Support. | A task that completes when the send operation is complete. |
| `EmailSupportUtilRegistrar.AddEmailSupportUtilAsSingleton(services)` | Adds `IEmailSupportUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `EmailSupportUtilRegistrar.AddEmailSupportUtilAsScoped(services)` | Adds `IEmailSupportUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
