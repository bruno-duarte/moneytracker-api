namespace MoneyTracker.Application.DTOs.People
{
	public class PersonDto
	{
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateOnly BirthDate { get; set; }
	}
}