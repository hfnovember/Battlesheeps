using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BattleSheeps {
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    /// 

    public partial class GameWindow : Window {
        /********************************************************************************/
        public readonly GameSize GAMESIZE;
        public readonly int SHEEP_TO_PLACE;
        public const ushort NUM_OF_PLAYERS = 2;
        public const ushort BUTTON_WIDTH = 40;
        public const ushort BUTTON_HEIGHT = 40;
        private Square[,] playerSquares;
        private Square[,] computerSquares;
        private Player turn;
        private readonly ImageBrush flower;
        private readonly ImageBrush sheep;
        private readonly ImageBrush deadSheep;
        private readonly ImageBrush backgroundI;
        private Random randomizer;
        private int games = 0;
        private int turns = 0;
        private int humanWins = 0;
        private int computerWins = 0;
        private int humanSheepKilled = 0;
        private int computerSheepKilled = 0;
        List<Point> computerChoices;
        System.Media.SoundPlayer sheepSound;
        System.Media.SoundPlayer gunSound;

        /********************************************************************************/
        public GameWindow(GameSize gameSize) {
            //Init form
            InitializeComponent();

            //Init nums
            GAMESIZE = gameSize;
            SHEEP_TO_PLACE = ((int)GAMESIZE*(int)GAMESIZE) / 5;
            randomizer = new Random();

            //Init Images
            flower = new ImageBrush();
            flower.ImageSource = new BitmapImage(new Uri("Images/flower.png", UriKind.Relative));
            sheep = new ImageBrush();
            sheep.ImageSource = new BitmapImage(new Uri("Images/sheep.png", UriKind.Relative));
            deadSheep = new ImageBrush();
            deadSheep.ImageSource = new BitmapImage(new Uri("Images/red-sheep.png", UriKind.Relative));
            backgroundI = new ImageBrush();
            backgroundI.ImageSource = new BitmapImage(new Uri("Images/background.fw.png", UriKind.Relative));
            this.Background = backgroundI;

            //Init Sounds
            sheepSound = new System.Media.SoundPlayer(@"Sounds\sheep.wav");
            gunSound = new System.Media.SoundPlayer(@"Sounds\gun.wav");

            //Init structs
            playerSquares = new Square[(int)GAMESIZE,(int)GAMESIZE];
            computerSquares = new Square[(int)GAMESIZE,(int)GAMESIZE];
            computerChoices = new List<Point>();

            //Init func
            DrawSquares();
            InitializeSheep();
        
        }//end GameWindow()
        /********************************************************************************/
        private void DrawSquares() {

            playerStackpanel.Children.Clear();
            computerStackpanel.Children.Clear();

            int squares = (int)GAMESIZE;

            //Draw the Human Squares:
            List<StackPanel> stackpanelList = new List<StackPanel>();
            int sID = 0;

            for (int i = 0; i < squares; i++) {
                stackpanelList.Add(new StackPanel());
                for (int j = 0; j < squares; j++) {
                    playerSquares[i,j] = new Square(Player.HUMAN);
                    playerSquares[i, j].SetState(SquareState.EMPTY);
                    Thickness margin = playerSquares[i,j].Margin;
                    playerSquares[i,j].Margin = margin;
                    playerSquares[i,j].Name = "HumanButton" + i + "_" + j;
                    playerSquares[i,j].Width = BUTTON_WIDTH;
                    playerSquares[i,j].Height = BUTTON_HEIGHT;
                    playerSquares[i,j].Style = FindResource("btnStyle") as Style;
                    stackpanelList[sID].Children.Add(playerSquares[i, j]);
                }//end for2
                sID++;
            }//end for

            foreach (StackPanel s in stackpanelList) {
                s.Orientation = Orientation.Horizontal;
                playerStackpanel.Children.Add(s);
            }//end for

            //Draw the Computer Squares:
            stackpanelList.Clear();
            sID = 0;

            for (int i = 0; i < squares; i++) {
                stackpanelList.Add(new StackPanel());
                for (int j = 0; j < squares; j++) {
                    computerSquares[i, j] = new Square(Player.COMPUTER);
                    computerSquares[i, j].SetState(SquareState.EMPTY);
                    Thickness margin = computerSquares[i, j].Margin;
                    computerSquares[i, j].Margin = margin;
                    computerSquares[i, j].Name = "ComputerButton" + i + "_" + j; ;
                    computerSquares[i, j].Width = BUTTON_WIDTH;
                    computerSquares[i, j].Height = BUTTON_HEIGHT;
                    computerSquares[i, j].Style = FindResource("btnCPUStyle") as Style;
                    computerSquares[i, j].Click += new RoutedEventHandler(ButtonClick);
                    stackpanelList[sID].Children.Add(computerSquares[i, j]);
                }//end for2
                sID++;
            }//end for

            foreach (StackPanel s in stackpanelList) {
                s.Orientation = Orientation.Horizontal;
                computerStackpanel.Children.Add(s);
            }//end for

            UpdateLabels();

        }//end DrawSquares()
        /********************************************************************************/
        private void InitializeSheep() {
            int squares = (int)GAMESIZE;
            int generated = SHEEP_TO_PLACE;
            games++;
            turns = 0;
            List<Point> list = new List<Point>();

            //Initialize Player's Sheep:
            while (generated > 0) {
                
                int randomI = randomizer.Next(0, squares);
                int randomJ = randomizer.Next(0, squares);
                bool exists = false;

                foreach (Point p in list) {
                    if (p.i == randomI && p.j == randomJ) {
                        exists = true; break;
                    }//end if
                }//end for

                if (!exists) {
                    Point np; np.i = randomI; np.j = randomJ;
                    list.Add(np);
                    generated--;
                    playerSquares[randomI, randomJ].SetState(SquareState.ALIVE);
                    playerSquares[randomI, randomJ].Background = sheep;
                }//end if
                
            }//end while

            
            //Clear up the background for player's empty squares
            for (int i = 0; i < squares; i++) {
                for (int j = 0; j < squares; j++) {
                    foreach (Point p in list) {
                        if (playerSquares[i, j].GetState() == SquareState.EMPTY) playerSquares[i, j].Background = null;
                    }//end for
                }//end for
            }//end for

            generated = SHEEP_TO_PLACE;
            list.Clear();

            //Initialize Computer's Sheep:
            while (generated > 0) {

                int randomI = randomizer.Next(0, squares);
                int randomJ = randomizer.Next(0, squares);
                bool exists = false;

                foreach (Point p in list) {
                    if (p.i == randomI && p.j == randomJ) {
                        exists = true; break;
                    }//end if
                }//end for

                if (!exists) {
                    Point np; np.i = randomI; np.j = randomJ;
                    list.Add(np);
                    generated--;
                    computerSquares[randomI, randomJ].SetState(SquareState.ALIVE);
                    //computerSquares[randomI, randomJ].Background = sheep; //TODO: Comment this line out.
                }//end if
                
            }//end while

            UpdateLabels();

        }//end InitializeSheep()
        /********************************************************************************/
        private void ButtonClick(object sender, RoutedEventArgs e) { 

            if (turn != Player.HUMAN) throw new InvalidOperationException();

            Square square = (Square)sender;
            string s = square.Name;

            int i = int.Parse(s[14].ToString());
            int j = int.Parse(s[16].ToString());

            if (computerSquares[i, j].GetState() == SquareState.POPPED) return;
            if (computerSquares[i, j].GetState() == SquareState.DEAD) return;

            if (computerSquares[i, j].GetState() == SquareState.ALIVE) {
                computerSquares[i, j].SetState(SquareState.DEAD);
                computerSquares[i, j].Background = deadSheep;
                gunSound.Play();
                humanSheepKilled++;
                turns++;
                //MessageBox.Show("Was alive, now dead");
            }//end if alive

            if (computerSquares[i, j].GetState() == SquareState.EMPTY) {
                computerSquares[i, j].SetState(SquareState.POPPED);
                computerSquares[i, j].Background = flower;
                turns++;
                //MessageBox.Show("Was empty, popped");
            }//end if empty

            Player winner = GameIsOver();
            if (winner == Player.COMPUTER) {
                MessageBox.Show("Computer wins!", "ROUND OVER");
                computerWins++;
                ClearBoard();
            }//end if computer wins
            else if (winner == Player.HUMAN) {
                MessageBox.Show("You win!", "ROUND OVER");
                humanWins++;
                ClearBoard();
            }//end if player wins
            else if (winner == Player.NONE) {
                turn = Player.COMPUTER;
                Play();
            }//end if nobody wins

            UpdateLabels();

        }//end humanButtonClick()
        /********************************************************************************/
        private Player GameIsOver() {

            Player winner = Player.NONE;

            //If human's turn was done:
            if (turn == Player.HUMAN) {

                winner = Player.HUMAN;

                for (int i = 0; i < (int)GAMESIZE; i++) {
                    for (int j = 0; j < (int)GAMESIZE; j++) {
                        if (computerSquares[i,j].GetState() == SquareState.ALIVE) {
                            winner = Player.NONE;
                            break;
                        }//end if
                    }//end for2
                }//end for1
            }//end if human

            //If computer's turn was done:
            if (turn == Player.COMPUTER) {

                winner = Player.COMPUTER;

                for (int i = 0; i < (int)GAMESIZE; i++) {
                    for (int j = 0; j < (int)GAMESIZE; j++) {
                        if (playerSquares[i, j].GetState() == SquareState.ALIVE) {
                            winner = Player.NONE;
                            break;
                        }//end if
                    }//end for 2
                }//end for 1
            }//end if computer

            UpdateLabels();
            return winner;

        }//end GameIsOver()
        /********************************************************************************/
        private void Play() {
            Point pt;
            pt.i = 0;
            pt.j = 0;
            bool found = false;

            //Find a non-used spot:
            while (!found) {
                pt.i = randomizer.Next(0, (int)GAMESIZE);
                pt.j = randomizer.Next(0, (int)GAMESIZE);

                bool existsInList = false;
                foreach (Point p in computerChoices) {
                    if (p.i == pt.i && p.j == pt.j) {
                        existsInList = true; break;
                    }//end if
                }//end for

                if (!existsInList) {
                    computerChoices.Add(pt);
                    found = true;
                }//end if

            }//end while

            //Attack:
            if (playerSquares[pt.i,pt.j].GetState() == SquareState.EMPTY) {
                playerSquares[pt.i, pt.j].SetState(SquareState.POPPED);
                playerSquares[pt.i, pt.j].Background = flower;
            }//end if empty
            else if (playerSquares[pt.i, pt.j].GetState() == SquareState.ALIVE) {
                playerSquares[pt.i, pt.j].SetState(SquareState.DEAD);
                playerSquares[pt.i, pt.j].Background = deadSheep;
                sheepSound.Play();
                computerSheepKilled++;
            }//end if alive
            else if (playerSquares[pt.i, pt.j].GetState() == SquareState.POPPED) throw new InvalidOperationException();
            else if (playerSquares[pt.i, pt.j].GetState() == SquareState.DEAD) throw new InvalidOperationException(); 



            Player winner = GameIsOver();
            if (winner == Player.COMPUTER) {
                MessageBox.Show("Computer wins!", "ROUND OVER");
                computerWins++;
                ClearBoard();
                turn = Player.HUMAN;
            }//end if computer wins
            else if (winner == Player.HUMAN) {
                MessageBox.Show("You win!", "ROUND OVER");
                humanWins++;
                ClearBoard();
                turn = Player.HUMAN;
            }//end if player wins
            else if (winner == Player.NONE) {
                turn = Player.HUMAN;
            }//end if nobody wins

            UpdateLabels();

        }//end Play()
        /********************************************************************************/
        private void ClearBoard() {
            playerStackpanel.Children.Clear();
            computerStackpanel.Children.Clear();
            if (MessageBox.Show("Our battlesheeps need you commander! Would you like to play again?", "Play again?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Reset();
            else {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }//end if 

            UpdateLabels();

        }//end ClearBoard()
        /********************************************************************************/
        private void Reset() {
            computerChoices.Clear();
            DrawSquares();
            InitializeSheep();
            UpdateLabels();
        }//end Reset()
        /********************************************************************************/
        private void btnBack_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("Once you're awake, it's hard to go back to sheep...", "Go back?", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }//if yes
        }//end back click
        /********************************************************************************/
        private void btnReset_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("This round will be lost! Are you sure?", "Loser?", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                computerWins++;
                Reset();
            }//end if yes
        }//end reset blick
        /********************************************************************************/
        private void UpdateLabels() {
            lblGamesPlayed.Content = games + " Games Played";
            lblTurns.Content = "Turn " + turns;
            lblPlayerSheep.Content = humanSheepKilled + " sheep destroyed";
            lblComputerSheep.Content = computerSheepKilled + " sheep destroyed";
            lblScoreComputer.Content = "[" + computerWins + "]";
            lblScorePlayer.Content = "[" + humanWins + "]";
        }//end UpdateLabels()
        /********************************************************************************/

    }//end class GameWindow
}//end namespace BattleSheeps
