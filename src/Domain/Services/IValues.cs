namespace Application.Domain
{
    using System.Collections.Generic;

    public interface IValues
    {
        IEnumerable<ValueDto> GetValues();
    }
}