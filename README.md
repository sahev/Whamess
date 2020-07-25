## Development server

- Selenium GRID Standalone Server; 
- Docker Toolbox;


## Build Dependencies

- MSTest.TestAdapter;
- MSTest.TestFramework;
- NUnit;
- Selenium.WebDriver;
- Selenium.WebDriver.ChromeDriver;


## Running 

- Run this commands on CMD: 

	1: docker-machine create -d virtualbox <name>; (create vm)
	
	2: docker-machine env <name>; (info of machine)
	
	3: docker-compose up -d; (initialize file of hub configuration)
	
	4: @FOR /f "tokens=*" %i IN ('docker-machine env') DO @%i; (initialize shell configuration)
	
	
- Execute in Test Suite Explorer
