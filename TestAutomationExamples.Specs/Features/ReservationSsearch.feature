Feature: Reservation Search Feature
Background: Given the search home page is displayed

Scenario: Search results display campgrounds matching criteria entered
	When the user fills out the reservation form
	| Location           | StartDate | EndDate | Guests |
	| Canyon Lake, Texas |           |         |        |
	And the user clicks Search on the home page
	Then the search results page is displayed
	And the correct search results are displayed on the page
	| Results                                                     |
	| Yogi Bear's Jellystone Park™ Camp-Resort: Hill Country! tes |
	| Big Oaks RV Park                                            |
	| Guadalupe Riverr                                            |

Scenario: Location field autocompletes the City and State
	When the user enters the location Lod
	Then autocomplete populates the cities and state that match the search string entered
	| Results                                   |
	| Lodi, California                          |
	| Lodi, New Jersey                          |
	| Lodi, Wisconsin                           |
	| Saratoga Escape Lodges and RV Resort      |
	| Schroon River Escape Lodges and RV Resort |
	| San Isabel Lodging                        |
