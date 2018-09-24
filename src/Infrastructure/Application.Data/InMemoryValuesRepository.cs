namespace Application.Data
{
    using System.Collections.Generic;
    using Application.Domain;

    public class InMemoryValuesRepository : IValues
    {
        public IEnumerable<ValueDto> GetValues()
        {
            return new List<ValueDto>() { new ValueDto { Name = "name", Value = "value" } };
        }
    }
}