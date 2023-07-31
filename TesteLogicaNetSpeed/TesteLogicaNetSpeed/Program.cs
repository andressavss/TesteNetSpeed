using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using TesteLogicaNetSpeed;

var listCar = new List<Car>();

string answer = "";

while (answer != "N")
{
    try
    {
        string question = "Qual o ano do carro? ";
        Console.Write(question);
        int year = int.Parse(Console.ReadLine());
        string question2 = "Qual o valor do carro? ";
        Console.Write(question2);
        double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        listCar.Add(new Car()
        {
            Year = year,
            Value = value
        });

        double discount;

        double total = 0;
        if (year <= 2000)
        {
            discount = value * 0.12;
            total = value - discount;
        }
        else
        {
            discount = value * 0.7;
            total = value - discount;
        }

        Console.WriteLine($"Valor do desconto: {discount}");
        Console.WriteLine($"Total à ser pago: {total}");

        Console.Write("Deseja continuar? ");
        answer = Console.ReadLine().ToUpper();
    }
    catch (Exception ex)
    {
            Console.WriteLine(ex);
    }   
}

Console.WriteLine();

var qtyCarsLess2000 = listCar.Where(sum => sum.Year <= 2000).Count();
Console.WriteLine($"Quantidade de carros até 2000: {qtyCarsLess2000}");
Console.WriteLine($"Quantidade de carros: {listCar.Count}");
