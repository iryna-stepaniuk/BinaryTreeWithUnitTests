using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1BinaryTree
{
    public sealed class CheckIfBinaryTreeContainsItemEventArgs<TItem> : EventArgs
    {
        public TItem CheckedItem { get; private set; }
        public string Message { get; private set; }

        public CheckIfBinaryTreeContainsItemEventArgs(TItem checkedItem, string message)
        {
            Message = message;
            CheckedItem = checkedItem;
        }
    }
}
