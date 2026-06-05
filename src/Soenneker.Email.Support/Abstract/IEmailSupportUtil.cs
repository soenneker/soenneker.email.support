using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Support.Abstract;

/// <summary>
/// A utility that allows for quick access to support email sending
/// </summary>
public interface IEmailSupportUtil
{
    /// <summary>
    /// Executes the send operation.
    /// </summary>
    /// <param name="subject">The subject.</param>
    /// <param name="bodyHtml">The body html.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Send(string subject, string bodyHtml, CancellationToken cancellationToken = default);
}
