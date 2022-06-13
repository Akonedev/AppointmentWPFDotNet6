using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppointmentWPFDotNet6
{
    /// <summary>
    /// Suivez les étapes 1a ou 1b puis 2 pour utiliser ce contrôle personnalisé dans un fichier XAML.
    ///
    /// Étape 1a) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans le projet actif.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:AppointmentWPFDotNet6.Pages"
    ///
    ///
    /// Étape 1b) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans un autre projet.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:AppointmentWPFDotNet6.Pages;assembly=AppointmentWPFDotNet6.Pages"
    ///
    /// Vous devrez également ajouter une référence du projet contenant le fichier XAML
    /// à ce projet et regénérer pour éviter des erreurs de compilation :
    ///
    ///     Cliquez avec le bouton droit sur le projet cible dans l'Explorateur de solutions, puis sur
    ///     "Ajouter une référence"->"Projets"->[Recherchez et sélectionnez ce projet]
    ///
    ///
    /// Étape 2)
    /// Utilisez à présent votre contrôle dans le fichier XAML.
    ///
    ///     <MyNamespace:NavBar/>
    ///
    /// </summary>
    public class NavBar : ButtonBase
    {   
         static NavBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavBar), new FrameworkPropertyMetadata(typeof(NavBar)));
        }

        public static readonly DependencyProperty NavImageSourceProperty = DependencyProperty.Register("NavImageSource", typeof(ImageSource), typeof(NavBar), new PropertyMetadata(null));
        public static readonly DependencyProperty NavTextProperty = DependencyProperty.Register("NavText", typeof(string), typeof(NavBar), new PropertyMetadata(null));
       // public static readonly DependencyProperty NavUriProperty = DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavBar), new PropertyMetadata(null));

    /*     public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavBar), new PropertyMetadata(null));
       public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NavBar), new PropertyMetadata(null));
       

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
*/


        public ImageSource NavImageSource
        {
            get { return (ImageSource)GetValue(NavImageSourceProperty); }
            set { SetValue(NavImageSourceProperty, value); }
        }

        public string NavText
        {
            get { return (string)GetValue(NavTextProperty); }
            set { SetValue(NavTextProperty, value); }
        }

       /* public Uri NavUri
        {
            get { return (Uri)GetValue(NavUriProperty); }
            set { SetValue(NavUriProperty, value); }
        }*/
    }
}
