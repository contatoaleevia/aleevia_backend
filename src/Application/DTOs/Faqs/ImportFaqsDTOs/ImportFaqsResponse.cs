using JetBrains.Annotations;

namespace Application.DTOs.Faqs.ImportFaqsDTOs;

public class ImportResult
{
    public List<ImportFaqsRequest> Sucesso { get; set; } = [];
    public List<ImportError> Erros { get; set; } = [];
}

public class ImportError(ImportFaqsRequest item, string errorMessage)
{
    [UsedImplicitly] public ImportFaqsRequest Item { get; set; } = item;
    [UsedImplicitly] public string ErrorMessage { get; set; } = errorMessage;
}