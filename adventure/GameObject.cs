using System;

namespace Swin_Adventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;
        }

        public string ShortDescription
        {
            get
            {
                return _name + " " + "(" + FirstId + ")";
            }
        }

        public string Name { get => _name; }

        public virtual string FullDescription { get => _description; }
    }
}
