using System;
using System.Collections.Generic;
using Gtk;
using ClassLib;
using lab8;

public partial class MainWindow : Gtk.Window
{
    
    public Window2 w2 = new Window2();
    public List<Local> Locals;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        Locals = new List<Local>();

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnViewButtonClicked(object sender, EventArgs e)
    {
        DoneLabel.Hide();
        w2.Show();
        
    }

    

    protected void OnAddButtonClicked(object sender, EventArgs e)
    {
        DoneLabel.Hide();
        NameLabel.Show();
        NameBox.Show();
        TypeLabeld.Show();
        Typebox.Show();
        OwnerLabel.Show();
        OwnerBox.Show();
        AddButton.Hide();
        ViewButton.Hide();
        BackButton.Show();
        DoneButton.Show();
        HoursBox.Show();
        HoursLabel.Show();
    }

    protected void OnTypeboxChanged(object sender, EventArgs e)
    {
        ComboBox it = (ComboBox)sender;
        ScreenLabel.Hide();
        ScreenSpin.Hide();
        CatLabel.Hide();
        CatBox.Hide();
        ExcLabel.Hide();
        ExTablesButton.Hide();
        

        if (it.ActiveText == "Cine")
        {
            ScreenLabel.Show();
            ScreenSpin.Show();
        }
        else if (it.ActiveText == "Restaurant")
        {
            ExcLabel.Show();
            ExTablesButton.Show();

        }
        else if (it.ActiveText == "Store")
        {
            CatLabel.Show();
            CatBox.Show();
            


        }

        else if (it.ActiveText == "Hobbie")
        {

        }



      
    }

    protected void OnBackButtonClicked(object sender, EventArgs e)
    {
        Back();
        DoneLabel.Hide();
    }

    protected void Back()
    {
        NameLabel.Hide();
        NameBox.Hide();
        NameBox.Text = "";
        TypeLabeld.Hide();
        Typebox.Hide();
        OwnerLabel.Hide();
        OwnerBox.Hide();
        OwnerBox.Text = "";
        AddButton.Show();
        ViewButton.Show();
        BackButton.Hide();
        DoneButton.Hide();
        ScreenLabel.Hide();
        ScreenSpin.Hide();
        ScreenSpin.Text = "0";
        CatLabel.Hide();
        CatBox.Hide();
        ExcLabel.Hide();
        ExTablesButton.Hide();
        ExTablesButton.Active = false;
        HoursLabel.Hide();
        HoursBox.Hide();
        HoursBox.Text = "";
        
        
    }

    protected void OnDoneButtonClicked(object sender, EventArgs e)
    {

        string ty = Typebox.ActiveText;
        int id = Locals.Count + 1;
        if (ty == "Cine")
        {
            Cine cine = new Cine(NameBox.Text, id, HoursBox.Text, OwnerBox.Text, ScreenSpin.ValueAsInt);
            LocalController.Locals.Add(cine);
        }

        else if (ty == "Hobbie")
        {
            Hobbie hobbie = new Hobbie(NameBox.Text, id, HoursBox.Text, OwnerBox.Text);
            LocalController.Locals.Add(hobbie);
        }
        else if (ty == "Restaurant")
        {
            Restaurant restaurant = new Restaurant(NameBox.Text, id, HoursBox.Text, OwnerBox.Text, ExTablesButton.Active);
            LocalController.Locals.Add(restaurant);
        }

        else if (ty == "Store")
        {
            string cats = CatBox.Text;
            List<string> x = new List<string>();
            foreach (string cat in cats.Split(','))
            {
                x.Add(cat);
            }
            Store store = new Store(NameBox.Text, id, HoursBox.Text, OwnerBox.Text, x);
            LocalController.Locals.Add(store);
        }

        DoneLabel.Text = $"Local N˚ {LocalController.Locals.Count} created!";
        DoneLabel.Show();
        Back();
    }
}
