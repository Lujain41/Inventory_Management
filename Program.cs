using System;

public class Program
{
    public static void Main()
    {
        // Create items with specific names, quantities, and optional creation dates
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 10, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 10, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 10, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 10, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 10, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 10, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 10, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 10, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 10, new DateTime(2023, 10, 1));
        // Defaults to current date
        var coffee = new Item("Coffee", 10); 
        var sandwich = new Item("Sandwich", 10);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 10);
        var sunscreen = new Item("Sunscreen", 10);

        // Create a store with a maximum capacity of 150 items
        var store = new Store(150);
        
        try
        {
            // Add items to the store
            store.AddItem(waterBottle);
            store.AddItem(chocolateBar);
            store.AddItem(notebook);
            store.AddItem(pen);
            store.AddItem(tissuePack);
            store.AddItem(chipsBag);
            store.AddItem(sodaCan);
            store.AddItem(soap);
            store.AddItem(shampoo);
            store.AddItem(toothbrush);
            store.AddItem(coffee);
            store.AddItem(sandwich);
            store.AddItem(batteries);
            store.AddItem(umbrella);
            store.AddItem(sunscreen);
            

            // Display the total quantity of items in the store
            Console.WriteLine("- The total quantity of Items: " + store.GetCurrentVolume()+"\n");
            
            // Attempt to add an item that would exceed the store's capacity
            var blackTea = new Item("Black Tea", 10); // Would exceed capacity if added
            store.AddItem(blackTea); // This should throw an exception
            
        }
        catch (InvalidOperationException ex)
        {
            // Handle exceptions related to invalid operations, such as exceeding store capacity
            Console.WriteLine("Error: " + ex.Message); // Display a message indicating the nature of the error
        }
        catch (ArgumentException ex)
        {
            // Handle exceptions related to invalid arguments, such as adding an item with a duplicate name
           Console.WriteLine("Error: " + ex.Message); // Display a message indicating the nature of the error
        }

        // Display the total quantity of items in the store after trying to add the large item
        Console.WriteLine("\n- The store's current total item count is: " + store.GetCurrentVolume());

        // Find and display items by their names
        // If the item is found (foundItem2 is not null), print its name
        // Otherwise, print "Not Found" 
        Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - -  ");
        Console.WriteLine("| Find and display items by their names:|");
        Console.WriteLine(" - - - - - - - - - - - - - - - - - - - -  ");

        var foundItem1 = store.FindItemByName("Water Bottle");
        Console.WriteLine("Found Item: " + (foundItem1 != null ? foundItem1.Name : "Not Found"));

        var foundItem2 = store.FindItemByName("Coffee");
        Console.WriteLine("Found Item: " + (foundItem2 != null ? foundItem2.Name : "Not Found"));

        var foundItem3 = store.FindItemByName("Eraser");
        Console.WriteLine("Found Item: " + (foundItem3 != null ? foundItem3.Name : "Not Found"));

        // Sort items by name and display them
        var sortedItems_1 = store.SortByNameAsc();
        Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - - ");
        Console.WriteLine("| Items Sorted by Name in Ascending Order:|");
        Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - ");
        foreach (var item in sortedItems_1)
        {
            Console.WriteLine(item.Name);
        }

        // Remove items from the store
        store.RemoveItem("Water Bottle");
        store.RemoveItem("Chocolate Bar");
        
        // Display the total quantity of items in the store after removal
        Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("| The total quantity of Items after removal: " + store.GetCurrentVolume()+"  |");
        Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - -");


        // Sort by date
        var sortedItems_2 = store.SortByDate(SortOrder.DESC);
        Console.WriteLine("\n - - - - - - - - - - - - - - - ");
        Console.WriteLine("| Sorted Items by Date (DESC): |");
        Console.WriteLine(" - - - - - - - - - - - - - - -  ");
        foreach (var item in sortedItems_2)
        {
            Console.WriteLine($"{item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
        }

        // Group by date
        var groupedItems = store.GroupByDate();
        foreach (var group in groupedItems)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group.Value)
            {
                Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
            }
        }
    }
}
