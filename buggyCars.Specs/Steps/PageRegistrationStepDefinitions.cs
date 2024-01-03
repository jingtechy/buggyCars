using BuggyCars.PageObjects;
using BuggyCars.Specs.Drivers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BuggyCars.Steps;

[Binding]
public class PageRegistrationStepDefinitions
{
    // Page Object for Registration
    private RegistrationPageObject registrationPageObject;

    private static string login = "";

    public PageRegistrationStepDefinitions(BrowserDriver browserDriver)
    {
        registrationPageObject = new RegistrationPageObject(browserDriver.Current);
    }
    
    
    [Given(@"User is at Register Page")]
    public void GivenUserIsAtRegisterPage()
    {
        registrationPageObject.OpenRegistrationPage();
    }

    [Given(@"User has a new Login name")]
    public void GivenUserHasANewLoginName()
    {
        login = new Random().NextInt64().ToString();
        registrationPageObject.EnterUsername(login);
    }
    
    [Given(@"User has the same Login name")]
    public void GivenUserHasTheSameLoginName()
    {
        registrationPageObject.EnterUsername(login);
    }
    
    [Given(@"the FirstName is ""(.*)""")]
    public void GivenTheFirstNameIs(string firstname)
    {
        registrationPageObject.EnterFirstName(firstname);
    }

    [Given(@"the LastName is ""(.*)""")]
    public void GivenTheLastNameIs(string lastname)
    {
        registrationPageObject.EnterLastName(lastname);
    }

    [Given(@"the Password is ""(.*)""")]
    public void GivenThePasswordIs(string password)
    {
        registrationPageObject.EnterPassword(password);
    }

    [Given(@"the ConfirmPassword is ""(.*)""")]
    public void GivenTheConfirmPasswordIs(string password)
    {
        registrationPageObject.EnterConfirmPassword(password);
    }

    [When(@"User clicks on the Register button")]
    public void WhenUserClicksOnTheRegisterButton()
    {
        registrationPageObject.ClickRegister();
    }

    [Then(@"message should display (.*)")]
    public void ThenMessageShouldDisplay(string expectedMessage)
    {
        string actualMessage = registrationPageObject.GetMessageAfterRegistration();

        Assert.AreEqual(actualMessage,expectedMessage.Trim());
    }
}