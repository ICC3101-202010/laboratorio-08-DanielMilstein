using System;
using System.Collections.Generic;
using ClassLib;

namespace lab8
{
    public partial class Window2 : Gtk.Window
    {
        

        public List<string> cn = new List<string>() {"Name", "Business Hours", "Owner"
        , "Screens", "Categories", "Exclusive tables", "Local type", "ID"};

        public Window2() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            
            Deletable = false;
            
            Dictionary<int, Dictionary<string, string>> dict = LocalController.FillDict();
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


            ViewTree2.Model = viewListStore;
            Gtk.CellRendererText IDCell = new Gtk.CellRendererText();
            Gtk.CellRendererText NameCell = new Gtk.CellRendererText();
            Gtk.CellRendererText Cell1 = new Gtk.CellRendererText();
            Gtk.CellRendererText Cell2 = new Gtk.CellRendererText();
            Gtk.CellRendererText Cell3 = new Gtk.CellRendererText();
            Gtk.CellRendererText Cell4 = new Gtk.CellRendererText();
            Gtk.CellRendererText Cell5 = new Gtk.CellRendererText();
            Gtk.CellRendererText Cell6 = new Gtk.CellRendererText();




            foreach (Dictionary<string,string> item in dict.Values)
            {
                viewListStore.AppendValues(item["ID"], item[cn[0]], item[cn[1]], item[cn[2]],
                    item[cn[3]], item[cn[4]], item[cn[5]], item[cn[6]]);
                
                idColumn.PackStart(IDCell, true);
                idColumn.AddAttribute(IDCell, "text", 0);

                //viewListStore.AppendValues(item[cn[0]]);
                
                nameColumn.PackStart(NameCell, true);
                nameColumn.AddAttribute(NameCell, "text", 1);

                //viewListStore.AppendValues(item[cn[1]]);
                
                hColumn.PackStart(Cell1, true);
                hColumn.AddAttribute(Cell1, "text", 2);

                //viewListStore.AppendValues(item[cn[2]]);
                
                oColumn.PackStart(Cell2, true);
                oColumn.AddAttribute(Cell2, "text", 3);

                //viewListStore.AppendValues(item[cn[3]]);
                
                sColumn.PackStart(Cell3, true);
                sColumn.AddAttribute(Cell3, "text", 4);

                //viewListStore.AppendValues(item[cn[4]]);
                
                cColumn.PackStart(Cell4, true);
                cColumn.AddAttribute(Cell4, "text", 5);

                //viewListStore.AppendValues(item[cn[5]]);
                
                tColumn.PackStart(Cell5, true);
                tColumn.AddAttribute(Cell5, "text", 6);

                //viewListStore.AppendValues(item[cn[6]]);
                
                lColumn.PackStart(Cell6, true);
                lColumn.AddAttribute(Cell6, "text", 7);
            }
            





        }

        protected void OnBack2Clicked(object sender, EventArgs e)
        {
            Hide();
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
