using Avondspel.Domain;
using Avondspel.Infrastructure.Data;

namespace Avondspel.API.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<BordspellenAvond> GetBordspellenAvond([Service] AvondspelDbContext context) =>
            context.BordspellenAvond;
    }
}
