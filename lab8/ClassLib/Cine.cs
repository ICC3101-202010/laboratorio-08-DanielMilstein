using System;
namespace lab8
{
    public class Cine : Local
    {
        private int NofScreens;
        public Cine(string name, int id, string hours, string owner, int screens): base(name, id, hours, owner)
        {
            NofScreens = screens;
        }

        public int GetScreens() { return NofScreens; }
    }
}
