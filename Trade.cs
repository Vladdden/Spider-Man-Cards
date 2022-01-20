using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MARVELCards
{
    class Trade
    {
        readonly int Id;
        readonly int Cost;
        readonly string Comment;
        private List<Card> listOfCards = new List<Card>();
        private CardsInfo cardsInfo;
        private string PathToTrades;

        public Trade(int cost, string comment)
        {
            cardsInfo = new CardsInfo();
            PathToTrades = Path.Combine(cardsInfo.PathToFolder, "Trades");
            Id = GetId();
            Cost = cost;
            Comment = comment;
        }

        public int AddCardToTrade(Card card)
        {
            listOfCards.Add(card);
            return listOfCards.Count;
        }
        
        private int GetId()
        {
            return Directory.GetFiles(PathToTrades).Length + 1;
        }
        
        private void WriteTradeToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{PathToTrades}\\{Id}.txt", true, System.Text.Encoding.Default))
                {
                    string AllCards = "";
                    foreach (var card in listOfCards)
                    {
                        AllCards += $"{card.GetId()},";
                    }
                    sw.WriteLine($"{Id},{Cost},{Comment}");
                    sw.WriteLine($"{Id}");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        
    }
}
