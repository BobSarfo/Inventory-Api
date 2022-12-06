using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Shared.Exceptions
{
    [Serializable]
    public class InventoryException : Exception
    {
        public InventoryException(string message) : base(message) { }
        public InventoryException(string message, Exception inner) : base(message, inner) { }
       
        public virtual string? Code { get; }

        protected InventoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }

}
