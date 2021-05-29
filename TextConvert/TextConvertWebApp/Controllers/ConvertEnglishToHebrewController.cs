using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace TextConvertWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertEnglishToHebrewController : ControllerBase
    {
        private readonly ILogger<ConvertEnglishToHebrewController> _logger;

        public ConvertEnglishToHebrewController(ILogger<ConvertEnglishToHebrewController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{englishInputString}")]
        public string Get(string englishInputString)
        {
            return TextConvert.Hebrew.ConvertEnglishToHebrew(englishInputString);
        }
    }
}
