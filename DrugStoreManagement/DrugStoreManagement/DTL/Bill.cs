using System;

namespace Project.DTL
{
    public class Bill
    {
        private int billId;
        private DateTime createDate;
        private double total;
        private int staffId;
        private int customerId;
        private int isDebt;

        public Bill() { }

        public Bill(int billId, DateTime createDate, double total, int staffId, int customerId, int isDebt)
        {
            this.BillId = billId;
            this.CreateDate = createDate;
            this.Total = total;
            this.StaffId = staffId;
            this.CustomerId = customerId;
            this.IsDebt = isDebt;
        }

        public int BillId
        {
            get
            {
                return billId;
            }

            set
            {
                billId = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }

            set
            {
                createDate = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int StaffId
        {
            get
            {
                return staffId;
            }

            set
            {
                staffId = value;
            }
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


    }
}
