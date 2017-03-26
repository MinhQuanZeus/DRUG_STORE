namespace Project.DTL
{
    public class ProductUnit
    {
        private int unitId;
        private int productID;
        private string unitName;
        private int conversionValue;
        private double sellPrice;

        public ProductUnit() { }

        public ProductUnit(int unitId, int productID, string unitName, int conversionValue, double sellPrice)
        {
            this.unitId = unitId;
            this.productID = productID;
            this.unitName = unitName;
            this.conversionValue = conversionValue;
            this.sellPrice = sellPrice;
        }

        public ProductUnit(int productID, string unitName, int conversionValue, double sellPrice)
        {
            this.productID = productID;
            this.unitName = unitName;
            this.conversionValue = conversionValue;
            this.sellPrice = sellPrice;
        }

        public int UnitId
        {
            get
            {
                return unitId;
            }

            set
            {
                unitId = value;
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

        public string UnitName
        {
            get
            {
                return unitName;
            }

            set
            {
                unitName = value;
            }
        }

        public int ConversionValue
        {
            get
            {
                return conversionValue;
            }

            set
            {
                conversionValue = value;
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
    }
}
