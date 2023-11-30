# StockPro - Inventory Management System

StockPro is a comprehensive Inventory Management System developed using Blazor with ASP.NET Core 6.0 and MS SQL Server for your business's purchasing, sales, and reporting needs.

## Features

- **Producing Products**: Easily add and produce new products to enhance your inventory selection.
- **Purchasing and Editing Inventory**: Efficiently manage inventory by purchasing new items and editing existing inventory details.
- **Selling Products**: Streamlined process for selling products to customers with tracking and reporting features.
- **Reporting**: Includes comprehensive reporting functionality for purchasing, producing, and sales operations with order numbers and user identification.
- **PDF Generation**: Enables users to print or download PDF files for easy documentation and sharing.
- **User Authentication and Authorization**: Utilizes ASP.NET Core Identity for secure user management and permissions controls.
- **Forms Submission and Validation**: Implements robust form submission and custom validation mechanisms to ensure data accuracy.
- **Intuitive User Interface**: Developed with Blazor Components and Bootstrap on the front-end providing a mobile responsive and user-friendly experience.
- **Entity Framework Core with SQL Server**: Utilizes Entity Framework Core for seamless database connectivity with SQL Server.
- **Clean Architecture**: Follows a clean architecture design pattern, promoting clarity, maintainability, and scalability.

## Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/StockPro.git

2. **Navigate to the Project Directory:**
    ```bash
    cd StockPro
    ```

3. **Restore Dependencies:**
    ```bash
    dotnet restore
    ```

4. **Apply EF Core Migrations:**
    Ensure that you have applied EF Core migrations to set up the database schema.
    ```bash
    dotnet ef database update
    ```

5. **Run the Application:**
    ```bash
    dotnet run
    ```

6. **Access StockPro:**
    Open your browser and navigate to [http://localhost:5000](http://localhost:5000) or [https://localhost:5001](https://localhost:5001).

## Usage

1. **Login or Register:**
    Create an account or log in using existing credentials.

2. **Assign Permissions in MS SQL Server:**
    To enable specific functionalities, ensure that the user account has the appropriate permissions in MS SQL Server. For example:
    - To generate sales, the account should have a "Sales" attribute assigned in SQL Server corresponding to their unique user ID.
    - For user management, an admin account can be created with the "Administrator" attribute. Once the admin account is set up, user management can be handled from within the application @page "/manageusers".


3. **Navigate Through Dashboard:**
    Explore the NavMenu to access the features of StockPro.

4. **Generate Reports:**
    Use the reporting functionality to generate detailed reports. PDF files can be printed or downloaded for offline use.

## Contributing

We welcome contributions from the community. Feel free to fork the repository, create issues, or submit pull requests. 

