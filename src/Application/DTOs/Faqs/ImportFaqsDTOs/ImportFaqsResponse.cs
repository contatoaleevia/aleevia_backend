namespace Application.DTOs.Faqs.ImportFaqsDTOs
{
    public class ImportResult
    {
        public List<ImportFaqsRequest> Sucesso { get; set; } = new();
        public List<ImportError> Erros { get; set; } = new();
    }

    public class ImportError
    {
        public ImportFaqsRequest Item { get; set; }
        public string ErrorMessage { get; set; }
    }
}