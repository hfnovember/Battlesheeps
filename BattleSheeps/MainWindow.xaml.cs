using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleSheeps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random randomizer = new Random();

        public MainWindow() {
            InitializeComponent();
            TextBlock t = new TextBlock();
            t.TextWrapping = TextWrapping.Wrap;
            t.Text = Taunt.MESSAGES[randomizer.Next(0, Taunt.MESSAGE_SIZE)];
            messageLabel.Content = t;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            GameWindow game = new GameWindow(GameSize.SIZE_5);
            game.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            GameWindow game = new GameWindow(GameSize.SIZE_10);
            game.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                int rand = randomizer.Next(0, Taunt.TAUNT_SIZE);
                string randomText = Taunt.TAUNTS[rand];
                MessageBox.Show(randomText, "BAD DAY AT THE OFFICE?");
                Close();
            }//end if
        }//end exit
    }
}
