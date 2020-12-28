using Entities;
using System;

namespace Services {
    class RentalService {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService TaxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService) {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            this.TaxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental) {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0;
            if (duration.TotalHours <= 12) {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }
            double tax = TaxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
