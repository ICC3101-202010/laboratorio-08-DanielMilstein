using System;
using System.Collections.Generic;

namespace lab8
{
    public partial class Window2 : Gtk.Window
    {
        public Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();

        public List<string> cn = new List<string>() {"Name", "Business Hours", "Owner"
        , "Screens", "Categories", "Exclusive tables", "Local type", "ID"};

        public Window2() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            Deletable = false;

            Gtk.TreeViewColumn nameColumn = new Gtk.TreeViewColumn();
            nameColumn.Title = "Name";
            Gtk.TreeViewColumn idColumn = new Gtk.TreeViewColumn();
            idColumn.Title = "ID";
            Gtk.TreeViewColumn hColumn = new Gtk.TreeViewColumn();
            hColumn.Title = "Business Hours";
            Gtk.TreeViewColumn oColumn = new Gtk.TreeViewColumn();
            oColumn.Title = "Owner";
            Gtk.TreeViewColumn sColumn = new Gtk.TreeViewColumn();
            sColumn.Title = "Screens";
            Gtk.TreeViewColumn cColumn = new Gtk.TreeViewColumn();
            cColumn.Title = "Categories";
            Gtk.TreeViewColumn tColumn = new Gtk.TreeViewColumn();
            tColumn.Title = "Exclusive tables";
            Gtk.TreeViewColumn lColumn = new Gtk.TreeViewColumn();
            lColumn.Title = "Local type";

            ViewTree2.AppendColumn(idColumn);
            ViewTree2.AppendColumn(nameColumn);
            ViewTree2.AppendColumn(hColumn);
            ViewTree2.AppendColumn(oColumn);
            ViewTree2.AppendColumn(sColumn);
            ViewTree2.AppendColumn(cColumn);
            ViewTree2.AppendColumn(tColumn);
            ViewTree2.AppendColumn(lColumn);

            Gtk.ListStore viewListStore = new Gtk.ListStore(typeof(string), typeof(string), typeof(string)
                , typeof(string), typeof(string), typeof(string), typeof(string));

            

            foreach (var item in dictionary.Values)
            {
                viewListStore.AppendValues(item["ID"]);
                Gtk.CellRendererText IDCell = new Gtk.CellRendererText();
                idColumn.PackStart(IDCell, true);
                idColumn.AddAttribute(IDCell, item["ID"], 0);

                Gtk.CellRendererText NameCell = new Gtk.CellRendererText();
                nameColumn.PackStart(NameCell, true);
                nameColumn.AddAttribute(NameCell, item[cn[0]], 1);

                Gtk.CellRendererText Cell1 = new Gtk.CellRendererText();
                hColumn.PackStart(Cell1, true);
                hColumn.AddAttribute(Cell1, item[cn[1]], 2);

                Gtk.CellRendererText Cell2 = new Gtk.CellRendererText();
                oColumn.PackStart(Cell2, true);
                oColumn.AddAttribute(Cell2, item[cn[2]], 3);

                Gtk.CellRendererText Cell3 = new Gtk.CellRendererText();
                sColumn.PackStart(Cell3, true);
                sColumn.AddAttribute(Cell3, item[cn[3]], 4);

                Gtk.CellRendererText Cell4 = new Gtk.CellRendererText();
                cColumn.PackStart(Cell4, true);
                cColumn.AddAttribute(Cell4, item[cn[4]], 5);

                Gtk.CellRendererText Cell5 = new Gtk.CellRendererText();
                tColumn.PackStart(Cell5, true);
                tColumn.AddAttribute(Cell5, item[cn[5]], 6);

                Gtk.CellRendererText Cell6 = new Gtk.CellRendererText();
                lColumn.PackStart(Cell6, true);
                lColumn.AddAttribute(Cell6, item[cn[6]], 7);
            }
            ViewTree2.Model = viewListStore;





        }

        protected void OnBack2Clicked(object sender, EventArgs e)
        {
            Hide();
        }

        

        public void FillDict(List<Local> locals)
        {
            foreach (Local local in locals)
            {
                int id = local.GetId();
                string lname = local.GetName();
                string bhours = local.GetHours();
                string owner = local.GetOwner();
                string type = "";
                Dictionary<string, string> thisloc = new Dictionary<string, string>();
                thisloc.Add(cn[0], lname);
                thisloc.Add(cn[1], bhours);
                thisloc.Add(cn[2], owner);
                thisloc.Add(cn[7], id.ToString());
                if (local.GetType() == typeof(Cine))
                {
                    Cine cine = (Cine)local;
                    string nScreens = cine.GetScreens().ToString();
                    type = "Cine";
                    thisloc.Add(cn[3], nScreens);
                    thisloc.Add(cn[4], "NA");
                    thisloc.Add(cn[5], "NA");
                    thisloc.Add(cn[6], type);


                }

                else if (local.GetType() == typeof(Restaurant))
                {
                    string tables = "";
                    Restaurant res = (Restaurant)local;
                    type = "Restaurant";
                    if (res.GetTables() == true)
                    {
                        tables = "Yes";
                    }
                    else
                    {
                        tables = "No";
                    }
                    thisloc.Add(cn[3], "NA");
                    thisloc.Add(cn[4], "NA");
                    thisloc.Add(cn[5], tables);
                    thisloc.Add(cn[6], type);
                }

                else if (local.GetType() == typeof(Store))
                {
                    Store store = (Store)local;
                    type = "Store";
                    thisloc.Add(cn[3], "NA");
                    thisloc.Add(cn[4], "TBA");
                    thisloc.Add(cn[5], "NA");
                    thisloc.Add(cn[6], type);


                }

                else if (local.GetType() == typeof(Hobbie))
                {
                    type = "Hobbie";
                    thisloc.Add(cn[3], "NA");
                    thisloc.Add(cn[4], "NA");
                    thisloc.Add(cn[5], "NA");
                    thisloc.Add(cn[6], type);
                }
                dictionary.Add(id, thisloc);


            }
        }

        protected void OnViewTree2DeleteEvent(object o, Gtk.DeleteEventArgs args)
        {
        }

        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
        {
            Hide();
        }


        
    }
}
