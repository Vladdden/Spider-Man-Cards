using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MARVELCards
{
    /// <summary>
    /// Логика взаимодействия для AddCard.xaml
    /// </summary>
    public partial class AddCard : Window
    {
        private CardsInfo cardsInfo;
        private int TradeId;
        private float PricePerCard;
        public AddCard(int tradeId, float pricePerCard)
        {
            InitializeComponent();
            cardsInfo = new CardsInfo();
            for (int i = 0; i < cardsInfo.Groups.GetLength(0); i++)
            {
                Group_combobox.Items.Add(cardsInfo.Groups[i,0]);
            }
            Status_combobox.ItemsSource = cardsInfo.Status;
            Chapter_combobox.ItemsSource = cardsInfo.Chapter;
            TradeId = tradeId;
            PricePerCard = pricePerCard;
        }

        private void Number_textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(Number_textbox.Text, out int number);
            Type_textbox.Text = cardsInfo.CheckType(number);
            AutoSetTollTip_textblock.Visibility = Visibility.Visible;
            Type_textbox.IsEnabled = false;
            if (cardsInfo.CheckYear(number) != 2008)
            {
                Group_combobox.SelectedItem = "-";
                Group_combobox.IsEnabled = false;
            }
        }

        private void AddCard_button_Click(object sender, RoutedEventArgs e)
        {
            //Check data
            {
                if (Name_textbox.Text.Length > 3)
                {
                    if (Int32.TryParse(Number_textbox.Text, out int Num))
                    {
                        if (Num < cardsInfo.TotalCount && Num > 0)
                        {
                            if (Status_combobox.SelectedIndex > -1 && Chapter_combobox.SelectedIndex > -1 && Group_combobox.SelectedIndex > -1)
                            {
                                if (Int32.TryParse(Intelligence_textbox.Text, out int Intelligence) && Int32.TryParse(Power_textbox.Text, out int Power) && Int32.TryParse(SpeedAndAgility_textbox.Text, out int SpeedAndAgility) && Int32.TryParse(SpecialSkills_textbox.Text, out int SpecialSkills) && Int32.TryParse(FightingSkills_textbox.Text, out int FightingSkills))
                                {
                                    if (Intelligence < 500 && Power < 500 && SpeedAndAgility < 500 && SpecialSkills < 500 && FightingSkills < 500)
                                    {
                                        Card card = new Card(Num, Name_textbox.Text, Chapter_combobox.Text, Type_textbox.Text, Group_combobox.Text, Status_combobox.Text, Intelligence, Power, SpeedAndAgility, SpecialSkills, FightingSkills, (bool)OriginalCollectionFlag_checkbox.IsChecked, TradeId, PricePerCard);
                                    }
                                    else MessageBox.Show("Введено невозможное значение параметра карточки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                                }
                                else MessageBox.Show("Проверьте введенные параметры карточки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                            }
                            else MessageBox.Show("Заполнены не все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        else MessageBox.Show("Введен несуществующий номер карты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else MessageBox.Show("Убедитесь, что в поле ввода номера введены ИСКЛЮЧИТЕЛЬНО цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                }
                else MessageBox.Show("Проверьте поле ввода имени!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
