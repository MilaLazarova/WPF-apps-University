using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public string MainCaptionText { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }

            }
        }

        public List<Person> ExpenseDataSource { get; set; }
        public ObservableCollection<String> PersonsChecked { get; set; }
        public ExpenseItHome()
        {
           
            InitializeComponent();

            this.DataContext = this;
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
            ExpenseDataSource = new List<Person>(){
new Person()
{
Name="Mike",
Department ="Legal",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
}
},
new Person()
{
Name ="Lisa",
Department ="Marketing",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
}
},
new Person()
{
Name="John",
Department ="Engineering",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
new Expense() { ExpenseType="Software", ExpenseAmount=500 }
}
},
new Person()
{
Name="Mary",
Department ="Finance",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
}
},
new Person()
{
Name="Theo",
Department ="Marketing",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
}
},
new Person()
{
Name="James",
Department ="Translating",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Birthday Party", ExpenseAmount=95 }
}
},
new Person()
{
Name="David",
Department ="Translating",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Costume", ExpenseAmount=400 }
}
}
};          
            PersonsChecked = new ObservableCollection<string>();
            
        }

      

        private void peopleListBox_SelectionChanged_1(object sender,SelectionChangedEventArgs e)

        {

            LastChecked = DateTime.Now;
            PersonsChecked.Add(lastChecked.ToString()+" - "+(peopleListBox.SelectedItem as Person).Name);
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ExpenseItReport expenseReport = new ExpenseItReport(this.peopleListBox.SelectedItem) {

                Width = this.Width,
                Height = this.Height

            };
            expenseReport.ShowDialog();


        }
    }
}
