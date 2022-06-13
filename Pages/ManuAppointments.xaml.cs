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
    /// Logique d'interaction pour ManuAppointments.xaml
    /// </summary>
    public partial class ManuAppointments : Page
    {
        AppointmentWPFContext _db = new AppointmentWPFContext();
        private int updatingCustId = 0;
        public ManuAppointments()
        {
            InitializeComponent();

            /* this.txtBroker.DisplayMemberPath = "CountryName";
             this.cmbCountryList.SelectedValuePath = "CountryCode";
             this.cmbCountryList.ItemsSource = HomeBusinessLogic.LoadCountryList();
             this.cmbCountryList.Text = "Choose Country";*/
            //this.grCustomers.ItemsSource = db.Customers.ToList();

            this.cbBroker.ItemsSource = _db.Brokers.ToList();
            this.cbBroker.Text = "Choisir un couriter";

            this.cbCustomer.ItemsSource = _db.Customers.ToList();
            this.cbCustomer.Text = "Choisir un client";
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
  
           /* if (txtDateHour.Text != ""
               && txtSubject.Text != ""
               && txtBroker.Text != ""
               && txtCustomer.Text != "")
            {
                Appointment appointment = new Appointment()
                {
                    DateHour = txtDateHour.Text,
                    Subject = txtSubject.Text,
                    IdBroker = txtBroker.Text,
                    IdCustomer = txtCustomer.Text,
                };

                db.Appointments.Add(appointment);
                db.SaveChanges();

                txtDateHour.Text = "";
                txtSubject.Text = "";
                txtBroker.Text = "";
                txtCustomer.Text = "";
                Button_Click_Show(sender, e);
            }
            else
            {
                MessageBox.Show("Vous devez remplir tousles champs svp.");
            };
*/
        }

        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
            this.grAppointments.ItemsSource = _db.Appointments.ToList();
        }

        private void grAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.grAppointments.SelectedIndex >= 0)
            {
                if (this.grAppointments.SelectedItems.Count >= 0)
                {
                    Appointment appointSelected = (Appointment)this.grAppointments.SelectedItems[0];

                  /*  this.updatingCustId = appointSelected.Id;
                    this.txtDateHour.Text = appointSelected.DateHour;
                    this.txtSubject.Text = appointSelected.Subject;
                    this.txtBroker.Text = appointSelected.IdBroker;
                    this.txtCustomer.Text = appointSelected.IdCustomer;*/

                    _db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

            var appointSelected = _db.Appointments.Where(c => c.Id == updatingCustId).FirstOrDefault();

           /* if (appointSelected != null)
            {
                //cust.Id = updatingCustId;
                appointSelected.DateHour = this.txtDateHour.Text;
                appointSelected.Subject = this.txtSubject.Text;
                appointSelected.Broker = this.txtBroker.Text;
                appointSelected.txtCustomer = this.txtCustomer.Text;

                db.SaveChanges();
                txtDateHour.Text = "";
                txtSubject.Text = "";
                txtBroker.Text = "";
                txtCustomer.Text = "";
                Button_Click_Show(sender, e);
            }*/

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
                var appoint = _db.Appointments.Where(c => c.Id == updatingCustId).FirstOrDefault();
                if (appoint != null)
                {
                    _db.Appointments.Remove(appoint);
                    _db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }
    }
}
