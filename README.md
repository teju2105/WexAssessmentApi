# WexAssessmentApi

## Overview
This project is a .NET Core Web API application that implements a simple product management system. It provides endpoints to perform CRUD operations on products and integrates with Duende IdentityServer for OAuth 2.0 authentication and authorization.

### Files Added and Their Purposes
- `Controllers/ProductsController.cs`: Contains the implementation of the ProductsController, which handles HTTP requests related to products such as GET, POST, PUT, and DELETE.
- `Models/Product.cs`: Defines the Product class with properties such as Id, Name, Price, Category, and StockQuantity.
- `Repositories/IRepository.cs`: Defines the IRepository interface with methods for basic CRUD operations.
- `Repositories/Repository.cs`: Implements the IRepository interface using an in-memory dictionary to simulate data storage.
- `Repositories/IProductRepository.cs`: Inherits from IRepository and adds a method to retrieve products by category.
- `Repositories/ProductRepository.cs`: Implements IProductRepository and provides methods to retrieve products by category.
- `Program.cs`: Contains the entry point of the application and configures services, middleware, and endpoints.
- `appsettings.json`: Configuration file for the application, currently containing basic logging settings.
- `WexAssessmentApi.csproj`: Project file for the .NET Core Web API application.


## Steps to Run the Application
1. Clone the repository to your local machine.
2. Open the project in Visual Studio or any code editor of your choice.
3. Configure the IdentityServer settings in the `Program.cs` file to match your environment.
4. Ensure that the necessary NuGet packages are restored.
5. Build the solution.
6. Start the application.

## Assumptions Made During Development
1. In-memory storage is used for storing product data for simplicity. In a real-world scenario, this would be replaced with a database.
2. IdentityServer is configured to use the client credentials grant type for authentication. Additional authentication methods can be implemented as needed.
3. This project assumes basic knowledge of .NET Core, ASP.NET Core, and OAuth 2.0.

## Testing the Application with Postman
1. Open Postman.
2. Obtain an access token using the following steps:
   - Create a new request and set the request type to POST.
      Click on the Authorization tab in the new request.
      From the Type dropdown, select OAuth 2.0.
      Token Name: Choose any name, e.g., "WexAssessmentApi Token".
      Grant Type: Client Credentials.
      Access Token URL: https://localhost:7238/connect/token.
      Client ID: client.
      Client Secret: secret.
      Scope: api1.
      Click on Get New Access Token.
3. Copy the access token from the response.
4. Test the API endpoints using the following URLs:
   - GET /api/products: `https://localhost:7238/api/products`
   - GET /api/products/{id}: `https://localhost:7238/api/products/{id}`
   - POST /api/products: `https://localhost:7238/api/products`
   - PUT /api/products/{id}: `https://localhost:7238/api/products/{id}`
   - DELETE /api/products/{id}: `https://localhost:7238/api/products/{id}`
5. Set the authorization header in each request:
   - Select the Authorization tab in Postman.
   - Choose Type: OAuth 2.0.
   - Paste the access token in the Token field.
6. Send requests to the respective endpoints to test the functionality.

