using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppointmentWPFDotNet6.Pages
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            /* var clickedBtn = e.OriginalSource as NavBar;
             NavigationService.Navigate(clickedBtn.NavUri);*/
           /* WrapPanel s = sender as WrapPanel;
            string menuText = s.Children.ToString();*/
        }


        private void Customer_Click(object sender, RoutedEventArgs e)
        {
           /* ContentFrame.Navigate(new System.Uri("Pages/Customer.xaml",
            UriKind.RelativeOrAbsolute));*/
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem s = sender as MenuItem;
            string menuText = s.Header.ToString();

            if (menuText == "Home")
            {
               /* grHomePage.Navigate(new System.Uri("Pages/HomePage.xaml",
            UriKind.RelativeOrAbsolute));*/
            }
            else if (menuText == "Client")
            {
                ContentFrame.Navigate(new System.Uri("Pages/ManuCustomers.xaml",
                            UriKind.RelativeOrAbsolute));
            }
            else if (menuText == "Courtiers")
            {
                ContentFrame.Navigate(new System.Uri("Pages/ManuBrokers.xaml",
                           UriKind.RelativeOrAbsolute));
            }
            else if (menuText == "Rendez-Vous")
            {
                ContentFrame.Navigate(new System.Uri("Pages/ManuAppointments.xaml",
                           UriKind.RelativeOrAbsolute));
            }
            else if (menuText == "Login")
            {
                ContentFrame.Navigate(new System.Uri("Pages/Login.xaml",
                           UriKind.RelativeOrAbsolute));
            }
            else if (menuText == "Logout")
            {
                ContentFrame.Navigate(new System.Uri("Pages/Logout.xaml",
                          UriKind.RelativeOrAbsolute));
            }
            else if (menuText == "Register")
            {
                ContentFrame.Navigate(new System.Uri("Pages/Register.xaml",
                         UriKind.RelativeOrAbsolute));
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
                ContentFrame.Navigate(new System.Uri("Pages/ManuCustomers.xaml",
                            UriKind.RelativeOrAbsolute));
            }
            else if (navText == "Courtiers")
            {
                ContentFrame.Navigate(new System.Uri("Pages/ManuBrokers.xaml",
                           UriKind.RelativeOrAbsolute));
            }
            else if (navText == "Rendez-Vous")
            {
                ContentFrame.Navigate(new System.Uri("Pages/ManuAppointments.xaml",
                           UriKind.RelativeOrAbsolute));
            }
            else if (navText == "Login")
            {
                ContentFrame.Navigate(new System.Uri("Pages/Login.xaml",
                           UriKind.RelativeOrAbsolute));
            }
            else if (navText == "Logout")
            {
                ContentFrame.Navigate(new System.Uri("Pages/Logout.xaml",
                          UriKind.RelativeOrAbsolute));
            }
            else if (navText == "Register")
            {
                ContentFrame.Navigate(new System.Uri("Pages/Register.xaml",
                         UriKind.RelativeOrAbsolute));
            }

        }


    }
}
