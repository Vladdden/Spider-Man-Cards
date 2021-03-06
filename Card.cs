using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MARVELCards
{
    class Card
    {
        private string PathToCards;
        private int Id;
        readonly int Number;

        readonly String Name;
        readonly String Chapter;
        readonly String Type;
        readonly String Group;
        readonly String Status;
        readonly int Year;

        readonly int Intelligence;
        readonly int Power;
        readonly int SpeedAndAgility;
        readonly int SpecialSkills;
        readonly int FightingSkills;
        readonly bool OriginalCollectionFlag;
        readonly int TradeId;
        readonly float PricePerCard;
        

        private CardsInfo cardsInfo;
        
        public Card(int number, string name, string chapter, string type, string group, string status, int intelligence, int power, int speedAndAgility, int specialSkills, int fightingSkills, bool originalCollectionFlag, int tradeId, float pricePerCard)
        {
            cardsInfo = new CardsInfo();
            PathToCards = Path.Combine(cardsInfo.PathToFolder, "Cards");
            Id = CheckId();
            Number = number;
            Name = name;
            Chapter = chapter;
            Type = type;
            Group = group;
            Status = status;
            Intelligence = intelligence;
            Power = power;
            SpeedAndAgility = speedAndAgility;
            SpecialSkills = specialSkills;
            FightingSkills = fightingSkills;
            Year = cardsInfo.CheckYear(Number);
            OriginalCollectionFlag = originalCollectionFlag;
            TradeId = tradeId;
            PricePerCard = pricePerCard;
            WriteCardToFile();
        }

        private void WriteCardToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{PathToCards}\\{Number}.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{Id},{Number},{Name},{Chapter},{Type},{Group},{Status},{Intelligence},{Power},{SpeedAndAgility},{SpecialSkills},{FightingSkills},{Year},{OriginalCollectionFlag},{TradeId},{PricePerCard.ToString(new CultureInfo("en-US"))}");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private int CheckId()
        {
            return Directory.GetFiles(PathToCards).Length + 1;
        }
        
        public int GetId()
        {
            return Id;
        }
    }
}
