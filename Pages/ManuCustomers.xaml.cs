using AppointmentWPFDotNet6.Data;
using AppointmentWPFDotNet6.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppointmentWPFDotNet6.Pages
{
    /// <summary>
    /// Logique d'interaction pour ManuCustomers.xaml
    /// </summary>
    public partial class ManuCustomers : Page
    {
        AppointmentWPFContext db = new AppointmentWPFContext();
        private int updatingCustId = 0;

        //private readonly AppointmentWPFContext _db;
        public ManuCustomers()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem? s = sender as MenuItem;
            string? menuText = s!.Header.ToString();

            if (menuText == "Home")
            {

            }
            else if (menuText == "Client")
            {

            }
            else if (menuText == "Courtiers")
            {

            }
            else if (menuText == "Rendez-Vous")
            {

            }
            else if (menuText == "Login")
            {
            }

            else if (menuText == "Logout")
            {

            }
            else if (menuText == "Register")
            {

            }
        }

        private void NavBar_Click(object sender, RoutedEventArgs e)
        {
            NavBar? s = sender as NavBar;
            string? navText = s!.NavText.ToString();
            if (navText == "Home")
            {
                /*  grHomePage.Navigate(new System.Uri("Pages/HomePage.xaml",
              UriKind.RelativeOrAbsolute));*/
            }
            else if (navText == "Clients")
            {

            }
            else if (navText == "Courtiers")
            {

            }
            else if (navText == "Rendez-Vous")
            {

            }
            else if (navText == "Login")
            {

            }
            else if (navText == "Logout")
            {

            }
            else if (navText == "Register")
            {

            }

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AppointmentWPFContext db = new AppointmentWPFContext();
            //Customers customers = (Customers)sender;
            if (txtLastName.Text != ""
               && txtFirstName.Text != ""
               && txtEmail.Text != ""
               && txtPhone.Text != ""
               && txtBudget.Text != "")
            {
                Customer customers = new Customer()
                {
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Budget = Int32.Parse(txtBudget.Text)
                };

                db.Customers.Add(customers);

                /*  Customer dbcustomers = new Customer();
                  dbcustomers. = txtLastName.Text;
  */


                //db.Customers.Add(customers);
                db.SaveChanges();

                txtLastName.Text = "";
                txtFirstName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtBudget.Text = "0";
                Button_Click_Show(sender, e);
            }
            else
            {
                MessageBox.Show("Vous devez remplir tousles champs svp.");
            };

        }

        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
            // AppointmentWPFEntities db = new AppointmentWPFEntities();
            /*  var custs = from c in db.Customers
                          select new
                          {
                              c.FirstName,
                              c.LastName,
                              c.Email,
                              c.Phone,
                              c.Budget
                          };

              foreach (var c in custs)
              {
                  Console.WriteLine(c.FirstName);
              }
              this.grCustomers.ItemsSource = custs.ToList();*/

            this.grCustomers.ItemsSource = db.Customers.ToList();
        }

        private void grCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.grCustomers.SelectedIndex >= 0)
            {
                if (this.grCustomers.SelectedItems.Count >= 0)
                {
                    Customer custSelected = (Customer)this.grCustomers.SelectedItems;

                    this.updatingCustId = custSelected.Id;
                    this.txtLastNameEdit.Text = custSelected.LastName;
                    this.txtFirstNameEdit.Text = custSelected.FirstName;
                    this.txtEmailEdit.Text = custSelected.Email;
                    this.txtPhoneEdit.Text = custSelected.Phone;
                    this.txtBudgetEdit.Text = custSelected.Budget.ToString();

                    db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            var cust = db.Customers.Where(c => c.Id == updatingCustId).FirstOrDefault();

            if (cust != null)
            {
                cust.LastName = this.txtLastNameEdit.Text;
                cust.FirstName = this.txtFirstNameEdit.Text;
                cust.Email = this.txtEmailEdit.Text;
                cust.Phone = this.txtPhoneEdit.Text;
                cust.Budget = int.Parse(this.txtBudgetEdit.Text);

                db.SaveChanges();
                txtLastNameEdit.Text = "";
                txtFirstNameEdit.Text = "";
                txtEmailEdit.Text = "";
                txtPhoneEdit.Text = "";
                txtBudgetEdit.Text = "0";
                Button_Click_Show(sender, e);
            }

            var custtest = db.Customers.Where(c => c.Id == updatingCustId).FirstOrDefault();
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Confirmation de la Suppresion", "Suppresion du Client",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
                );

            if (msgBoxResult == MessageBoxResult.Yes)
            {
                 var cust = db.Customers.Where(c => c.Id == updatingCustId).FirstOrDefault();
                if (cust != null)
                {
                    db.Customers.Remove(cust);
                    db.SaveChanges();
                    txtLastNameEdit.Text = "";
                    txtFirstNameEdit.Text = "";
                    txtEmailEdit.Text = "";
                    txtPhoneEdit.Text = "";
                    txtBudgetEdit.Text = "0";
                    Button_Click_Show(sender, e);
                }
            }

        }

    }
}
