# launchpad_dev_code_challenge

How to get your system running:

1-This project was created using .net 6 and entity framework.
2-Neet to install Microsoft SqlServer. 
1-In Visual Studio select Api project as a start up project
2-run add-migration command
3-run update-database

Note:This app have three endpoint
    https://localhost:7222/api/game/start
    The start endpoint does not receive the andy parameter
    https://localhost:7222/api/game/getGames
     The Getgames endpoint does not receive any parameter
    https://localhost:7222/api/move/createmove
    CreateMove endpoint receives playerId,gameId, row, col and name.



Note: I deed not add a enpoint to register a player I assume that endpoint is other ticket

Question: What is the appropriate OAuth 2/OIDC grant to use for a web application using a SPA (Single Page Application) and why.

For a web application using a Single Page Application (SPA) architecture, the appropriate OAuth 2/OIDC (OpenID Connect) grant to use is either the Implicit Grant or the Authorization Code with PKCE (Proof Key for Code Exchange) Grant.

The Implicit Grant is less secure but simpler to implement as it allows the client-side JavaScript code to directly receive an access token from the Authorization Server.

The Authorization Code with PKCE Grant is more secure as it involves the use of a backend server to securely exchange an authorization code for an access token. It uses PKCE to mitigate the risk of an attacker intercepting the authorization code.

The choice of grant type depends on the security requirements and the capabilities of the web application. If security is a top priority, the Authorization Code with PKCE Grant is recommended. If simplicity is a priority, the Implicit Grant may be a good choice for SPAs as it provides better security than the Implicit Grant. The Implicit Grant is simpler to implement but less secure because it exposes the access token in the browser URL. The choice of grant type depends on the specific security requirements and capabilities of the web application.
