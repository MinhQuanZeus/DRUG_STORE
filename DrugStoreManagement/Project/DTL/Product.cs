using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTL
{
    public class Product
    {
        private int id;
        private int productypeID;
        private string name;
        private string description;
        private string guide;
        private int storeId;
        private string unit;
      
        private double price;
        private double sellPrice;
        private int status;

        public Product() { }

        public Product(int id, int productypeID, string name, string description, string guide, int storeId, string unit,  double price, double sellPrice)
        {
            this.id = id;
            this.productypeID = productypeID;
            this.name = name;
            this.description = description;
            this.guide = guide;
            this.storeId = storeId;
            this.unit = unit;
          
            this.price = price;
            this.sellPrice = sellPrice;
        }

        public Product(int productypeID, string name, string description, string guide, int storeId, string unit,  double price, double sellPrice)
        {
            this.productypeID = productypeID;
            this.name = name;
            this.description = description;
            this.guide = guide;
            this.storeId = storeId;
            this.unit = unit;
           
            this.price = price;
            this.sellPrice = sellPrice;
        }

        public Product(int id, int productypeID, string name, string description, string guide, int storeId, string unit,  double price, double sellPrice, int status)
        {
            this.id = id;
            this.productypeID = productypeID;
            this.name = name;
            this.description = description;
            this.guide = guide;
            this.storeId = storeId;
            this.unit = unit;
           
            this.price = price;
            this.sellPrice = sellPrice;
            this.Status = status;
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

        public int ProductypeID
        {
            get
            {
                return productypeID;
            }

            set
            {
                productypeID = value;
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Guide
        {
            get
            {
                return guide;
            }

            set
            {
                guide = value;
            }
        }

        public int StoreId
        {
            get
            {
                return storeId;
            }

            set
            {
                storeId = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

      

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public double SellPrice
        {
            get
            {
                return sellPrice;
            }

            set
            {
                sellPrice = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
