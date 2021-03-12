# Api Client
## Setup
1. Setup your local database with the table setup just by running the sql script "bizbloqz-init.sql" under scripts/database/v1.0/
2. Rebuild the solution and make sure BizBloqz.Clients.Api is the main project
3. By default, the launchSettings is configured to run in Development using "appSettings.Development.json" and on port 5001
4. Optional - You can run also on Docker but make sure that you ConnectionStrings will point properly to your database source. Note that you will encounter issues when using localhost database, to resolve you will need to identify the corresponding IP of the host in docker mode.
