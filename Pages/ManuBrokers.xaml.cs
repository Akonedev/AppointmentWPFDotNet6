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
    /// Logique d'interaction pour ManuBrokers.xaml
    /// </summary>
    public partial class ManuBrokers : Page
    {
        AppointmentWPFContext db = new AppointmentWPFContext();
        private int updatingCustId = 0;
        public ManuBrokers()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem s = sender as MenuItem;
            string menuText = s.Header.ToString();

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
            NavBar s = sender as NavBar;
            string navText = s.NavText.ToString();
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
            if (txtLastName.Text != ""
               && txtFirstName.Text != ""
               && txtEmail.Text != ""
               && txtPhone.Text != ""
               )
            {
                Broker brokers = new Broker()
                {
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text                  
                };

                db.Brokers.Add(brokers);
                db.SaveChanges();

                txtLastName.Text = "";
                txtFirstName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                Button_Click_Show(sender, e);
            }
            else
            {
                MessageBox.Show("Vous devez remplir tousles champs svp.");
            };

        }

        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
            this.grBrokers.ItemsSource = db.Brokers.ToList();
        }

        private void grCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             // AppointmentWPFEntities db = new AppointmentWPFEntities();
            if (this.grBrokers.SelectedIndex >= 0)
            {
                if (this.grBrokers.SelectedItems.Count >= 0)
                {
                    Broker custSelected = (Broker)this.grBrokers.SelectedItems[0];

                    this.updatingCustId = custSelected.Id;
                    this.txtLastNameEdit.Text = custSelected.LastName;
                    this.txtFirstNameEdit.Text = custSelected.FirstName;
                    this.txtEmailEdit.Text = custSelected.Email;
                    this.txtPhoneEdit.Text = custSelected.Phone;
                    db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            var brok = db.Brokers.Where(c => c.Id == updatingCustId).FirstOrDefault();

            if (brok != null)
            {
                //cust.Id = updatingCustId;
                brok.LastName = this.txtLastNameEdit.Text;
                brok.FirstName = this.txtFirstNameEdit.Text;
                brok.Email = this.txtEmailEdit.Text;
                brok.Phone = this.txtPhoneEdit.Text;

                db.SaveChanges();
                txtLastNameEdit.Text = "";
                txtFirstNameEdit.Text = "";
                txtEmailEdit.Text = "";
                txtPhoneEdit.Text = "";
                Button_Click_Show(sender, e);
            }
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
                var brok = db.Brokers.Where(c => c.Id == updatingCustId).FirstOrDefault();
                if (brok != null)
                {
                    db.Brokers.Remove(brok);
                    db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }
    }
}
