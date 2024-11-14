namespace WebApi.Test.Login.DoLogin;

public class DoLoginTest : IClassFixture<CustomWebApplicationFactory>
{
    private const string METHOD = "api/Login";
    
    private readonly HttpClient _httpClient;
    private readonly string _email;
    private readonly string _password;
    private readonly string _name;
    
    public DoLoginTest(CustomWebApplicationFactory webApplicationFactory)
    { 
        _httpClient = webApplicationFactory.CreateClient();
        _email = webApplicationFactory.GetEmail();
        _password = webApplicationFactory.GetPassword();
        _name = webApplicationFactory.GetName();
    }
    
    [Fact]
    public async Task Success()
    {
        var request = new RequestLoginJson
        {
            Email = _email,
            Password = _password
        };

        var response = await _httpClient.PostAsJsonAsync(METHOD, request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var responseBody = await response.Content.ReadAsStreamAsync();
        
        var responseData = await JsonDocument.ParseAsync(responseBody);
        
        responseData.RootElement.GetProperty("name").GetString().Should().Be(_name);
        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [ClassData((typeof(CultureInlineDataTest)))]
    public async Task Error_Login_Invalid(string culture)
    {
        var request = RequestLoginJsonBuilder.Build();
        
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(culture));
        var response = await _httpClient.PostAsJsonAsync(METHOD, request);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        
        var responseBody = await response.Content.ReadAsStreamAsync();  
        
        var responseData = await JsonDocument.ParseAsync(responseBody);
        
        var errors = responseData.RootElement.GetProperty("errorMessage").EnumerateArray();
        
        var expectedmessage = ResourceErrorMessages.ResourceManager.GetString("EMAIL_OR_PASSWORD_INVALID", new CultureInfo(culture));
        
        errors.Should().HaveCount(1).And.Contain(c => c.GetString()!.Equals(expectedmessage));
    }
}