namespace Application.Domain
{
    using System.Collections.Generic;

    public class ValuesInteractor : IValuesInteractor
    {
        private readonly IValues _values;

        public ValuesInteractor(IValues values)
        {
            _values = values;
        }

        public IEnumerable<ValueDto> Get()
        {
            return _values.GetValues();
        }
    }
}
