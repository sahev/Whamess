## Info 

This app uses a user session store to load WhatsApp and uses them to sendposts. 

Development purpose for studies ONLY. 
All rights reserved to the appropriate representatives

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
		http://localhost/api/data
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
		
Interface:

	- http://localhost/upload/upload.aspx

	- Upload file (.xls or .xlsx) for process data:
	
	- File needed type:

		1: required for first column: NUMBER (11xxxxxxxxx);

		2: required for second column: NAME;

		3: more 5 columns optional witch any data;

	- TextBox:
		{0}: required number column;
		{1}: required text column;
		{2}: optional data column;
		{3}: optional data column;
		{4}: optional data column;
		{5}: optional data column;
		{6}: optional data column;

	- Example usage: 
		
		number: {0}
		name: {1}
		pos 3: {2}
		pos 4: {3}
		pos 5: {4}
		pos 6: {5}
		pos 7: {6}
			 
		

	