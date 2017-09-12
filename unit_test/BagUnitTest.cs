using System;
using NUnit.Framework;

namespace Swin_Adventure
{
    [TestFixture]
    public class BagUnitTest
    {
        Bag b1;
        Inventory b1Inventory;
        Item shovel;

        [SetUp] 
        public void SetUp()
        {
            b1 = new Bag(new string[] { "b1", "bag" }, "bag", "A bag which contains items");
            b1Inventory = b1.Inventory;
            shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine");

            b1Inventory.Put(shovel);
        }

        [Test]
        public void LocatesItems()
        {
            Assert.AreEqual(shovel, b1.Locate("shovel"));
        }
    
        [Test]
        public void LocateSelf()
        {
            Assert.AreEqual(b1, b1.Locate("b1"));
        }

        [Test]
        public void LocateNull()
        {
            Assert.AreEqual(null, b1.Locate("sword"));
        }

        [Test]
        public void BagFullDescription()
        {
            Assert.AreEqual("In the b1 you can see:\n\ta shovel (shovel)\n", b1.FullDescription);
        }

        [Test]
        public void BagInBag()
        {
            Bag b2 = new Bag(new string[] { "b2", "bag" }, "bag", "A bag which contains items");
            Inventory b2Inventory = b2.Inventory;

            b1Inventory.Put(b2); //Add bag 2 into bag 1 inventory

            Assert.AreEqual(b2, b1.Locate("b2")); //locate bag 2 in bag 1 inventory
            Assert.AreEqual(shovel, b1.Locate("shovel"));

            Item hammer = new Item(new string[] { "hammer" }, "hammer", "You hit nails with it, or skulls....");
            b2Inventory.Put(hammer);

            Assert.AreEqual(null, b1.Locate("hammer"));
        }
    }
}
