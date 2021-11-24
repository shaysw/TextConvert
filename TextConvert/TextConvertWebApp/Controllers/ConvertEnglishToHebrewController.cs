using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        private HttpClient _httpClient;
        private Dictionary<Language, EnglishQweryConvertibleKeyboardLayout> _convertibleKeyboardLayouts = new()
        {
            { Language.Hebrew, new Hebrew() }
        };
        

        public ConvertTextApiController(ILogger<ConvertTextApiController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<ActionResult<string>> ConvertTextAsync(ConvertTextRequest convertTextRequest)
        {
            var sourceLanguage = convertTextRequest.SourceLanguage;
            var targetLanguage = convertTextRequest.TargetLanguage;
            var stringToConvert = convertTextRequest.StringToConvert;
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
            string convertedString;

            // TODO: not sure this is the best approach, for example, eng to eng but hebrew input string (remains hebrew)
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

            var message = $"[{remoteIpAddress}] : {stringToConvert}({sourceLanguage}) -> {convertedString}({targetLanguage})";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, EventServerLogMessage.eventServerUrl);
            request.Content = new StringContent(new EventServerLogMessage(message).ToString(),
                                                Encoding.UTF8,
                                                "application/json");

            await _httpClient.SendAsync(request);
            _logger.LogInformation(message);
            return convertedString;
        }

    }
}
