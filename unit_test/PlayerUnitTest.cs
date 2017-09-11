using System;
using NUnit.Framework;
using System.Diagnostics;
namespace Swin_Adventure
{
    [TestFixture]
    public class PlayerUnitTest
    {
        Player newPlayer;
        Inventory newInventory;
        Item shovel;

        [SetUp]
        public void SetUp()
        {
            newPlayer = new Player("me", "inventory");
            newInventory = newPlayer.Inventory;
            shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine");

            newInventory.Put(shovel);
        }

        [Test]
        public void IsIdentifiable()
        {            
            Assert.IsTrue(newPlayer.AreYou("me"));
            Assert.IsTrue(newPlayer.AreYou("inventory"));
        }

        [Test]
        public void LocateItem()
        {
            Assert.AreEqual(shovel, newInventory.Fetch("shovel"));
        }

        [Test]
        public void LocateSelf()
        {
            Assert.AreEqual(newPlayer, newPlayer.Locate("me"));
            Assert.AreEqual(newPlayer, newPlayer.Locate("inventory"));
        }

        [Test]
        public void LocateNull()
        {
            Assert.AreEqual(null, newPlayer.Locate("stick"));
        }

        [Test]
        public void FullDescription()
        {
            Item pc = new Item(new string[] { "pc" }, "a computer", "A Personal Computer");
            newInventory.Put(pc);

            Assert.AreEqual("You are Fred the mighty programmer\nYou are carrying\n\ta shovel (shovel)\n\ta computer (pc)\n", newPlayer.FullDescription);
            TestContext.WriteLine(newPlayer.FullDescription);
        }
    }
}
