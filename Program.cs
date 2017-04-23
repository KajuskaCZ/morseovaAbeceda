using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleSifrovani
{
    class Program
    {
        //Pořadové číslo souboru, do kterého se uloží text v Morseově abecedě
        public static int morseTextFileNumber;
        public static int fromMorseTextFileNumber ;

        //Hlavní menu, které se v programu objeví pouze jednou a to na začátku
        public static void mainMenu()
        {
            //Console.WindowHeight = 35;
            //Console.WindowWidth = 70;
            Console.Title = "SIFROVANI";
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("              .-------------------------------------.\n");
            Console.Write("             /  .-.        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" - ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("SIFROVANI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" -");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("       .-.  \\\n");

            Console.Write("            |  /   \\   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(",-,-,-.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("                 /   \\  |\n");

            Console.Write("            | |\\_.  |  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("`'| | |   ,-. ,-, . .");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("  |    /| |\n");
            Console.Write("            |\\|  | /|    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("; | | \\ |-' | | | |");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("  |\\  | |/|\n");
            Console.Write("            | `---' |      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' `-' `-' ' ' '-'");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("  | `---' |\n");

            Console.Write("            |       |-------------------------|       |\n");
            Console.Write("            \\       |                         |       /\n");
            Console.Write("             \\     /                           \\     /\n");
            Console.Write("              `---'                             `---'\n");

            Console.Write("             _,                                     ,_\n");
            Console.Write("               )                                   (\n");
            Console.Write("              (  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Pro Morseovu abecedu stisknete M");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("   )\n");
            Console.Write("               ) ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Doplneni pro dalsi sifry...   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("    (\n");
            Console.Write("              (  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Pro ukonceni programu stisknete K");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("  )\n");
            Console.Write("               )                                   (\n");
            Console.Write("              (__,_,-=-,_,-=-,_,-=-,_,-=-,_,-=-,_,__)\n\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        //Hlavní menu, které doprovází užiatele v průběhu programu
        static void smallMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" _,.-'~'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("MENU");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("'~'-.,__,.-'~'-.,__,.-'~'-.,_\n");
            Console.Write(" :   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pro Morseovu abecedu stisknete M");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("     :\n");
            Console.Write(" :   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Doplneni pro dalsi sifry...   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("       :\n");
            Console.Write(" :   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pro ukonceni programu stisknete K");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("    :\n");
            Console.Write(" ;----------------------------------------;\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        //Menu spojené s operacemi nad Morseovou abecedou
        public static void morseovaAbecedaMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(".:*~*:._.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("MENU: Morseova abeceda");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("._.:*~*:._.:*~*:._.:*~*:._.:*~*:.\n");
            Console.Write(" .");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    Pro zasifrovani textu do Morseovy abecedy stisknete M");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("     .\n");
            Console.Write(" .");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("    Pro rozsifrovani textu v Morseove abecede stisknete R");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("     .\n");
            Console.Write(" .");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    Pro navrat do hlavniho menu stisknete Z");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("                   .\n");
            Console.Write(" ;--------------------------------------------------------------;\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Zašifrování textu do Morseovy abecedy, vstupem je text, který chceme zašifrovat
        //Výstupem funkce je string zašifrovaného textu
        //Pokud je vstupní text ve špatném formátu, tak funkce vrátí prázdný řetězec
        public static string textToMorse(string line)
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>();

            morseCode['a'] = ".-";
            morseCode['b'] = "-...";
            morseCode['c'] = "-.-.";
            morseCode['d'] = "-..";
            morseCode['e'] = ".";
            morseCode['f'] = "..-.";
            morseCode['g'] = "--.";
            morseCode['h'] = "....";
            morseCode['i'] = "..";
            morseCode['j'] = ".---";
            morseCode['k'] = "-.-";
            morseCode['l'] = ".-..";
            morseCode['m'] = "--";
            morseCode['n'] = "-.";
            morseCode['o'] = "---";
            morseCode['p'] = ".--.";
            morseCode['q'] = "--.-";
            morseCode['r'] = ".-.";
            morseCode['s'] = "...";
            morseCode['t'] = "-";
            morseCode['u'] = "..-";
            morseCode['v'] = "...-";
            morseCode['w'] = ".--";
            morseCode['x'] = "-..-";
            morseCode['y'] = "-.--";
            morseCode['z'] = "--..";

            string morseText = "";

            line = line.ToLower();
            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] == ' ')
                {
                    continue;
                }
                if (morseCode.ContainsKey(line[i]))
                {
                    if (i != line.Length - 1 && line[i + 1] == ' ')
                    {
                        morseText += morseCode[line[i]];
                        morseText += "//";
                        continue;
                    }
                    morseText += morseCode[line[i]];
                    morseText += "/";
                }
                else
                {
                    return "";
                }
            }
            return morseText;
        }

        //Rozšifrování textu zapsaného v Morseově abecedě, vstupem je text, který chceme rošifrovat
        //Výstupem funkce je rozšifrovaný text
        //Pokud je vstupní text ve špatném formátu, tak funkce vrátí prázdný řetězec
        public static string morseToText(string line)
        {
            Dictionary<string, char> morseCode = new Dictionary<string, char>();

            morseCode[".-"] = 'a';
            morseCode["-..."] = 'b';
            morseCode["-.-."] = 'c';
            morseCode["-.."] = 'd';
            morseCode["."] = 'e';
            morseCode["..-."] = 'f';
            morseCode["--."] = 'g';
            morseCode["...."] = 'h';
            morseCode[".."] = 'i';
            morseCode[".---"] = 'j';
            morseCode["-.-"] = 'k';
            morseCode[".-.."] = 'l';
            morseCode["--"] = 'm';
            morseCode["-."] = 'n';
            morseCode["---"] = 'o';
            morseCode[".--."] = 'p';
            morseCode["--.-"] = 'q';
            morseCode[".-."] = 'r';
            morseCode["..."] = 's';
            morseCode["-"] = 't';
            morseCode["..-"] = 'u';
            morseCode["...-"] = 'v';
            morseCode[".--"] = 'w';
            morseCode["-..-"] = 'x';
            morseCode["-.--"] = 'y';
            morseCode["--.."] = 'z';

            string fromMorseText = "";
            string tmp = "";
            bool slash = false;

            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] == '.' || line[i] == '-')
                {
                    tmp += line[i];
                }
                else if (line[i] == '/')
                {
                    if (i != 0 && line[i - 1] == '/')
                    {
                        if (slash)
                        {
                            return "";
                        }
                        fromMorseText += ' ';
                        slash = true;
                    }
                    else
                    {
                        if (morseCode.ContainsKey(tmp))
                        {
                            fromMorseText += morseCode[tmp];
                            tmp = "";
                            slash = false;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                else
                {
                    return "";
                }
            }

            if (tmp != "")
            {
                return "";
            }

            return fromMorseText; 
        }

        //Čte text ze souboru. Soubor obsahuje text, který chceme rozšifrovat z Morseovy abecedy.
        //Vstupem funkce je název souboru, ze kterého čteme text
        //Funkce text vypíše do konzole a následně uloží do souboru.
        public static void ReadFromFileFromMorse(string fileName)
        {
            try
            {
                string fromMorseText = "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string fileLine;
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        if (morseToText(fileLine) == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Zadan neplatny znak v textu!");
                            Console.ForegroundColor = ConsoleColor.White;

                            return;
                        }
                        fromMorseText += morseToText(fileLine);

                        fromMorseText += '\n';
                    }
                    Console.Write(fromMorseText);

                    WriteToFile(fromMorseText, "fromMorseText", ref fromMorseTextFileNumber);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Soubor nenalezen:");
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Čte text ze souboru. Soubor obsahuje text, který chceme zašifrovat do Morseovy abecedy.
        //Vstupem funkce je název souboru, ze kterého čteme text
        //Funkce text vypíše do konzole a následně uloží do souboru.
        public static void ReadFromFileToMorse(string fileName)
        {
            try
            {
                string morseText = "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string fileLine;
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        if (textToMorse(fileLine) == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Zadan neplatny znak v textu!");
                            Console.ForegroundColor = ConsoleColor.White;

                            return;
                        }
                        morseText += textToMorse(fileLine);

                        morseText += '\n';
                    }
                    Console.Write(morseText);

                    WriteToFile(morseText, "morseText", ref morseTextFileNumber);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Soubor nenalezen.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Funkce ukládá text do souboru.
        //Vstupem je text, který chceme uložit, typ šifry, který používáme a číselné pořadí souboru.
        public static void WriteToFile(string text, string cipherType, ref int numberOfFile)
        {
            using (StreamWriter sw = new StreamWriter(@cipherType + numberOfFile + ".txt"))
            {
                sw.Write(text);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Text byl ulozen do souboru: " + cipherType + numberOfFile + ".txt");
                Console.ForegroundColor = ConsoleColor.White;

                ++numberOfFile;
            }
        }

        static void Main(string[] args)
        {
            morseTextFileNumber = 0;
            fromMorseTextFileNumber = 0;

            mainMenu();

            string line = "";

            while (true)
            {
                //Písmeno hlavního menu
                char c;
                c = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine("");

                switch (c)
                {
                    //Morseova abeceda
                    case 'M':
                        {
                            morseovaAbecedaMenu();
                            bool back = false;

                            //While menu Morseova abeceda
                            while (true)
                            {
                                //Písmeno menu Morseova abeceda
                                c = char.ToUpper(Console.ReadKey().KeyChar);
                                Console.WriteLine("");

                                switch (c)
                                {
                                    //Zvolen překlad textu do Morseovy abecedy
                                    case 'M':
                                        {
                                            string morseText = "";

                                            //Zepta se, jestli chce uzivatel text nacist ze souboru
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine("Chtete text nacist ze souboru? Y/N");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            
                                            //While menu Chcete načíst text
                                            while (c != 'Y' && c != 'N')
                                            {
                                                c = char.ToUpper(Console.ReadKey().KeyChar);
                                                Console.WriteLine("");

                                                switch (c)
                                                {
                                                    //Text je načítán ze souboru
                                                    case 'Y':
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            Console.WriteLine("Zadejte jmeno souboru:");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            
                                                            line = Console.ReadLine();

                                                            ReadFromFileToMorse(line);

                                                            break;
                                                        }
                                                    //Text uživatel píše do konzole
                                                    case 'N':
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            Console.WriteLine("Zadejte text do konzole:");
                                                            Console.ForegroundColor = ConsoleColor.White;

                                                            line = Console.ReadLine();

                                                            morseText = textToMorse(line);

                                                            if(morseText == "")
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                Console.WriteLine("Zadan neplatny znak v textu!");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                break;
                                                            } 
                                                            Console.WriteLine(morseText);

                                                            WriteToFile(morseText, "morseText", ref morseTextFileNumber);

                                                            break;
                                                        }
                                                    //Zadán nesprávný znak
                                                    default:
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            Console.WriteLine("Zadan nespravny znak v menu");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            
                                                            break;
                                                        }
                                                }
                                            }
                                            morseovaAbecedaMenu();
                                            break;
                                        }
                                    //Zvoleno rozšifrování textu z Morseovy abecedy
                                    case 'R':
                                    {
                                        string fromMorseText = "";

                                        //Zeptá se, jestli chce uzivatel text nacist ze souboru
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.WriteLine("Chtete text nacist ze souboru? Y/N");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        //While menu Chcete načíst text
                                        while (c != 'Y' && c != 'N')
                                        {
                                            c = char.ToUpper(Console.ReadKey().KeyChar);
                                            Console.WriteLine("");

                                            switch (c)
                                            {
                                                //Text je načítán ze souboru
                                                case 'Y':
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine("Zadejte jmeno souboru:");
                                                        Console.ForegroundColor = ConsoleColor.White;

                                                        line = Console.ReadLine();

                                                        ReadFromFileFromMorse(line);

                                                        break;
                                                    }
                                                //Text uživatel píše do konzole
                                                case 'N':
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine("Zadejte text do konzole:");
                                                        Console.ForegroundColor = ConsoleColor.White;

                                                        line = Console.ReadLine();

                                                        fromMorseText = morseToText(line);

                                                        if (fromMorseText == "")
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            Console.WriteLine("Zadan neplatny znak v textu!");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            break;
                                                        }
                                                        Console.WriteLine(fromMorseText);

                                                        WriteToFile(fromMorseText, "fromMorseText", ref fromMorseTextFileNumber);

                                                        break;
                                                    }
                                                //Zadán nesprávný znak
                                                default:
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine("Zadan nespravny znak v menu");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        break;
                                                    }
                                            }

                                        }

                                        morseovaAbecedaMenu();
                                        break;
                                        }
                                    //Vrátí zpět do hlavního menu
                                    case 'Z':
                                        {
                                            back = true;
                                            break;
                                        }
                                    //Zadán nesprávný znak
                                    default:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine("Zadan nespravny znak v menu");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        }
                                }
                                if (back)
                                {
                                    break;
                                }
                            }
                            //Spuštění malého havního menu
                            smallMenu();
                            break;
                        }
                    //Konec programu
                    case 'K':
                        {
                            return;
                        }
                    //Zadán nesprávný znak
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Nespravny znak");
                            Console.ForegroundColor = ConsoleColor.White;
                           
                            break;
                        }
                }
            }
        }
    }
}
