using System.Collections.Generic;

namespace NoAdsHere.Database.Entities
{
    public class Guild
    {
        public int Id { get; set; }

        internal Guild(int guildId)
        {
            Id = guildId;
        }

        internal Guild()
        {
        }
    }
}