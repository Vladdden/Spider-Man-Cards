using System;
using System.Collections.Generic;
using System.Text;

namespace MARVELCards
{
    class CardsInfo
    {
        public readonly int TotalCount = 825;
        public readonly int FirstChapter = 275;
        public readonly int SecondChapter = 550;
        public readonly int ThirdChapter = 825;
        public readonly int[] SuperCards = { 1, 5, 12, 13, 17, 21, 28, 32, 33, 40, 41, 48, 52, 53, 57, 61, 65, 69, 73, 77, 81, 85, 89, 93, 97, 101, 105, 109, 113, 117, 129, 174, 180, 555, 564, 568, 578, 581, 583, 595, 601, 605, 614, 628, 635, 648, 655, 662, 673, 684, 689, 693, 711, 720, 724, 739, 744, 759, 765, 767, 772, 785, 798, 801, 811, 817 };
        public readonly int[] UltraCards = { 3, 7, 20, 30, 110, 118, 133, 148, 200, 219, 281, 301, 341, 349, 388, 423, 429, 441, 495, 547, 561, 580, 624, 640, 660, 705, 713, 730, 790, 810 };
        public readonly int[] UltraSuperCards = { 119, 130, 158, 161, 178, 184, 324, 353, 412, 435, 475, 500, 579, 677, 701, 731, 741, 792 };

        public string PathToFolder = @"C:\Users\Vlad2\Documents\Человек-Паук";

        public readonly string[] Types =
        {
            "Обычная",
            "Супер (СК)",
            "Ультра (УК)",
            "Ультра-Супер (УСК)"
        };

        public readonly string[,] Groups = new string[8,2] {
            { "-", "" },
            { "Герои","Бойцы светлой стороны." },
            { "Злодеи","Очень плохие парни!" },
            { "Супергерои","Самые мощные геройские карточки с блестящим покрытием." },
            { "Архизлодеи","Наимощнейшие злодейские карточки с блестящим покрытием." },
            { "Пауки-оборотни","Человек-Паук под разнообразными личинами." },
            { "Боевые карточки","Изображения битв Спайди с главными врагами." },
            { "Карточки бонусы", "Дадут тебе дополнительные возможности во время игр." }
        };

        public readonly string[] Status =
        {
            "Ужасное",
            "Плохое",
            "Хорошее",
            "Отличное"
        };

        public readonly string[] Chapter =
        {
            "-",
            "Cyперместа",
            "Герои",
            "Друзья",
            "Злодеи",
            "Карточка-бонус",
            "Классическая обложка",
            "Команда",
            "Особая",
            "Суперместа",
            "Боевая карточка"
        };

        public string CheckType(int CardNumber)
        {
            foreach (int card in SuperCards)
                if (card == CardNumber) return Types[1];
            foreach (int card in UltraCards)
                if (card == CardNumber) return Types[2];
            foreach (int card in UltraSuperCards)
                if (card == CardNumber) return Types[3];
            return Types[0];
        }

        public int CheckYear(int number)
        {
            if (number > FirstChapter)
            {
                return number > SecondChapter ? 2010 : 2009;
            }
            else return 2008;
        }
    }
}
