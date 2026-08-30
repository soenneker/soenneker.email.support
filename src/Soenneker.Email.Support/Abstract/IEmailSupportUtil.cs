using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Support.Abstract;

/// <summary>
/// Sends an HTML message to the support address configured for the application.
/// </summary>
public interface IEmailSupportUtil
{
    /// <summary>
    /// Sends an HTML email to the configured support recipient through the email dispatcher.
    /// </summary>
    /// <param name="subject">Email subject.</param>
    /// <param name="bodyHtml">HTML inserted into the default email template as <c>bodyText</c>.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the send operation is complete.</returns>
    ValueTask Send(string subject, string bodyHtml, CancellationToken cancellationToken = default);
}
