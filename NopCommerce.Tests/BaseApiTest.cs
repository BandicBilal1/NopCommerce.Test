using NopCommerce.API.Assembly;
using NopCommerce.Core;
using NopCommerce.Core.Interfaces;
using NopCommerce.UI.Frame;

namespace NopCommerce.Tests;

[TestFixture]
[Parallelizable]
public class BaseApiTest
{
    protected ApiFactory ApiFactory;

    public BaseApiTest()
    {

    }

    [SetUp]
    public void Setup()
    {
        ApiFactory = new ApiFactory();
    }

    [TearDown]
    public void TestTearDown()
    {

    }
}