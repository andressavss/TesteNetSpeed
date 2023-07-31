Console.Write("Código do aluno: ");
int cod = int.Parse(Console.ReadLine());

while (cod != 0)
{
    try
    {
        List<double> notes = new List<double>();

        Console.Write("Nota 1 do aluno: ");
        notes.Add(double.Parse(Console.ReadLine()));
        Console.Write("Nota 2 do aluno: ");
        notes.Add(double.Parse(Console.ReadLine()));
        Console.Write("Nota 3 do aluno: ");
        notes.Add(double.Parse(Console.ReadLine()));

        int index = 0;
        double total = 0;

        foreach (var note in notes)
        {
            if (note == notes.Max() && index == 0)
            {
                total += note * 4;
                index++;
            }
            else
            {
                total += note * 3;
            }
        }

        double avg = total / 10;

        if (avg >= 6)
        {
            Console.WriteLine("Aprovado!");
        }
        else
        {
            Console.WriteLine("Reprovado!");
        }

        Console.Write("Código do aluno: ");
        cod = int.Parse(Console.ReadLine());
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }  
}
