using System;

namespace Teste4
{
    internal class BankSlip
    {
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Value { get; set; }
        public double TotalFees { get; set; }
        public double TotalFine { get; set; }

        public BankSlip()
        {
        }

        public BankSlip(DateTime dueDate, DateTime paymentDate, double originalValue, double totalFees = 0, double totalFine = 0)
        {
            DueDate = dueDate;
            PaymentDate = paymentDate;
            Value = originalValue;
            TotalFees = totalFine;
            TotalFine = totalFees;
        }
    }
}
