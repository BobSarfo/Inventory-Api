using Inventory.Core.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Domain.ValueObjects
{
    public record CustomerName
    {
        public string Value { get; }

        public CustomerName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 2)
            {
                throw new InvalidCustomerNameException(value);
            }

            Value = value;
        }

        public static implicit operator CustomerName(string value) => value is null ? null : new CustomerName(value);

        public static implicit operator string(CustomerName value) => value?.Value;

        public override int GetHashCode() => Value is not null ? Value.GetHashCode() : 0;

        public override string ToString() => Value;
    }
}


