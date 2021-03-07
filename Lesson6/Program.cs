using System;
using System.IO;
using System.Text.Json;

namespace Lesson6
{

    class Program
    {
        const string TASKFILE = "tasks.json";
        const string TESTDIR = @"D:\test\";
        const string FILELIST_NAME = "filesAndDirs.txt";
        const string FILELIST_NAME_RECURSIVELY = "filesAndDirsRecursively.txt";
        static readonly string[,] INT_ARRAY_4x4 =  { { "21", "12", "1", "32" }, { "51", "3", "8", "2" }, { "74", "28", "15", "13" }, { "24", "93", "98", "51" } };
        static readonly string[,] INT_ARRAY_3x4 = { { "51", "3", "8", "2" }, { "74", "28", "15", "13" }, { "24", "93", "98", "51" } };
        static readonly string[,] INT_ARRAY_4x4_BAD = { { "21", "12", "1", "32" }, { "51", "3", "8", "2" }, { "74", "2g8", "15", "13" }, { "24", "93", "98", "51" } };
        static (string fio, string pos, string email, string phone, int salary, int age) 
            person1 = (fio: "Шестаков Семен Семёнович", pos:"Менеджер", email:"shestakov@mail.ru", phone: "9038084688", salary: 65000, age: 46),
            person2 = (fio: "Кулатов Филимон Серафимович", pos:"Руководитель", email: "kulatov@mail.ru", phone: "9775548562", salary:146000, age:48),
            person3 = (fio: "Архипов Ефим Андреевич", pos:"Проектировщик", email: "arhipov@mail.ru", phone: "9067748598", salary:84000, age:38),
            person4 = (fio: "Иванов Егор Геннадьевич", pos:"Аналитик", email: "ivanov@mail.ru", phone: "9111123258", salary:90000, age:45),
            person5 = (fio: "Субботин Анатолий Федотович", pos:"Разработчик", email: "subbotin@mail.ru", phone: "9058893232", salary:140000, age:36);

        static void Main()
        {
            Console.WriteLine("Задание 1-1. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл - БЕЗ РЕКУРСИ.\n" +
                "Нажмите любую кнопку для запуска...");
            Console.ReadKey();
            GetFileAndSubdirList();

            Console.WriteLine("\nЗадание 1-2. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл - С РЕКУРСИЕЙ.\n" +
                "Нажмите любую кнопку для запуска...");
            Console.ReadKey();
            GetFileAndSubdirListRecursively(path: TESTDIR, clearLogFile: true);       // Вызывает рекурсивный обход директории

            Console.WriteLine("\nЗадание 2. Приложение \"Список задач\".\n" +
                "Нажмите любую кнопку для запуска...");
            Console.ReadKey();
            ToDoApp();

            Console.WriteLine("\nЗадание 3. Напишите метод, на вход которого подаётся двумерный строковый массив размером 4х4\n" +
                "Нажмите любую кнопку для запуска...");
            Console.ReadKey();
            Console.WriteLine("\nПодаем на вход массив неверного размера:");
            SumArrayElements(INT_ARRAY_3x4);
            Console.WriteLine("\nПодаем на вход массив с неправильными данными(не int):");
            SumArrayElements(INT_ARRAY_4x4_BAD);
            Console.WriteLine("\nПодаем на вход правильный массив:");
            SumArrayElements(INT_ARRAY_4x4);

            Console.WriteLine("\nЗадание 4. Создать класс \"Сотрудник\"\n" +
                "Нажмите любую кнопку для запуска...");
            Console.ReadKey();
            PrintEmployees();

        }

        private static void PrintEmployees()
        {
            Employee[] empArray = new Employee[5];
            empArray[0] = new Employee(person1.fio, person1.pos, person1.email, person1.phone, person1.salary, person1.age);
            empArray[1] = new Employee(person2.fio, person2.pos, person2.email, person2.phone, person2.salary, person2.age);
            empArray[2] = new Employee(person3.fio, person3.pos, person3.email, person3.phone, person3.salary, person3.age);
            empArray[3] = new Employee(person4.fio, person4.pos, person4.email, person4.phone, person4.salary, person4.age);
            empArray[4] = new Employee(person5.fio, person5.pos, person5.email, person5.phone, person5.salary, person5.age);

            int startAge = GetIntFromConsole("Введите возраст, старше которого вывести сотрудников:");

            foreach (var employee in empArray)
            {
                if (employee.Age > startAge)
                    employee.GetInfo();                
            }
        }

