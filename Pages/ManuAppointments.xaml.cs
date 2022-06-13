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

            List<Broker> brklist = new List<Broker>();
            List<Customer> custlist = new List<Customer>();

            brklist = _db.Brokers.ToList();
            custlist = _db.Customers.ToList();

            this.cbBroker.Text = "Choisir un couriter";
            this.cbBroker.DisplayMemberPath = "Id";
            this.cbBroker.DisplayMemberPath = "FirstName";
            this.cbBroker.SelectedValuePath = "Id";
            this.cbBroker.ItemsSource = brklist;

            this.cbCustomer.Text = "Choisir un client";
            this.cbCustomer.DisplayMemberPath = "Id";
            this.cbCustomer.DisplayMemberPath = "FirstName";
            this.cbCustomer.SelectedValuePath = "Id";
            this.cbCustomer.ItemsSource = custlist;

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

            Broker broker = (Broker)this.cbBroker.SelectedItem;
            Customer customer = (Customer)this.cbCustomer.SelectedItem;

            string dt = this.dtDateHour.Text;
            string hours = this.txtHeures.Text;
            string minuts = this.txtMinutes.Text;
            string subject = this.txtSubject.Text;
            int brkId = broker.Id;
            int custId = customer.Id;

            DateTime dtconverted = Convert.ToDateTime(dt);
            int intYear = dtconverted.Year;
            int intMonth = dtconverted.Month;
            int intDday = dtconverted.Day;

            string dateValue1 = dtconverted.ToString("MM/dd/yyyy");

            int intHours = int.Parse(hours);
            int intMinuts = int.Parse(minuts);

            DateTime createDt = new DateTime(intYear, intMonth, intDday, intHours, intMinuts, 0);
            Appointment appointment = new Appointment();

            appointment.DateHour = createDt;
            appointment.Subject = subject;
            appointment.IdCustomer = custId;
            appointment.IdBroker = brkId;

            if (dtDateHour.Text != ""
               && txtSubject.Text != ""
               && cbBroker.Text != ""
               && cbCustomer.Text != "")
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();

                dtDateHour.Text = "";
                txtSubject.Text = "";
                cbBroker.Text = "";
                cbCustomer.Text = "";
                Button_Click_Show(sender, e);
            }
            else
            {
                MessageBox.Show("Vous devez remplir tousles champs svp.");
            };

        }

        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
            this.grAppointments.ItemsSource = _db.Appointments.ToList();
        }

        private void grAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Appointment appointSelected = (Appointment)this.grAppointments.SelectedItem;

            if (this.grAppointments.SelectedIndex >= 0)
            {
                Appointment appointSelected = (Appointment)this.grAppointments.SelectedItem;
                Broker brokerEdit = _db.Brokers.Find(appointSelected.IdBroker);
                Customer customerEdit = _db.Customers.Find(appointSelected.IdCustomer);

                List<Broker> brokerEditList = new List<Broker>();
                List<Customer> customerEditList = new List<Customer>();

                brokerEditList = _db.Brokers.ToList();
                customerEditList = _db.Customers.ToList();


                if (appointSelected != null)
                {
                    _db.Update(appointSelected);
                    _db.SaveChanges();
                    Button_Click_Show(sender, e);
                }

                this.dtDateHourEdit.Text = appointSelected.DateHour.ToString();
                this.txtHeuresEdit.Text = appointSelected.DateHour.Hour.ToString();
                this.txtMinutesEdit.Text = appointSelected.DateHour.Minute.ToString();
                this.dtDateHourEdit.Text = appointSelected.DateHour.ToString();
                this.txtSubjectEdit.Text = appointSelected.Subject;

                this.cbBrokerEdit.DisplayMemberPath = "FirstName";
                this.cbBrokerEdit.SelectedValuePath = "Id";
                this.cbBrokerEdit.ItemsSource = brokerEditList;

                this.cbCustomerEdit.Text = "Choisir un client";
                this.cbCustomerEdit.DisplayMemberPath = "Id";
                this.cbCustomerEdit.DisplayMemberPath = "FirstName";
                this.cbCustomerEdit.SelectedValuePath = "Id";
                this.cbCustomerEdit.ItemsSource = customerEditList;

            }

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            // var appointSelected = _db.Appointments.Where(c => c.Id == updatingCustId).FirstOrDefault();
            Appointment appointToUpd = (Appointment)this.grAppointments.SelectedItem;
      


            if (appointToUpd != null)
            {
                Broker broker = (Broker)this.cbBroker.SelectedItem;
                Customer customer = (Customer)this.cbCustomer.SelectedItem;

                Broker brokerEdit = _db.Brokers.Find(appointToUpd.IdBroker);
                Customer customerEdit = _db.Customers.Find(appointToUpd.IdCustomer);

                string dt = this.dtDateHourEdit.Text;
                string hours = this.txtHeuresEdit.Text;
                string minuts = this.txtMinutesEdit.Text;
                if (dt == "")
                {
                    MessageBox.Show("Vous devez saisir une date pourle rendez-vous");
                    return;
                }
                if (hours == "")
                {
                    MessageBox.Show("Vous devez saisir une Heure pourle rendez-vous");
                    return;
                }
              
                if (minuts == "")
                {
                    MessageBox.Show("Vous devez saisir les minutes pourle rendez-vous");
                    return;
                }               

                DateTime dtconverted = Convert.ToDateTime(dt);

                int intYear = dtconverted.Year;
                int intMonth = dtconverted.Month;
                int intDday = dtconverted.Day;

                string dateValue1 = dtconverted.ToString("MM/dd/yyyy");

                int intHours = int.Parse(hours);
                int intMinuts = int.Parse(minuts);


                DateTime createDt = new DateTime(intYear, intMonth, intDday, intHours, intMinuts, 0);

                appointToUpd.DateHour = createDt;
                appointToUpd.Subject = this.txtSubjectEdit.Text;
                if (customer != null)
                {
                    appointToUpd.IdCustomer = customer.Id;
                }
                else
                {
                    appointToUpd.IdCustomer = customerEdit.Id;
                }

                if (broker != null)
                {
                    appointToUpd.IdBroker = broker.Id;

                }
                else
                {
                    appointToUpd.IdBroker = brokerEdit.Id;
                }

                _db.Update(appointToUpd);
                _db.SaveChanges();

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
                Appointment appointToDel = (Appointment)this.grAppointments.SelectedItem;
                if (appointToDel != null)
                {
                    _db.Appointments.Remove(appointToDel);
                    _db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }
    }
}
