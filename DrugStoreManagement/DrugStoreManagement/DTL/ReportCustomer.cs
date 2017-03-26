namespace Project.DTL
{
    class ReportCustomer
    {
        int id;
        string name;
        string address;
        string phone;
        double revenue;
        int isDebt;

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

        public double Revenue
        {
            get
            {
                return revenue;
            }

            set
            {
                revenue = value;
            }
        }

        public int IsDebt
        {
            get
            {
                return isDebt;
            }

            set
            {
                isDebt = value;
            }
        }

        public ReportCustomer(int id, string name, string address, string phone, double revenue, int isDebt)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Revenue = revenue;
            this.IsDebt = isDebt;
        }
    }
}
