namespace MoneyTracker.Application.DTOs.People
{
	public class PersonQueryDto : BaseQueryDto
	{
        public string? Name { get; set; }
        public DateOnly? BirthDate { get; set; }
	}
}