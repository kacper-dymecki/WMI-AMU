using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace Projekt_DPOB
{
    public partial class Chat : Window
    {
        private MySqlConnection DataReaderMySQLConnection = MySQLOptions.ReturnConnection();
        private MySqlConnection DataManipulationMySQLConnection = MySQLOptions.ReturnConnection();
        private bool isReadingMessages, isReadingUsers, isReadingCommands;
        private string lastMessage;
        private FlowDocument richMessagesBoxContent = new FlowDocument();
        private System.Timers.Timer afkTimer = new System.Timers.Timer();
        private List<Users> onlineUsers = new List<Users> { };

        public Chat()
        {
            InitializeComponent();
#if DEBUG
            //ProgramOptions.LoggedInUser = new User("puszek", "Online", "puszek");
#endif
            statusLabel.Content = ProgramOptions.TranslatedLabels[5] + ProgramOptions.LoggedInUser.Nick + " " + ProgramOptions.TranslatedLabels[6] + " " + MySQLOptions.Server;
            optionsButton.Content = ProgramOptions.TranslatedLabels[7];
            messageLabel.Content = ProgramOptions.TranslatedLabels[8];
            sendButton.Content = ProgramOptions.TranslatedLabels[9];
            DataReaderMySQLConnection.Open();
            DataManipulationMySQLConnection.Open();
            afkTimer.Interval = 5000;
            afkTimer.Elapsed += AfkTimer_Elapsed;
            ChangeUserStatusAsync();
            ReadData();
        }

        private async void ReadData()
        {
            while(true)
            {
                ReadCommands();
                ReadOnlineUsers();
                ReadMessages();
                await Task.Delay(300);
            }   
        }
        private async void ReadCommands()
        {
            try
            {
                MySqlCommand readCommands = new MySqlCommand("SELECT command,target,status FROM COMMANDS WHERE target = '" + ProgramOptions.LoggedInUser.Nick + "' AND status = 'start' LIMIT 1;", DataReaderMySQLConnection);
                System.Data.Common.DbDataReader reader = await readCommands.ExecuteReaderAsync();
                while ((isReadingCommands = await reader.ReadAsync()) == true)
                {
                    if (reader.GetString(2) == "start" && (reader.GetString(0) == "kicked" || reader.GetString(0) == "banned"))
                    {
                        MySqlCommand updateCommand = new MySqlCommand("START TRANSACTION; UPDATE COMMANDS SET status = 'finished' WHERE target = '" + ProgramOptions.LoggedInUser.Nick + "'; COMMIT; ", DataManipulationMySQLConnection);
                        await updateCommand.ExecuteNonQueryAsync();
                        MessageBox.Show("You were " + reader.GetString(0) + " from the server!");
                        this.Close();
                    }
                }
                reader.Close();
            }
            catch(Exception mysqlException)
            {
                if(mysqlException is MySqlException)
                {
                    System.Diagnostics.Debug.WriteLine("Exception thrown in ReadCommandsAsync; Not harmful; " + mysqlException.ToString());
                }
            }
        }

        private async void ReadOnlineUsers()
        {
            try
            {
                MySqlCommand readOnlineUsers = new MySqlCommand("SELECT ONLINE_USERS.nick, ONLINE_USERS.status, ACCOUNTS.privileges, ACCOUNTS.login FROM ONLINE_USERS LEFT JOIN ACCOUNTS ON ONLINE_USERS.Nick = ACCOUNTS.Nick WHERE ONLINE_USERS.status != 'Offline';", DataReaderMySQLConnection);
                System.Data.Common.DbDataReader reader = await readOnlineUsers.ExecuteReaderAsync();
                List<Users> temporaryUsers = new List<Users> { };
                while ((isReadingUsers = await reader.ReadAsync()) == true)
                {
                    switch (reader.GetString(2))
                    {
                        case "administrator":
                            temporaryUsers.Add(new Administrator(reader.GetString(0), reader.GetString(1)));
                            if (reader.GetString(0) == ProgramOptions.LoggedInUser.Nick && !(ProgramOptions.LoggedInUser is Administrator))
                            {
                                ProgramOptions.LoggedInUser = new Administrator(ProgramOptions.LoggedInUser.Nick, ProgramOptions.LoggedInUser.Status, reader.GetString(3));
                            }
                            break;
                        case "moderator":
                            temporaryUsers.Add(new Moderator(reader.GetString(0), reader.GetString(1)));
                            if (reader.GetString(0) == ProgramOptions.LoggedInUser.Nick && !(ProgramOptions.LoggedInUser is Moderator))
                            {
                                ProgramOptions.LoggedInUser = new Moderator(ProgramOptions.LoggedInUser.Nick, ProgramOptions.LoggedInUser.Status, reader.GetString(3));
                            }
                            break;
                        default:
                            temporaryUsers.Add(new User(reader.GetString(0), reader.GetString(1)));
                            if (reader.GetString(0) == ProgramOptions.LoggedInUser.Nick && !(ProgramOptions.LoggedInUser is User))
                            {
                                ProgramOptions.LoggedInUser = new User(ProgramOptions.LoggedInUser.Nick, ProgramOptions.LoggedInUser.Status, reader.GetString(3));
                            }
                            break;
                    }
                }
                if (temporaryUsers != onlineUsers)
                {
                    onlineUsers = temporaryUsers;
                }
                reader.Close();
                loggedInUsersList.ItemsSource = onlineUsers;
            }
            catch (Exception mysqlException)
            {
                if (mysqlException is MySqlException)
                {
                    System.Diagnostics.Debug.WriteLine("Exception thrown in ReadOnlineUsersAsync; Not harmful; " + mysqlException.ToString());
                }
            }
        }

        private async void ReadMessages()
        {
            try
            {
                MySqlCommand readOnlineUsers = new MySqlCommand("SELECT user_nick, message FROM CHAT ORDER BY chat_id DESC LIMIT 1;", DataReaderMySQLConnection);

                System.Data.Common.DbDataReader reader = await readOnlineUsers.ExecuteReaderAsync();
                while ((isReadingMessages = await reader.ReadAsync()) == true)
                {
                    string nick = reader.GetString(0);
                    string message = reader.GetString(1);
                    if (nick == "server" && message.Contains("###"))
                    {
                        if (message != lastMessage)
                        {
                            Paragraph newMessage = new Paragraph();
                            lastMessage = message;
                            newMessage.Inlines.Add(message);
                            newMessage.Inlines.LastInline.Foreground = new SolidColorBrush(Color.FromRgb(147, 147, 147));
                            richMessagesBoxContent.Blocks.Add(newMessage);
                            richMessagesBox.Document = richMessagesBoxContent;
                            if (ProgramOptions.ScrollToBottom)
                            {
                                richMessagesBox.ScrollToEnd();
                            }
                        }
                    }
                    else
                    {
                        string tempMessage = "<" + nick + "> : " + message;
                        if (lastMessage != tempMessage)
                        {
                            Paragraph newMessage = new Paragraph();
                            Color temporaryColor = Color.FromRgb(0, 255, 0);
                            foreach (Users user in onlineUsers)
                            {
                                if (user.Nick == nick)
                                {
                                    temporaryColor = user.Color;
                                    break;
                                }
                            }
                            lastMessage = tempMessage;
                            newMessage.Inlines.Add("<" + nick + ">");
                            newMessage.Inlines.LastInline.Foreground = new SolidColorBrush(temporaryColor);
                            newMessage.Inlines.Add(" : " + message);
                            newMessage.Inlines.LastInline.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                            richMessagesBoxContent.Blocks.Add(newMessage);
                            richMessagesBox.Document = richMessagesBoxContent;
                            if (ProgramOptions.ScrollToBottom)
                            {
                                richMessagesBox.ScrollToEnd();
                            }
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception mysqlException)
            {
                if (mysqlException is MySqlException)
                {
                    System.Diagnostics.Debug.WriteLine("Exception thrown in ReadMessagesAsync; Not harmful; " + mysqlException.ToString());
                }
            }
        }

        private async void SendMessageAsync()
        {
            MySqlCommand sendMessage = new MySqlCommand("INSERT INTO CHAT VALUES(default,'" + messageBox.Text + "','" + ProgramOptions.LoggedInUser.Nick +"');", DataManipulationMySQLConnection);
            await sendMessage.ExecuteNonQueryAsync();
            messageBox.Text = "";
        }

        private void SendCommandAsync()
        {
            string nick;
            if (messageBox.Text.Contains("/kick"))
            {
                if(ProgramOptions.LoggedInUser.CanKick)
                {
                    nick = messageBox.Text.Substring(messageBox.Text.IndexOf("/kick") + 6);
                    SendCommand("kicked", nick);
                }
                else
                {
                    NoPermissionsMessage();
                }
            }
            else if(messageBox.Text.Contains("/ban"))
            {
                if(ProgramOptions.LoggedInUser.CanBan)
                {
                    nick = messageBox.Text.Substring(messageBox.Text.IndexOf("/ban") + 5);
                    SendCommand("banned", nick);
                }
                else
                {
                    NoPermissionsMessage();
                }
            }
            else if(messageBox.Text.Contains("/unban"))
            {
                if (ProgramOptions.LoggedInUser.CanBan)
                {
                    nick = messageBox.Text.Substring(messageBox.Text.IndexOf("/unban") + 7);
                    SendCommand("unbanned", nick);
                }
                else
                {
                    NoPermissionsMessage();
                }
            }
            else if (messageBox.Text.Contains("/set"))
            {
                if(ProgramOptions.LoggedInUser.CanSetPrivileges)
                {
                    if (messageBox.Text.Contains(" admin "))
                    {
                        nick = messageBox.Text.Substring(messageBox.Text.IndexOf("/set") + 11);
                        SendCommand("admin", nick);
                    }
                    if (messageBox.Text.Contains(" moderator "))
                    {
                        nick = messageBox.Text.Substring(messageBox.Text.IndexOf("/set") + 15);
                        SendCommand("moderator", nick);
                    }
                    if (messageBox.Text.Contains(" user "))
                    {
                        nick = messageBox.Text.Substring(messageBox.Text.IndexOf("/set") + 10);
                        SendCommand("user", nick);
                    }
                }
                else
                {
                    NoPermissionsMessage();
                }
            }
            else if(messageBox.Text.Contains("/help"))
            {
                Paragraph helpMessage = new Paragraph();
                helpMessage.Inlines.Add(
                    "#########################################################" +
                    "\n# List of available commands" +
                    "\n# /help - shows help" +
                    "\n# /kick [nick] - kick certain user" +
                    "\n# /ban [nick] [time] - ban certain user for [time] seconds" +
                    "\n# /set [privilege] [nick] - set certain user's privileges" +
                    "\n# /unban [nick] - unban certain user" +
                    "\n#########################################################");
                helpMessage.Inlines.Add(ProgramOptions.TranslatedLabels[10]);
                helpMessage.Inlines.LastInline.Foreground = new SolidColorBrush(Color.FromRgb(147, 147, 147));
                richMessagesBoxContent.Blocks.Add(helpMessage);
                richMessagesBox.Document = richMessagesBoxContent;
                if (ProgramOptions.ScrollToBottom)
                {
                    richMessagesBox.ScrollToEnd();
                }
                messageBox.Text = "";
            }
        }

        private async void SendCommand(string command,string nick)
        {
            foreach(Users temporaryUser in onlineUsers)
            {
                if(temporaryUser.ToString().Contains(nick))
                {
                    MySqlCommand SendCommand = new MySqlCommand("START TRANSACTION; INSERT INTO COMMANDS VALUES(default,'" + ProgramOptions.LoggedInUser.Nick + "','" + command + "','" + temporaryUser.Nick + "','start'); COMMIT;", DataManipulationMySQLConnection);
                    await SendCommand.ExecuteNonQueryAsync();
                    if(command == "banned")
                    {
                        SendCommand.CommandText = "START TRANSACTION; INSERT INTO BANLIST VALUES(default,'" + ProgramOptions.LoggedInUser.Nick + "','" + temporaryUser.Nick + "','notfinished',addtime(now(), '00:15:00')); COMMIT;";
                        await SendCommand.ExecuteNonQueryAsync();
                    }
                    if(command == "unbanned")
                    {
                        SendCommand.CommandText = "START TRANSACTION; UPDATE BANLIST SET status = 'finished' WHERE target = '" + nick + "' ORDER BY ban_id DESC LIMIT 1;COMMIT;";
                        await SendCommand.ExecuteNonQueryAsync();
                    }
                    if (command == "admin" || command == "moderator" || command == "user")
                    {
                        SendCommand.CommandText = "UPDATE ACCOUNTS SET privileges = '" + command + "' WHERE nick = '" + nick + "';";
                        await SendCommand.ExecuteNonQueryAsync();
                        SendCommand.CommandText = "START TRANSACTION; INSERT INTO CHAT VALUES(default,'### User " + nick + " has became a " + command + " because of " + ProgramOptions.LoggedInUser.Nick + " ###' ,'server'); COMMIT;";
                        await SendCommand.ExecuteNonQueryAsync();
                    }
                    else
                    {
                        SendCommand.CommandText = "START TRANSACTION; INSERT INTO CHAT VALUES(default,'### User " + nick + " has been " + command + " by " + ProgramOptions.LoggedInUser.Nick + " ###' ,'server'); COMMIT;";
                        await SendCommand.ExecuteNonQueryAsync();
                    }
                    break;
                }
            }
            messageBox.Text = "";
        }

        private void NoPermissionsMessage()
        {
            messageBox.Text = "";
            Paragraph newMessage = new Paragraph();
            newMessage.Inlines.Add("### You don't have enough permissions to execute this command ###");
            newMessage.Inlines.LastInline.Foreground = new SolidColorBrush(Color.FromRgb(147, 147, 147));
            richMessagesBoxContent.Blocks.Add(newMessage);
            richMessagesBox.Document = richMessagesBoxContent;
            if(ProgramOptions.ScrollToBottom)
            {
                richMessagesBox.ScrollToEnd();
            }
        }

        private void MessageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(messageBox.Text != "")
            {
                messageLabel.Content = "";
            }
            else
            {
                messageLabel.Content = "[Wiadomość]";
            }
        }

        private async void ChangeUserStatusAsync()
        {
            System.Diagnostics.Debug.WriteLine("changing user status to " + ProgramOptions.LoggedInUser.Status);
            try
            {
                MySqlCommand changeStatus = new MySqlCommand("START TRANSACTION; UPDATE ONLINE_USERS SET status = '" + ProgramOptions.LoggedInUser.Status + "' WHERE nick = '" + ProgramOptions.LoggedInUser.Nick + "'; COMMIT;", DataManipulationMySQLConnection);
                await changeStatus.ExecuteNonQueryAsync();
            }
            catch(Exception mysqlException)
            {
                if(mysqlException is MySqlException)
                {
                    await Task.Delay(1000);
                    ChangeUserStatusAsync();
                }
            }
        }

        private void AfkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ProgramOptions.LoggedInUser.Status = "Away";
            ChangeUserStatusAsync();
            afkTimer.Stop();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("lost focus");
            if(afkTimer.Enabled != true)
            {
                afkTimer.Start();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("regained focus");
            afkTimer.Stop();
            if (ProgramOptions.LoggedInUser.Status == "Away")
            {
                ProgramOptions.LoggedInUser.Status = "Online";
                ChangeUserStatusAsync();
            }
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow Window = new OptionsWindow();
            Window.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProgramOptions.LoggedInUser.Status = "Offline";
            ChangeUserStatusAsync();
            
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if(messageBox.Text != "" || messageBox.Text != null)
            {
                if(messageBox.Text.Contains("/kick") || messageBox.Text.Contains("/ban") || messageBox.Text.Contains("/unban") || messageBox.Text.Contains("/help") || messageBox.Text.Contains("/set"))
                {
                    messageBox.IsEnabled = false;
                    SendCommandAsync();
                    messageBox.IsEnabled = true;
                }
                else
                {
                    messageBox.IsEnabled = false;
                    SendMessageAsync();
                    messageBox.IsEnabled = true;
                }
            }
        }
    }
}
