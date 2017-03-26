namespace Project.DTL
{
    public class ImportDetail
    {
        private int importDetailID;
        private int importId;
        private int productId;
        private int quantity;
        private double price;

        public ImportDetail() { }

        public ImportDetail(int importDetailID, int importId, int productId, int quantity, double price)
        {
            this.importDetailID = importDetailID;
            this.importId = importId;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }

        public int ImportDetailID
        {
            get
            {
                return importDetailID;
            }

            set
            {
                importDetailID = value;
            }
        }

        public int ImportId
        {
            get
            {
                return importId;
            }

            set
            {
                importId = value;
            }
        }

        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
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
    }
}
