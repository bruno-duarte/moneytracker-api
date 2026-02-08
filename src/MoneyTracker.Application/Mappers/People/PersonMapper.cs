using MoneyTracker.Application.DTOs.People;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Mappers.People
{
	public static class PersonMapper
	{
        public static PersonDto ToDto(this Person p)
        {
            return new PersonDto
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate,
            };
        }
	}
}