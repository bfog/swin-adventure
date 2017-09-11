using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace Swin_Adventure
{
    public class IdentifiableObject
    {
        private List<String> _identifiers = new List<string>();

       public IdentifiableObject(string[] idents)
        {
            foreach(string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                return _identifiers[0];
            }
        }
    }

}
