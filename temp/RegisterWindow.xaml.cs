using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Projekt_DPOB
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            loginLabel.Content = ProgramOptions.TranslatedLabels[0];
            passwordLabel.Content = ProgramOptions.TranslatedLabels[1];
            nickLabel.Content = ProgramOptions.TranslatedLabels[2];
            registerButton.Content = ProgramOptions.TranslatedLabels[4];
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password != "")
            {
                passwordLabel.Content = "";
            }
            else
            {
                passwordLabel.Content = ProgramOptions.TranslatedLabels[1];
            }
        }

        private void loginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loginBox.Text != "")
            {
                loginLabel.Content = "";
            }
            else
            {
                loginLabel.Content = ProgramOptions.TranslatedLabels[0];
            }
        }
        private void nickBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nickBox.Text != "")
            {
                nickLabel.Content = "";
            }
            else
            {
                nickLabel.Content = ProgramOptions.TranslatedLabels[0];
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != "" && passwordBox.Password != "" && nickBox.Text != "")
            {
                MySqlConnection Connection = MySQLOptions.ReturnConnection();
                Connection.Open();
                MySqlCommand Check = new MySqlCommand("SELECT account_id FROM ACCOUNTS WHERE login = '" + loginBox.Text + "' AND nick = '" + nickBox.Text + "'", Connection);
                MySqlDataReader reader = Check.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show(ProgramOptions.TranslatedLabels[10]);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    MySqlCommand Insert = new MySqlCommand("INSERT INTO ACCOUNTS VALUES(default, '" + loginBox.Text + "', '" + passwordBox.Password + "', '" + nickBox.Text + "', 'user');", Connection);
                    Insert.ExecuteNonQuery();
                    Insert.CommandText = "INSERT INTO ONLINE_USERS VALUES(default, '" + nickBox.Text + "','Offline');";
                    Insert.ExecuteNonQuery();
                    MessageBox.Show(ProgramOptions.TranslatedLabels[11]);
                    this.Close();
                }
            }
        }
    }
}
