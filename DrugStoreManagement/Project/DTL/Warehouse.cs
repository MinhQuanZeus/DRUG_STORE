using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTL
{
    public class Warehouse
    {
        private int Id;
        private int productID;
        private string registeredNumber;
        private DateTime expiryDate;
        private int quantity;
        private DateTime importDate;

        public Warehouse() { }

        public Warehouse(int id, int productID, string registeredNumber, DateTime expiryDate, int quantity, DateTime importDate)
        {
            Id = id;
            this.productID = productID;
            this.registeredNumber = registeredNumber;
            this.expiryDate = expiryDate;
            this.quantity = quantity;
            this.importDate = importDate;
        }

        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public int ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public string RegisteredNumber
        {
            get
            {
                return registeredNumber;
            }

            set
            {
                registeredNumber = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return expiryDate;
            }

            set
            {
                expiryDate = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public DateTime ImportDate
        {
            get
            {
                return importDate;
            }

            set
            {
                importDate = value;
            }
        }
    }
}
