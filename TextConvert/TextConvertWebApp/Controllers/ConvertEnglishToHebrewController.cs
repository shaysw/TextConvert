using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TextConvert;

using static TextConvertWebApp.Controllers.ConvertTextRequest;

namespace TextConvertWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertTextApiController : ControllerBase
    {
        private readonly ILogger<ConvertTextApiController> _logger;
        private Dictionary<Language, EnglishQweryConvertibleKeyboardLayout> _convertibleKeyboardLayouts = new()
        {
            { Language.Hebrew, new Hebrew() }
        };

        public ConvertTextApiController(ILogger<ConvertTextApiController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<string>> ConvertText(ConvertTextRequest convertTextRequest)
        {
            var sourceLanguage = convertTextRequest.SourceLanguage;
            var targetLanguage = convertTextRequest.TargetLanguage;
            var stringToConvert = convertTextRequest.StringToConvert;
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
            string convertedString;

            if (sourceLanguage == targetLanguage)
            {
                convertedString = stringToConvert;
            }
            else
            {
                // TODO: handle conversions between 2 languages which are not engllish
                if (sourceLanguage == Language.English)
                {
                    if (!_convertibleKeyboardLayouts.ContainsKey(targetLanguage))
                    {
                        throw new Exception($"Mapping for {targetLanguage} not found");
                    }
                    convertedString = _convertibleKeyboardLayouts[targetLanguage].ConvertEnglishQwertyStringToConvertibleKeyboardLayout(stringToConvert);
                }
                else
                // TODO: implicitly assuming target is english
                {
                    if (!_convertibleKeyboardLayouts.ContainsKey(sourceLanguage))
                    {
                        throw new Exception($"Mapping for {sourceLanguage} not found");
                    }
                    convertedString = _convertibleKeyboardLayouts[sourceLanguage].ConvertConvertibleKeyboardLayoutToEnglishQwertyString(stringToConvert);
                }
            }

            _logger.LogInformation($"[{remoteIpAddress}] : {stringToConvert}({sourceLanguage}) -> {convertedString}({targetLanguage})");
            return convertedString;
        }
    }
}
