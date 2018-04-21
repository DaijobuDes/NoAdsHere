using NoAdsHere.Database.Entities.Enums;

namespace NoAdsHere.Database.Entities
{
    public class User
    {
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }

        public ViolationLevel ViolationLevel { get; set; } = ViolationLevel.Nothing;

        internal User()
        {
        }
    }
}