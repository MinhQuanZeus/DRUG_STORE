namespace Project.DTL
{
    public class BillDetail
    {
        private int billDetailId;
        private int billId;
        private int productId;
        private int quantity;
        private double captial;
        private string registeredNumberDetail;

        public BillDetail()
        {

        }

        public BillDetail(int billDetailId, int billId, int productId, int quantity, double captial)
        {
            this.billDetailId = billDetailId;
            this.billId = billId;
            this.productId = productId;
            this.quantity = quantity;
            this.captial = captial;
        }

        public BillDetail(int billDetailId, int billId, int productId, int quantity, double captial, string registeredNumberDetail)
        {
            this.billDetailId = billDetailId;
            this.billId = billId;
            this.productId = productId;
            this.quantity = quantity;
            this.captial = captial;
            this.registeredNumberDetail = registeredNumberDetail;
        }

        public int BillDetailId
        {
            get
            {
                return billDetailId;
            }

            set
            {
                billDetailId = value;
            }
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

        public double Captial
        {
            get
            {
                return captial;
            }

            set
            {
                captial = value;
            }
        }

        public string RegisteredNumberDetail
        {
            get
            {
                return registeredNumberDetail;
            }

            set
            {
                registeredNumberDetail = value;
            }
        }
    }
}
