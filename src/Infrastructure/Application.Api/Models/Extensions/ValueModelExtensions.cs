namespace Application.Api.Controllers
{
    using Application.Api.Models;
    using Application.Domain;

    public static class ValueModelExtensions
    {
        public static ValueOutputModel ToModel(this ValueDto dto) => new ValueOutputModel
        {
            Name = dto.Name,
            Value = dto.Value
        };
    }
}