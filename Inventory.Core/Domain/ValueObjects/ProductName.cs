using Inventory.Core.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Domain.ValueObjects
{
    public class ProductName
    {
        public string Value { get; }

        public ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 250 or < 2)
            {
                throw new InvalidProductNameException(value);
            }

            Value = value;
        }

        public static implicit operator ProductName(string value) => value is null ? null : new ProductName(value);

        public static implicit operator string(ProductName value) => value?.Value;

        public override int GetHashCode() => Value is not null ? Value.GetHashCode() : 0;

        public override string ToString() => Value;
    }
}


