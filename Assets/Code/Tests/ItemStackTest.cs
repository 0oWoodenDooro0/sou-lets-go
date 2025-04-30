using System;
using Code.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Code.Tests
{
    [TestFixture]
    public class ItemStackTest
    {
        private ItemStack _itemStack, _itemStack2, _itemStack3;
        private Item _item, _item2;

        [SetUp]
        public void Setup()
        {
            _item = ScriptableObject.CreateInstance<Item>();
            _item.id = 1;
            _item.name = "Item";
            _item.width = 1;
            _item.height = 2;
            _item.price = 1000;
            _itemStack = new ItemStack(_item);
            _itemStack2 = new ItemStack(_item, 2);
            _itemStack2.ChangeOrientation();
            _item2 = ScriptableObject.CreateInstance<Item>();
            _item2.id = 2;
            _item2.name = "item";
            _item2.width = 2;
            _item2.height = 2;
            _item2.price = 2000;
            _itemStack3 = new ItemStack(_item2);
        }

        [Test]
        public void TestGetGuid()
        {
            Assert.IsTrue(Guid.TryParse(_itemStack.GetGuid(), out var guid));
        }

        [Test]
        public void TestGetWidth()
        {
            Assert.AreEqual(1, _itemStack.GetWidth());
            Assert.AreEqual(2, _itemStack2.GetWidth());
        }
        
        [Test]
        public void TestGetHeight()
        {
            Assert.AreEqual(2, _itemStack.GetHeight());
            Assert.AreEqual(1, _itemStack2.GetHeight());
        }

        [Test]
        public void TestGetOrientation()
        {
            Assert.AreEqual(ItemOrientation.Deafult, _itemStack.GetOrientation());
            Assert.AreEqual(ItemOrientation.Right, _itemStack2.GetOrientation());
        }

        [Test]
        public void TestChangeOrientation()
        {
            _itemStack.ChangeOrientation();
            Assert.AreEqual(ItemOrientation.Right, _itemStack.GetOrientation());
            _itemStack.ChangeOrientation();
            Assert.AreEqual(ItemOrientation.Deafult, _itemStack.GetOrientation());
            _itemStack3.ChangeOrientation();
            Assert.AreEqual(ItemOrientation.Deafult, _itemStack3.GetOrientation());
        }
    }
}