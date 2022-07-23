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
using System.Diagnostics;

namespace DefeatManagerGUI
{
    public partial class WinLoseManagingPage : Page
    {
        public DefeatManager defeatManager;
        private Window window;


        public WinLoseManagingPage(int nbJokers, int maxLosses, Window window)
        {
            InitializeComponent();

            this.defeatManager = new DefeatManager(nbJokers, maxLosses);

            this.ResetUI();
            this.window = window;
        }

        private void ResetUI()
        {
            if (this.defeatManager.IsGameOver())
            {
                this.CloseGameAndEnd();
            }

            RemainingJokersLabel.Content = $"Jokers restants : {this.defeatManager.GetNbJokers()}";
            RemainingLossesLabel.Content = $"Défaites restante : {this.defeatManager.GetRemainingLosses()}";

            this.WinButton.IsEnabled = true;
            this.LoseButton.IsEnabled = true;

            bool hasJokers = (this.defeatManager.GetNbJokers() > 0);
            this.JokerCheckBox.IsEnabled = hasJokers;
            this.JokerCheckBox.IsChecked = false;

            RematchButton.Visibility = Visibility.Hidden;
            NoRematchButton.Visibility = Visibility.Hidden;
            RematchButton.IsEnabled = true;
            NoRematchButton.IsEnabled = true;

            RBWin.Visibility = Visibility.Hidden;
            RBLose.Visibility = Visibility.Hidden;

            
            this.DisplayMatchHistory();
            this.UpdateRatioBar();
        }

        private void DisplayMatchHistory()
        {
            WinCountLabel.Content = this.defeatManager.GetWonMatchesCount();
            LoseCountLabel.Content = this.defeatManager.GetLostMatchesCount();
        }

        private void UpdateRatioBar() 
        {
            int playedMatchesCount = this.defeatManager.GetMatchesPlayedCount();
            int wonMatchesCount = this.defeatManager.GetWonMatchesCount();

            if (playedMatchesCount <= 0)
            {
                DefeatProgressBar.Background = Brushes.Gray;
                DefeatProgressBar.Value = 0;
            }
            else
            {
                DefeatProgressBar.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8E3535");
                DefeatProgressBar.Value = ((double)wonMatchesCount / (double)playedMatchesCount) * 100;
            }
        }

        private void DisableUI()
        {
            WinButton.IsEnabled = false;
            LoseButton.IsEnabled = false;
            JokerCheckBox.IsEnabled = false;
        }

        private void OnLosePressed(object sender, RoutedEventArgs e)
        {
            this.DisableUI();
            this.DisplayRematchButtons();

        }

        private void OnWinPressed(object sender, RoutedEventArgs e)
        {
            this.DisableUI();
            this.defeatManager.AddWin((bool)JokerCheckBox.IsChecked);
            this.ResetUI();
        }

        private void DisplayRematchButtons()
        {
            RematchButton.Visibility = Visibility.Visible;
            NoRematchButton.Visibility = Visibility.Visible;
        }

        private void OnNoRematchButton(object sender, RoutedEventArgs e)
        {
            this.defeatManager.AddLose((bool)JokerCheckBox.IsChecked);
            this.ResetUI();
        }

        private void OnRematchButton(object sender, RoutedEventArgs e)
        {
            RBWin.Visibility = Visibility.Visible;
            RBLose.Visibility = Visibility.Visible;
            RematchButton.IsEnabled = false;
            NoRematchButton.IsEnabled = false;
        }

        private void OnRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            Button pressedButton = sender as Button;

            if (pressedButton.Name == "RBLose")
            {
                this.defeatManager.AddLoseRematch(false);
            }
            else
            {
                this.defeatManager.AddWinRematch(false);
            }

            this.ResetUI();
        }

        private void CloseGameAndEnd()
        {
            Process[] FoundProcesses = Process.GetProcessesByName("BrawlhallaGame");
            foreach (var brawlhallaProcess in FoundProcesses)
                brawlhallaProcess.Kill();

            EndPage endPage = new EndPage(this.defeatManager.GetWonMatchesCount(), this.defeatManager.GetLostMatchesCount());
            this.window.Content = endPage;
        }

    }
}
