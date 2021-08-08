# IT 481 Unit 2 Assignment

### Author
Derek Fitzpatrick
8/8/21

## Application Setup
I was studying the repository pattern so I implemnted it here. Code is separated into the following logical tiers
### Business
This is in its own namespace and contains a Customer class that acts as a DTO and ICustomerRepository Interface
This also contains a Service class called CustomerService that encapsulates the methods of the repository.

### Data
This is in its own namespace and contains the CustomerRepository implementation of ICustomerRepository

### Presentation
MainWindow.xaml and a .NET Core WPF Layout that shows the customer count and a data grid of the Customer table.
This utilizes our business class as the IEnumerable.

## Rubric Requirements

### Connection String
I pass a connection string to the Repository class in the data layer.
The business class acts mainly as a container with a Service class

### Get Count of Customers
This is found in the Service class. 

### Get First and Last Names of Customers
This is found and implemented in the Service class. The GUI uses a DataGrid though so it is not called.
But functionally, it is there, just with more data

### Create Instance of the Data Layer
Data layer is instanciated through the CustomerService class.

### Upload to SCM
You are here!

