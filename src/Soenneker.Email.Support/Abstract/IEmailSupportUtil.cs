using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Support.Abstract;

/// <summary>
/// A utility that allows for quick access to support email sending
/// </summary>
public interface IEmailSupportUtil
{
    /// <summary>
    /// Sends email Support.
    /// </summary>
    /// <param name="subject">Subject for the send operation.</param>
    /// <param name="bodyHtml">Body HTML for the send operation.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the send operation is complete.</returns>
    ValueTask Send(string subject, string bodyHtml, CancellationToken cancellationToken = default);
}
