using System;
using Soenneker.Email.Support.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Email.Dispatcher.Abstract;
using Soenneker.Messages.Email;
using Microsoft.Extensions.Configuration;
using Soenneker.Enums.Email.Format;
using Soenneker.Enums.Email.Priority;
using Soenneker.Extensions.Configuration;
using Soenneker.Utils.Environment;

namespace Soenneker.Email.Support;

/// <inheritdoc cref="IEmailSupportUtil"/>
public sealed class EmailSupportUtil : IEmailSupportUtil
{
    private readonly IEmailDispatcher _emailDispatcher;
    private readonly IConfiguration _configuration;

    public EmailSupportUtil(IEmailDispatcher emailDispatcher, IConfiguration configuration)
    {
        _emailDispatcher = emailDispatcher;
        _configuration = configuration;
    }

    public ValueTask Send(string subject, string bodyHtml, CancellationToken cancellationToken = default)
    {
        var to = _configuration.GetValueStrict<string>("Email:SupportAddress");

        var message = new EmailMessage
        {
            Queue = "email",
            Type = "email",
            To = [to],
            Subject = subject,
            Tokens = new Dictionary<string, string>
            {
                { "bodyText", bodyHtml }
            },
            Id = Guid.NewGuid()
                     .ToString(),
            CreatedAt = DateTimeOffset.UtcNow,
            Sender = EnvironmentUtil.GetMachineName(),
            Format = EmailFormat.Html,
            Priority = EmailPriority.Normal
        };

        return _emailDispatcher.Dispatch(message, cancellationToken);
    }
}