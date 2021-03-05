using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _MB {

    public partial class Form1 : Form {

        int[,] Player1Mtr = new int[10, 10]; // Матрица расстановки первого игрока
        int Player1Ship1 = 4; // Кол-во однопалубников 1го игрока
        int Player1Ship2 = 3; // Кол-во двухпалубников 1го игрока
        int Player1Ship3 = 2; // Кол-во трехпалубников 1го игрока
        int Player1Ship4 = 1; // Кол-во четырехпалубников 1го игрока
        int[,] Player2Mtr = new int[10, 10]; // Матрица расстановки второго игрока
        int Player2Ship1 = 4; // Кол-во однопалубников 2го игрока
        int Player2Ship2 = 3; // Кол-во двухпалубников 2го игрока
        int Player2Ship3 = 2; // Кол-во трехпалубников 2го игрока
        int Player2Ship4 = 1; // Кол-во четырехпалубников 2го игрока
        int[,] Player1Hitmap = new int[10, 10]; // Карта ударов 1го игрока
        int[,] Player2Hitmap = new int[10, 10]; // Карта ударов 2го игрока
        int[,] PrevMtr = new int[10, 10]; // Матрица центрального поля
        int GM = 0; // Игровой режим 0 - Расстановка / 1 - Игра / 2 - Конец игры 
        int CheckMode = 0; // Переменная для постройки барьеров вокруг кораблей 
        int CurrentPlayer = 0; // Переменная текущего игрока 0 - 1й игрок / 1 - 2й игрок

        public Form1() { // Первичная инициализация программы
            InitializeComponent();
            labelInfoPlayer1.Text = String.Empty; // (1) Очистка некоторых строчек на экране
            labelInfoPlayer2.Text = String.Empty; // (1)
            labelPrevOOR.Text = String.Empty; // (1)
            labelCurrentPlayer.Text = String.Empty; // (1)
            labelPlayer1Ship4.Text = $"4П: {Player1Ship4}"; // (2) Расстановка визуального количества кораблей у игроков (4П - четырехпалубник, 3П - трехпалубник и т.д)
            labelPlayer1Ship3.Text = $"3П: {Player1Ship3}"; // (2)
            labelPlayer1Ship2.Text = $"2П: {Player1Ship2}"; // (2)
            labelPlayer1Ship1.Text = $"1П: {Player1Ship1}"; // (2)
            labelPlayer2Ship4.Text = $"4П: {Player2Ship4}"; // (2)
            labelPlayer2Ship3.Text = $"3П: {Player2Ship3}"; // (2)
            labelPlayer2Ship2.Text = $"2П: {Player2Ship2}"; // (2)
            labelPlayer2Ship1.Text = $"1П: {Player2Ship1}"; // (2)
            labelInfoPlayer2.Text = "Ожидает..."; // Ставим визуальную строку "Ожидает..." второму игроку
            label71.Visible = false; // (3) Отключение элементов управления второго игрока до того, как придет его очередь
            label70.Visible = false; // (3)
            label69.Visible = false; // (3)
            textBoxPlayer2X.Visible = false; // (3)
            textBoxPlayer2Y.Visible = false; // (3)
            textBoxPlayer2ShipSize.Visible = false; // (3)
            checkBoxPlayer2Vertical.Visible = false; // (3)
            buttonPlayer2Add.Visible = false; // (3)
            label44.Visible = false; // (3)
            label45.Visible = false; // (3)
            textBoxAttackX.Visible = false; // (3)
            textBoxAttackY.Visible = false; // (3)
            buttonAttack.Visible = false; // (3)
            for (int i = 0; i < 10; i++) { // Заполняем все матрицы нулями
                for (int j = 0; j < 10; j++) {
                    PrevMtr[i, j] = 0;
                    Player1Mtr[i, j] = 0;
                    Player2Mtr[i, j] = 0;
                    Player1Hitmap[i, j] = 0;
                    Player2Hitmap[i, j] = 0;
                }
            }
            GamemodeSet(); Player1MtrUpdate(); Player2MtrUpdate(); PreviewMap(); // Обновляем/Рисуем визуальные матрицы
        }

        void GamemodeSet() { // Функция режима игры
            switch(GM) { // Блок свич, принимающий переменную гейммода
                case 1: // 1 - Режим игры
                    label44.Visible = true; // (4) Показываем элементы для игры на экране
                    label45.Visible = true; // (4) 
                    textBoxAttackX.Visible = true; // (4) 
                    textBoxAttackY.Visible = true; // (4) 
                    buttonAttack.Visible = true; // (4) 
                    buttonPrevActive.Visible = false; // (4) 
                    labelInfoPlayer1.Visible = false; // (4) 
                    labelInfoPlayer2.Visible = false; // (4) 
                    for (int i = 1; i <= 2; i++) { // Цикл, убирающий с экрана строки количества кораблей у двух игроков
                        for (int j = 1; j <= 4; j++) {
                            Controls[$"labelPlayer{i}Ship{j}"].Visible = false;
                        }
                    }
                    CurrentPlayer = 0; labelCurrentPlayer.Text = $"Ход {CurrentPlayer + 1}го игрока"; // Показываем чей сейчас ход
                    Player1MtrUpdate(); Player2MtrUpdate(); PlayMapDraw(); break; // Обновляем визуальные матрицы
                case 2: // Конец игры
                    buttonAttack.Visible = false; // (9) Убираем оставшиеся элементы управления
                    textBoxAttackX.Visible = false; // (9) 
                    textBoxAttackY.Visible = false; // (9)
                    label44.Visible = false; // (9)
                    label45.Visible = false; // (9)
                    labelPrevOOR.Visible = false; // (9)
                    labelCurrentPlayer.Text = $"Победил {Winner + 1}й игрок"; // Выводим на экран победителяяяяя
                    break;
            }
        }
        void PlayerGMSwitch() { // Функция, сменяющая очередь игроков при расстановке кораблей
            if (CurrentPlayer == 0 && Player1Ship1 + Player1Ship2 + Player1Ship3 + Player1Ship4 == 0) { // Если первый игрок завершил расстановку
                labelInfoPlayer1.Text = "Готов!"; // Показываем, что первый игрок завершил расстановку
                label1.Visible = false; // (5) Убираем элементы управления первого игрока с экрана
                label2.Visible = false; // (5)
                label3.Visible = false; // (5)
                textBoxPlayer1X.Visible = false; // (5)
                textBoxPlayer1Y.Visible = false; // (5)
                textBoxPlayer1ShipSize.Visible = false; // (5)
                checkBoxPlayer1Vertical.Visible = false; // (5)
                buttonPlayer1Add.Visible = false; // (5)
                labelInfoPlayer2.Text = String.Empty; // (5)
                label71.Visible = true; // (6) Показываем элементы управления второго игрока
                label70.Visible = true; // (6)
                label69.Visible = true; // (6)
                textBoxPlayer2X.Visible = true; // (6)
                textBoxPlayer2Y.Visible = true; // (6)
                textBoxPlayer2ShipSize.Visible = true; // (6)
                checkBoxPlayer2Vertical.Visible = true; // (6)
                buttonPlayer2Add.Visible = true; // (6)
                CurrentPlayer = 1; // Ставим флажок текущего игрока на 1 (2й игрок)
                for (int i = 0; i < 10; i++) { // Очищаем матрицу посередине (заполняем нулями)
                    for (int j = 0; j < 10; j++) {
                        PrevMtr[i, j] = 0;
                    }
                }
            }
            if (CurrentPlayer == 1 && Player2Ship1 + Player2Ship2 + Player2Ship3 + Player2Ship4 == 0) { // Если второй игрок завершил расстановку своего флота
                label71.Visible = false; // (7) Убираем элементы управления второго игрока с экрана
                label70.Visible = false; // (7)
                label69.Visible = false; // (7)
                textBoxPlayer2X.Visible = false; // (7)
                textBoxPlayer2Y.Visible = false; // (7)
                textBoxPlayer2ShipSize.Visible = false; // (7)
                checkBoxPlayer2Vertical.Visible = false; // (7)
                buttonPlayer2Add.Visible = false; // (7)
                for (int i = 0; i < 10; i++) { // Очищаем матрицу посередине (заполняем нулями)
                    for (int j = 0; j < 10; j++) {
                        PrevMtr[i, j] = 0;
                    }
                }
                GM = 1; GamemodeSet(); // Ставим режим игры с расстановки на игру
            }
            if (GM == 0) { // Если режим игры 0 (расстановка), то показываем матрицу превью
                PreviewMap();
            }
        }

        int AlphaReturner(string e) { // Функция интерпретации буквы в число (для обозначения координат на поле)
            switch(e) {
                default : return 0; // Если введена неправильная буква или символы то будет возвращен 0, что приведет к сообщению об ошибке
                case "A": return 1;
                case "B": return 2;
                case "C": return 3;
                case "D": return 4;
                case "E": return 5;
                case "F": return 6;
                case "G": return 7;
                case "H": return 8;
                case "I": return 9;
                case "J": return 10;
            }
        }

        void PreviewMap() { // Построение карты для превью посередине окна. 0 - Игрок 1, 1 - Игрок 2
            if (GM == 0) { // Проверка на то, чтобы данная функция выполнялась только когда идет процесс расстановки кораблей
                if (CurrentPlayer == 0) { // Очередь 1го игрока
                    tableLayoutPreview.Controls.Clear(); // Очищаем визуальную матрицу посередине
                    for (int i = 0; i < 10; i++) { // Цикл прохода по матрице
                        for (int j = 0; j < 10; j++) {
                            PictureBox PBP = new PictureBox(); // Создаем новый визуальный элемент матрицы
                            PBP.BackColor = Color.LightBlue; // Красим его в ярко-голубой
                            if (Player1Mtr[i, j] == 1) { // Проверка если в текущей ячейке есть фрагмент корабля
                                PBP.BackColor = Color.LightCyan; // Тогда красим эту ячейку в ярко-сиан
                            }
                            if (PrevMtr[i, j] == 1) { // Проверяем, где 1й игрок поставил свой корабль
                                PBP.BackColor = Color.Red; // Соответствующие ячейки красим в красный
                            }
                            tableLayoutPreview.Controls.Add(PBP, j, i); // Зарисовка матрицы на экране (добавление каждой ячейки в j стобец i строки)
                        }
                    }
                }
                else if (CurrentPlayer == 1) { // Идентично сверху, только уже для второго игрока
                    tableLayoutPreview.Controls.Clear();
                    for (int i = 0; i < 10; i++) {
                        for (int j = 0; j < 10; j++) {
                            PictureBox PBP = new PictureBox();
                            PBP.BackColor = Color.LightBlue;
                            if (Player2Mtr[i, j] == 1) {
                                PBP.BackColor = Color.LightCyan;
                            }
                            if (PrevMtr[i, j] == 1) {
                                PBP.BackColor = Color.Red;
                            }
                            tableLayoutPreview.Controls.Add(PBP, j, i);
                        }
                    }
                }
            }
        }

        private void buttonPrevActive_Click(object sender, EventArgs e) { // Действие кнопки "Посмотреть на карте"
            try { // Блок try-catch сначала выполняет действия внутри скобочек try. Затем, если вдруг происходит ошибка (Exception) блок catch ее ловит и выполняет действие уже после скобочек соответствующего catch
                for (int i = 0; i < 10; i++) { // Обнуляем матрицу превью
                for (int j = 0; j < 10; j++) {
                    PrevMtr[i, j] = 0;
                }
            }
                if (CurrentPlayer == 0) { // Если 1й игрок
                    int X = AlphaReturner(textBoxPlayer1X.Text) - 1; // Получение координаты X, которую вел игрок 1
                    int Y = Convert.ToInt32(textBoxPlayer1Y.Text) - 1; // Получение координаты Y, которую вел игрок 1
                    for (int i = 0; i < Convert.ToInt32(textBoxPlayer1ShipSize.Text); i++) { // Цикл, который проверяет выходит ли корабль за пределы экрана
                        if (checkBoxPlayer1Vertical.Checked) { 
                            PrevMtr[Y, X] += 0;
                        }
                        else {
                            PrevMtr[Y, X] += 0;
                        }
                    }
                    X = AlphaReturner(textBoxPlayer1X.Text) - 1; // Снова получаем координаты, введенные игроком 1
                    Y = Convert.ToInt32(textBoxPlayer1Y.Text) - 1;
                    for (int i = 0; i < Convert.ToInt32(textBoxPlayer1ShipSize.Text); i++) { // Цикл, который в соответствии с размером корабля строит его на матрице
                        if (checkBoxPlayer1Vertical.Checked) { // Если вертикально, то построение идет от верхней точки корабля вниз, горизонтально - от самой левой точки вправо
                            PrevMtr[Y, X] = 1; Y++; // Элементы кораблей на матрице обозначаются единичками, отсутствие - нулями
                        } else {
                            PrevMtr[Y, X] = 1; X++;
                        }
                    }
            } else if(CurrentPlayer == 1) { // Идентично сверху, только для второго игрока
                    int X = AlphaReturner(textBoxPlayer2X.Text) - 1;
                    int Y = Convert.ToInt32(textBoxPlayer2Y.Text) - 1;
                    for (int i = 0; i < Convert.ToInt32(textBoxPlayer2ShipSize.Text); i++) {
                        if (checkBoxPlayer2Vertical.Checked) {
                            PrevMtr[Y, X] += 0;
                        } else {
                            PrevMtr[Y, X] += 0;
                        }
                    }
                    X = AlphaReturner(textBoxPlayer2X.Text) - 1;
                    Y = Convert.ToInt32(textBoxPlayer2Y.Text) - 1;
                    for (int i = 0; i < Convert.ToInt32(textBoxPlayer2ShipSize.Text); i++) {
                        if (checkBoxPlayer2Vertical.Checked) {
                            PrevMtr[Y, X] = 1; Y++;
                        } else {
                            PrevMtr[Y, X] = 1; X++;
                        }
                    }
                }
            PreviewMap(); // Зарисовываем получившуюся матрицу на экране 
            }
            catch (IndexOutOfRangeException) { // Поймали ошибку выхода за пределы массива
                labelPrevOOR.Text = "Корабль выходит за ренджу"; // Выводим на экран
            }
            catch (FormatException) { // Поймали ошибку о неверном типе данных, введенных пользователем
                return; // Завершаем функцию, вводим данные заново
            }
        }

        // Методы первого игрока

        void Player1MtrUpdate() { // Функция обновления матрицы первого игрока (крайняя слева)
            tableLayoutPanelPlayer1.Controls.Clear(); // Чистим визуальную матрицу
            for (int i = 0; i < 10; i++) { // Цикл прохода по матрице
                for (int j = 0; j < 10; j++) {
                    PictureBox PB = new PictureBox(); // Создаем новую визуальную ячейку
                    PB.BackColor = Color.LightGray; // Красим ее в ярко-серый
                    if (Player1Mtr[i, j] == 1) { // Если в текущей ячейке есть фрагмент корабля
                        PB.BackColor = Color.Blue; // Красим в синий
                        if (GM == 1 && Player2Hitmap[i, j] == Player1Mtr[i, j]) { // Если идет игра и второй игрок попал по кораблю первого
                            PB.BackColor = Color.Red; // Красим ячейку в красный
                        }
                    }
                    if (GM == 1 && Player2Hitmap[i, j] != Player1Mtr[i, j] && Player2Hitmap[i, j] == 1) { // Если идет игра, но второй игрок промазал
                        PB.BackColor = Color.Orange; // Красим ячейку в оранжевый
                    } 
                    if (GM == 0) { // Если идет расстановка кораблей
                        if (Player1Mtr[i, j] == -1) { // Если ячейка является ячейкой вокруг корабля
                            PB.BackColor = Color.DarkRed; // Красим ее в темно-красный
                        }
                    }
                    tableLayoutPanelPlayer1.Controls.Add(PB, j, i); // Кладем ячейку в j столбец i строки визуальной матрицы
                }
            }
            labelPlayer1Ship4.Text = $"4П: {Player1Ship4}"; // (8) Расстановка визуального количества кораблей у первого игрока (4П - четырехпалубник, 3П - трехпалубник и т.д)
            labelPlayer1Ship3.Text = $"3П: {Player1Ship3}"; // (8) 
            labelPlayer1Ship2.Text = $"2П: {Player1Ship2}"; // (8)
            labelPlayer1Ship1.Text = $"1П: {Player1Ship1}"; // (8)
        }

        void Taken1Set(int Y, int X) { // Построение недосягаемых ячеек вокруг блков кораблей 1го игрока
                switch (CheckMode) { // Проходим по всем 8 ячейкам воркуг одной ячейки // -1 -1 -1
                    case 0:                                                            // -1  1 -1
                        Y -= 1; X -= 1; // В левый верхний угол от блока корабля       // -1 -1 -1
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) { // Проверка, чтобы ячейки не вышли за границы матрицы
                            if (Player1Mtr[Y, X] == 0) { // Проверка чтобы ячейка была пуста
                                Player1Mtr[Y, X] = -1; // -1 флажок, который отмечает занимаемые кораблем ячейки вокруг него
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break; // Переходим к следующей ячейке, рекурсивно вызываем текущую функцию с кординатами следующей ячейки
                    case 1:
                        Y += 0; X += 1; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break;
                    case 2:
                        Y += 0; X += 1; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break;
                    case 3:
                        Y += 1; X += 0; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break;
                    case 4:
                        Y += 1; X += 0; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break;
                    case 5:
                        Y -= 0; X -= 1; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break;
                    case 6:
                        Y -= 0; X -= 1; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        CheckMode++; Taken1Set(Y, X); break;
                    case 7:
                        Y -= 1; X -= 0; // По часовой стрелке
                        if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                            if (Player1Mtr[Y, X] == 0) {
                                Player1Mtr[Y, X] = -1;
                            }
                        }
                        break;
                }
                CheckMode = 0; // Обнуляем шаги

        }

        void Ship1Taker(int Y, int X, int ShipSize, bool Pos) { // Pos == true - Вертикально (вниз), иначе горизонтально (вправо)
            try { // Тот же try-catch. Функция расстановки кораблей первого игрока
                switch (ShipSize) { // Проверка, присутствует ли у 1го игрока корпбль, который он хочет разместить
                    default: return;
                    case 1: if (Player1Ship1 == 0) { labelInfoPlayer1.Text = "Однопалубные закончились!"; return; } break; // Если определенного корабля больше не доступно для размещения - возврат
                    case 2: if (Player1Ship2 == 0) { labelInfoPlayer1.Text = "Двупалубные закончились!"; return; } break;
                    case 3: if (Player1Ship3 == 0) { labelInfoPlayer1.Text = "Трехпалубные закончились!"; return; } break;
                    case 4: if (Player1Ship4 == 0) { labelInfoPlayer1.Text = "Четырехпалубные закончились!"; return; } break;
                }
                for (int i = 0; i < ShipSize; i++) { // Цикл для проверки не выходит ли корабль за пределы игрового поля
                    if (Pos) { // Вертикально или горизонтально
                        Player1Mtr[Y, X] += 0;
                    } else {
                        Player1Mtr[Y, X] += 0;
                    }
                }
                int CX = X, CY = Y; // Объявление локальных переменных для координат ячеек кораблей
                for (int i = 0; i < ShipSize; i++) { // Цикл проверки задевает ли корабль другой корабль
                    if (Player1Mtr[CY, CX] != 0) {
                        throw new Exception(); // Если задевает - выкидываем ошибку
                    }
                    if (Pos) {
                        CY++;
                    } else {
                        CX++;
                    }
                }
                for (int i = 0; i < ShipSize; i++) { // Цикл построения корабля на экране
                if (Pos) { // Проверка вертикально/горизонтально
                    Player1Mtr[Y, X] = 1; Taken1Set(Y, X); Y++;
                } else {
                    Player1Mtr[Y, X] = 1; Taken1Set(Y, X); X++;
                }
            }
                switch (ShipSize) { // На основании какого размера был корабль отнимаем у первого игрока соответствующий корабль из списка доступных
                    case 1: Player1Ship1--; break;
                    case 2: Player1Ship2--; break;
                    case 3: Player1Ship3--; break;
                    case 4: Player1Ship4--; break;
                }
                PlayerGMSwitch(); // Вызов функции смены очереди игроков
            }
            catch (IndexOutOfRangeException) {
                labelInfoPlayer1.Text = "Корабль выходит за ренджу"; // Выводим на экран, если корабль вышел за пределы
            }
            catch (Exception) {
                labelInfoPlayer1.Text = "Корабль задевает другой или его воды"; // Выводим на экран, если корабль задевает другой
            }
        }

        private void buttonPlayer1Add_Click(object sender, EventArgs e) { // Кнопка добавления корабля для первого игрока
            try {
                labelInfoPlayer1.Text = String.Empty; // Очищаем некоторые строки на экране
                labelPrevOOR.Text = String.Empty;
                // Вызываем функции расстановки и обновления визуальной матрицы игрока 1
                Ship1Taker(Convert.ToInt32(textBoxPlayer1Y.Text) - 1, AlphaReturner(textBoxPlayer1X.Text) - 1, Convert.ToInt32(textBoxPlayer1ShipSize.Text), checkBoxPlayer1Vertical.Checked); Player1MtrUpdate(); 
            }   
            catch (FormatException) {
                return; // Возврат если были введены некорректные данные
            }
        }

        // Игрок 2 (идентичные функции для второго игрока, как для первого сверху)

        void Player2MtrUpdate() {
            tableLayoutPanelPlayer2.Controls.Clear();
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    PictureBox PB = new PictureBox();
                    PB.BackColor = Color.LightGray;
                    if (Player2Mtr[i, j] == 1) {
                        PB.BackColor = Color.Blue;
                        if(GM == 1 && Player1Hitmap[i, j] == Player2Mtr[i, j]) {
                            PB.BackColor = Color.Red;
                        }
                    }
                    if (GM == 1 && Player1Hitmap[i, j] != Player2Mtr[i, j] && Player1Hitmap[i, j] == 1) {
                        PB.BackColor = Color.Orange;
                    }
                    if (GM == 0) {
                        if (Player2Mtr[i, j] == -1) {
                            PB.BackColor = Color.DarkRed;
                        }
                    }
                    tableLayoutPanelPlayer2.Controls.Add(PB, j, i);
                }
            }
            labelPlayer2Ship4.Text = $"4П: {Player2Ship4}";
            labelPlayer2Ship3.Text = $"3П: {Player2Ship3}";
            labelPlayer2Ship2.Text = $"2П: {Player2Ship2}";
            labelPlayer2Ship1.Text = $"1П: {Player2Ship1}";
        }

        void Taken2Set(int Y, int X) { // Построение недосягаемых ячеек вокруг блков кораблей
            switch (CheckMode) {
                case 0:
                    Y -= 1; X -= 1; // В левый верхний угол от блока корабля
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 1:
                    Y += 0; X += 1; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 2:
                    Y += 0; X += 1; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 3:
                    Y += 1; X += 0; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 4:
                    Y += 1; X += 0; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 5:
                    Y -= 0; X -= 1; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 6:
                    Y -= 0; X -= 1; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    CheckMode++; Taken2Set(Y, X); break;
                case 7:
                    Y -= 1; X -= 0; // По часовой стрелке
                    if ((Y >= 0 && X >= 0) && (Y < 10 && X < 10)) {
                        if (Player2Mtr[Y, X] == 0) {
                            Player2Mtr[Y, X] = -1;
                        }
                    }
                    break;
            }
            CheckMode = 0;

        }

        void Ship2Taker(int Y, int X, int ShipSize, bool Pos) { // Pos == true - Вертикально (вниз), иначе горизонтально (вправо)
            try {
                switch (ShipSize) {
                    default: return;
                    case 1: if (Player2Ship1 == 0) { labelInfoPlayer2.Text = "Однопалубные закончились!"; return; } break;
                    case 2: if (Player2Ship2 == 0) { labelInfoPlayer2.Text = "Двупалубные закончились!"; return; } break;
                    case 3: if (Player2Ship3 == 0) { labelInfoPlayer2.Text = "Трехпалубные закончились!"; return; } break;
                    case 4: if (Player2Ship4 == 0) { labelInfoPlayer2.Text = "Четырехпалубные закончились!"; return; } break;
                }
                for (int i = 0; i < ShipSize; i++) {
                    if (Pos) {
                        Player2Mtr[Y, X] += 0;
                    } else {
                        Player2Mtr[Y, X] += 0;
                    }
                }
                int CX = X, CY = Y;
                for (int i = 0; i < ShipSize; i++) {
                    if (Player2Mtr[CY, CX] != 0) {
                        throw new Exception();
                    } if (Pos) {
                        CY++;
                    } else {
                        CX++;
                    }
                }
                for (int i = 0; i < ShipSize; i++) {
                    if (Pos) {
                        Player2Mtr[Y, X] = 1; Taken2Set(Y, X); Y++;
                    } else {
                        Player2Mtr[Y, X] = 1; Taken2Set(Y, X); X++;
                    }
                }
                switch (ShipSize) {
                    case 1: Player2Ship1--; break;
                    case 2: Player2Ship2--; break;
                    case 3: Player2Ship3--; break;
                    case 4: Player2Ship4--; break;
                }
                PlayerGMSwitch();
            }
            catch (IndexOutOfRangeException) {
                labelInfoPlayer2.Text = "Корабль выходит за ренджу";
            }
            catch (Exception) {
                labelInfoPlayer2.Text = "Корабль задевает другой или его воды";
            }
        }

        private void buttonPlayer2Add_Click(object sender, EventArgs e) {
            try {
                labelInfoPlayer2.Text = String.Empty;
                labelPrevOOR.Text = String.Empty;
                Ship2Taker(Convert.ToInt32(textBoxPlayer2Y.Text) - 1, AlphaReturner(textBoxPlayer2X.Text) - 1, Convert.ToInt32(textBoxPlayer2ShipSize.Text), checkBoxPlayer2Vertical.Checked); Player2MtrUpdate();
            }
            catch (FormatException) {
                return;
            }
        }

        // Геймплей

        int P1Amount = 20, P2Amount = 20, Winner; // Переменные количества ячеек кораблей для каждого игрока (4 * 1 + 2 * 3 + 3 * 2 + 4 * 1) и переменная победителя раунда

        async void PlayerSwitch() { // Ассинхронный метод для переключения ходов игроков
            await Task.Delay(TimeSpan.FromMilliseconds(2000)); // Задержка в 2 секунды
            buttonAttack.Visible = true; // Возврат кнопки атаки
            if (CurrentPlayer == 0) { // Если первый игрок - переключить на второго и наоборот
                CurrentPlayer = 1;
            } else {
                CurrentPlayer = 0;
            }
            labelCurrentPlayer.Text = $"Ход {CurrentPlayer + 1}го игрока"; PlayMapDraw();  // Выводим на экран чей сейчас ход и вызываем функцию зарисовки матрицы
        }

        // Блок запретов на ввод в поля X Y

        private void textBoxPlayer1X_TextChanged(object sender, EventArgs e) {
            if (!Regex.Match(textBoxPlayer1X.Text, @"[A-J]").Success || textBoxPlayer1X.Text.Length > 1) {
                textBoxPlayer1X.Text = String.Empty;
            }
        }

        private void textBoxPlayer2X_TextChanged(object sender, EventArgs e) {
            if (!Regex.Match(textBoxPlayer2X.Text, @"[A-J]").Success || textBoxPlayer2X.Text.Length > 1) {
                textBoxPlayer2X.Text = String.Empty;
            }
        }

        private void textBoxAttackX_TextChanged(object sender, EventArgs e) {
            if (!Regex.Match(textBoxAttackX.Text, @"[A-J]").Success || textBoxAttackX.Text.Length > 1) {
                textBoxAttackX.Text = String.Empty;
            }
        }

        private void textBoxPlayer1Y_TextChanged(object sender, EventArgs e) {
            if(textBoxPlayer1Y.Text != String.Empty)
            if (Convert.ToInt32(textBoxPlayer1Y.Text) <= 0 || Convert.ToInt32(textBoxPlayer1Y.Text) > 10) {
                textBoxPlayer1Y.Text = String.Empty;
            }
        }

        private void textBoxPlayer2Y_TextChanged(object sender, EventArgs e) {
            if (textBoxPlayer2Y.Text != String.Empty)
                if (Convert.ToInt32(textBoxPlayer2Y.Text) <= 0 || Convert.ToInt32(textBoxPlayer2Y.Text) > 10) {
                textBoxPlayer2Y.Text = String.Empty;
            }
        }

        private void textBoxAttackY_TextChanged(object sender, EventArgs e) {
            if (textBoxAttackY.Text != String.Empty)
                if (Convert.ToInt32(textBoxAttackY.Text) <= 0 || Convert.ToInt32(textBoxAttackY.Text) > 10) {
                textBoxAttackY.Text = String.Empty;
            }
        }

        void PlayMapDraw() { // Зарисовка матрицы игрового поля посередине
            if (CurrentPlayer == 0) { // Для первого игрока
                tableLayoutPreview.Controls.Clear(); // Чистим визуальную матрицу
                for (int i = 0; i < 10; i++) { // Проход по матрице
                    for (int j = 0; j < 10; j++) {
                        PictureBox PBP = new PictureBox(); // Создаем новую визуальную ячейку
                        PBP.BackColor = Color.LightBlue; // Красим ее в светло-синий
                        if (Player1Hitmap[i, j] == 1 && Player1Hitmap[i, j] == Player2Mtr[i, j]) {
                            PBP.BackColor = Color.Red; // Если первый игрок попал - красим в красный
                        }
                        if (Player1Hitmap[i, j] == 1 && Player1Hitmap[i, j] != Player2Mtr[i, j]) {
                            PBP.BackColor = Color.Orange; // Если не попал - красим в оранжевый
                        }
                        tableLayoutPreview.Controls.Add(PBP, j, i); // Добавляем ячейку в матрицу
                    }
                }
            }
            else if (CurrentPlayer == 1) { // Идентично для второго игрока
                tableLayoutPreview.Controls.Clear();
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 10; j++) {
                        PictureBox PBP = new PictureBox();
                        PBP.BackColor = Color.LightBlue;
                        if (Player2Hitmap[i, j] == 1 && Player2Hitmap[i, j] == Player1Mtr[i, j]) {
                            PBP.BackColor = Color.Red;
                        }
                        if (Player2Hitmap[i, j] == 1 && Player2Hitmap[i, j] != Player1Mtr[i, j]) {
                            PBP.BackColor = Color.Orange;
                        }
                        tableLayoutPreview.Controls.Add(PBP, j, i);
                    }
                }
            }
        }

        private void buttonAttack_Click(object sender, EventArgs e) { // Действие кнопки "Ударить"
            try {
                int X = AlphaReturner(textBoxAttackX.Text) - 1, Y = Convert.ToInt32(textBoxAttackY.Text) - 1; // Получаем координаты, введенные в поля
                if (CurrentPlayer == 0 && Player1Hitmap[Y, X] != 1) { // Первый игрок
                    Player1Hitmap[Y, X] = 1; // Ставим флажок удара на матрицу ударов первого игрока
                    if (Player1Hitmap[Y, X] == Player2Mtr[Y, X]) {
                        labelPrevOOR.Text = "Есть попадание!"; // Если совпало, то есть пробитие, отнимаем у второго игрока ячейку
                        PlayMapDraw(); Player2MtrUpdate(); P2Amount--;
                    } else {
                        labelPrevOOR.Text = "Нет попадания!"; // Иначе переходим к ходу второго игрока
                        buttonAttack.Visible = false; PlayMapDraw(); Player2MtrUpdate(); PlayerSwitch(); // Убираем на время кнопку атаки, вызываем функции
                    }
                } else if (Player1Hitmap[Y, X] == 1) {
                    labelPrevOOR.Text = "Сюда уже били!";
                }
                if (CurrentPlayer == 1 && Player2Hitmap[Y, X] != 1) { // Идентично для второго
                    Player2Hitmap[Y, X] = 1;
                    if (Player2Hitmap[Y, X] == Player1Mtr[Y, X]) {
                        labelPrevOOR.Text = "Есть попадание!";
                        PlayMapDraw(); Player1MtrUpdate(); P1Amount--;
                    } else {
                        labelPrevOOR.Text = "Нет попадания!";
                        buttonAttack.Visible = false; PlayMapDraw(); Player1MtrUpdate(); PlayerSwitch();
                    }
                } else if (Player2Hitmap[Y, X] == 1) {
                    labelPrevOOR.Text = "Сюда уже били!";
                }
                if (P1Amount <= 0 || P2Amount <= 0) { // Определение победителя
                    if (P1Amount == 0) { // Победил первый или наоборот
                        Winner = 1;
                    }
                    if (P2Amount == 0) {
                        Winner = 0;
                    }
                    GM = 2; GamemodeSet(); // Ставим флажок заввершения игры и вызываем функции
                }
            }
            catch (IndexOutOfRangeException) { // Ловим возможные ошибки
                return;
            }
            catch (FormatException) {
                return;
            }
        }
    }
}