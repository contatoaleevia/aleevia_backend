namespace Application.DTOs.Adresses.CreateAdressDTOs;
public class CreateAddressResponseDto
{
    public Guid Id { get; set; }
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;

    public CreateAddressResponseDto()
    {
    }

    public CreateAddressResponseDto(Guid id, string street, string number)
    {
        Id = id;
        Street = street;
        Number = number;
    }
}