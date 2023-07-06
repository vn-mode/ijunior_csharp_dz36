const string CommandAddDossier = "1";
const string CommandShowAllDossiers = "2";
const string CommandDeleteDossier = "3";
const string CommandExit = "4";

bool isOpen = true;

Dictionary<string, string> dossiers = new Dictionary<string, string>();

while (isOpen)
{
    Console.WriteLine("Введите номер команды");
    Console.WriteLine($"{CommandAddDossier} - Добавить досье");
    Console.WriteLine($"{CommandShowAllDossiers} - Показать все досье");
    Console.WriteLine($"{CommandDeleteDossier} - Удалить выбранное досье");
    Console.WriteLine($"{CommandExit} - Выход из программы");

    string command = Console.ReadLine();
    Console.Clear();

    switch (command)
    {
        case CommandAddDossier:
            AddDossier(dossiers);
            break;

        case CommandShowAllDossiers:
            ShowDossier(dossiers);
            break;

        case CommandDeleteDossier:
            DeleteDossier(dossiers);
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

static void AddDossier(Dictionary<string, string> dossiers)
{
    Console.Write("Введите ФИО: ");
    string name = Console.ReadLine();
    Console.Write("Введите должность: ");
    string position = Console.ReadLine();

    if (dossiers.ContainsKey(name))
    {
        Console.WriteLine("Досье с таким ФИО уже существует.");
    }
    else
    {
        dossiers.Add(name, position);
        Console.WriteLine("Досье успешно добавлено.");
    }
}

static void DeleteDossier(Dictionary<string, string> dossiers)
{
    ShowDossier(dossiers);
    Console.Write("Введите номер досье, которое хотите удалить: ");
    string userInput = Console.ReadLine();

    if (int.TryParse(userInput, out int dossierNumber) && dossierNumber > 0 && dossierNumber <= dossiers.Count)
    {
        var key = dossiers.Keys.ElementAt(dossierNumber - 1);
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

    int dossierNumber = 1;

    foreach (var dossier in dossiers)
    {
        Console.WriteLine($"{dossierNumber}. {dossier.Key} - {dossier.Value}");
        dossierNumber++;
    }
}
