using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Faqs.ImportFaqsDTOs;

public record ImportFaqsFile(IFormFile Archive);
