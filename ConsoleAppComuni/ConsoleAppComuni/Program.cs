// See https://aka.ms/new-console-template for more information

using ClassLibraryComuni;

var stat = new Stat();
var regione = stat.GetRegioneWithMoreComune(@"C:\Data\MyPath\Codici-statistici-e-denominazioni-al-22_01_2024.csv");
Console.WriteLine($"La regione con più comuni è: {regione}");
