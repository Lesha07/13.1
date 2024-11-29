using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        
        List<TodoItem> List = new List<TodoItem>();
        string userConsoleInput;
        do
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nСписок справ:");
            Console.WriteLine("1. Додати справу");
            Console.WriteLine("2. Вивести всі справи");
            Console.WriteLine("3. Позначити справу як виконану");
            Console.WriteLine("4. Видалити справу");
            Console.WriteLine("5. Вийти");
            Console.Write("Оберіть опцію (1-5): ");

            userConsoleInput = Console.ReadLine();

            switch (userConsoleInput)
            {
                case "1":
                    AddDoItem(List);
                    break;
                case "2":
                    DisplayTodoList(List);
                    break;
                case "3":
                    MarkTodoItemAsDone(List);
                    break;
                case "4":
                    RemoveTodoItem(List);
                    break;
                case "5":
                    Console.WriteLine("Вихід із програми...");
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }

        } while (userConsoleInput != "5");
    }

    static void AddDoItem(List<TodoItem> List)
    {
        Console.Write("Введіть назву справи: ");
        string? title = Console.ReadLine();
        List.Add(new TodoItem { Title = title, IsDone = false });
        Console.WriteLine("Справу додано до списку.");
    }

    static void DisplayTodoList(List<TodoItem> List)
    {
        if (List.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        Console.WriteLine("\nВаші справи:");
        for (int i = 0; i < List.Count; i++)
        {
            string status = List[i].IsDone ? "[Виконано]" : "[Невиконано]";
            Console.WriteLine($"{i + 1}. {List[i].Title} {status}");
        }
    }

    static void MarkTodoItemAsDone(List<TodoItem> List)
    {
        if (List.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        Console.Write("Введіть номер справи для позначення як виконаної: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= List.Count)
        {
            List[index - 1].IsDone = true;
            Console.WriteLine("Справу позначено як виконану.");
        }
        else
        {
            Console.WriteLine("Неправильний номер. Спробуйте ще раз.");
        }
    }

    static void RemoveTodoItem(List<TodoItem> List)
    {
        if (List.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        Console.Write("Введіть номер справи для видалення: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= List.Count)
        {
            List.RemoveAt(index - 1);
            Console.WriteLine("Справу видалено.");
        }
        else
        {
            Console.WriteLine("Неправильний номер. Спробуйте ще раз.");
        }
    }
}

class TodoItem
{
    public string Title { get; set; }
    public bool IsDone { get; set; }
}
