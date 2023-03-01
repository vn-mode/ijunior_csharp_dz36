const string CommandAddDossier = "1";
const string CommandShowAllDossiers = "2";
const string CommandDeleteDossier = "3";
const string CommandExit = "4";

bool isOpen = true;

List<string> dossier = new List<string>();
List<string> position = new List<string>();

while (isOpen)
{
    Console.WriteLine("Введите номер команды");
    Console.WriteLine("1 - Добавить досье");
    Console.WriteLine("2 - Показать все досье");
    Console.WriteLine("3 - Удалить выбранное досье");
    Console.WriteLine("4 - Выход из программы");

    switch (Console.ReadLine())
    {
        case CommandAddDossier:
            AddDossier(ref dossier, ref position);
            break;

        case CommandShowAllDossiers:
            ShowDossier(dossier, position);
            break;

        case CommandDeleteDossier:
            DeleteDossier(ref dossier, ref position);
            break;

        case CommandExit:
            isOpen = false;
            Console.WriteLine("Вы вышли из программы.");
            break;

        default:
            Console.WriteLine("Команда не найдена. Попробуйте ещё раз.");
            break;
    }
    Console.ReadKey();
    Console.Clear();
}

static void AddDossier(ref List<string> dossier, ref List<string> position)
{
    Console.Write("Введите ФИО: ");
    string userInput = Console.ReadLine();
    dossier.Add(userInput);
    Console.Write("Введите должность: ");
    userInput = Console.ReadLine();
    position.Add(userInput);
    Console.WriteLine("Досье успешно добавлено.");
}

static void DeleteDossier(ref List<string> dossier, ref List<string> position)
{
    Console.Write("Введите номер досье: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    if (dossier.Count != 0)
    {
        dossier.RemoveAt(userInput - 1);
        position.RemoveAt(userInput - 1);
        Console.WriteLine("Досье успешно удалено.");
    }
    else
    {
        Console.WriteLine("Список досье пуст");
    }
}

static void ShowDossier(List<string> dossier, List<string> position)
{
    Console.WriteLine("Все досье:");
    for (int i = 0; i < dossier.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + dossier[i] + " " + position[i]);
    }
}