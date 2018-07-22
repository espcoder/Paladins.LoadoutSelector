using System.Collections.Generic;

namespace PaladinsDomain
{
    public class Card
    {
        public int Id { get; set; }
        public Champion Champion { get; set; }
        public string Name { get; set; }

        public List<LoadoutCard> Loadouts { get; set; }
    }
}