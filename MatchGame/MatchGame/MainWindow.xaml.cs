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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "😺","😺",
                "🐵","🐵",
                "🦁","🦁",
                "🐮","🐮",
                "🐲","🐲",
                "🐼","🐼",
                "🐬","🐬",
                "🐟","🐟"
            };

            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                Console.WriteLine(index);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }


        }



        TextBlock lastTextBlockClicked;

        //Keeping track if a player has clicked on the first animal in a pair and is now trying to find its match.
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBlock textBlock = sender as TextBlock;

            // If a player clicked the first item in a pair, we make that item invisiable and store its textBlock in case if we need to find a match or not.
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;

            }
            // This indicates that we have found a match and we can proceed to find more matching pairs
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }

            else
            {
                // This indicates that if the last selected item does not match the first, we make that 2nd item visisble and continue to search for a match.
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;

            }



        }
    }
}
