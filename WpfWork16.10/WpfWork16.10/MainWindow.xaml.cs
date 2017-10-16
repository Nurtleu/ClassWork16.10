using DevOne.Security.Cryptography.BCrypt;
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

namespace WpfWork16._10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string login, password, hashPassword;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            GetInputUserDate(out login, out password);

            if (CheckUserInputOrEmptyString())
            {
                hashPassword = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
                MessageBox.Show(hashPassword);
            }
        }

        private void CheckUserButton_Click(object sender, RoutedEventArgs e)
        {
            GetInputUserDate(out login, out password);

            if (CheckUserInputOrEmptyString())
            {
                string newhashString = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
                MessageBox.Show(newhashString);

                bool isEquals = BCryptHelper.CheckPassword(password, hashPassword);

                if (isEquals) MessageBox.Show("Equals");
                else MessageBox.Show("Not Equals");

            }
        }

        private bool CheckUserInputOrEmptyString()
        {
            return !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password);
        }

        private void GetInputUserDate(out string login, out string password)
        {
            login = loginTextBox.Text;
            password = passwordTextBox.Text;
        }
    }
}
