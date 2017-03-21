using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTL
{
    public class Import
    {
        private int importID;
        private DateTime importDate;
        private double total;
        private int staffID;

        public Import() { }

        public Import(int importID, DateTime importDate, double total, int staffID)
        {
            this.importID = importID;
            this.importDate = importDate;
            this.total = total;
            this.staffID = staffID;
        }

        public int ImportID
        {
            get
            {
                return importID;
            }

            set
            {
                importID = value;
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

        public int StaffID
        {
            get
            {
                return staffID;
            }

            set
            {
                staffID = value;
            }
        }
    }
}
