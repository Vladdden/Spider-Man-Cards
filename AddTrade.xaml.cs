using System;
using System.Windows;

namespace MARVELCards
{
    public partial class AddTrade : Window
    {
        private Trade trade;
        public AddTrade()
        {
            InitializeComponent();
            CardsCount_textblock.Text = "0 / 0";

        }

        public int CountOfCards;

        private void AddCardInTrade_button_OnClick(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Cost_textbox.Text, out int cost))
                trade = new Trade(cost, Comment_textbox.Text);
            AddCard addCard = new AddCard();
            addCard.Show();
        }

        private void SaveTrade_button_OnClick(object sender, RoutedEventArgs e)
        {
            trade.WriteTradeToFile();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CountOfCard_textbox.IsEnabled = true;
        }

        private void CountOfCard_textbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Int32.TryParse(CountOfCard_textbox.Text, out int TotalCount))
                SetCountOfCards(second: TotalCount);
            else if (CountOfCard_textbox.Text == "")
                SetCountOfCards(second: 0);
        }

        public void SetCountOfCards(int first = -1, int second = -1)
        {
            char[] separators = new char[] { ' ', '/' };
            string str = CardsCount_textblock.Text;
            string[] numbers = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (first == -1) first = Convert.ToInt32(numbers[0]);
            if (second == -1) second = Convert.ToInt32(numbers[1]);
            CardsCount_textblock.Text = $"{first} / {second}";
        }
    }
}