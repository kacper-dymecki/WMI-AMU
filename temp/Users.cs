using System.Windows.Media;

namespace Projekt_DPOB
{
    class Users
    {
        private string _Nick;
        private string _Status;
        private string _Login;
        private Color _Color = Color.FromRgb(0,0,0);
        private bool _CanKick = false;
        private bool _CanBan = false;
        private bool _CanSetPrivileges = false;

        public Users(string Nick, string Status)
        {
            _Nick = Nick;
            _Status = Status;
        }

        public Users(string Nick, string Status, string Login)
        {
            _Nick = Nick;
            _Status = Status;
            _Login = Login;
        }

        public override string ToString()
        {
            return Nick + " " + Status;
        }

        public string Nick
        {
            get
            {
                return _Nick;
            }
            set
            {
                _Nick = value;
            }
        }

        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public bool CanKick
        {
            get
            {
                return _CanKick;
            }
            set
            {
                _CanKick = value;
            }
        }

        public bool CanBan
        {
            get
            {
                return _CanBan;
            }
            set
            {
                _CanBan = value;
            }
        }

        public bool CanSetPrivileges
        {
            get
            {
                return _CanSetPrivileges;
            }
            set
            {
                _CanSetPrivileges = value;
            }
        }

        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }
    }

    class Administrator : Users
    {
        public Administrator(string Nick, string Status) : base(Nick,Status)
        {
            CanKick = true;
            CanBan = true;
            CanSetPrivileges = true;
            this.Color = Color.FromRgb(255, 0, 0);
        }
        public Administrator(string Nick, string Status, string Login) : base(Nick, Status, Login)
        {
            CanKick = true;
            CanBan = true;
            CanSetPrivileges = true;
            this.Color = Color.FromRgb(255, 0, 0);
        }
    }

    class Moderator : Users
    {
        public Moderator(string Nick, string Status) : base(Nick,Status)
        {
            CanKick = true;
            this.Color = Color.FromRgb(255, 0, 255);
        }
        public Moderator(string Nick, string Status, string Login) : base(Nick, Status, Login)
        {
            CanKick = true;
            this.Color = Color.FromRgb(255, 0, 255);
        }
    }

    class User : Users
    {
        public User(string Nick, string Status) : base(Nick,Status)
        {
            this.Color = Color.FromRgb(180, 180, 180);
        }
        public User(string Nick, string Status, string Login) : base(Nick, Status, Login)
        {
            this.Color = Color.FromRgb(180, 180, 180);
        }
    }
}
