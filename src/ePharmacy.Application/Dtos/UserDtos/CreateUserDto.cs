using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Dtos.UserDtos;
public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
