namespace Application.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Domain;

    public class ValuesRepository : IValues
    {
        private ApplicationDbContext _context;

        public ValuesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ValueDto> GetValues()
        {
            return _context.Values.Select(value => new ValueDto
            {
                Name = value.Name,
                Value = value.Amount.ToString()
            });
        }
    }
}
