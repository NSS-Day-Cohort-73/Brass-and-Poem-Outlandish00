//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Data.Common;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Saturn Devouring His Son",
        Price = 300.00M,
        ProductTypeId = 3,
    },
    new Product()
    {
        Name = "Saxophone",
        Price = 350.00M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Quoth the Raven",
        Price = 50.00M,
        ProductTypeId = 2,
    },
    new Product()
    {
        Name = "Trumpet",
        Price = 400.00M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Turn the Stars",
        Price = 100.00M,
        ProductTypeId = 2,
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List.
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType() { Id = 1, Title = "Instrument" },
    new ProductType() { Id = 2, Title = "Poem" },
    new ProductType() { Id = 3, Title = "Art" },
};

//put your greeting here
string greeting =
    @"                        HELLO! And welcome to Brass and Poem!
                                            Your one stop shop for Instruments, Art, and Poems!
                                            Quoth the raven 'Buy some stuff!'
                                            ";
Console.WriteLine($"{greeting}");
string userChoice = null;

//implement your loop here
while (userChoice != "5")
{
    DisplayMenu();
    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;

        case "2":
            DeleteProduct(products, productTypes);
            break;

        case "3":
            AddProduct(products, productTypes);
            break;

        case "4":
            UpdateProduct(products, productTypes);
            break;

        case "5":
            Console.WriteLine();
            Console.WriteLine("Exiting the program...");
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine(
        @"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
"
    );
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        ProductType currentProductsType = productTypes.FirstOrDefault(productType =>
            productType.Id == products[i].ProductTypeId
        );
        Console.WriteLine();
        Console.WriteLine(
            $"{i + 1}. {products[i].Name} is an {currentProductsType.Title} and costs {products[i].Price}"
        );
        Console.WriteLine();
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine();
    Console.WriteLine(
        @"                        Choose the number of the product you would like to delete."
    );
    int userDeleteSelection = int.Parse(Console.ReadLine());
    products.RemoveAt(userDeleteSelection - 1);
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("We need some information bout your product");
    Console.WriteLine("What is the name of your object?");
    Console.WriteLine();
    string userProductName = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("How much did you want to charge for it?");
    decimal userPriceChoice = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Please select the product type based on the index");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine();
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        Console.WriteLine();
    }
    int userTypeId = int.Parse(Console.ReadLine());
    Console.WriteLine();

    Product userProduct = new Product()
    {
        Name = userProductName,
        Price = userPriceChoice,
        ProductTypeId = userTypeId,
    };
    products.Add(userProduct);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($@"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine();
    Console.WriteLine("Select an artifact based on the number.");
    Console.WriteLine();
    int userSectedId = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine("Enter the name of your product:");
    Console.WriteLine();
    string userName = Console.ReadLine();
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($@"{i + 1}. {productTypes[i].Title}");
    }
    Console.WriteLine("Choose the type based on the number.");
    Console.WriteLine();
    string userProductType = Console.ReadLine();
    Console.WriteLine("How much do you want for it?");
    string userPriceString = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(userName))
        products[userSectedId - 1].Name = userName;
    try
    {
        int userProductTypeInt = int.Parse(userProductType);
        products[userSectedId - 1].ProductTypeId = userProductTypeInt;
        decimal userPrice = decimal.Parse(userPriceString);
        products[userSectedId - 1].Price = userPrice;
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid Input");
    }
}

// don't move or change this!
public partial class Program { }
