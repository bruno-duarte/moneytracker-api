namespace MoneyTracker.Application.DTOs.People
{
	public class PersonPatchDto
	{
        public string? Name { get; set; }
        public DateOnly? BirthDate { get; set; }
	}
}