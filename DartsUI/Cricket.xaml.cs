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

namespace DartsUI
{
    /// <summary>
    /// Interaction logic for Cricket.xaml
    /// </summary>
    public partial class Cricket : Window
    {
        private List<Player> Players { get; set; }
        private int PlayerCount { get; set; }
        public Cricket()
        {
            InitializeComponent();
            PlayerCount = 2;
            Players = new List<Player>();
            for(int i = 0; i < PlayerCount; i++)
            {
                string name = $"Player {i + 1}";
                Players.Add(new Player(name));
            }
        }

        private void ScoreBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var playerNum = Convert.ToInt32(ScoreButton.GetPlayer(btn));
            var points = Convert.ToInt32(ScoreButton.GetPoints(btn));
            var state = Convert.ToInt32(ScoreButton.GetState(btn));

            var playerObj = Players[playerNum - 1];

            if(state < 3)
            {
                state++;

            }
            else
            {
                playerObj.addPoints(points);
            }
            //Console.WriteLine(ScoreButton.GetPlayer)
        }


    }
    public class Player
    {
        public string Score { get; set; }
        public string Name { get; set; }
        public bool ClosedOut { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = "0";
            ClosedOut = false;
        }

        public int getScoreInt()
        {
            return Convert.ToInt32(Score);
        }

        public void addPoints(int points)
        {
            var s = Convert.ToInt32(Score);
            s += points;
            Score = $"{s}";
        }
    }
    public static class ScoreButton
    {
        public static readonly DependencyProperty PlayerProperty = DependencyProperty.RegisterAttached("Player",
            typeof(string), typeof(ScoreButton), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PointsProperty = DependencyProperty.RegisterAttached("Points",
            typeof(string), typeof(ScoreButton), new FrameworkPropertyMetadata(null));

        public static DependencyProperty StateProperty = DependencyProperty.RegisterAttached("State",
            typeof(string), typeof(ScoreButton), new FrameworkPropertyMetadata(null));

        public static string GetPlayer(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            return (string)element.GetValue(PlayerProperty);
        }
        public static void SetPlayer(UIElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.SetValue(PlayerProperty, value);
        }

        public static string GetPoints(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            return (string)element.GetValue(PointsProperty);
        }
        public static void SetPoints(UIElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.SetValue(PointsProperty, value);
        }
        public static string GetState(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            return (string)element.GetValue(PointsProperty);
        }
        public static void SetState(UIElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.SetValue(PointsProperty, value);
        }

        public static void UpdateIcon(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.s
        }
    }
}
