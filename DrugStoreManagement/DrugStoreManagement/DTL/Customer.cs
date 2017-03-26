namespace Project.DTL
{
    public class Customer
    {
        private int customerId;
        private string name;
        private string address;
        private string phone;
        private int storeID;

        public Customer() { }

        public Customer(int customerId, string name, string address, string phone, int storeID)
        {
            this.customerId = customerId;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.storeID = storeID;
        }

        public int CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
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
