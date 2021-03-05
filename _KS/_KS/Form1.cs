using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _KS {

    public partial class Form1 : Form { // Главный класс программы

        public class IntakeNode { // Двусвязный список элементов дохода
            public string Type; // Поле типа дохода
            public double Value; // Поле суммы дохожа

            public IntakeNode Next; // Указатель на следующий элемент
            public IntakeNode Prev; // Указатель на предыдущий элемент
        }

        IntakeNode IHead = null; // Указатель на голову (начало) списка
        double TotalMoney = 0; // Всего сумма дохода
        int IntakeCount = 0; // Ко-во источников дохода

        public class OuttakeNode { // То же самое, что и выше, но уже с расходами
            public string Type;
            public string Category; // Поле категории расходов
            public double Value;

            public OuttakeNode Next;
            public OuttakeNode Prev;
        }

        OuttakeNode OHead = null;
        double TotalOuttake = 0;
        int OuttakeCount = 0;

        public Form1() { // Начальная инициализация программы
            InitializeComponent();
            // Чистим строки с информацией в проге
            labelInSources.Text = String.Empty; 
            labelInValueTotal.Text = String.Empty;
            labelOutSource.Text = String.Empty;
            labelOutValue.Text = String.Empty;
            labelTotalIntake.Text = String.Empty;
            labelTotalOuttake.Text = String.Empty;
            labelRemainingBalance.Text = String.Empty;
            // Чистим диаграммы
            ChartIntake.Series.Clear();
            ChartIntake.Titles.Clear();
            ChartOuttakeTypes.Series.Clear();
            ChartOuttakeTypes.Titles.Clear();
            ChartOuttakeCategories.Series.Clear();
            ChartOuttakeCategories.Titles.Clear();
            // Создание столбцов для списка доходов
            dataGridViewIn.Columns.Add("_itype", "Тип дохода");
            dataGridViewIn.Columns.Add("_ivalue", "Сумма дохода");
            // Создание столбцов для списка расходов
            dataGridViewOut.Columns.Add("_otype", "Тип расхода");
            dataGridViewOut.Columns.Add("_ocategory", "Категория");
            dataGridViewOut.Columns.Add("_ovalue", "Сумма");
        }

        void DiagSet() {
            ChartIntake.Series.Clear(); // Чистим диаграммы перед записью в них данных
            ChartIntake.Titles.Clear();
            ChartOuttakeTypes.Series.Clear();
            ChartOuttakeTypes.Titles.Clear();
            ChartOuttakeCategories.Series.Clear();
            ChartOuttakeCategories.Titles.Clear();

            IntakeNode LADR = IHead; // Ставим локальный указатель на голову списка доходов (для прохода по нему)
            ChartIntake.Titles.Add("Доходы"); // Название диаграммы
            ChartIntake.Series.Add(new Series("IntakeSeries") {
                ChartType = SeriesChartType.Pie // Тип диаграммы (пирог, типа круговой)
            });
            double[] yInValues = new double[IntakeCount]; // Массив с суммами доходов
            string[] xInValues = new string[IntakeCount]; // Массив с названиями доходов
            int i = 0; while (LADR != null) { // Через цикл, пока НЕ конец списка, заполняем верхние массивы данными из стека
                yInValues[i] = LADR.Value;
                xInValues[i] = LADR.Type;
                i++; LADR = LADR.Next; // Каждый раз после прохода ставим указатель на следующий элемент стека
            }
            ChartIntake.Series["IntakeSeries"].Points.DataBindXY(xInValues, yInValues); // Забиваем данные в диаграмму доходов

            OuttakeNode OLADR = OHead; // То же самое, что сверху, но с расходами ПО НАЗВАНИЮ РАСХОДОВ
            ChartOuttakeTypes.Titles.Add("Расходы по типам");
            ChartOuttakeTypes.Series.Add(new Series("OuttakeTypesSeries") {
                ChartType = SeriesChartType.Pie
            });
            double[] yOutTValues = new double[OuttakeCount];
            string[] xOutTValues = new string[OuttakeCount];
            int j = 0; while (OLADR != null) {
                yOutTValues[j] = OLADR.Value;
                xOutTValues[j] = OLADR.Type;
                j++; OLADR = OLADR.Next;
            }
            ChartOuttakeTypes.Series["OuttakeTypesSeries"].Points.DataBindXY(xOutTValues, yOutTValues);

            OLADR = OHead; // Здесь уже по категориям расходов, но идентично выше
            ChartOuttakeCategories.Titles.Add("Расходы по категориям"); // Так же называем и т. д.
            ChartOuttakeCategories.Series.Add(new Series("OuttakeCategoriesSeries") {
                ChartType = SeriesChartType.Pie
            });
            string[] TempCat = new string[OuttakeCount]; // Временный массив для названий КАТЕГОРИЙ
            int Temp = 0; while (OLADR != null) { // Так же через подобный цикл заполняем этот массив с названями категорий
                TempCat[Temp] = OLADR.Category;
                Temp++; OLADR = OLADR.Next;
            }
            string[] xOutCValues = TempCat.Distinct().ToArray(); // Убираем повторяющиеся названия категорий
            double[] yOutCValues = new double[xOutCValues.Length]; // Создаем массив сумм для категорий (по размеру количества различных категорий)
            for (int VCount = 0; VCount < xOutCValues.Length; VCount++) { // Цикл заполнения сумм расходов по категориям
                OLADR = OHead; // Ставим указатель
                while (OLADR != null) { 
                    if (OLADR.Category == xOutCValues[VCount]) { // Если название текущей категории совпадает с данными из текущего элемента списка
                        yOutCValues[VCount] += OLADR.Value; // Прибавить сумму расхода текущего ЭЛЕМЕНТА к позиции его КАТЕГОРИИ в массиве сумм
                    }
                    OLADR = OLADR.Next;
                }
            }
            ChartOuttakeCategories.Series["OuttakeCategoriesSeries"].Points.DataBindXY(xOutCValues, yOutCValues); // Забиваем данные в диаграмму
        }

        // Ниже работа с доходами

        void IntakeTotalCount() { // Считаем доходы
            IntakeNode LADR = IHead; // Снова локальный указатель на голову списка доходов
            TotalMoney = 0; // Обнуляем счетчик доходов
            dataGridViewIn.Rows.Clear(); // Чистим таблицу доходов
            while (LADR != null) { // Пока не конец списка..
                TotalMoney += LADR.Value; // Прибавляем к счетчику сумму каждого элемента списка
                dataGridViewIn.Rows.Add($"{LADR.Type}", $"{LADR.Value}р."); LADR = LADR.Next; // Добавляем строки в таблицу
            }
            labelInSources.Text = $"Всего источников: {IntakeCount}"; // Это вывод на те строчки маленькие, что рядом с таблицей
            labelInValueTotal.Text = $"Всего сумма доходов: {TotalMoney}р."; // То же самое
        }

        private void buttonInAdd_Click(object sender, EventArgs e) { // Кнопка добавения дохода в список доходов
            try { // Блок try выполняет код в его скобках, пока не встретит ошибку, которую поймает catch
                double Value = Convert.ToDouble(textBoxInValue.Text); // Строка проверки ошибки
                if (IHead == null) { // Если нет начала списка, значит список надо создать
                    IHead = new IntakeNode(); // Закидываем новый экземпляр в голову списка доходов
                    IHead.Type = textBoxInType.Text; // Забиваем тип из поля ввода программы
                    IHead.Value = Convert.ToDouble(textBoxInValue.Text); // Забиваем сумму из поля ввода программы
                } else { // Если список создан, то нужно просто создать новый элемент
                    IntakeNode LADR = IHead; // Локальный указатель на голову
                    while (LADR.Next != null) {
                        LADR = LADR.Next; // Цикл, ищущий конец списка
                    }
                    LADR.Next = new IntakeNode(); // Создаем новый элемент
                    LADR.Next.Prev = LADR; // Ставим указатель на предыдущий элемент
                    LADR.Next.Type = textBoxInType.Text; // Так же забиваем данные
                    LADR.Next.Value = Value;
                    LADR.Next.Next = null; // Ставим нулевой указатель на следующий элемент (ибо текущий последний)
                }
                IntakeCount++; IntakeTotalCount(); // Увеличиваем кол-во доходов на 1, вызываем функцию пересчета таблицы/данных
            } 
            catch (FormatException) { // Поймали ошибку
                textBoxInType.Text = "Ошибка ввода данных!";
                textBoxInValue.Text = String.Empty;
            }
        }

        private void buttonIDelete_Click(object sender, EventArgs e) { // Кнопка удаления элемента из списка доходов
            IntakeNode LADR = IHead; // Локальный указатель на голову списка
            while (LADR != null) { // Пока не конец списка
                if (LADR.Type == textBoxInType.Text) { // Название удаляемого совпало с элементом в списке
                    if (LADR == IHead) { // Если удаляемый элемент голова
                        IHead = LADR.Next; IntakeCount--; break; // Ставим указатель головы на следующий элемент, понижаем кол-во элементов на 1
                    }
                    if (LADR.Next == null) { // Если удаляемый элемент последний в списке
                        LADR.Prev.Next = null; IntakeCount--; break; // Ставим в качестве последнего элемента списка предыдущий элемент, понижаем кол-во элементов на 1
                    }
                    LADR.Next.Prev = LADR.Prev; // Во всех остальных случаях (элемент где-то посередине) расставляем указатели
                    LADR.Prev.Next = LADR.Next;
                    IntakeCount--; break; // Уменьшаем кол-во на 1
                }
                LADR = LADR.Next; // Продвигаем локальный указатель
            }
            IntakeTotalCount(); // Вызываем функцию пересчета таблицы/данных
        }

        // Ниже работа с расходами

        private void buttonOutAdd_Click(object sender, EventArgs e) { // Кнопка добавления расхода
            try {
                double Value = Convert.ToDouble(textBoxOutValue.Text);
                if (OHead == null) { // Если нет начала списка, значит список надо создать
                    OHead = new OuttakeNode(); // Закидываем новый экземпляр в голову списка расходов
                    OHead.Type = textBoxOutType.Text; // Записываем тип
                    OHead.Category = textBoxOutCategory.Text; // Записываем категорию
                    OHead.Value = Value; // Записываем сумму
                } else { // Если список уже есть
                    OuttakeNode LADR = OHead; // Локальный указатель 
                    while (LADR.Next != null) {
                        LADR = LADR.Next; // Ищем конец списка
                    }
                    LADR.Next = new OuttakeNode(); // Создаем новый экземпляр класса
                    LADR.Next.Prev = LADR; // Ставим указатель на предыдущий элемент у нового экземпляра
                    LADR.Next.Type = textBoxOutType.Text; // Заполняем данные ниже
                    LADR.Next.Category = textBoxOutCategory.Text;
                    LADR.Next.Value = Value;
                    LADR.Next.Next = null;
                }
                OuttakeCount++; OuttakeTotalCount(); // Увеличиваем кол-во расходов на 1. Вызываем функцию подсчета расходов
            }
            catch (FormatException) {
                textBoxOutType.Text = "Ошибка ввода данных!";
                textBoxOutCategory.Text = String.Empty;
                textBoxOutValue.Text = String.Empty;
            }
        }

        void OuttakeTotalCount() { // Подсчет расходов
            OuttakeNode LADR = OHead; // Локальный указатель
            TotalOuttake = 0; // Сброс общего кол-ва расходов
            dataGridViewOut.Rows.Clear(); // Чистим таблицу расходов
            while (LADR != null) { // Пока не конец списка
                TotalOuttake += LADR.Value; // Складывание полной суммы расходов
                dataGridViewOut.Rows.Add($"{LADR.Type}", $"{LADR.Category}", $"{LADR.Value}р."); LADR = LADR.Next; // Заполнение таблицы расходов
            }
            labelOutSource.Text = $"Всего расходов: {OuttakeCount}"; // Вывод информации в маленькие строки рядом с таблицей снизу
            labelOutValue.Text = $"Всего сумма расходов: {TotalOuttake}р.";
        }

        private void buttonOutDelete_Click(object sender, EventArgs e) { // Идентично с удалением из списка доходов по типу расхода, только с расходами
            OuttakeNode LADR = OHead;
            while (LADR != null) {
                if (LADR.Type == textBoxOutType.Text) {
                    if (LADR == OHead) {
                        OHead = LADR.Next; OuttakeCount--; break;
                    }
                    if (LADR.Next == null) {
                        LADR.Prev.Next = null; OuttakeCount--; break;
                    }
                    LADR.Next.Prev = LADR.Prev;
                    LADR.Prev.Next = LADR.Next;
                    OuttakeCount--; break;
                }
                LADR = LADR.Next;
            }
            OuttakeTotalCount();
        }

        private void buttonOutDelCategory_Click(object sender, EventArgs e) { // Удаление всей категории расходов
            OuttakeNode LADR = OHead; // Локальный указатель на элементы списка
            while (LADR != null) { // Пока не конец списка
                if (LADR.Category == textBoxOutCategory.Text) { // Каждый раз когда категория элемента совпадает с введенной пользователем - этот объект удаляется
                    if (LADR == OHead) { // Далее идентично со всеми удалениями выше
                        OHead = LADR.Next; OuttakeCount--;
                    } else if (LADR.Next == null) {
                        LADR.Prev.Next = null; OuttakeCount--;
                    } else {
                        LADR.Next.Prev = LADR.Prev;
                        LADR.Prev.Next = LADR.Next;
                        OuttakeCount--; 
                    }
                }
                LADR = LADR.Next;
            }
            OuttakeTotalCount();
        }

        private void buttonSummary_Click(object sender, EventArgs e) { // Кнопка расчетов
            labelTotalIntake.Text = $"Всего доходов на {TotalMoney}р."; // Вывод суммы доходов 
            labelTotalOuttake.Text = $"Всего расходов на {TotalOuttake}р."; // Вывод суммы расходов
            labelRemainingBalance.Text = $"Баланс: {TotalMoney - TotalOuttake}р."; // Вывод оставшегося баланса (разница)
            DiagSet(); // Вызов функции зарисовщика диаграмм
        }
    }
}
