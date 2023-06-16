using Avondspel.Domain;
using Avondspel.Domain.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avondspel.Infrastructure.Data
{
    public static class SeedData
    {
       /* public static void EnsurePopulated(IApplicationBuilder app)
        {
            AvondspelDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AvondspelDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Bordspellen.Any())
            {
                context.Bordspellen.AddRange(
                    new Bordspel
                    {
                        Naam = "Patchwork",
                        Description = "Probeer zoveel mogelijk lapjes op je dekentableau te leggen. Zorg niet alleen dat het lapje past, maar houd ook rekening met de tijd die het inpassen kost en de inkomsten die het in knopen genereert. Uiteindelijk krijg je namelijk zoveel punten als het aantal knopen dat je hebt minus tweemaal de onbebouwde velden op je speelbord. Bouw je als eerste een deken van 7 x 7, dan scoor je bonuspunten!",
                        genre = Genre.Fantasy,
                        foto = "idk",
                        soortSpel = SoortSpel.Bordspellen,
                        GebruikerId = "190fd8db-257e-4a58-9452-f1ff44190471"

                    },
                    new Bordspel
                    {
                        Naam = "Flamecraft",
                        Description = "Artisan dragons, the smaller and magically talented versions of their larger (and destructive) cousins, are sought by shopkeepers so that they may delight customers with their flamecraft. You are a Flamekeeper, skilled in the art of conversing with dragons, placing them in their ideal home and using enchantments to entice them to produce wondrous things. Your reputation will grow as you aid the dragons and shopkeepers, and the Flamekeeper with the most reputation will be known as the Master of Flamecraft.",
                        genre = Genre.Fantasy,
                        foto = "idk",
                        soortSpel = SoortSpel.Bordspellen,
                        GebruikerId = "190fd8db-257e-4a58-9452-f1ff44190471"

                    }
                );
                context.SaveChanges();
            }

            if (!context.Eten.Any())
            {
                context.Eten.AddRange(
                    new Eten
                    {
                        Name = "Taart",
                        Lactose = true,
                        Notenallergie = true,

                    },
                    new Eten
                    {
                        Name = "Chips"

                    },
                    new Eten
                    {
                        Name = "Winegums",
                        Vega = true

                    },
                    new Eten
                    {
                        Name = "Chocolate chips koekjes",
                        Lactose = true,
                        Notenallergie = true,

                    },
                    new Eten
                    {
                        Name = "Mini snacks",
                        Vega = true,
                    },
                    new Eten
                    {
                        Name = "Cola"

                    },
                    new Eten
                    {
                        Name = "Wijn",
                        Alcohol = true,

                    },
                    new Eten
                    {
                        Name = "Bier",
                        Alcohol = true,

                    },
                    new Eten
                    {
                        Name = "Thee"

                    }
                    );
                context.SaveChanges();
            }
        }*/

    }
}