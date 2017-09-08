using System;
using System.IO;


namespace BC_Cancer_Agency.four_D_VMAT
{
    internal static class InputHandler
    {
        public static string GetPathFromInput()
        {
#if DEBUG
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(CurrentDirectory, "a.bin");
            return path;
#else
        start:
            	Console.WriteLine("Please enter the name of TLE file:");
            	string name = Console.ReadLine();
            	string CurrentDirectory = Directory.GetCurrentDirectory();
            	string path = Path.Combine(CurrentDirectory, name);

            	Console.WriteLine("The full address will be: " + path + ".");
            confirmation1:
            	Console.WriteLine("Are you sure? (Y/N)");
            	var response1 = Console.ReadLine();

            	switch (response1.ToUpper())
            	{
            		case "Y":
            			break;
            		case "N":
            			goto start;
            		default:
            			Console.WriteLine("please enter 'Y' or 'N'");
            			goto confirmation1;
            	}
            confirmation2:
            if (!File.Exists(path))
            {
            	Console.WriteLine("File doesn't exist, do you want to enter file name again? (Y/N)");
            	var response2 = Console.ReadLine();
            	switch (response2.ToUpper())
            	{
            		case "Y":
            			goto start;
            		case "N":
            			System.Environment.Exit(1);
            			break;
            		default:
            			Console.WriteLine("please enter 'Y' or 'N'");
            			goto confirmation2;
            	}
            }
            return path;
#endif
        }
    }
}