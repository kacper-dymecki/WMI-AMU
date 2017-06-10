using System.Windows;
using System.IO;

namespace Projekt_DPOB
{
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            languagesBox.Items.Add(ProgramOptions.Languages.English);
            languagesBox.Items.Add(ProgramOptions.Languages.Polish);
            languagesBox.SelectedValue = ProgramOptions.ActualLanguage;
            scrollToBottomBox.IsChecked = ProgramOptions.ScrollToBottom;
            rememberBox.IsChecked = ProgramOptions.IsRememberEnabled;
            languageLabel.Content = ProgramOptions.TranslatedLabels[13];
            scrollToBottomBox.Content = ProgramOptions.TranslatedLabels[14];
            rememberBox.Content = ProgramOptions.TranslatedLabels[15];
            saveButton.Content = ProgramOptions.TranslatedLabels[16];
            defaultButton.Content = ProgramOptions.TranslatedLabels[17];
            cancelButton.Content = ProgramOptions.TranslatedLabels[18];
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void defaultButton_Click(object sender, RoutedEventArgs e)
        {
            string[] DefaultOptions = new string[] { "language english", "tobottom true", "remember false", "login " };
            File.WriteAllLines(@"data/options.ini", DefaultOptions);
            ProgramOptions.ActualLanguage = ProgramOptions.Languages.English;
            ProgramOptions.ScrollToBottom = true;
            ProgramOptions.IsRememberEnabled = false;
            languagesBox.SelectedValue = ProgramOptions.ActualLanguage;
            scrollToBottomBox.IsChecked = ProgramOptions.ScrollToBottom;
            rememberBox.IsChecked = ProgramOptions.IsRememberEnabled;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string login = "";
            if(rememberBox.IsChecked.Value == true)
            {
                login = ProgramOptions.LoggedInUser.Login;
            }
            string[] DefaultOptions = new string[] { "language " + languagesBox.SelectedItem.ToString(), "tobottom " + scrollToBottomBox.IsChecked.Value.ToString(), "remember " + rememberBox.IsChecked.Value.ToString(), "login " + login };
            File.WriteAllLines(@"data/options.ini", DefaultOptions);
            ProgramOptions.ActualLanguage = (ProgramOptions.Languages)languagesBox.SelectedItem;
            ProgramOptions.ScrollToBottom = scrollToBottomBox.IsChecked.Value;
            ProgramOptions.IsRememberEnabled = rememberBox.IsChecked.Value;
            this.Close();
        }
    }
}
