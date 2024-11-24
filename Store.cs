using System;
using System.Collections.Generic;
using System.Linq;

public class Store
{
    // Private fields
    private List<Item> _items; // Collection to store items
    private int _capacity; // Maximum number of items allowed in the store

    // Constructor to initialize the Store object
    // Initializes an empty list to hold the items and sets the maximum capacity
    public Store(int capacity)
    {
        _items = new List<Item>();
        _capacity = capacity;
    }

    // Method to add a new item to the store
    // Throws an exception if adding the item would exceed the store's capacity
    // Also throws an exception if an item with the same name already exists
    public void AddItem(Item item)
    {
        // Check if adding the new item would exceed the store's capacity
        if (GetCurrentVolume() + item.Quantity > _capacity)
        {
            throw new InvalidOperationException("Adding this item would exceed the store's capacity.");
        }

        // Check if an item with the same name already exists in the store
        if (FindItemByName(item.Name) != null)
        {
            throw new ArgumentException("An item with that name is already in the store.");
        }

        // Add the new item to the list
        _items.Add(item);
    }

    // Method to remove an item from the store by its name
    // Throws an exception if the item is not found
    public void RemoveItem(string itemName)
    {
        // Find the item to remove by its name
        var itemToRemove = FindItemByName(itemName);
        if (itemToRemove != null)
        {
            // Remove the item from the list if found
            _items.Remove(itemToRemove);
        }
        else
        {
            // Throw an exception if the item was not found
            throw new ArgumentException("The specified item does not exist.");
        }
    }

    // Method to calculate the total quantity of all items in the store
    // Uses LINQ to sum up the quantities of all items
    public int GetCurrentVolume()
    {
        return _items.Sum(item => item.Quantity);
    }

    // Method to find an item in the store by its name
    // Returns the item if found, otherwise returns null
    public Item FindItemByName(string name)
    {
        // Use LINQ to find the first item that matches the name 
        return _items.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // Method to get a list of items sorted by their names in ascending order
    // Returns the sorted list of items
    public List<Item> SortByNameAsc()
    {
        // Use LINQ to order items by their name and convert the result to a list
        return _items.OrderBy(item => item.Name).ToList();
    }

    // Method to sort items by their creation date
    // Returns a list of items sorted by date in ascending or descending order
    public List<Item> SortByDate(SortOrder sortOrder)
    {
        if (sortOrder == SortOrder.ASC)
        {
            return _items.OrderBy(item => item.CreatedDate).ToList();
        }
        else
        {
            return _items.OrderByDescending(item => item.CreatedDate).ToList();
        }
    }

    // Method to group items by their creation date
    // Returns a dictionary with "New Arrival" and "Old" as keys
    public Dictionary<string, List<Item>> GroupByDate()
    {
        var threeMonthsAgo = DateTime.Now.AddMonths(-3);
        var groupedItems = new Dictionary<string, List<Item>>();

        groupedItems["New Arrival"] = _items.Where(item => item.CreatedDate >= threeMonthsAgo).ToList();
        groupedItems["Old"] = _items.Where(item => item.CreatedDate < threeMonthsAgo).ToList();

        return groupedItems;
    }
}

// Enum to specify sort order
public enum SortOrder
{
    ASC, // Ascending
    DESC // Descending
}


