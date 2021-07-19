using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace TextConvertWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertTextApiController : ControllerBase
    {
        private readonly ILogger<ConvertTextApiController> _logger;

        public ConvertTextApiController(ILogger<ConvertTextApiController> logger)
        {
            _logger = logger;
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<string>> ConvertText(ConvertTextRequest convertTextRequest)
        {
            var sourceLanguage = convertTextRequest.SourceLanguage;
            var targetLanguage = convertTextRequest.TargetLanguage;
            var stringToConvert = convertTextRequest.StringToConvert;

            _logger.LogInformation($"Converting '{stringToConvert}' from {sourceLanguage} to {targetLanguage}");

            switch (sourceLanguage)
            {
                case ConvertTextRequest.Language.English:
                    switch (targetLanguage)
                    {
                        case ConvertTextRequest.Language.Hebrew:
                            return TextConvert.Hebrew.ConvertEnglishToHebrew(convertTextRequest.StringToConvert);
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
    }
}
