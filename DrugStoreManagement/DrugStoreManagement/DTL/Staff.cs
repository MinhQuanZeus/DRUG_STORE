namespace Project.DTL
{
    public class Staff
    {
        private int id;
        private string name;
        private string username;
        private string password;
        private string address;
        private string phone;
        private bool isManager;
        private int storeID;

        public Staff() { }

        public Staff(int id, string name, string username, string password, string address, string phone, bool isManager, int storeID)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.address = address;
            this.phone = phone;
            this.isManager = isManager;
            this.storeID = storeID;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public bool IsManager
        {
            get
            {
                return isManager;
            }

            set
            {
                isManager = value;
            }
        }

        public int StoreID
        {
            get
            {
                return storeID;
            }

            set
            {
                storeID = value;
            }
        }
    }
}
