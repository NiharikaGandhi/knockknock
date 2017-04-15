using System.Configuration;

namespace ReferenceAPI.Setting
{
    public interface ITokenSettings
    {
        string Token { get;  }
    }

    public class TokenSettings : ITokenSettings
    {
        public string Token => ConfigurationManager.AppSettings["Token"];
    }
}