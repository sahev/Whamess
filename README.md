## Info 

This app uses a user session store to load WhatsApp and uses them to sendposts.

## Development server

- Selenium GRID Standalone Server; 
- Docker Toolbox;


## Build Dependencies

- MSTest.TestAdapter;
- MSTest.TestFramework;
- NUnit;
- NUnit3.Console;
- Selenium.WebDriver;
- Selenium.WebDriver.ChromeDriver;

## Running 

With Docker:

	- Run this commands on CMD: 

		1: docker-machine create -d virtualbox <name>; (create vm)

		2: docker-machine env <name>; (info of machine)

		3: docker-compose up -d; (initialize file of hub configuration)

		4: @FOR /f "tokens=*" %i IN ('docker-machine env') DO @%i; (initialize shell configuration)


	- Execute in Test Suite Explorer


With Selenium GRID:

	- Start Selenium grid with hub and respectives nodes;
	- Run "runsendmessage.bat" passing parameters for test.


Endpoint:

	- Initialize the project and build on local/server;
	- API:
		http://localhost/endpoint/data
		Method: POST
		Body type: JSON
		Body: 
			{ 
				"number": "5511123445689", //only 13 numbers
				"text": "message" //only != ""
			}
		
		return types:	
		http: 200 OK
			{ 
				"success": "Mensagem enviada!"
			}
			http: 400 BAD REQUEST
			{
				"error": "Numero invalido!"
			}
			http: 400 BAD REQUEST
			{
				"error": "Insira uma mensagem!"
			}		
		
		
