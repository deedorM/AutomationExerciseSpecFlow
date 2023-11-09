Feature: User Registration 

@Prod
 Scenario:  Register A New User
    Given I navigate to AutoExerciseHomePage url
    Then I verify that <New User Signup!> is visible
    When I enter 'Ade' and 'ade@ade.com'
    And I click the 'signup' button
    Then I verify that 'ENTER ACCOUNT INFORMATION' is visible
    When I fill in the details:
      | Field         | Value       |
      | Title         | Mr.         |
      | Password      | secret123   |
      | Date of Birth | 1/July/1993 |
    And I select the checkbox <'Sign up for our newsletter!'> and <'Receive special offers from our partners!'>
   
    And I fill in the following details:
      | First Name         | John                    |
      | Last Name          | Doe                     |
      | Company            | ABC Inc.                |
      | Address            | 123 Main Street         |
      | Address2           | Apt 4B                  |
      | Country            | United States           |
      | State              | California              |
      | City               | Los Angeles             |
      | Zipcode            | 90001                   |
      | Mobile Number      | 123-456-7890            |
  
  





#    Feature: User Login and Account Deletion
#
#  Scenario: Login to the account and delete it
#    Given I launch the browser
#    When I navigate to url 'http://automationexercise.com'
#    Then I verify that the home page is visible successfully
#    When I click on the 'Signup / Login' button
#    Then I verify that 'Login to your account' is visible
#    When I enter the correct email address and password
#    And I click the 'login' button
#    Then I verify that 'Logged in as username' is visible
#    When I click the 'Delete Account' button
#    Then I verify that 'ACCOUNT DELETED!' is visible