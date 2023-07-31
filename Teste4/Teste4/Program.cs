using Microsoft.Win32.SafeHandles;
using Nager.Holiday;
using System.Globalization;

namespace Teste4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var holidayClient = new HolidayClient();

            try
            {
                Console.Write("Informe a data de vencimento (ex: dd/mm/yyyy): ");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Informe o valor do boleto: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Informe a data de pagamento (ex: dd/mm/yyyy): ");
                DateTime paymentDate = DateTime.Parse(Console.ReadLine());
                double totalFees = 0.0;
                double totalFine = 0.0;

                BankSlip bankSlip = new BankSlip()
                {
                    DueDate = dueDate,
                    PaymentDate = paymentDate,
                    Value = value,
                    TotalFees = totalFees,
                    TotalFine = totalFine
                };

                Console.WriteLine();

                var holiday = await holidayClient.GetHolidaysAsync(DateTime.Now.Year, "br");

                if (dueDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    var days = ( paymentDate - dueDate).Days;

                    if (days > 2)
                    {
                        var newBankSlip = CreateBankSlipWithFees(bankSlip, days + 1);
                        newBankSlip.DueDate = paymentDate;
                        Console.WriteLine($"Valor do boleto recalculado R$: {newBankSlip.Value.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de juros R$: {newBankSlip.TotalFees.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de multa R$: {newBankSlip.TotalFine.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                    else
                    {
                        bankSlip.DueDate = paymentDate;
                        Console.WriteLine($"Valor do boleto recalculado R$: {bankSlip.Value.ToString("F2", CultureInfo.InvariantCulture)}");

                    }
                }
                else if (dueDate.DayOfWeek == DayOfWeek.Sunday || (holiday.Where(holiday => holiday.Date == dueDate).Count() > 1))
                {
                    var days = (paymentDate - dueDate).Days;

                    if (days > 1)
                    {
                        var newBankSlip = CreateBankSlipWithFees(bankSlip, days + 1 );
                        newBankSlip.DueDate = paymentDate;
                        Console.WriteLine($"Valor do boleto recalculado R$: {newBankSlip.Value.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de juros R$: {newBankSlip.TotalFees.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de multa R$: {newBankSlip.TotalFine.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                    else
                    {
                        bankSlip.DueDate = paymentDate;
                        Console.WriteLine($"Valor do boleto recalculado R$: {bankSlip.Value.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de juros R$: {bankSlip.TotalFees.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de multa R$: {bankSlip.TotalFine.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }
                else 
                {
                    if (bankSlip.DueDate >= paymentDate)
                    {
                        Console.WriteLine($"Valor do boleto recalculado R$: {bankSlip.Value.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de juros R$: {bankSlip.TotalFees.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de multa R$: {bankSlip.TotalFine.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                    else
                    {
                        var days = (paymentDate - dueDate).Days;

                        var newBankSlip = CreateBankSlipWithFees(bankSlip, days);
                        newBankSlip.DueDate = paymentDate;
                        Console.WriteLine($"Valor do boleto recalculado R$: {newBankSlip.Value.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de juros R$: {newBankSlip.TotalFees.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.WriteLine($"Valor total de multa R$: {newBankSlip.TotalFine.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                    
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static BankSlip CreateBankSlipWithFees(BankSlip bankSlip, int days)
        {
            double totalFees = 0.03 * days;
            bankSlip.Value += 2 + totalFees;
            bankSlip.TotalFine = 2;
            bankSlip.TotalFees = totalFees;
            
            return bankSlip;
        } 
    }
}


