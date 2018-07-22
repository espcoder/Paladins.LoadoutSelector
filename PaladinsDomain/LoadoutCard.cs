namespace PaladinsDomain
{
    public class LoadoutCard
    {
        public int LoadoutId { get; set; }
        public Loadout Loadout { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }

        public int Level { get; set; }
    }
}