Feature: Page Registration
        In order to vote for a sport car
        As a visitor of the website
        I want to be able to register in the website

 
Scenario: Register Successfully with Valid Credentials
        Given User is at Register Page
        And User has a new Login name
        And the FirstName is "123"
        And the LastName is "123"
        And the Password is "Aa123456!"
        And the ConfirmPassword is "Aa123456!"
        When User clicks on the Register button
        Then message should display Registration is successful
        
Scenario: Register Unsuccessfully with Used Credentials
        Given User is at Register Page
        And User has the same Login name
        And the FirstName is "123"
        And the LastName is "123"
        And the Password is "Aa123456!"
        And the ConfirmPassword is "Aa123456!"
        When User clicks on the Register button
        Then message should display UsernameExistsException: User already exists