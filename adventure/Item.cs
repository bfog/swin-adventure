using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc) { }

        public override string FullDescription
        {
            get
            {
                return "You are carrying " + ShortDescription;
            }
        }
    }
}
