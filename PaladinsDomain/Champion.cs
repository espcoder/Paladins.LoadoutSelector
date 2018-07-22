using System.Collections.Generic;

namespace PaladinsDomain
{
    public class Champion
    {
        public Champion()
        {
            Loadouts = new List<Loadout>();
        }

        public int Id { get; set; }
        public List<Loadout> Loadouts { get; set; }
        public string Name { get; set; }
    }
}