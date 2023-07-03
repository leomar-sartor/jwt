using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DemoNet5.AuthHelpers
{
    public static class SymetricSecurit
    {
        public static SymmetricSecurityKey GetKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretNotThatSmartChangeThis"));
        }
    }
}
