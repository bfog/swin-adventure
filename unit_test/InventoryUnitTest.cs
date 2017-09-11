using System;
using NUnit.Framework;

namespace Swin_Adventure
{
    [TestFixture]
    public class InventoryUnitTest
    {
        Player newPlayer;
        Inventory newInventory;
        Item shovel;

        [SetUp]
        public void SetUp()
        {
            newPlayer = new Player("me", "inventory");
            newInventory = new Inventory();
            shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine");

            newInventory.Put(shovel);
        }

        [Test]
        public void FindItem()
        {
            Assert.IsTrue(newInventory.HasItem("shovel"));
        }

        [Test]
        public void NoItemFind()
        {
            Assert.IsFalse(newInventory.HasItem("rock"));
        }

        [Test]
        public void FetchItem()
        {
            Assert.AreEqual(shovel, newInventory.Fetch("shovel"));
        }

        [Test]
        public void TakeItem()
        {
            Assert.AreEqual(shovel, newInventory.Take("shovel"));
            Assert.IsFalse(newInventory.HasItem("shovel"));
        }

        [Test]
        public void ItemList()
        {
            Item pc = new Item(new string[] { "pc"}, "a computer", "A Personal Computer");

            newInventory.Put(pc);
            Assert.AreEqual("\ta shovel (shovel)\n\ta computer (pc)\n", newInventory.ItemList);           
        }
    }
}
