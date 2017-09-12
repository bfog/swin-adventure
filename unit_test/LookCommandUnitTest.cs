using System;
using NUnit.Framework;

namespace Swin_Adventure
{
    [TestFixture]
    public class LookCommandUnitTest
    {
        Player newPlayer;
        Inventory bagInventory, playerInventory;
        Item gem;
        LookCommand look;
        Bag bag;

        [SetUp]
        public void SetUp()
        {
            newPlayer = new Player("me", "inventory");
            bag = new Bag(new string[] { "bag" }, "a bag", "A bag which contains items");
            playerInventory = newPlayer.Inventory;
            bagInventory = bag.Inventory;
            gem = new Item(new string[] { "gem"}, "a gem", "A shiny red gemS");
            look = new LookCommand(new string[] { "look" });

            playerInventory.Put(bag);
            playerInventory.Put(gem);
        }
        
        [Test]
        public void LookAtMe()
        {
            Assert.AreEqual("You are Fred the mighty programmer\nYou are carrying\n\ta bag (bag)\n\ta gem (gem)\n", look.Execute(newPlayer, new string[] { "look", "at", "inventory"}));
        }

        [Test]
        public void LookAtGem()
        {
            Assert.AreEqual("You are carrying a gem (gem)", look.Execute(newPlayer, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void LookAtUnk()
        {
            playerInventory.Take("gem"); //remove gem item first

            Assert.AreEqual("I cannot find the gem", look.Execute(newPlayer, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void LookAtGemInMe()
        {
            Assert.AreEqual("You are carrying a gem (gem)", look.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [Test]
        public void LookAtGemInBag()
        {
            bagInventory.Put(gem);

            Assert.AreEqual("You are carrying a gem (gem)", look.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void LookAtGemInNoBag()
        {
            bagInventory.Put(gem);
            playerInventory.Take("bag");

            Assert.AreEqual("I cannot find the bag", look.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void LookAtNoGemInBag()
        {
            Assert.AreEqual("I cannot find the gem", look.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void InvalidLook()
        {
            Assert.AreEqual("I don't know how to look like that", look.Execute(newPlayer, new string[] { "look", "test" }));
            Assert.AreEqual("Error in look input", look.Execute(newPlayer, new string[] { "test", "at", "gem" }));
            Assert.AreEqual("What do you want to look at?", look.Execute(newPlayer, new string[] { "look", "test", "gem" }));
            Assert.AreEqual("What do you want to look in?", look.Execute(newPlayer, new string[] { "look", "at", "gem", "test", "bag" }));
        }
    }
}
