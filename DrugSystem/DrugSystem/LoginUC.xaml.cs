using BLL;
using BLL.BE;
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
        User user;
        public event EventHandler<RoutedEventArgs> ClickHandler;
        IBll Bll;
        public LoginUC()
        {
            InitializeComponent();
            Bll = new BllImplementation();
            Userpassword = this.UserPassword;
            UserMail = this.UserEmail;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckTextBoxNotEmpty();
                user = Bll.GetLoginUser(UserMail.Text, Userpassword.Text);
                if (user != null)
                {
                    if (ClickHandler != null)
                    {
                        ClickHandler.Invoke(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckTextBoxNotEmpty()
        {
            string ErrorMessage = null;
            if (UserMail.Text.Length < 1)
                ErrorMessage += "Email Address Is Requierd\n";
            if (Userpassword.Text.Length < 1)
                ErrorMessage += "Password Is Requierd\n";
            if (ErrorMessage != null)
                throw new ArgumentException(ErrorMessage);
        }
    }
}
