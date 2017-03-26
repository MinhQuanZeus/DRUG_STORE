namespace Project.DTL
{
    public class Store
    {
        private int storeID;
        private string name;

        public Store() { }

        public Store(int storeID, string name)
        {
            this.storeID = storeID;
            this.name = name;
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
    }
}
