using System;
using System.Collections.Generic;
using lab8;

namespace ClassLib
{
    public static class LocalController
    {
        public static Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();
        public static List<string> cn = new List<string>() {"Name", "Business Hours", "Owner"
        , "Screens", "Categories", "Exclusive tables", "Local type", "ID"};
        public static List<Local> Locals = new List<Local>();


        public static void FillDict(List<Local> locals)
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
                    string cats = "";
                    foreach (string cat in store.GetCats())
                    {
                        cats += cat;
                        cats += ", ";
                    }
                    cats = cats.Substring(0, cats.Length - 2);
                    thisloc.Add(cn[3], "NA");
                    thisloc.Add(cn[4], cats);
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
    }
}
