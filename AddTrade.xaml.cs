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
            //Check data
            {
                if (Name_textbox.Text.Length > 5)
                {
                    if (Int32.TryParse(Cost_textbox.Text, out int cost))
                    {
                        if (cost  >= 0)
                        {
                            trade = new Trade(cost, Comment_textbox.Text);
                            AddCard addCard = new AddCard(trade.Id, Convert.ToSingle(PricePerCard_textbox.Text));
                            addCard.Show();                        
                        }
                        else MessageBox.Show("Введено невозможное значение цены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else MessageBox.Show("Убедитесь, что в поле ввода цены введены ИСКЛЮЧИТЕЛЬНО цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                }
                else MessageBox.Show("Проверьте поле ввода имени!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void SaveTrade_button_OnClick(object sender, RoutedEventArgs e)
        {
            trade.WriteTradeToFile();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CountOfCard_textbox.IsEnabled = true;
        }

        private void Cost_textbox_SetPricePerOne(int TotalCount)
        {
            if (Int32.TryParse( Cost_textbox.Text, out int cost))
            {
                PricePerCard_textbox.Text = Math.Round((float)cost / (float)TotalCount, 2).ToString();;
            }
        }

        private void CountOfCard_textbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Int32.TryParse(CountOfCard_textbox.Text, out int TotalCount))
            {
                SetCountOfCards(second: TotalCount);
                Cost_textbox_SetPricePerOne(TotalCount);
            }
                
            else if (CountOfCard_textbox.Text == "")
            {
                SetCountOfCards(second: 0);
                PricePerCard_textbox.Text = "";
            }
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
