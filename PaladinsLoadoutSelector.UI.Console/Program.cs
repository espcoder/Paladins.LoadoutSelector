using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PaladinsDomain;
using PaladinsLoadoutSelector.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaladinsLoadoutSelector.UI.Console
{
    internal class Program
    {
        private static PaladinsLoudoutSelectorContext context = new PaladinsLoudoutSelectorContext();

        private static void Main(string[] args)
        {
            // EnsureDeleted to Delete the local database when the app runs.
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            #region Setup Data
            // Use these methods to seed the database with data.
            InsertChampion();
            AddCards();
            SetupMyProfile();
            #endregion Setup Data

            //GetAllChampionQuery();
            //GetSingleChampion("baric");
            //UpdateChampion(2, "Fernando");

            var champ = GetChampion("Ruckus");
            DisplayChampion(champ);

            System.Console.Read();
        }

        private static Champion GetChampion(string name)
        {
            var champ = context.Champions
                .Include(i => i.Loadouts)
                .ThenInclude(ti => ti.LoadoutCards)
                .ThenInclude(c => c.Card)
                .FirstOrDefault(f => f.Name == name);

            return champ;
        }

        private static void DisplayChampion(Champion champ)
        {
            if (champ == null)
            {
                System.Console.WriteLine("The Champion does not exist in the datastore.");
                return;
            }

            System.Console.WriteLine($"{champ.Name} has loadout: {champ.Loadouts.First()?.Name ?? "No loadouts"}");
            
            if (champ.Loadouts.Any())
            {
                foreach (var loadout in champ.Loadouts)
                {
                    System.Console.WriteLine($"Loadout: {loadout.Name}");
                    foreach (var loadoutCard in loadout.LoadoutCards)
                    {
                        System.Console.WriteLine($"{loadoutCard.Card.Name} at level {loadoutCard.Level.ToString()}");
                    }
                }
            }
        }

        private static void AddCards()
        {
            var ruckus = context.Champions.First(f => f.Name == "Ruckus");

            var nanoTech = new Card { Champion = ruckus, Name = "nanotechnology".ToUpper() };
            var refraction = new Card { Champion = ruckus, Name = "refraction".ToUpper() };
            var crystal = new Card { Champion = ruckus, Name = "crystal capacitor".ToUpper() };
            var extendMag = new Card { Champion = ruckus, Name = "extended magazines".ToUpper() };
            var metalMarch = new Card { Champion = ruckus, Name = "metal march".ToUpper() };

            var cards = new List<Card> { nanoTech, refraction, crystal, metalMarch, extendMag };
            context.Cards.AddRange(cards);

            context.SaveChanges();
        }

        private static void SetupMyProfile()
        {
            try
            {
                var ruckus = context.Champions.First(f => f.Name == "Ruckus");
                var cards = context.Cards.Where(w => w.Champion == ruckus).ToList();

                var loadout = new Loadout
                {
                    Champion = ruckus,
                    Name = "Nano-Emitter"
                };
                context.Loadouts.Add(loadout);

                var loadoutCards = new List<LoadoutCard>
                {
                    new LoadoutCard{ Card=cards.First(f => f.Name == "nanotechnology".ToUpper()), Loadout = loadout, Level=2},
                    new LoadoutCard{Card=cards.First(f=> f.Name=="refraction".ToUpper()), Loadout=loadout, Level=4},
                    new LoadoutCard{Card = cards.First(f=>f.Name=="extended magazines".ToUpper()), Loadout=loadout, Level=3 },
                    new LoadoutCard{Card =cards.First(f=>f.Name=="crystal capacitor".ToUpper()), Loadout=loadout, Level=4},
                    new LoadoutCard{Card=cards.First(f=>f.Name=="metal march".ToUpper()), Loadout=loadout, Level=2}
                };
                context.LoadoutCards.AddRange(loadoutCards);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Ahhh %^&$. Error doing this:{ex.Message}");
            }
        }

        private static void UpdateChampion(int id, string newName)
        {
            var champ = context.Champions.Find(id);
            champ.Name = newName;
            context.SaveChanges();
        }

        private static void GetSingleChampion(string name)
        {
            System.Console.WriteLine(context.Champions.FirstOrDefault(x => x.Name == name)?.Name ?? "No champion by that name found");
        }

        private static void GetAllChampionQuery()
        {
            foreach (var item in context.Champions)
            {
                System.Console.WriteLine($"Champion: {item.Name}");
            }
        }

        private static void InsertChampion()
        {
            var listOChamps = new List<Champion>
            {
                 new Champion { Name = "Ruckus" },
                 new Champion { Name = "Lex" },
                 new Champion {Name="Cassie"},
                 new Champion{Name="Viktor"},
            };

            context.Champions.AddRange(listOChamps);
            context.SaveChanges();
        }
    }
}