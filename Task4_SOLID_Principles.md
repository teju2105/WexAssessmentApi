# Task 4: SOLID Principles

## SOLID Principles

### Single Responsibility Principle (SRP)
- Each class and method in the project has a single responsibility. 
For example, the `ProductsController` is responsible for handling HTTP requests related to products, while the `ProductRepository` is responsible for data storage and retrieval.

### Open/Closed Principle (OCP)
- The code is open for extension but closed for modification. 
For example, the repository pattern allows for the addition of new repository implementations (e.g., for different data storage mechanisms) without modifying existing code.
Additionally, the use of interfaces and dependency injection facilitates the substitution of different implementations at runtime without changing the client code.

### Liskov Substitution Principle (LSP)
- Derived types (e.g., specific repository implementations) can be substituted for their base types (e.g., the generic repository interface) without affecting the correctness of the program.
For example, `ProductRepository` implements the `IRepository<Product>` interface, ensuring that it can be used interchangeably with other repository implementations.

### Interface Segregation Principle (ISP)
- Interfaces are tailored to specific client needs, preventing clients from being forced to depend on methods they do not use.
For instance, `IProductRepository` extends `IRepository<Product>` and adds additional methods specific to product-related operations, ensuring that clients of `IProductRepository` are not burdened with unnecessary methods.

### Dependency Inversion Principle (DIP)
- High-level modules (e.g., controllers) depend on abstractions (e.g., repository interfaces) rather than concrete implementations, allowing for decoupling and easier maintenance.
For instance, `ProductsController` depends on `IProductRepository`, enabling it to work with any implementation of the repository interface without being tightly coupled to a specific implementation.

