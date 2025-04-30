using Code.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Code.Tests
{
    [TestFixture]
    public class ContainerTest
    {
        private Container _container;
        private ItemStack _itemStack, _itemStack2, _itemStackBig;
        private Item _item, _itemBig;

        [SetUp]
        public void Setup()
        {
            _container = new Container(9, 5);
            _item = ScriptableObject.CreateInstance<Item>();
            _item.id = 1;
            _item.name = "Test";
            _item.width = 2;
            _item.height = 1;
            _item.price = 1000;
            _itemStack = new ItemStack(_item);
            _itemStack2 = new ItemStack(_item);
            _itemBig = ScriptableObject.CreateInstance<Item>();
            _itemBig.id = 2;
            _itemBig.name = "Test";
            _itemBig.width = 6;
            _itemBig.height = 6;
            _itemBig.price = 7000;
            _itemStackBig = new ItemStack(_itemBig);
        }

        [Test]
        public void TestGetItemStack()
        {
            _container.AddItemStack(_itemStack, 1, 1);
            Assert.AreEqual(null, _container.GetItemStack(2, -1));
            Assert.AreEqual(null, _container.GetItemStack(-2, 1));
            Assert.AreEqual(_itemStack, _container.GetItemStack(1, 1));
            Assert.AreEqual(null, _container.GetItemStack(0, 1));
        }

        [Test]
        public void TestAddItemStack()
        {
            Assert.AreEqual(_itemStack, _container.AddItemStack(_itemStack, 2, 2));
            Assert.AreEqual(null, _container.AddItemStack(_itemStack, 2, 2));
            Assert.AreEqual(null, _container.AddItemStack(_itemStackBig));
            Assert.AreEqual(_itemStack2, _container.AddItemStack(_itemStack2));
        }

        [Test]
        public void TestCanAddItemStack()
        {
            Assert.AreEqual(true, _container.CanAddItemStack(_itemStack, 7, 4));
            Assert.AreEqual(false, _container.CanAddItemStack(_itemStack, 7, 5));
            Assert.AreEqual(false, _container.CanAddItemStack(_itemStack, 7, 9));
            Assert.AreEqual(false, _container.CanAddItemStack(_itemStack, 9, 3));
            Assert.AreEqual(false, _container.CanAddItemStack(_itemStack, 8, 1));
            _container.AddItemStack(_itemStack, 2, 1);
            Assert.AreEqual(false, _container.CanAddItemStack(_itemStack, 2, 1));
        }
    }
}