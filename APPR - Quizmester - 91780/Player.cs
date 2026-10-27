using System;

namespace APPR___Quizmester___91780
{
    internal class Player
    {
        private int playerId;
        private string playerName;
        private bool isAdmin;

        public Player(int playerId, string playerName, bool isAdmin)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.isAdmin = isAdmin;
        }

        public int GetPlayerId()
        {
            return playerId;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public bool GetIsAdmin()
        {
            return isAdmin;
        }
    }
}