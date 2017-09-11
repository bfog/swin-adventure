using System;
using NUnit.Framework;

namespace Swin_Adventure
{
    [TestFixture]
    public class ItemUnitTest
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
        public void ItemIsIdentifiable()
        {
            Assert.IsTrue(shovel.AreYou("shovel"));
        }
        
        [Test]
        public void ShortDescription()
        {
            Assert.AreEqual("a shovel (shovel)", shovel.ShortDescription);
        }

        [Test]
        public void FullDescription()
        {
            Assert.AreEqual("You are carrying a shovel (shovel)", shovel.FullDescription);
        }
    }
}
