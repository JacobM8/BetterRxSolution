using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BetterRxSolution.Services;
using Moq.Protected;
using System.Linq;

public class NpiRegistryServiceTests
{
    private Mock<IHttpClientFactory> _clientFactoryMock;
    private Mock<HttpMessageHandler> _handlerMock;
    private NpiRegistryService _service;

    [SetUp]
    public void Setup()
    {
        _clientFactoryMock = new Mock<IHttpClientFactory>();
        _handlerMock = new Mock<HttpMessageHandler>();

        // Setup the mock to return a specific HttpResponseMessage
        _handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{ 'result_count': 1, 'results': [{ 'basic': { 'first_name': 'John', 'last_name': 'Doe' } }] }")
            });


        var client = new HttpClient(_handlerMock.Object);
        _clientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

        _service = new NpiRegistryService(_clientFactoryMock.Object);
    }

    [Test]
    public async Task GetProviders_ReturnsProviderData()
    {
        string firstName = "John";
        string lastName = "Doe";
        string taxonomyDescription = "description";
        string city = "city";
        string state = "state";
        int zip = 12345;

        var result = await _service.GetProviders(firstName, lastName, taxonomyDescription, city, state, zip);
        var resultList = result.Results.ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(resultList.Count, Is.EqualTo(2));
            Assert.That(resultList[0].Basic.FirstName, Is.EqualTo(firstName));
            Assert.That(resultList[0].Basic.LastName, Is.EqualTo(lastName));
        });
    }
}
