[![](https://img.shields.io/nuget/v/soenneker.email.support.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.support/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.support/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.email.support/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.email.support.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.support/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.support/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.email.support/actions/workflows/codeql.yml)

# Soenneker.Email.Support

Sends a subject and HTML body to the application's configured support address through `IEmailDispatcher`.

## Install

```bash
dotnet add package Soenneker.Email.Support
```

## Configuration

```json
{
  "Email": {
    "SupportAddress": "support@example.com"
  }
}
```

`Email:SupportAddress` is required and is read for each send. The dispatcher and selected sender also require their own configuration.

## Registration

Register an `IEmailSender` implementation first, then the support utility:

```csharp
using Soenneker.Email.Sender.Registrars;
using Soenneker.Email.Support.Registrars;

services.AddEmailSenderAsSingleton();
services.AddEmailSupportUtilAsSingleton();
```

`AddEmailSupportUtilAsSingleton()` registers the support utility and dispatcher as singletons. `AddEmailSupportUtilAsScoped()` registers both as scoped. Match the chosen sender lifetime: a singleton dispatcher must not capture a scoped sender.

The dispatcher constructor requires an `IEmailSender` even when queue routing is enabled, so a sender registration is always necessary.

## Send to support

```csharp
using Soenneker.Email.Support.Abstract;

IEmailSupportUtil support = serviceProvider.GetRequiredService<IEmailSupportUtil>();

await support.Send(
    "Import failed",
    "<p>The nightly customer import failed after 3 attempts.</p>",
    cancellationToken);
```

The utility creates an HTML `EmailMessage`, puts `bodyHtml` in the `bodyText` template token, uses normal priority, and identifies the current machine as the sender. Actual delivery is immediate or queued according to `Email:UseQueue`.

The HTML is not sanitized or encoded by this utility. Encode or sanitize untrusted values before including them. Completion follows dispatcher semantics: queued mode means accepted by the queue transport; direct mode means accepted by the sender. Cancellation cannot retract a message already queued or delivered.
