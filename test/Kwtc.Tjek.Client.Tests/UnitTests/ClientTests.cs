using System.Net;
using System.Text.Json;
using FluentAssertions;
using Kwtc.Tjek.Client.Abstractions.Models;
using Moq;
using Moq.Protected;

namespace Kwtc.Tjek.Client.Tests.UnitTests;

public class ClientTests
{
    private readonly Mock<IHttpClientFactory> httpClientFactoryMock = new();

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public Task Search_InvalidSearchTerm_ShouldThrow(string searchTerm)
    {
        // Arrange
        var sut = GetSut();

        // Act
        var act = async () => await sut.Search(searchTerm);

        // Assert
        return act.Should().ThrowAsync<ArgumentException>();
    }

    [Theory]
    [InlineData("ValidSearchTerm")]
    [InlineData("Valid Search Term")]
    [InlineData("Valid%Search%Term")]
    [InlineData("Valid#Search#Term")]
    [InlineData("Valid.Search.Term")]
    [InlineData("Valid\\Search\\Term")]
    [InlineData("Vælid.Seårch.Tørm")]
    public async Task Search_ValidSearchTermExpectedResponse_ShouldSendRequest(string searchTerm)
    {
        // Arrange
        var httpClient = GetMockedClient(
            uri: $"search?query={searchTerm.ToValidUri()}",
            content: JsonSerializer.Serialize(new List<Offer> { new() })
        );
        var sut = GetSut();

        this.httpClientFactoryMock
            .Setup(x => x.CreateClient(Constants.HttpClientName))
            .Returns(httpClient);

        // Act
        await sut.Search(searchTerm);

        // Assert
        this.httpClientFactoryMock.Verify(x => x.CreateClient(Constants.HttpClientName), Times.Once);
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.Forbidden)]
    [InlineData(HttpStatusCode.Unauthorized)]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.InternalServerError)]
    [InlineData(HttpStatusCode.MethodNotAllowed)]
    public async Task Search_ValidSearchTermUnexpectedResponseCode_ShouldThrow(HttpStatusCode statusCode)
    {
        // Arrange
        const string searchTerm = "ValidSearchTerm";
        var httpClient = GetMockedClient(
            uri: $"search?query={searchTerm.ToValidUri()}",
            statusCode: statusCode
        );
        var sut = GetSut();

        this.httpClientFactoryMock
            .Setup(x => x.CreateClient(Constants.HttpClientName))
            .Returns(httpClient);

        // Act
        var act = () => sut.Search(searchTerm);

        // Assert
        await act.Should().ThrowAsync<HttpRequestException>();

        this.httpClientFactoryMock.Verify(x => x.CreateClient(Constants.HttpClientName), Times.Once);
    }

    [Fact]
    public async Task Search_ValidSearchTermUnexpectedResponseContent_ShouldThrow()
    {
        // Arrange
        const string searchTerm = "ValidSearchTerm";
        var httpClient = GetMockedClient(
            uri: $"search?query={searchTerm.ToValidUri()}",
            content: string.Empty
        );
        var sut = GetSut();

        this.httpClientFactoryMock
            .Setup(x => x.CreateClient(Constants.HttpClientName))
            .Returns(httpClient);

        // Act
        var act = () => sut.Search(searchTerm);

        // Assert
        await act.Should().ThrowAsync<HttpRequestException>().WithMessage("*Response content is empty*");

        this.httpClientFactoryMock.Verify(x => x.CreateClient(Constants.HttpClientName), Times.Once);
    }

    private static HttpClient GetMockedClient(string uri, HttpStatusCode statusCode = HttpStatusCode.OK, string content = "")
    {
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(x =>
                    x.RequestUri!.AbsoluteUri.EndsWith(uri)
                ),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });

        var httpClient = new HttpClient(httpMessageHandlerMock.Object);
        httpClient.BaseAddress = new Uri(Constants.BaseUrl);

        return httpClient;
    }

    private Client GetSut()
    {
        return new Client(this.httpClientFactoryMock.Object);
    }
}
