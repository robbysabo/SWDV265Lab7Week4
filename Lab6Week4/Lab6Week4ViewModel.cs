using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections;

namespace Lab6Week4;

public class Lab6Week4ViewModel : INotifyPropertyChanged
{
    /*private ArrayList toppings = new ArrayList { "Pepperoni", "Bellpepper", "Mushroom", "Olive" };
    //private List<string> toppings = ["Pepperoni","Bellpepper","Mushroom","Olive"];
    
    public ArrayList Toppings
    {
        get => toppings;
        set
        {
            toppings.Add(value);
            OnPropertyChanged();
        }
    }*/

    public string ToppingText
    {
        get
        {
            string txt = String.Empty;
            foreach (string item in toppings["toppings"])
            {
                txt += item + ", ";
            }

            txt = txt.Substring(0, txt.Length - 2);
            return txt;
        }
        set
        {
            ArrayList currentToppings = toppings["toppings"];
            currentToppings.Add(value);
            Toppings = new Dictionary<string, ArrayList> { {"toppings",currentToppings } };
            OnPropertyChanged();
        }
    }

    private Dictionary<string, ArrayList> toppings = new Dictionary<string, ArrayList>
    {
        { "toppings",new ArrayList{ "Pepperoni", "Bellpepper", "Mushroom", "Olive" } }
    };
    public Dictionary<string, ArrayList> Toppings
    {
        get { return toppings; }
        set 
        { 
            toppings = value;
            OnPropertyChanged();
        }
    }


    public ICommand EnterNewTopping
    { 
        get; 
        private set; 
    }

    private void OnEnterNewTopping(string newEntryText)
    {
        ToppingText = newEntryText;
    }

    public Lab6Week4ViewModel()
    {
        EnterNewTopping = new Command((newTopping) => OnEnterNewTopping((string)newTopping));
    }


    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler? PropertyChanged;
}