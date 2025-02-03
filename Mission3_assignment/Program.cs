//Sarah Boyer Mission 3

// See https://aka.ms/new-console-template for more information

//information: all 4 items
//create new instance of the item
//add it to a list, use .add

// • Add Food Items
// • Delete Food Items
// • Print List of Current Food Items
// use a loop for this
// • Exit the Program

//connect to my foodstorage
using Mission3_assignment;

//create a loop so that the user can choose what they want to do
bool restart = true;

//create a list
List<FoodItem> foodList = new List<FoodItem>();

while (restart)
{
    //user input for what they want to do
    Console.WriteLine("Welcome to the Food Bank! What would you like to do?: ");
    Console.WriteLine("Enter a number: \n1.Add food item \n2.Delete food item \n3.Print list of current food item \n4.Exit the program");

    //store the user input
    string userInput = "";
    userInput = Console.ReadLine();
    int choice;

    //check if the user input is valid
    while (!int.TryParse(userInput, out choice) || choice < 1 || choice > 4)
    {
        Console.WriteLine("Invalid Entry, Try Again");
        restart = true;
    }

    //create a switch statement for the user input
    switch (choice)
    {
        case 1:
            //create a new instance
            FoodItem newFood = new FoodItem();
            
            //call the method for adding
            newFood.AddFood(foodList);  // Pass foodList to the method
            break;
        case 2:
            
            //call the method for deleting
            FoodItem.DeleteFood(foodList);  // Pass foodList to the method
            break;
        case 3:
            
            //call the method for displaying
            FoodItem.DisplayList(foodList);  // Pass foodList to the method
            break;
        case 4:
            
            //call the method for exiting
            restart = false;  // Exit the program
            break;
    }
    
}

