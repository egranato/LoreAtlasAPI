using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoreAtlas.Domain;

namespace LoreAtlas.Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context)
    {
      if (context.Universes.Any()) return;

      var universes = new List<Universe>
      {
        new Universe
        {
          Name = "Halo",
          Description = "An interstellar war between humanity and an alliance of aliens known as the Covenant. The Covenant, led by their religious leaders called the Prophets, worship an ancient civilization known as the Forerunners, who perished while defeating the parasitic Flood. The eponymous Halo Array are a group of immense, habitable, ring-shaped superweapons that were created by the Forerunners to destroy the Flood, but which the Covenant mistake for religious artifacts that, if activated, would transport them on a Great Journey to meet the Forerunners."
        },
        new Universe
        {
          Name = "Harry Potter",
          Description = "chronicle the lives of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all of whom are students at Hogwarts School of Witchcraft and Wizardry. The main story arc concerns Harry's struggle against Lord Voldemort, a dark wizard who intends to become immortal, overthrow the wizard governing body known as the Ministry of Magic and subjugate all wizards and Muggles (non-magical people)."
        }
      };

      await context.Universes.AddRangeAsync(universes);
      await context.SaveChangesAsync();
    }
  }
}