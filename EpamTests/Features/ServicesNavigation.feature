Feature: Navigation to Services Section

  Scenario Outline: Validate user can navigate to a selected AI service
    Given I am on the EPAM homepage
    When I navigate to the "Services" section
    And I select the service category "<category>"
    Then the page title should be "<category>"
    And the section "Our Related Expertise" should be visible

    Examples:
      | category         |
      | Generative AI    |
      | Responsible AI   |
