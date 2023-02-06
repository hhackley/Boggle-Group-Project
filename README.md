# group-10-boggle
**CSCE-361 Final Project**<br />
**Group members:** Alex Herman, Hunter Hackley, Matthew Rokusek, Logan White<br />
<br />
## Project Description
A computer recreation of the pencil-and-paper version of Boggle.<br />
Playable by a single player or by multiple players over a network. <br />
## Project Startup
Software needed: Visual Studio 2022, a frontend code editor like vs code or webstorm, nodejs.
<br />
<br />
Setting up backend: Open up BoggleAPI.sln in Visual Studio, add your database credentials to app.config,
and run BoggleAPI using the play button at the top
<br />
<br />
Setting up frontend: Open the boggle-ui folder in your front end code editor,
Open two terminals. In the first terminal cd into ./Socket. run the command npm install, and "node .\Index.js\".
In the second terminal cd into cd ./Web App and run the command npm install and "npm start"
<br />
<br />
Everything should be set up now. If you want to run the game on multiple devices, you must edit line 7
in Gameplay.jsx in the frontend from 'http://localhost:80' to 'http://IPv4 Address:80', and
on line 6 in Index.js to include 'http://IPv4 Address:8080' in the cors origin list.
