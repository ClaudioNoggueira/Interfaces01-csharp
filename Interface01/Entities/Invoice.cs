using System.Globalization;

namespace Entities {
    class Invoice {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax) {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment() {
            return BasicPayment + Tax;
        }

        public override string ToString() {
            return "Basic payment: R$ " + BasicPayment.ToString("F2", CultureInfo.InvariantCulture) 
                + "\nTax: R$ " + Tax.ToString("F2", CultureInfo.InvariantCulture) 
                + "\nTotal payment: R$ " + TotalPayment().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
