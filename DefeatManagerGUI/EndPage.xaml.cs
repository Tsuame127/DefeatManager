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

namespace DefeatManagerGUI
{
    public partial class EndPage : Page
    {
        public EndPage(int winCount, int loseCount)
        {
            InitializeComponent();

            int matchesPlayed = winCount + loseCount;
            double winLoseRatio = Math.Round((double)winCount / matchesPlayed * 100, 2);

            StatsSummary.Content = $"Matchs joués : {matchesPlayed}\n\nVictoires : {winCount}\n\nDéfaites : {loseCount}\n\nRatio V/D : {winLoseRatio}%";
        }
    }
}
