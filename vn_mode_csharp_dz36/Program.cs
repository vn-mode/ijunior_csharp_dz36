const string CommandAddDossier = "1";
const string CommandShowAllDossiers = "2";
const string CommandDeleteDossier = "3";
const string CommandExit = "4";

bool isOpen = true;

Dictionary<string, string> dossiers = new Dictionary<string, string>();

while (isOpen)
{
    Console.WriteLine("Введите номер команды");
    Console.WriteLine("1 - Добавить досье");
    Console.WriteLine("2 - Показать все досье");
    Console.WriteLine("3 - Удалить выбранное досье");
    Console.WriteLine("4 - Выход из программы");

    string command = Console.ReadLine();
    Console.Clear();

    switch (command)
    {
        case CommandAddDossier:
            AddDossier(ref dossiers);
            break;

        case CommandShowAllDossiers:
            ShowDossier(dossiers);
            break;

        case CommandDeleteDossier:
            DeleteDossier(ref dossiers);
            break;

        case CommandExit:
            isOpen = false;
            break;

        default:
            Console.WriteLine("Команда не найдена. Попробуйте ещё раз.");
            break;
    }

    Console.ReadKey();
    Console.Clear();
}

Console.WriteLine("Вы вышли из программы.");

static void AddDossier(ref Dictionary<string, string> dossiers)
{
    Console.Write("Введите ФИО: ");
    string name = Console.ReadLine();
    Console.Write("Введите должность: ");
    string position = Console.ReadLine();
    dossiers.Add(name, position);
    Console.WriteLine("Досье успешно добавлено.");
}

static void DeleteDossier(ref Dictionary<string, string> dossiers)
{
    ShowDossier(dossiers);
    Console.Write("Введите номер досье, которое хотите удалить: ");
    string userInput = Console.ReadLine();

    if (int.TryParse(userInput, out int resultParse) && resultParse > 0 && resultParse <= dossiers.Count)
    {
        var key = dossiers.Keys.ElementAt(resultParse - 1);
        dossiers.Remove(key);
        Console.WriteLine("Досье успешно удалено.");
    }
    else
    {
        Console.WriteLine("Вы ввели некорректные данные. Попробуйте ещё раз.");
    }
}

static void ShowDossier(Dictionary<string, string> dossiers)
{
    Console.WriteLine("Все досье:");
    int i = 1;
    foreach (var dossier in dossiers)
    {
        Console.WriteLine($"{i}. {dossier.Key} - {dossier.Value}");
        i++;
    }
}
