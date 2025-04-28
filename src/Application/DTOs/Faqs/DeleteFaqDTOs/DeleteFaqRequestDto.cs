namespace Application.DTOs.Faqs.DeleteFaqDTOs;
public class DeleteFaqRequestDto
{
    public DeleteFaqRequestDto(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}