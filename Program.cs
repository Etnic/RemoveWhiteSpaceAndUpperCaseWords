// See https://aka.ms/new-console-template for more information
using RemoveWhiteSpaceAndUpperCaseWords;
using System.Globalization;
using System.Text;


bool showMenu = true;
while (showMenu)
{
    showMenu = MainMenu();
}

static bool MainMenu()
{

    Console.Clear();
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1) One String");
    Console.WriteLine("2) From file");
    Console.WriteLine("3) Exit");
    Console.Write("\r\nSelect an option: ");

    switch (Console.ReadLine())
    {
        case "1":
            AppService.OneWordString();
            return true;
        case "2":
            AppService.FromFile();
            return true;
        case "3":
            return false;
        default:
            return true;
    }
}






