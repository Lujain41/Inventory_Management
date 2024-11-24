using System;

public class Item
{
    // Private fields
    private string _name;
    private int _quantity;
    private DateTime _createdDate;

    // Constructor to initialize an Item object
    public Item(string name, int quantity, DateTime? createdDate = null)
    {
        _name = name;
        _quantity = quantity >= 0 ? quantity : throw new ArgumentException("Quantity cannot be negative.");
        _createdDate = createdDate ?? DateTime.Now;
    }

    // Public properties to access private fields
    public string Name => _name;
    public int Quantity => _quantity;
    public DateTime CreatedDate => _createdDate;
}
