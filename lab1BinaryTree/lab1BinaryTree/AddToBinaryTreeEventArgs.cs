using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1BinaryTree
{
    public sealed class AddToBinaryTreeEventArgs<TItem> : EventArgs
    {
        public TItem AddedItem { get; private set; }
        public string Message { get; private set; }

        public AddToBinaryTreeEventArgs(TItem addedItem, string message)
        {
            Message = message;
            AddedItem = addedItem;
        }
    }
}
