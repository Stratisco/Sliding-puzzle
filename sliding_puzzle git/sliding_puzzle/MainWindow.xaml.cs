using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace sliding_puzzle {
    public partial class MainWindow : Window {
        static class globals { 
            public static string spacer = ""; 

            public static string[,] odd_solved = new string[,] { { "1", "3", "5", "7" }, { "9", "11", "13", "15" }, { "2", "4", "6", "8" }, { "10", "12", "16", globals.spacer } };
            public static string[,] order_solved = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", globals.spacer } };
            public static string[,] solved = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", globals.spacer } };
            public static string[,] board = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", globals.spacer, "15" } };
            public static int collum = 3;
            public static int row = 2;
            public static int moves = 0;
            public static bool cont = true;
            public static int points = 0;
            public static int difficulty = 25;
            public static string shuffle_order;
            public static int multiplier = 2;
            public static bool initialising = true;
            public static bool isOdd = false;
            public static int adder = 0;
        }


        public string Move(string way) { 
            way = way.ToLower();
            if (globals.cont) {
                if (way == "d") {
                    if (globals.row + 1 < 4) { 
                        globals.board[globals.collum, globals.row] = globals.board[globals.collum, globals.row + 1];
                        globals.board[globals.collum, globals.row + 1] = globals.spacer;
                        globals.row++;

                        return "done";
                    }
                }
                if (way == "a") {
                    if (globals.row - 1 > -1) {
                        globals.board[globals.collum, globals.row] = globals.board[globals.collum, globals.row - 1];
                        globals.board[globals.collum, globals.row - 1] = globals.spacer;
                        globals.row--;

                        return "done";
                    }
                }
                if (way == "w") {
                    if (globals.collum - 1 > -1) {
                        globals.board[globals.collum, globals.row] = globals.board[globals.collum - 1, globals.row];
                        globals.board[globals.collum - 1, globals.row] = globals.spacer;
                        globals.collum--;

                        return "done";
                    }
                }
                if (way == "s") {
                    if (globals.collum + 1 < 4) {
                        globals.board[globals.collum, globals.row] = globals.board[globals.collum + 1, globals.row];
                        globals.board[globals.collum + 1, globals.row] = globals.spacer;
                        globals.collum++;

                        return "done"; 
                    }
                }
            }
            return "anything else";
        }

        public bool oddOverEven() { 
            bool check = globals.isOdd;
            double value;
            for (int r = 0; r < 2; r++) {
                for (int c = 0; c < 4; c++) {
                    if (globals.board[r, c] == globals.spacer) {
                        value = 16;
                    } else {
                        value = Convert.ToDouble(globals.board[r, c]);
                    }
                    if (value % 2 == 0) {
                        check = false;
                    }
                }
            }
            return check;

        }

        public bool check() { 
            bool check_tmp = true;

            for (int i = 0; i < 4; i++) {
                for (int l = 0; l < 4; l++) {
                    if (globals.board[i, l] != globals.solved[i, l]) {
                        check_tmp = false;
                    }
                }
            }
            return check_tmp;
        }

        public SolidColorBrush Colour_box(string value) { 
            SolidColorBrush grey_brush = new SolidColorBrush { Color = Color.FromArgb(255, 212, 212, 212) }; 
            SolidColorBrush blue_brush = new SolidColorBrush { Color = Color.FromArgb(255, 223, 242, 255) };

            SolidColorBrush colour = new SolidColorBrush();

            if (value != globals.spacer) {
                double d_value = Convert.ToDouble(value);

                if (d_value % 2 == 0) {
                    colour = grey_brush;
                } else {
                    colour = Brushes.White;
                }
            } else {
                colour = blue_brush;
            }
            return colour;
        }

        public void Update(string sucsess, bool just_screen = false) { 
            box_1.Text = globals.board[0, 0];
            box_2.Text = globals.board[0, 1];
            box_3.Text = globals.board[0, 2];
            box_4.Text = globals.board[0, 3];
            box_5.Text = globals.board[1, 0];
            box_6.Text = globals.board[1, 1];
            box_7.Text = globals.board[1, 2];
            box_8.Text = globals.board[1, 3];
            box_9.Text = globals.board[2, 0];
            box_10.Text = globals.board[2, 1];
            box_11.Text = globals.board[2, 2];
            box_12.Text = globals.board[2, 3];
            box_13.Text = globals.board[3, 0];
            box_14.Text = globals.board[3, 1];
            box_15.Text = globals.board[3, 2];
            box_16.Text = globals.board[3, 3];

            border_1.Fill = Colour_box(globals.board[0, 0]);
            border_2.Fill = Colour_box(globals.board[0, 1]);
            border_3.Fill = Colour_box(globals.board[0, 2]);
            border_4.Fill = Colour_box(globals.board[0, 3]);
            border_5.Fill = Colour_box(globals.board[1, 0]);
            border_6.Fill = Colour_box(globals.board[1, 1]);
            border_7.Fill = Colour_box(globals.board[1, 2]);
            border_8.Fill = Colour_box(globals.board[1, 3]);
            border_9.Fill = Colour_box(globals.board[2, 0]);
            border_10.Fill = Colour_box(globals.board[2, 1]);
            border_11.Fill = Colour_box(globals.board[2, 2]);
            border_12.Fill = Colour_box(globals.board[2, 3]);
            border_13.Fill = Colour_box(globals.board[3, 0]);
            border_14.Fill = Colour_box(globals.board[3, 1]);
            border_15.Fill = Colour_box(globals.board[3, 2]);
            border_16.Fill = Colour_box(globals.board[3, 3]);

            points_text.Text = $"Points: {Convert.ToString(globals.points)}"; 

            if (!globals.cont) { 
                restart_text.Opacity = 1;
            } else {
                restart_text.Opacity = 0;
            }

            if (!just_screen) { 
                if (sucsess == "done") { 
                    globals.moves++;

                    if (check() || oddOverEven()) {
                        globals.cont = false;
                        int earned_points;
                        if (globals.moves < globals.difficulty * 1.5) { 
                            earned_points = ((globals.difficulty / 2) + (globals.difficulty - globals.moves) + globals.adder) * globals.multiplier;
                        } else {
                            earned_points = (10 + globals.adder) * globals.multiplier; 
                        }
                        globals.points += earned_points;

                        points_text.Text = $"Points: {Convert.ToString(globals.points)}";

                        MessageBoxResult again = MessageBox.Show("you completed the puzzle and got " + earned_points + " points.\nTry again?", "", MessageBoxButton.YesNo);
                        if (again == MessageBoxResult.No) {
                            MessageBox.Show("Too bad");
                        }
                    }

                }
            }
            moves_text.Text = $"Moves: {Convert.ToString(globals.moves)}";
        }

        public void randomize(int dificulty) { 
            string tmp = "";
            Random rnd = new Random();
            globals.shuffle_order = "0";
            for (int i = 0; i < dificulty + 1; i++) { 
                int random_number = rnd.Next(1, 5); 

                if (random_number == 1) {
                    tmp = Move("w");
                    globals.shuffle_order = "w" + globals.shuffle_order;
                } else if (random_number == 2) {
                    tmp = Move("a");
                    globals.shuffle_order = "a" + globals.shuffle_order;
                } else if (random_number == 3) {
                    tmp = Move("s");
                    globals.shuffle_order = "s" + globals.shuffle_order;
                } else if (random_number == 4) {
                    tmp = Move("d");
                    globals.shuffle_order = "d" + globals.shuffle_order;
                }
            }
            Update("null", true);
        }

        public void Purchase(string item) { 
            if (item == "1" && globals.points >= 2000) {
                globals.points -= 2000;
                globals.multiplier += 1;
                MessageBox.Show("Your multiplier is now " + Convert.ToString(globals.multiplier), "Shop keeper");
            } else if (item == "2" && globals.points >= 800) {
                globals.points -= 800;
                globals.adder += 20;
                MessageBox.Show("Your score adder is now " + Convert.ToString(globals.adder), "Shop keeper");

            } else {
                MessageBox.Show("Insufficient points", "Shop keeper");
            }
            points_text.Text = $"Points: {Convert.ToString(globals.points)}";

        }

        /////////////////////////////////////////////////////////////////////// | Events | ///////////////////////////////////////////////////////////////////////

        private void Grid_KeyDown(object sender, KeyEventArgs e) { 
            if (e.Key == Key.W || e.Key == Key.Up) {
                up_button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            } else if (e.Key == Key.A || e.Key == Key.Left) { 
                left_button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            } else if (e.Key == Key.S || e.Key == Key.Down) {
                down_button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            } else if (e.Key == Key.D || e.Key == Key.Right) {
                right_button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            } else if (e.Key == Key.Escape) {
                this.Close(); 
            }
            controls.Opacity = 0;
        }

        private void down_button_Click(object sender, RoutedEventArgs e) {
            string tmp1 = Move("s"); 
            Update(tmp1); 
        }

        private void up_button_Click(object sender, RoutedEventArgs e) { 
            string tmp1 = Move("w");
            Update(tmp1);
        }

        private void left_button_Click(object sender, RoutedEventArgs e) { 
            string tmp1 = Move("a");
            Update(tmp1);
        }

        private void right_button_Click(object sender, RoutedEventArgs e) { 
            string tmp1 = Move("d");
            Update(tmp1);
        }

        private void dificulty_selection_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (dificulty_selection.SelectedItem != null) {
                string select = Convert.ToString((ComboBoxItem)dificulty_selection.SelectedItem);
                select = select.Substring(select.Length - (select.Length - 38)); 

                if (select == "Easy") { 
                    globals.difficulty = 16;
                } else if (select == "Medium") {
                    globals.difficulty = 50;

                } else if (select == "Difficult") {
                    globals.difficulty = 100;

                } else if (select == "Puzzle Master") {
                    globals.difficulty = 1000;
                }
            } else {
                globals.difficulty = 50; 
            }
        }

        private void reset_button_Click(object sender, RoutedEventArgs e) {
            string select = Convert.ToString((ComboBoxItem)order_mode.SelectedItem);
            if (order_mode.SelectedItem != null) {
                select = select.Substring(select.Length - (select.Length - 38));
            }



            if (select == "Odd/Even") { 
                globals.board = new string[,] { { "1", "3", "5", "7" }, { "9", "11", "13", "15" }, { "2", "4", "6", "8" }, { "10", "12", "14", globals.spacer } };
                globals.solved = new string[,] { { "1", "3", "5", "7" }, { "9", "11", "13", "15" }, { "2", "4", "6", "8" }, { "10", "12", "14", globals.spacer } };
                globals.isOdd = true;
            } else { 
                globals.board = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", globals.spacer } };
                globals.solved = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", globals.spacer } };
                globals.isOdd = false;
            }



            globals.row = 3;
            globals.collum = 3; 
            globals.cont = true; 
            randomize(globals.difficulty); 
            globals.moves = 0; 

            if (!globals.initialising) { MessageBox.Show("you have restarted the puzzle"); } 


            Update("", true); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Purchase("1"); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Purchase("2"); 
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            if (globals.points >= 100000) {
                MessageBox.Show("I told you he was worthy. He has solved what we could not.", "The Creator");
                MessageBox.Show("Can you hear me my follower? I have something for you.", "The Creator");
                MessageBox.Show("A symbol of your great mind.", "The Creator");
                MessageBox.Show("Consider it a gift from...", "The Creator");
                MessageBox.Show("...A Friend.", "The Creator"); 
                trophy.Opacity = 1;
                worth.Opacity = 0;
                worth.IsEnabled = false; 
            } else {
                MessageBox.Show("You still have much to learn", "?????");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            controls.Opacity = 0; 
        }

        public MainWindow() { 
            InitializeComponent();
            reset_button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); 
            globals.initialising = false;

        }
    }
}