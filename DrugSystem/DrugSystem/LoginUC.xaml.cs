using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        TextBox UserMail, Userpassword;
        public event EventHandler<RoutedEventArgs> ClickHandler;

        public LoginUC()
        {
            InitializeComponent();
            Userpassword = this.UserPassword;
            UserMail = this.UserEmail;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validations.ValidateEmailAddress(UserMail.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("invalid email address!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("missing email address!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Userpassword.Text == "123"|| Userpassword.Text == "" )
            {
                if (ClickHandler != null)
                {
                    ClickHandler.Invoke(sender, e);
                }
            }
        }  
    }
}
