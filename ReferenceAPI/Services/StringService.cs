using System;
using System.Linq;

namespace ReferenceAPI.Services
{
    public interface IStringService
    {
        string ReverseWords(string sentence);
    }

    public class StringService : IStringService
    {
        public string ReverseWords(string sentence)
        {
            var words = sentence.Split(' ');
            var reversedWords = words.Select(ReverseWord).ToList();
            return string.Join(" ", reversedWords);
        }

        private static string ReverseWord(string word)
        {
            var charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}