using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPR___Quizmester___91780
{
    internal class Score
    {
        private int scoreId;
        private TimeSpan score;
        private DateTime datePlayed;
        private string playername;

        public Score(int scoreId, TimeSpan score, DateTime datePlayed, string playername)
        {
            this.scoreId = scoreId;
            this.score = score;
            this.datePlayed = datePlayed;
            this.playername = playername;
        }

        public int GetScoreId()
        {
            return scoreId;
        }

        public TimeSpan GetScore()
        {
            return score;
        }

        public DateTime GetDatePlayed()
        {
            return datePlayed;
        }

        public string GetPlayername()
        {
            return playername;
        }
    }
}
