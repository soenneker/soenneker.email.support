using Soenneker.Tests.HostedUnit;

namespace Soenneker.Email.Support.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class EmailSupportUtilTests : HostedUnitTest
{
    public EmailSupportUtilTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
