using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace BuggyCars;

[TestFixture]
public class APITests
{
    [Test]
    public void LoginPost()
    {
        string PostUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/oauth/token";

        var client = new RestClient(PostUrl);

        var request = new RestRequest("/prod/oauth/token",Method.Post);

        request.AddJsonBody(new {grant_type = "password", username = "aqw2", password = "Q1w2e3r4!"});

        var response = client.Execute(request);

        Assert.IsTrue(response.Content.Contains("Not Found"));
    }
    
    [Test]
    public void ViewPopularMakerGet()
    {
        string ExpectedName = "Alfa Romeo";
            
        string GetUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/makes/c4u1mqnarscc72is00ng?modelsPage=1";

        var client = new RestClient(GetUrl);

        var request = new RestRequest();

        var response = client.Get(request);

        var responseJson = response.Content;

        string popularMakerName = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["name"].ToString();
        
        Assert.AreEqual(popularMakerName,ExpectedName.Trim());
        
    }

    [Test]
    public void EditProfilePut()
    {
        string PutUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/users/profile";

        var client = new RestClient(PutUrl);

        var request = new RestRequest("/prod/users/profile",Method.Put);

        request.AddJsonBody(new {username = "aqw", firstName = "aaaa", lastName = "a"});

        var response = client.Execute(request);
            
        //Assert.AreEqual(200,response.StatusCode);
        
        Console.WriteLine(response.Content);
            
    }
    
    [Test]
    public void VotePost()
    {
        string PostUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/models/c4u1mqnarscc72is00ng%7Cc4u1mqnarscc72is00sg/vote";

        var client = new RestClient(PostUrl);

        var request = new RestRequest("/prod/models/c4u1mqnarscc72is00ng%7Cc4u1mqnarscc72is00sg/vote",Method.Post);

        request.AddJsonBody(new {comment = "200"});

        var response = client.Execute(request);
            
        //Assert.AreEqual(200,response.StatusCode);
        
        Console.WriteLine(response.Content);
            
    }
    
    
}