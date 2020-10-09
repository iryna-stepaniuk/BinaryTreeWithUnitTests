using System;
using System.Collections;
using System.Collections.Generic;

namespace lab1BinaryTree
{
    public class BinaryTree<TItem> : ICollection<TItem> where TItem : IComparable<TItem>
    {
        public BinaryTree<TItem> LeftTree { get; private set; }
        public BinaryTree<TItem> RightTree { get; private set; }
        public TItem Node { get; private set; }

        public event EventHandler<AddToBinaryTreeEventArgs<TItem>> Added;
        public event EventHandler<CheckIfBinaryTreeContainsItemEventArgs<TItem>> CheckIfContains;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public bool IsReadOnly => false;
        public BinaryTree() { }
        public BinaryTree(TItem node)
        {
            if (node!=null)
            {
                this.Node = node;
                Count++;
            }
            else throw new NodeIsNullException("Node is NULL");
        }

        public void Add(TItem item)
        {
            if (item != null)
            {
                if (IsEmpty) {
                    this.Node = item;
                    this.Count++;
                    Added?.Invoke(this, new AddToBinaryTreeEventArgs<TItem>(item, $"{item} added to root"));
                }
                else
                {
                    if (this.Node.CompareTo(item) > 0)
                    {
                        if (this.LeftTree == null)
                        {
                            this.LeftTree = new BinaryTree<TItem>(item);
                            Added?.Invoke(this, new AddToBinaryTreeEventArgs<TItem>(item, $"{item} added to left tree"));
                        }

                        else
                        {
                            this.LeftTree.Add(item);
                            Added?.Invoke(this, new AddToBinaryTreeEventArgs<TItem>(item, $"{item} added to left tree"));
                        }
                    }
                    else
                    {
                        if (this.RightTree == null)
                        {
                            this.RightTree = new BinaryTree<TItem>(item);
                            Added?.Invoke(this, new AddToBinaryTreeEventArgs<TItem>(item, $"{item} added to right tree"));
                        }

                        else
                        {
                            this.RightTree.Add(item);
                            Added?.Invoke(this, new AddToBinaryTreeEventArgs<TItem>(item, $"{item} added to right tree"));
                        }
                    }
                }
                      
            }
            else throw new NodeIsNullException("Node is NULL");
        }

        public void Add(params TItem[] items)
        {
            if (items is null) throw new NodeIsNullException("Node is NULL");
            else
            {
                foreach (TItem item in items)
                {
                    this.Add(item);
                }
            }
        }

        public bool Contains(TItem item)
        {
            foreach (var n in this.InOrder(this.Node))
            {
                if (item.Equals(n))
                {
                    CheckIfContains?.Invoke(this, new CheckIfBinaryTreeContainsItemEventArgs<TItem>(item, $"{item} contains in tree"));
                    return true;
                }
            }
            CheckIfContains?.Invoke(this, new CheckIfBinaryTreeContainsItemEventArgs<TItem>(item, $"{item} doesn't contain in tree"));
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            return InOrder(this.Node).GetEnumerator();
        }

        public IEnumerable<TItem> PreOrder(TItem node)
        {
            if (node != null)
            {
                yield return node;
                if (LeftTree != null)
                {
                    foreach (var x in LeftTree.PreOrder(LeftTree.Node))
                    {
                        yield return x;
                    }
                }
                if (RightTree != null)
                {
                    foreach (var x in RightTree.PreOrder(RightTree.Node))
                    {
                        yield return x;
                    }
                }

            }

        }

        public IEnumerable<TItem> InOrder(TItem node)
        {
            if (node != null)
            {
                if (LeftTree != null)
                {
                    foreach (var x in LeftTree.PreOrder(LeftTree.Node))
                    {
                        yield return x;
                    }
                }
                yield return node;
                if (RightTree != null)
                {
                    foreach (var x in RightTree.PreOrder(RightTree.Node))
                    {
                        yield return x;
                    }
                }

            }

        }

        public IEnumerable<TItem> PostOrder(TItem node)
        {
            if (node != null)
            {
                if (LeftTree != null)
                {
                    foreach (var x in LeftTree.PreOrder(LeftTree.Node))
                    {
                        yield return x;
                    }
                }

                if (RightTree != null)
                {
                    foreach (var x in RightTree.PreOrder(RightTree.Node))
                    {
                        yield return x;
                    }
                }
                yield return node;

            }

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TItem item)
        {
            throw new NotImplementedException();
        }

    }
}