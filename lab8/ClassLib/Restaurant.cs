using System;
namespace lab8
{
    public class Restaurant : Local
    {
        private bool ExclTables;

        public Restaurant(string name, int id, string hours, string owner, bool tables) : base(name, id, hours, owner)
        {
            ExclTables = tables;
        }
    }
}
