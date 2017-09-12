using System;

namespace Swin_Adventure
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);

        string Name { get; } 
    }
}
