Feature: File Download from About Page

  Scenario: Verify that EPAM corporate overview PDF downloads successfully
    Given I am on the EPAM homepage
    And I accept cookies
    When I navigate to the About page
    And I click the download button
    Then the file "EPAM_Corporate_Overview_Q4FY-2024.pdf" should be downloaded
