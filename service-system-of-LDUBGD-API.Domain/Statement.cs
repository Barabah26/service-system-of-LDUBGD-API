namespace service_system_of_LDUBGD_API.Domain;

public class Statement
{
    public int StatementId { get; set; }
    public required string FullName { get; set; }
    public required string YearBirthday { get; set; }
    public required string Group { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Faculty { get; set; }
    public required string TypeOfStatement { get; set; }
    public required string UserId { get; set; }
    public ApplicationUser? User { get; set; }

}