        private static void SumArrayElements(string[,] array)
        {
            int Sum = 0;
            try
            {
                if (array.GetLength(0)!=4 || array.GetLength(1) != 4)       // если неправильный размер массива
                    throw new MyArraySizeException(array.GetLength(0), array.GetLength(1));


                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (!int.TryParse(array[i, j], out int element))        // если тип данных в ячейке не int
                            throw new MyArrayDataException(i+1, j+1);
                        
                        Sum += element;
                    }
                }
                Console.WriteLine($"Сумма элементов массива равна: {Sum}");
            }
            catch (MyArrayDataException e)
            {
                Console.WriteLine($"Ошибка преобразования данных в строке {e.Row}, столбец {e.Column}");
            }
            catch (MyArraySizeException e)
            {
                Console.WriteLine($"Ошибка! Массив неверного размера: {e.RowSize} на {e.ColumnSize}. (Ожидается: 4 на 4)");
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: "+e.Message);
            }
        }

        /// <summary>
        /// Метод, реализующий список задач
        /// </summary>
        public static void ToDoApp()
        {
            
            ToDo[] tasks = new ToDo[0];  
            if (File.Exists(TASKFILE))
            {
                Console.WriteLine($"Обнаружен файл с задачами '{TASKFILE}'. Загружаем данные...");
                LoadTasksFromFile(ref tasks);                
            }
            else
                Console.WriteLine($"Файл {TASKFILE} не обнаружен.");

            while (!PrintTaskList(ref tasks)) ;     // Крутимся в цикле пока пользователь не выбрал "Выход" в списке действий
        }

        /// <summary>
        /// Enum действий со списком задач
        /// </summary>
        enum TaksListActions
        {
            AddTask = 1,
            CompleteTask,
            RemoveTask,
            LoadTasksFromFile,
            SaveTasksToFile
        }

        /// <summary>
        /// Выводит в консоль список действий с задачами 
        /// </summary>
        /// <param name="tasks">массив задач</param>
        /// <returns>Возвращает true - если выбрали действие "Выход", иначе - false</returns>
        private static bool QueryActions(ref ToDo[] tasks)
        {
            Console.WriteLine("Список действий: " +
                "\n1. Добавить задачу, " +
                "\n2. Выполнить задачу, " +
                "\n3. Удалить задачу, " +
                "\n4. Загрузить задачи из файла, " +
                "\n5. Сохранить задачи в файл" +
                "\n6. Выйти ");
            int action = GetIntFromConsole("Выберите действие(1-5):", 1, 6);
            if (action == 6)    // Если выбрали выход из программы - выходим
                return true;
            PerformAction((TaksListActions)action, ref tasks);
            return false;
        }

        private static void PerformAction(TaksListActions action, ref ToDo[] tasks)
        {
            switch (action)
            {
                case TaksListActions.AddTask:
                    AddTask(ref tasks);
                    break;
                case TaksListActions.CompleteTask:
                    CompleteTask(ref tasks);
                    break;
                case TaksListActions.RemoveTask:
                    RemoveTask(ref tasks);
                    break;
                case TaksListActions.LoadTasksFromFile:
                    if (File.Exists(TASKFILE)) 
                        LoadTasksFromFile(ref tasks);
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Файл {TASKFILE} не существует!");
                    }                        
                    break;
                case TaksListActions.SaveTasksToFile:
                    SaveTasksToFile(ref tasks);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Сериализует и сохраняет содержимое массива задач в json-файл
        /// </summary>
        /// <param name="tasks">Входной массив задач</param>
        private static void SaveTasksToFile(ref ToDo[] tasks)
        {
            string[] jsonStr = new string[tasks.Length];   // Создаем массив строк для выгрузки в json-файл
            
            try
            {
                for (int i = 0; i < tasks.Length; i++)
                    jsonStr[i] = JsonSerializer.Serialize<ToDo>(tasks[i]);  // заполняем массив строками сириализованными объектов
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка сериализации! Текст ошибки: " + e.Message);
            }

            try
            {
                File.WriteAllLines(TASKFILE, jsonStr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка записи в файл! Текст ошибки: " + e.Message);
                return;
            }

            Console.Clear();
            Console.WriteLine($"Задачи({jsonStr.Length}шт.) успешно сохранены в файле {TASKFILE}!");

        }

        private static void RemoveTask(ref ToDo[] tasks)
        {
            if (tasks.Length == 0)        // Если задач в массиве нет, выводим сообщение и выходим
            {
                Console.Clear();
                Console.WriteLine("Нечего удалять. Список задач пуст!");
                return;
            }

            int taskNum = GetIntFromConsole($"Выберите номер задачи, которую нужно удалить(от {tasks.GetLowerBound(0) + 1} до {tasks.GetUpperBound(0) + 1}):", 
                tasks.GetLowerBound(0)+1, tasks.GetUpperBound(0)+1);
            Console.Clear();
            DelByIndex<ToDo>(ref tasks, taskNum-1);
            Console.WriteLine($"Задача № {taskNum} удалена!");
        }

        private static void CompleteTask(ref ToDo[] tasks)
        {
            if (tasks.Length == 0)        // Если задач в массиве нет, выводим сообщение и выходим
            {
                Console.Clear();
                Console.WriteLine("Нечего выполнять. Список задач пуст!");
                return;
            }
            int taskNum = GetIntFromConsole($"Выберите номер задачи, которую нужно удалить(от {tasks.GetLowerBound(0) + 1} до {tasks.GetUpperBound(0) + 1}):",
                tasks.GetLowerBound(0) + 1, tasks.GetUpperBound(0) + 1);
            Console.Clear();
            Console.WriteLine((tasks[taskNum - 1].IsDone)? "Данная задача уже выполнена!": $"Задача № {taskNum} выполнена!");
            tasks[taskNum - 1].IsDone = true;
        }

        private static void AddTask(ref ToDo[] tasks)
        {
            ToDo[] newArray = new ToDo[tasks.Length + 1];     //Создаем новый массив на 1 элемент больше

            Console.Write("\nВведите название задачи: ");
            string taskName = Console.ReadLine();

            for (int i = 0; i < tasks.Length; i++)
                newArray[i] = tasks[i];     // Копируем элементы старого массива в новый

            newArray[^1] = new ToDo(taskName);
            tasks = newArray;

            Console.Clear();
            Console.WriteLine($"Задача № {tasks.Length} добавлена.");
        }

        /// <summary>
        /// Распечатывает список задач из массива
        /// </summary>
        /// <param name="tasks">массив задач</param>
        /// <returns>True - если пользователь выбрал окончание работы, иначе - false</returns>
        private static bool PrintTaskList(ref ToDo[] tasks)
        {
            Console.WriteLine("\n===================");
            if (tasks.Length==0)        // Если задач в массиве нет
                Console.WriteLine("<Список задач пуст>");
            else
            {
                Console.WriteLine("Список задач: ");
                for (int i = 0; i < tasks.Length; i++)
                    Console.WriteLine($"{i + 1}. " + (tasks[i].IsDone ? "[x]" : "") + tasks[i].Title);                
            }
            Console.WriteLine("===================\n");
            return QueryActions(ref tasks);
        }

        /// <summary>
        /// Метод загружает данные из json-файла 
        /// </summary>
        /// <param name="file">Имя json-файла</param>
        /// <returns>Массив задач ToDo[]</returns>
        private static ToDo[] LoadTasksFromFile(ref ToDo[] tasks)
        {
            string[] jsonArray = File.ReadAllLines(TASKFILE);

            Array.Resize(ref tasks, jsonArray.Length);   // Меняем размер массива на число, равное количеству строк в json-файле
            try
            {
                for (int i = 0; i < jsonArray.Length; i++)
                    tasks[i] = JsonSerializer.Deserialize<ToDo>(jsonArray[i]);       // Заполняем массив заданий
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка десериализации! Текст ошибки: "+ e.Message);
            }
            Console.Clear();
            Console.WriteLine($"Задачи ({tasks.Length} шт.) успешно загружены из файла {TASKFILE}.");
            return tasks;
        }

        private static void GetFileAndSubdirListRecursively(string path, bool clearLogFile = false)
        {
            string ouputFilename = TESTDIR + FILELIST_NAME_RECURSIVELY; // @"D:\test\filesAndDirsRecursively.txt";

            if (!Directory.Exists(TESTDIR))
            {
                Console.WriteLine($"Директория \"{TESTDIR}\" не существует!");
                return;
            }

            string[] subDirs = Directory.GetDirectories(path);
            string[] dirFiles = Directory.GetFiles(path);

            try
            {
                if(clearLogFile)
                    File.WriteAllText(ouputFilename, "");   // Очищаем итоговый лог-файл                       

                File.AppendAllText(ouputFilename, path + Environment.NewLine);
                File.AppendAllLines(ouputFilename, dirFiles);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка записи в файл: " + e.Message);
                return;
            }

            for (int i = 0; i < subDirs.Length; i++)
                GetFileAndSubdirListRecursively(subDirs[i]);

            if (clearLogFile)
                Console.WriteLine($"Файл \"{ouputFilename}\" успешно создан!\n");
        }

        public static void GetFileAndSubdirList()
        {
            string ouputFilename = TESTDIR + FILELIST_NAME;

            if (Directory.Exists(TESTDIR))
                Console.WriteLine($"Используется директория: \"{TESTDIR}\"");
            else
            {
                Console.WriteLine($"Директория \"{TESTDIR}\" не существует");
                return;
            }
            // Перечень всех файлов и папок, вложенных в workDir
            string[] entries = Directory.GetFileSystemEntries(TESTDIR, "*", SearchOption.AllDirectories);

            try
            {
                File.WriteAllLines(ouputFilename, entries);
                Console.WriteLine($"Файл \"{ouputFilename}\" успешно создан!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка записи в файл: "+e.Message);
                return;
            }
        }
        /// <summary>
        /// Метод запрашивает ввод целого числа с клавиатуры.
        /// </summary>
        /// <param name="message">Приветствие для ввода</param>
        /// <param name="onlyPositive">Ожидать только положительные числа?</param>
        /// <returns>Парсит ввод и возвращает число int</returns>
        static int GetIntFromConsole(string message, int startValue = int.MinValue, int endValue = int.MaxValue)
        {
            int result;
            bool isParseSeccessfull;
            do
            {
                Console.Write($"{message} ");
                isParseSeccessfull = int.TryParse(Console.ReadLine(), out result);
                if (!isParseSeccessfull)   // если парсинг прошел неудачно - пишем ошибку и повторяем цикл(ввод)
                {
                    Console.WriteLine("Вы ввели не целое число. Повторите ввод.");
                    continue;
                }

                if ((result < startValue) || (result > endValue))
                {
                    Console.WriteLine("Введено неправильное число. Ожидается от {0} {1}", startValue, (endValue==int.MaxValue)?"и выше":"до "+ endValue);
                    isParseSeccessfull = false;   //принудительно ставим false, даже если парсинг прошел удачно
                    continue;
                }
                break;   // если все хорошо (т.е. не сработал ни один вышестоящий if) - выходим из цикла
            } while (!isParseSeccessfull);
            return result;
        }

        /// <summary>
        /// Метод удаляет элемент из массива (любого типа) по заданному индексу
        /// </summary>
        /// <param name="array">Изменяемый массив</param>
        /// <param name="delIndex">Индекс удаляемого элемента</param>
        public static void DelByIndex<T>(ref T[] array, int delIndex)
        {
            if (array.Length==1)
            {
                array = new T[0];
                return;
            }
            T[] newArray = new T[array.Length - 1];     //Создаем новый массив на 1 элемент меньше
            for (int i = 0; i < array.Length; i++)
            {
                if (i == delIndex)      // Пропускаем копирование удаляемого элемента
                    continue;
                newArray[(i < delIndex)?i:i-1] = array[i];  // После индекса удаленного элемента копируем элементы со сдвигом 1 (в конечном массиве)
            }
            array = newArray;
        }


        class ToDo
        {
            public string Title { get; set; }
            public bool IsDone { get; set; }

            public ToDo(string taskName)
            {
                Title = taskName;
                IsDone = false;
            }
            public ToDo()
            {
            }
        }

        /// <summary>
        /// Класс, описывающий Сотрудника компании
        /// </summary>
        public class Employee
        {
            private long? _phone;
            private int _age;
            private int _salary;

            public string FIO { get; set; }
            public string Position { get; set; }            
            public string EMail { get; set; }
            public string Phone
            {
                get 
                { 
                    return String.Format("{0:+7(###)###-##-##}", _phone);
                }
                set 
                {
                    try
                    {                       
                        _phone = Convert.ToInt64(value.Substring(0, 10));  // обрезаем строку до 10 символов с начала (на случай, если телефон длиннее)
                    }
                    catch (FormatException)     // Если задан неверный формат телефона(буквы/символы) - телефон будет пустым
                    {
                        _phone = null;                        
                    }
                     
                }
            }            

            public int Salary
            {
                get { return _salary; }
                set { _salary = value < 0 ? 0 : value; }    // если зарплата меньше нуля, ставим 0
            }


            public int Age
            {
                get { return _age; }
                set { _age = value < 18 ? 18 : value; }    // Если возраст работника меньше 18, то ставим 18 (несовершеннолетним работать нельзя!)
            }
            
            public Employee(string fio, string position, string email, string phone, int salary, int age)
            {
                FIO = fio;
                Position = position;
                EMail = email;
                Phone = phone;
                Salary = salary;
                Age = age;
            }

            public void GetInfo()
            {
                Console.WriteLine(
                    $"ФИО:\t\t{FIO}\n" +
                    $"Должность:\t{Position}\n" +
                    $"E-mail:\t\t{EMail}\n" +
                    $"Телефон:\t{Phone}\n" +
                    $"Зарплата:\t{Salary}\n" +
                    $"Возраст:\t{Age}\n");
            }
        }

        /// <summary>
        /// Класс исключения, описывающий ошибку неверной размерности массива
        /// </summary>
        class MyArraySizeException : Exception
        {
            public int RowSize { get; }
            public int ColumnSize { get; }
            public MyArraySizeException(int rows, int columns) 
            {
                RowSize = rows;
                ColumnSize = columns;
            }
        }

        /// <summary>
        /// Класс исключения, описывающий ошибку при преобразовании типов элементов массива
        /// </summary>
        class MyArrayDataException : Exception
        {
            public int Row { get; }
            public int Column { get; }

            public MyArrayDataException(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }
    }
}
