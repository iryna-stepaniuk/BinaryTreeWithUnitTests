using System;
using NUnit.Framework;

namespace lab1BinaryTree.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void CreateBinaryTree_WithNullRootInConstructor_ThrowNodeIsNullException()
        {
            BinaryTree<string> testTree;

            Assert.Throws<NodeIsNullException>(() => testTree = new BinaryTree<string>(null));
        }

        [Test]
        public void CreateBinaryTree_WithCorrectRootInConstructor_TreeIsCreatedWithInputRoot()
        {
            BinaryTree<string> testTree = new BinaryTree<string>("Root");

            Assert.AreEqual("Root", testTree.Node);
        }

        [Test]
        public void Add_CorrectNodeToEmptyTree_TreeIsCreatedWithInputRoot()
        {
            BinaryTree<string> testTree = new BinaryTree<string>();

            testTree.Add("Root");

            Assert.AreEqual("Root", testTree.Node);
        }

        [Test]
        public void Add_NullNodeToExistingTree_ThrowNodeIsNullException()
        {
            BinaryTree<int> testTree = new BinaryTree<int>(1);

            Assert.Throws<NodeIsNullException>(() => testTree.Add(null) );
        }

        [TestCase("A")]
        [TestCase("C")]
        public void Add_CorrectNodeToExistingTree_ReturnTrue(string newNode)
        {
            BinaryTree<string> testTree = new BinaryTree<string>("B");

            testTree.Add(newNode);

            Assert.IsTrue(testTree.Contains(newNode));
        }

        [Test]
        public void Add_ListOfElementsToExistingTree_ReturnTrue()
        {
            BinaryTree<string> testTree = new BinaryTree<string>("B");
            string[] nodes = { "Q", "A", "C", "M" };

            testTree.Add(nodes);

            Assert.Multiple(() =>
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    Assert.IsTrue(testTree.Contains(nodes[i]),$"Tree doesn't contain node №{i+1}");
                }
                
            });
        }

        [Test]
        public void Contains_NodeWhichIsInTree_ReturnTrue()
        {
            BinaryTree<int> testTree = new BinaryTree<int>(1);

            bool actual = testTree.Contains(1);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Contains_NodeWhichIsNotInTree_ReturnFalse()
        {
            BinaryTree<int> testTree = new BinaryTree<int>(1);

            bool actual = testTree.Contains(6);

            Assert.AreEqual(false, actual);
        }


    }
}
