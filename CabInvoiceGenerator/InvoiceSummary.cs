using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int numberOfRides;
        public double totalFare;
        public double averageFare;

        public InvoiceSummary(int numberOfRides,double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = totalFare / numberOfRides;
        }
        //For checking values present in two objects are same are not
        //if you want to compare object values of two diffrent address
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is InvoiceSummary))
                return false;
            InvoiceSummary invoice = (InvoiceSummary)obj;
            return this.numberOfRides == invoice.numberOfRides && this.totalFare == invoice.totalFare && this.averageFare == invoice.averageFare;
        }
    }
}
