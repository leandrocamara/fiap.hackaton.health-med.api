using System.Security.Cryptography;
using System.Text;

namespace Entities.SeedWork.Extensions;

public static class StringExtensions
{
    public static string ToMd5(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);
        var stringBuilder = new StringBuilder();

        foreach (var hashByte in hashBytes)
            stringBuilder.Append(hashByte.ToString("X2"));

        return stringBuilder.ToString();
    }
}