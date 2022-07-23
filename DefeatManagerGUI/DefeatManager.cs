using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum MatchResult { WIN, LOSE }

namespace DefeatManagerGUI
{

    public class DefeatManager
    {
        private int nbJokers;
        private int maxLosses;
        private int nbLosses;
        private bool isInWinStreak;
        private List<MatchResult> MatchesHistory;
        private int wonMatchesCount;
        private int lostMatchesCount;

        public DefeatManager(int nbJokers, int maxLosses)
        {
            this.nbJokers = nbJokers;
            this.maxLosses = maxLosses;
            this.nbLosses = 0;
            this.isInWinStreak = false;
            this.MatchesHistory = new List<MatchResult>();

            this.wonMatchesCount = 0;
            this.lostMatchesCount = 0;
        }


        public int GetWonMatchesCount()
        {
            return this.wonMatchesCount;
        }

        public int GetLostMatchesCount()
        {
            return this.lostMatchesCount;
        }

        public int GetMatchesPlayedCount()
        {
            return this.lostMatchesCount + this.wonMatchesCount;
        }
        public List<MatchResult> GetMatchesHistory()
        {
            return this.MatchesHistory;
        }

        public bool IsGameOver()
        {
            return (this.nbLosses >= this.maxLosses);
        }

        public int GetNbJokers()
        {
            return this.nbJokers;
        }

        public int GetRemainingLosses()
        {
            return this.maxLosses - this.nbLosses;
        }

        public void ResetWinStreak()
        {
            this.isInWinStreak = false;
        }

        public void AddWin(bool isUsingJoker)
        {
            this.MatchesHistory.Add(MatchResult.WIN);
            wonMatchesCount++;

            if (isUsingJoker)
                this.nbJokers--;

            else
            {
                if (this.isInWinStreak)
                {
                    this.ResetWinStreak();

                    if (this.nbLosses > 0)
                        this.nbLosses--;
                }
                else
                    this.isInWinStreak = true;
            }
        }

        public void AddLose(bool isUsingJoker)
        {
            this.MatchesHistory.Add(MatchResult.LOSE);
            lostMatchesCount++;

            this.ResetWinStreak();

            if (isUsingJoker == false)
                this.nbLosses++;
            else
                this.nbJokers--;
        }

        public void AddWinRematch(bool isUsingJoker)
        {
            this.MatchesHistory.Add(MatchResult.WIN);
            wonMatchesCount++;

            this.ResetWinStreak();

            if (isUsingJoker)
                this.nbJokers--;
        }
        
        public void AddLoseRematch(bool isUsingJoker)
        {
            this.MatchesHistory.Add(MatchResult.LOSE);

            lostMatchesCount++;

            this.ResetWinStreak();
            if (isUsingJoker)
                this.nbJokers--;

        }
    }
   
}


