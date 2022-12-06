using Inventory.Shared.Exceptions;


namespace Inventory.Core.Domain.Exception
{
    internal sealed class InvalidProductNameException : InventoryException
    {
        public string ProductName { get; }

        public InvalidProductNameException(string productName) : base($"Product name: '{productName}' is invalid.")
        {
            ProductName = productName;
        }
    }
}