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
using System.Windows.Shapes;
using System.IO;

namespace Hangman_O2OBYF
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        private string[] words;
        private string wordToGuess;
        private char[] guessedWord;
        int attempt = 0;
        private string Difficulty;

        public game(String DifficultyGet)
        {
            Difficulty = DifficultyGet.ToLower();
            InitializeComponent();
            StartGame();

        }

        private string[] Load()
        {
            String file = Difficulty + ".txt";
            try
            {

                if (File.Exists(file))
                {

                    string[] WordsFromFile = File.ReadAllLines(file);
                    return WordsFromFile;
                }
                else
                {
                    MessageBox.Show($"A file Not Found: {file}");
                    return null;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Not Found:");
                return null;
                Close();
            }


        }

        public void StartGame()
        {

            words = Load();
            Random random = new Random();
            wordToGuess = words[random.Next(words.Length)];
            guessedWord = new string('-', wordToGuess.Length).ToCharArray();
            attempt = 0;
            Letters.Content = new string(guessedWord);

        }


        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            Button ButtonClick = sender as Button;
            ButtonClick.IsEnabled = false;
            char Guess = ButtonClick.Content.ToString().ToLower()[0];
            if (wordToGuess.Contains(Guess))
            {
                fill(Guess);
            }
            else
            {
                hangmanDraw();
            }
        }



        private void fill(Char Guess)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == Guess)
                {
                    guessedWord[i] = Guess;
                }
            }
            Letters.Content = new string(guessedWord);
            if (new string(guessedWord) == wordToGuess)
            {
                MessageBox.Show($"Congratulations, you win!\n The word: {wordToGuess}");
                EndGame();
            }

        }

        private void hangmanDraw()
        {
            attempt++;
            if (attempt == 1)
            {
                FirstMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 2)
            {
                SecondMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 3)
            {
                ThirdMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 4)
            {
                FourthMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 5)
            {
                FifthMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 6)
            {
                SixthMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 7)
            {
                SeventhMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 8)
            {
                EighthMistake.Visibility = Visibility.Visible;
            }
            else if (attempt == 9)
            {
                NinthMistake.Visibility = Visibility.Visible;
            }
            else
            {
                TenthMistake.Visibility = Visibility.Visible;
                MessageBox.Show($"Mission Failed! :(\n Correct word: {wordToGuess}");
                EndGame();
            }
        }
        private void EndGame() 
        {
            MainWindow mainWindow = new MainWindow();

            Close();
            mainWindow.ShowDialog();
        }
    }
}
