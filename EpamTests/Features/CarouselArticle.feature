Feature: Carousel Article Title Validation

  Scenario Outline: Validate that article title matches after swiping carousel
    Given I am on the EPAM homepage
    And I accept cookies
    When I navigate to the Insights page
    And I swipe the carousel <numberOfSwipes> times
    And I click Read More on the active article
    Then the article title should match the carousel title

    Examples:
      | numberOfSwipes |
      | 2              |
      | 3              |
