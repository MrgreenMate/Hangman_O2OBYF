using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Hangman_O2OBYF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Easy.IsChecked == true)
            {
                StartGame("easy");
            }
            else if (Medium.IsChecked == true)
            {
                StartGame("medium");
            }
            else if (Hard.IsChecked == true)
            {
                StartGame("hard");
            }
            else
            {
                MessageBox.Show("Choose a Difficulty!", "Choose", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            
        }

        private void StartGame(string Difficulty) 
        {
            game gameWindow = new game(Difficulty);
            Close();
            gameWindow.ShowDialog();

        }

        

       
    }
}
