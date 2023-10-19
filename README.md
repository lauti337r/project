# project


Backend:

1. Clone the repository.

2. Install the EF Core CLI tool globally:  dotnet tool install --global dotnet-ef

3. Check the connection string in appsettings.json file in project-be.

4. Run the following command to migrate the changes to the db: dotnet ef database update

5. Run the project-be project in VS.

Frontend:

1. Open the project and go to the ApiService class. Make sure the apiUrl is the correct one.

2. Run the following command to install the dependencies: npm install

3. Run 'ng serve'
