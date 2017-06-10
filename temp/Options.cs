using System;
using System.IO;
using System.Diagnostics;

namespace Projekt_DPOB
{
    class ProgramOptions
    {
        private static Users _loggedInUser;
        private static bool _isRememberEnabled;
        private static bool _scrollToBottom;
        private static Languages _language = Languages.English;
        public static string[] TranslatedLabels = new string[15];
        
        public enum Languages
        {
            English,
            Polish
        }

        public static Languages ActualLanguage
        {
            get
            {
                return _language;
            }
            set
            {
                if (_language != value)
                {
                    _language = value;
                    LoadLabels();
                }
            }
        }


        public static void LoadLabels()
        {
            if(File.Exists(@"data/translation_" + ActualLanguage + ".txt"))
            {
                TranslatedLabels = File.ReadAllLines(@"data/translation_" + ActualLanguage + ".txt");
            }
            else
            {
                Debug.WriteLine("translation file 'translation_" + ActualLanguage + ".txt' is missing, staying with default translation");
            }
        }

        private static void LoadDefaultTranslation()
        {
            ActualLanguage = Languages.English;
        }

        public static bool IsRememberEnabled
        {
            get
            {
                return _isRememberEnabled;
            }
            set
            {
                _isRememberEnabled = value;
            }
        }

        public static Users LoggedInUser
        {
            get
            {
                return _loggedInUser;
            }
            set
            {
                _loggedInUser = value;
            }
        }

        public static bool ScrollToBottom
        {
            get
            {
                return _scrollToBottom;
            }
            set
            {
                _scrollToBottom = value;
            }
        }

    }

    class MySQLOptions
    {
        private static string _login = "chat";
        private static string _password = "chitchat";
        private static string _database = "chat";
        private static string _server = "puszkolandia.com";
        private static string _userNickname;
        private static string _connectionString = ConnectionString;

        private static string ConnectionString
        {
            get
            {
                return @"SERVER = " + _server + "; UID = " + _login + "; PASSWORD = " + _password + "; DATABASE = " + _database + "; SslMode = None; CHARSET = utf8;";
            }
        }

        public static string Server
        {
            get
            {
                return _server;
            }
        }

        public static string UserNickname
        {
            get
            {
                return _userNickname;
            }
            set
            {
                _userNickname = value;
            }
        }

        public static MySql.Data.MySqlClient.MySqlConnection ReturnConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection mysqlconn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString);
            return mysqlconn;
        }
    }
}
