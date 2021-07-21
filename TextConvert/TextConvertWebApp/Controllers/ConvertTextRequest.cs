namespace TextConvertWebApp.Controllers
{
    public class ConvertTextRequest
    {
        public enum Language { English, Hebrew };
        public Language SourceLanguage { get; set; }
        public Language TargetLanguage { get; set; }
        public string StringToConvert { get; set; }
    }
}