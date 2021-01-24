using ComputeService.v1.Services.Hash;
using ComputeService.v1.Services.Random;

namespace UrlShortener.Shared
{
    public static class Utilities
    {
        public static string GenerateRandomPath(int pathLength, string chars)
        {
            var randomStringGenerator = new RandomStringGenerator(pathLength, chars);
            return randomStringGenerator.Generate();
        }

        public static string HashIpAddress(string ipAddress, string applicationPepper, int iterations)
        {
            var data = ComputeService.v1.Shared.Utilities.ApplyPepper(ipAddress, applicationPepper);
            var sha512Service = new Sha512Service();

            return sha512Service.Hash(data, iterations);
        }
    }
}