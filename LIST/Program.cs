List<string> fullName = [];

Console.WriteLine("Введите ФИО (Фамилия Имя Отчество):");
fullName.AddRange(Console.ReadLine().Split(' ')); // Разбиваем строку на список

if (fullName.Count != 3) 
{
    Console.WriteLine("Ошибка! Введите корректное ФИО (Фамилия Имя Отчество)");
    return;
}

bool isRunning = true;


while (isRunning)
{
    Console.WriteLine("\nВыберите операцию:");
    Console.WriteLine("1) Вытащить фамилию, имя или отчество.");
    Console.WriteLine("2) Отсортировать фамилию по возрастанию или убыванию.");
    Console.WriteLine("3) Изменить своё имя, фамилию или отчество.");
    Console.WriteLine("4) Показать полное ФИО.");
    Console.WriteLine("5) Выйти.");
    Console.Write("Введите номер операции: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            ExtractPart(fullName);
            break;
        case 2:
            SortSurname(fullName);
            break;
        case 3:
            ChangePart(fullName);
            break;
        case 4:
            ShowFullName(fullName);
            break;
        case 5:
            isRunning = false;
            Console.WriteLine("Выход из программы.");
            break;
        default:
            Console.WriteLine("Неверный выбор! Попробуйте снова.");
            break;
    }
}

    // 1. Извлечение части ФИО
    static void ExtractPart(List<string> fullName)
{
    Console.WriteLine("Какую часть вы хотите вытащить? (1 - Фамилия, 2 - Имя, 3 - Отчество):");
    int partChoice = int.Parse(Console.ReadLine());

    if (partChoice >= 1 && partChoice <= 3)
    {
        Console.WriteLine($"Результат: {fullName[partChoice - 1]}");
    }
    else
    {
        Console.WriteLine("Неверный выбор!");
    }
}

// 2. Сортировка фамилии
static void SortSurname(List<string> fullName)
{
    Console.WriteLine("Выберите порядок сортировки фамилии (1 - по возрастанию, 2 - по убыванию):");
    int sortChoice = int.Parse(Console.ReadLine());
    char[] surnameArray = fullName[0].ToCharArray();

    if (sortChoice == 1)
    {
        Array.Sort(surnameArray); // Сортировка по возрастанию
    }
    else if (sortChoice == 2)
    {
        Array.Sort(surnameArray);
        Array.Reverse(surnameArray); // Сортировка по убыванию
    }
    else
    {
        Console.WriteLine("Неверный выбор!");
        return;
    }

    string sortedSurname = new(surnameArray);
    Console.WriteLine($"Результат: {sortedSurname}");
}

// 3. Изменение части ФИО
static void ChangePart(List<string> fullName)
{
    Console.WriteLine("Какую часть вы хотите изменить? (1 - Фамилия, 2 - Имя, 3 - Отчество):");
    int partChoice = int.Parse(Console.ReadLine());

    if (partChoice >= 1 && partChoice <= 3)
    {
        Console.WriteLine($"Введите новое значение для {GetPartName(partChoice)}:");
        string newValue = Console.ReadLine();
        fullName[partChoice - 1] = newValue;
        Console.WriteLine("Изменение выполнено.");
    }
    else
    {
        Console.WriteLine("Неверный выбор!");
    }
}

// 4. Показать полное ФИО
static void ShowFullName(List<string> fullName)
{
    Console.WriteLine($"Полное ФИО: {string.Join(" ", fullName)}");
}

// Вспомогательная функция для получения названия части ФИО
static string GetPartName(int choice)
{
    return choice switch
    {
        1 => "Фамилия",
        2 => "Имя",
        3 => "Отчество",
        _ => "Часть"
    };
}