using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace WebApplicationConfig
{
    public class ConfigOptionsModel
    {
        public string key1 { get; set; }
        public string key2 { get; set; }
        public string key3 { get; set; }
        [Range(1,500)]
        public int key4 { get; set; }
    }

    public class ConfigOptionsVaildateOptions : IValidateOptions<ConfigOptionsModel>
    {
        public ValidateOptionsResult Validate(string name, ConfigOptionsModel options)
        {
            if (options.key4 > 300) 
            {
                throw new ValidationException("key4 不能大于300");
            }
            return ValidateOptionsResult.Success;
        }
    }
}
