using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Faqs.ImportFaqsDTOs;
public class ImportFaqsFile
{
    public IFormFile Arquivo { get; set; }
}