namespace Mission3_assignment;

// 4 properties in this class
//Name (e.g., "Canned Beans")
// • Category (e.g., "Canned Goods", "Dairy", "Produce")
// • Quantity (e.g., 15 units)
// • Expiration Date

public class FoodItem
{
    //these need to be capitalized
    //properties
    public string FoodName { get; set; }
    public string CategoryName { get; set; }
    public int QuantityItem { get; set; }
    public DateTime ExpirationDate { get; set; }

    //default constructor
    public FoodItem()
    {
    }

    //constructor will have the same name
    //set parameters for each food item
    public FoodItem(string foodName, string categoryName, int quantityItem, DateTime expirationDate)
    {
        FoodName = foodName;
        CategoryName = categoryName;
        QuantityItem = quantityItem;
        ExpirationDate = expirationDate;
    }

    //method for adding food
    public void AddFood(List<FoodItem> foodList)
{
    //set the variables
    string foodName, categoryName;
    int inputQuantityItem = 0; // Renamed to avoid conflict
    DateTime inputExpirationDate = DateTime.MinValue; // Initialize it properly
    
    //create loop to get user input and check if it is valid
    while (true)
    {
        //name
        Console.WriteLine("What is the name of your item?: ");
        foodName = Console.ReadLine();

        // Check if the input is empty or contains only digits (indicating an integer).
        if (string.IsNullOrWhiteSpace(foodName) || int.TryParse(foodName, out _))
        {
            Console.WriteLine("Invalid entry. Please enter a valid name (not an integer).");
        }
        else
        {
            Console.WriteLine($"You entered a valid item name: {foodName}");
            break;
        }
    }

    //category
    while (true)
    {
        Console.WriteLine("What category does your item belong in? (e.g., Canned Goods, Dairy, Produce): ");
        categoryName = Console.ReadLine();

        // Check if the input is empty, whitespace, or a number.
        if (string.IsNullOrWhiteSpace(categoryName) || int.TryParse(categoryName, out _))
        {
            Console.WriteLine("Invalid entry. Please enter a valid category name (not an integer or blank).");
        }
        else
        {
            Console.WriteLine($"You entered a valid category: {categoryName}");
            break;
        }
    }

    //quantity
    while (true)
    {
        Console.WriteLine("What is the quantity in units of your item?: ");
        string quantityInput = Console.ReadLine();

        //make sure to convert to integer
        if (int.TryParse(quantityInput, out inputQuantityItem) && inputQuantityItem >= 0)
        {
            Console.WriteLine($"You entered a valid quantity: {inputQuantityItem}");
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry. Please enter a positive integer.");
        }
    }

    bool isValidDate = false;

    //expiration date
    while (!isValidDate)
    {
        Console.WriteLine("What is the expiration date of your item?: ");
        string expirationDateInput = Console.ReadLine();
        
        //make sure to convert to date
        if (DateTime.TryParse(expirationDateInput, out inputExpirationDate))
        {
            Console.WriteLine($"You entered a valid date: {inputExpirationDate.ToShortDateString()}");
            isValidDate = true;
        }
        else
        {
            Console.WriteLine("Invalid date. Please try again.");
        }
    }

    // Create a new item using the data entered
    if (inputExpirationDate != DateTime.MinValue)
    {
        //include the properties in this new instance of the class creating a food object
        FoodItem newItem = new FoodItem(foodName, categoryName, inputQuantityItem, inputExpirationDate);
        
        // Add the new item to the list
        foodList.Add(newItem);
    }
    
    // Check if the expiration date was successfully assigned
    else
    {
        Console.WriteLine("Error: Expiration date not properly assigned.");
    }
}

    //method for deleting food
    public static void DeleteFood(List<FoodItem> foodList)
    {
        
        while (true)
        {
            //delete by comparing user input strings to items in teh list
            Console.WriteLine("Enter the name of the item you want to remove (or type 'exit' to quit):");
            string userInput = Console.ReadLine();

            //compare strings
            var itemToRemove = foodList.FirstOrDefault(item => item.FoodName.Equals(userInput, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                //remove item
                foodList.Remove(itemToRemove);
                Console.WriteLine($"'{userInput}' has been removed.");
            }
            else
            {
                //error handling
                Console.WriteLine($"'{userInput}' was not found in the list.");
            }
            
            //user request to exit
            if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }

    //method for displaying the list
    public static void DisplayList(List<FoodItem> foodList)
        {
            //display the list if empty
            if (foodList.Count == 0)
            {
                Console.WriteLine("The food list is currently empty.");
                return;
            }
            
            //display the list if not empty
            Console.WriteLine("Current Food Items:");
            foreach (var item in foodList)
            {
                //this is where we use the getters and setters here at the end that were assigned
                Console.WriteLine(
                    $"- {item.FoodName}, {item.CategoryName}, {item.QuantityItem} units, Expires on {item.ExpirationDate.ToShortDateString()}");
            }
        }
    }
