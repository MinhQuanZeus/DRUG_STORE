using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTL
{
    public class ProductType
    {
        private int producttypeId;
        private string producttypeName;

        public ProductType() { }

        public ProductType(int producttypeId, string producttypeName)
        {
            this.producttypeId = producttypeId;
            this.producttypeName = producttypeName;
        }

        public int ProducttypeId
        {
            get
            {
                return producttypeId;
            }

            set
            {
                producttypeId = value;
            }
        }

        public string ProducttypeName
        {
            get
            {
                return producttypeName;
            }

            set
            {
                producttypeName = value;
            }
        }
    }
}
