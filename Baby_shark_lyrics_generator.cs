using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CodingChallenges;
[TestClass]
public class Baby_shark_lyrics_generator {

    /*
        Baby shark lyrics generator

        Create a function, as short as possible, that returns this lyrics.
        Your code should be less than 300 characters. Watch out for the three points at the end of the song.

        Baby shark, doo doo doo doo doo doo
        Baby shark, doo doo doo doo doo doo
        Baby shark, doo doo doo doo doo doo
        Baby shark!
        Mommy shark, doo doo doo doo doo doo
        Mommy shark, doo doo doo doo doo doo
        Mommy shark, doo doo doo doo doo doo
        Mommy shark!
        Daddy shark, doo doo doo doo doo doo
        Daddy shark, doo doo doo doo doo doo
        Daddy shark, doo doo doo doo doo doo
        Daddy shark!
        Grandma shark, doo doo doo doo doo doo
        Grandma shark, doo doo doo doo doo doo
        Grandma shark, doo doo doo doo doo doo
        Grandma shark!
        Grandpa shark, doo doo doo doo doo doo
        Grandpa shark, doo doo doo doo doo doo
        Grandpa shark, doo doo doo doo doo doo
        Grandpa shark!
        Let's go hunt, doo doo doo doo doo doo
        Let's go hunt, doo doo doo doo doo doo
        Let's go hunt, doo doo doo doo doo doo
        Let's go hunt!
        Run away,…
        Good Luck!

     */

    [TestMethod]
    public void Test() {

        string song = string.Join("\n", new string[] {
                        "Baby shark, doo doo doo doo doo doo",
                        "Baby shark, doo doo doo doo doo doo",
                        "Baby shark, doo doo doo doo doo doo",
                        "Baby shark!",
                        "Mommy shark, doo doo doo doo doo doo",
                        "Mommy shark, doo doo doo doo doo doo",
                        "Mommy shark, doo doo doo doo doo doo",
                        "Mommy shark!",
                        "Daddy shark, doo doo doo doo doo doo",
                        "Daddy shark, doo doo doo doo doo doo",
                        "Daddy shark, doo doo doo doo doo doo",
                        "Daddy shark!",
                        "Grandma shark, doo doo doo doo doo doo",
                        "Grandma shark, doo doo doo doo doo doo",
                        "Grandma shark, doo doo doo doo doo doo",
                        "Grandma shark!",
                        "Grandpa shark, doo doo doo doo doo doo",
                        "Grandpa shark, doo doo doo doo doo doo",
                        "Grandpa shark, doo doo doo doo doo doo",
                        "Grandpa shark!",
                        "Let's go hunt, doo doo doo doo doo doo",
                        "Let's go hunt, doo doo doo doo doo doo",
                        "Let's go hunt, doo doo doo doo doo doo",
                        "Let's go hunt!",
                        "Run away,…",
                        ""
                      });

        Assert.AreEqual(song, BabySharkLyrics());

    }

    /*
    This is the 299 characters long solution:

using System.Linq;
public static class Kata {
public static string BabySharkLyrics()=>string.Join("","Baby shark|Mommy shark|Daddy shark|Grandma shark|Grandpa shark|Let's go hunt".Split('|').Select(n=>string.Concat(Enumerable.Repeat($"{n}, doo doo doo doo doo doo\n",3))+$"{n}!\n"))+"Run away,…\n";}
    
    */

    public static string BabySharkLyrics() =>
        string.Join("",
            "Baby shark|Mommy shark|Daddy shark|Grandma shark|Grandpa shark|Let's go hunt".Split('|')
            .Select(n => string.Concat(Enumerable.Repeat($"{n}, doo doo doo doo doo doo\n", 3)) + $"{n}!\n")
            ) + "Run away,…\n";

    // --------------------------------------------------------------------------
    public static string BabySharkLyrics_TooLong() => string.Join("", "BSO/BSO/BSO/BS!/MSO/MSO/MSO/MS!/DSO/DSO/DSO/DS!/GSO/GSO/GSO/GS!/PSO/PSO/PSO/PS!/LO/LO/LO/L!/R/".Select(c => new System.Collections.Generic.Dictionary<char, string>() { { '/', "\n" }, { '!', "!" }, { 'O', ", doo doo doo doo doo doo" }, { 'S', " shark" }, { 'B', "Baby" }, { 'M', "Mommy" }, { 'D', "Daddy" }, { 'G', "Grandma" }, { 'P', "Grandpa" }, { 'L', "Let's go hunt" }, { 'R', "Run away,…" }, }[c]));

    public static string BabySharkLyrics_aBitShorter() => string.Join("\n", "Baby|Mommy|Daddy|Grandma|Grandpa".Split('|').SelectMany(x => Enumerable.Repeat($"{x} shark, doo doo doo doo doo doo", 3).Append($"{x} shark!")).Concat(Enumerable.Repeat("Let's go hunt, doo doo doo doo doo doo", 3).Append("Let's go hunt!")).Append("Run away,…\n"));

    public static string BabySharkLyrics_AlsoTooLong() => new Func<string, string, string>((d, l) =>
    string.Join("\n", "Baby|Mommy|Daddy|Grandma|Grandpa".Split('|')
    .SelectMany(x => Enumerable.Repeat($"{x} shark{d}", 3)
    .Append($"{x} shark!"))
    .Concat(Enumerable.Repeat($"{l}{d}", 3)))
    + $"\n{l}!\nRun away,…\n")
    (", doo doo doo doo doo doo", "Let's go hunt");

    public static string CompressString(string text) {
        byte[] buffer = Encoding.UTF8.GetBytes(text);
        using MemoryStream memoryStream = new();
        memoryStream.Write(BitConverter.GetBytes(buffer.Length), 0, 4);
        using (DeflateStream deflateStream = new(memoryStream, CompressionLevel.Optimal)) {
            deflateStream.Write(buffer, 0, buffer.Length);
        }
        return Convert.ToBase64String(memoryStream.ToArray());
    }
    public static string DecompressString(string compressedText) {
        byte[] deflateBuffer = Convert.FromBase64String(compressedText);
        using MemoryStream memoryStream = new(deflateBuffer, 4, deflateBuffer.Length - 4);
        using DeflateStream deflateStream = new(memoryStream, CompressionMode.Decompress);
        using MemoryStream outputStream = new();
        deflateStream.CopyTo(outputStream);
        return Encoding.UTF8.GetString(outputStream.ToArray());
    }

    public static string BabySharkLyrics_ZIP_also_too_long() {
        using MemoryStream ms = new(Convert.FromBase64String("CQMAAHNKTKpUKM5ILMrWUUjJz8eGuZyorkaRyzc/N5egBpooUuRySUxJIaiDJooUudyLEvNSchMJ6aGhMqgbCojTRRtlilw+qSXqxQrp+QoZpXkluHXRUJkiV1BpnkJieWKlzqOGZVwA"), 4, 100);
        using DeflateStream ds = new(ms, CompressionMode.Decompress);
        using MemoryStream os = new();
        ds.CopyTo(os);
        return Encoding.UTF8.GetString(os.ToArray());
    }

}
