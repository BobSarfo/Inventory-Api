using Inventory.Shared.Exceptions;


namespace Inventory.Core.Domain.Exception
{
    internal sealed class InvalidCustomerNameException : InventoryException
    {
        public string CustomerName { get; }

        public InvalidCustomerNameException(string customerName) : base($"Customer name: '{customerName}' is invalid.")
        {
            CustomerName = customerName;
        }
    }
}