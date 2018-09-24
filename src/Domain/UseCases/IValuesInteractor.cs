
namespace Application.Domain
{
    using System.Collections.Generic;

    public interface IValuesInteractor
    {
        IEnumerable<ValueDto> Get();
    }
}
