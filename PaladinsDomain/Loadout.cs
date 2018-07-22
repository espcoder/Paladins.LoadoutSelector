using System.Collections.Generic;

namespace PaladinsDomain
{
    public class Loadout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Champion Champion { get; set; }
        public List<Card> Cards { get; set; }
    }
}
