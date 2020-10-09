using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace lab1BinaryTree
{
    public class NodeIsNullException : ArgumentNullException
    {
        public NodeIsNullException() { }

        public NodeIsNullException(string message) : base(message) { }

        public NodeIsNullException(string message, Exception innerException) : base(message, innerException) { }

        public NodeIsNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
