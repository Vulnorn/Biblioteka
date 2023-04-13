using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dosie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MenuConsoleAddDossier = 1;
            const int MenuConsoleOutputAllDossiers = 2;
            const int MenuConsoleDeleteDossier = 3;
            const int MenuConsoleExit = 4;

            bool isWork = true;
            int userChoice;
            string[] fullNameDossier = new string[0];
            string[] postDossier = new string[0];
            string userInput;

            while (isWork)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"\n{MenuConsoleAddDossier}. Добавить досье. \n\n{MenuConsoleOutputAllDossiers}. Вывести все досье.\n\n{MenuConsoleDeleteDossier}. Удалить досье.\n\n{MenuConsoleExit}. Выход.");
                userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case MenuConsoleAddDossier:
                        Console.Clear();
                        Console.WriteLine($"Введите ФИО сотрудника.");
                        userInput = Console.ReadLine();
                        fullNameDossier = RewriteTheArray(fullNameDossier, userInput, fullNameDossier.Length);
                        Console.Clear();
                        Console.WriteLine($"Введите должность сотрудника.");
                        userInput = Console.ReadLine();
                        postDossier = RewriteTheArray(postDossier, userInput, postDossier.Length);
                        break;

                    case MenuConsoleOutputAllDossiers:
                        Console.Clear();

                        if (fullNameDossier.Length == 0)
                        {
                            Console.WriteLine($"Досье пустое, заполните досье!");
                            Console.ReadKey();
                        }
                        else
                        {
                            OutputDossier(fullNameDossier, postDossier);
                        }

                        break;

                    case MenuConsoleDeleteDossier:
                        Console.Clear();
                        Console.WriteLine($"Введите номер досье, тоторый вы холите удалить");
                        userChoice = Convert.ToInt32(Console.ReadLine());

                        if (userChoice <= fullNameDossier.Length && userChoice > 0)
                        {
                            SortArray(fullNameDossier, userChoice);
                            SortArray(postDossier, userChoice);
                            fullNameDossier = DeleteValue(fullNameDossier, fullNameDossier.Length);
                            postDossier = DeleteValue(postDossier, postDossier.Length);
                            Console.WriteLine($"Досье удалено!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"Такого номера нет!");
                            Console.ReadKey();
                        }

                        break;
                  
                    case MenuConsoleExit:
                        isWork = false;
                        break;

                    default:
                        break;
                }
            }
        }

        static string[] RewriteTheArray(string[] arrayToChange, string value, int lengthArray)
        {
            string[] tempArray = new string[lengthArray + 1];

            for (int i = 0; i < lengthArray; i++)
            {
                tempArray[i] = arrayToChange[i];
            }

            tempArray[lengthArray] = value;
            return arrayToChange = tempArray;
        }

        static void OutputDossier(string[] arrayFullName, string[] arrayPost)
        {
            int ordinalNumber = 1;

            for (int i = 0; i < arrayFullName.Length; i++)
            {
                Console.WriteLine($"{ordinalNumber}) {arrayFullName[i]} - {arrayPost[i]}");
                ordinalNumber++;
            }

            Console.ReadKey();
        }

        static void SortArray(string[] arrayToChange, int searchValue)
        {
            if (searchValue != arrayToChange.Length)
            {
                for (int i = searchValue - 1; i < arrayToChange.Length - 1; i++)
                {
                    string swithValue = arrayToChange[i];
                    arrayToChange[i] = arrayToChange[i + 1];
                    arrayToChange[i + 1] = swithValue;
                }
            }
        }

        static string[] DeleteValue(string[] arrayToDelete, int lengthArray)
        {
            string[] tempArray = new string[lengthArray - 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = arrayToDelete[i];
            }

            return arrayToDelete = tempArray;
        }

        static void FindTheLastName(string[] arrayFullName, string userInput, string[] arrayPost)
        {
            char whitespace = ' ';
            int quantityName = 0;

            for (int i = 0; i < arrayFullName.Length; i++)
            {
                string[] splitetWords = arrayFullName[i].Split(whitespace);

                if (splitetWords[0].ToLower() == userInput.ToLower())
                {
                    Console.WriteLine($"{i + 1}. {arrayFullName[i]} - {arrayFullName[i]}");
                    quantityName++;
                }

                if (quantityName == 0)
                {
                    Console.WriteLine($"Такой фамилии нет!");
                }
            }

            Console.ReadKey();
        }
    }
}