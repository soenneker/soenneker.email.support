using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Support.Abstract;

/// <summary>
/// A utility that allows for quick access to support email sending
/// </summary>
public interface IEmailSupportUtil
{
    ValueTask Send(string subject, string bodyHtml, CancellationToken cancellationToken = default);
}
