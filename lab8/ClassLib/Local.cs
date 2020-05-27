using System;
using System.Collections.Generic;

namespace lab8
{
    public abstract class Local
    {
        protected string Name;
        protected int Id;
        protected string Hours;
        protected string Owner;
        

        public Local(string name, int id, string hours, string owner)
        {
            Name = name;
            Id = id;
            Hours = hours;
            Owner = owner;
        }

        public string GetName() { return Name; }

        public string GetHours() { return Hours; }

        public string GetOwner() { return Owner; }

        public int GetId() { return Id; }

        



    }
}
