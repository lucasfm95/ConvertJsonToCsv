using ChoETL;

var pathBase = "C:\\ConvertJsonToCsv";
if (!Directory.Exists(pathBase))
{
    Directory.CreateDirectory(pathBase);
}
var choice = "s";
do
{
    Console.WriteLine("Informe o nome do arquivo");
    var filename = Console.ReadLine();


    var pathJson = $"{pathBase}\\{filename}.json";
    var pathCsv = $"{pathBase}\\{filename}.csv";


    using (var r = new ChoJSONReader(pathJson))
    {
        using (var w = new ChoCSVWriter(pathCsv).WithFirstLineHeader())
        {
            w.Write(r);
        }
    }

    Console.WriteLine("Arquivo gerado"); 
    
    Console.WriteLine("Deseja converter outro arquivo? (s/n)");
    choice = Console.ReadLine() ?? "n";
} while (choice.ToLower() == "s");

Console.WriteLine("bye");
