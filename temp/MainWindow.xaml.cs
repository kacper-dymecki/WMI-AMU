using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.IO;


namespace Projekt_DPOB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProgramOptions.LoadLabels();
            LoadOptionsFromFile();
            loginLabel.Content = ProgramOptions.TranslatedLabels[0];
            passwordLabel.Content = ProgramOptions.TranslatedLabels[1];
            loginButton.Content = ProgramOptions.TranslatedLabels[3];
            registerButton.Content = ProgramOptions.TranslatedLabels[4];
            loginBox_TextChanged(null, null);
        }
        private void LoadOptionsFromFile()
        {
            if (File.Exists(@"data/options.ini"))
            {
                try
                {
                    string[] optionsFile = File.ReadAllLines(@"data/options.ini");
                    if (optionsFile[0] == "language polish" || optionsFile[0] == "language Polish")
                    {
                        ProgramOptions.ActualLanguage = ProgramOptions.Languages.Polish;
                    }
                    else
                    {
                        ProgramOptions.ActualLanguage = ProgramOptions.Languages.English;
                    }
                    ProgramOptions.ScrollToBottom = Convert.ToBoolean(optionsFile[1].Substring(9));
                    ProgramOptions.IsRememberEnabled = Convert.ToBoolean(optionsFile[2].Substring(9));
                    if (ProgramOptions.IsRememberEnabled == true)
                    {
                        loginBox.Text = optionsFile[3].Substring(6);
                        loginLabel.Content = "";
                    }
                }
                catch(Exception IOException)
                {
                    System.Diagnostics.Debug.WriteLine(IOException.ToString() + "\nReplacing bad file with default one");
                    string[] DefaultOptions = new string[] { "language english", "tobottom true", "remember false", "" };
                    File.WriteAllLines(@"data/options.ini", DefaultOptions);
                }
            }
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

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != "" && passwordBox.Password != "")
            {
                MySqlConnection Connection = MySQLOptions.ReturnConnection();
                Connection.Open();
                MySqlCommand Check = new MySqlCommand("SELECT login,nick,privileges FROM ACCOUNTS WHERE login = '" + loginBox.Text + "' AND password = '" + passwordBox.Password + "'", Connection);
                MySqlDataReader reader = Check.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch (reader.GetString(2))
                        {
                            case "administrator":
                                ProgramOptions.LoggedInUser = new Administrator(reader.GetString(0), "Online", reader.GetString(1));
                                break;
                            case "moderator":
                                ProgramOptions.LoggedInUser = new Moderator(reader.GetString(0), "Online", reader.GetString(1));
                                break;
                            default:
                                ProgramOptions.LoggedInUser = new User(reader.GetString(0), "Online", reader.GetString(1));
                                break;
                        }
                    }
                    reader.Close();
                    Check.CommandText = "SELECT TIMEDIFF(NOW(),(SELECT finish_date FROM BANLIST WHERE target = '" + ProgramOptions.LoggedInUser.Nick + "' ORDER BY finish_date DESC LIMIT 1));";
                    reader = Check.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                if (reader.GetTimeSpan(0) != null && reader.GetTimeSpan(0).TotalMilliseconds >= 0)
                                {
                                    Chat newWindow = new Chat();
                                    this.Hide();
                                    reader.Close();
                                    newWindow.ShowDialog();
                                    this.Show();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show(ProgramOptions.TranslatedLabels[19]);
                                    reader.Close();
                                }
                            }
                            catch (Exception exception)
                            {
                                if (exception is System.Data.SqlTypes.SqlNullValueException)
                                {
                                    Chat newWindow = new Chat();
                                    this.Hide();
                                    reader.Close();
                                    newWindow.ShowDialog();
                                    this.Show();
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        if (exception is MySql.Data.MySqlClient.MySqlException)
                        {
                            reader.Close();
                        }

                    }
                    }
                else
                {
                    reader.Close();
                    MessageBox.Show(ProgramOptions.TranslatedLabels[12]);
                }
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.ShowDialog();
        }
    }
}
