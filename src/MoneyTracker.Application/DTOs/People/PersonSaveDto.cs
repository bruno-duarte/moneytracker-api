namespace MoneyTracker.Application.DTOs.People
{
	public class PersonSaveDto
	{
        public required string Name { get; set; }
        public DateOnly BirthDate { get; set; }
	}
}