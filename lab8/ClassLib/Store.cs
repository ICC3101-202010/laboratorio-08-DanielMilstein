using System;
using System.Collections.Generic;

namespace lab8
{
    public class Store : Local
    {
        protected List<string> Categories;

        public Store(string name, int id, string hours, string owner, List<string> categories) : base(name, id, hours, owner)
        {
            Categories = categories;
        }

        public List<string> GetCats()
            {
                return Categories;
            }
    }
}
