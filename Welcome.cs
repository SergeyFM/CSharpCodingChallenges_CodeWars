using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Welcome {
    [TestMethod]
    public void Test() {
        /*
        Your start-up's BA has told marketing that your website has a large audience in Scandinavia and surrounding countries. 
        Marketing thinks it would be great to welcome visitors to the site in their own language. 
        Luckily you already use an API that detects the user's location, so this is an easy win.

        The Task
        Write a 'welcome' function that takes a parameter 'language', with a type String, and returns a greeting - if you have it in your database. 
        It should default to English if the language is not in the database, or in the event of an invalid input.
        */

        Assert.AreEqual("Welcome", Greet("english"));
        Assert.AreEqual("Welkom", Greet("dutch"));
        Assert.AreEqual("Welcome", Greet("IP_ADDRESS_INVALID"));
        Assert.AreEqual("Welcome", Greet(""));
        Assert.AreEqual("Welcome", Greet("2"));

        Assert.AreEqual("Welcome", Greet_v2("english"));
        Assert.AreEqual("Welkom", Greet_v2("dutch"));
        Assert.AreEqual("Welcome", Greet_v2("IP_ADDRESS_INVALID"));
        Assert.AreEqual("Welcome", Greet_v2(""));
        Assert.AreEqual("Welcome", Greet_v2("2"));
    }


    public static string Greet(string language) =>
        langs.TryGetValue(language, out var result) ? result : langs.First().Value;

    private static readonly Dictionary<string, string> langs = new() {
          {"english", "Welcome"}
        , {"czech", "Vitejte"}
        , {"danish", "Velkomst"}
        , {"dutch", "Welkom"}
        , {"estonian", "Tere tulemast"}
        , {"finnish", "Tervetuloa"}
        , {"flemish", "Welgekomen"}
        , {"french", "Bienvenue"}
        , {"german", "Willkommen"}
        , {"irish", "Failte"}
        , {"italian", "Benvenuto"}
        , {"latvian", "Gaidits"}
        , {"lithuanian", "Laukiamas"}
        , {"polish", "Witamy"}
        , {"spanish", "Bienvenido"}
        , {"swedish", "Valkommen"}
        , {"welsh", "Croeso"}
    };


    public static string Greet_v2(string language) =>
        language switch {
            "czech" => "Vitejte",
            "danish" => "Velkomst",
            "dutch" => "Welkom",
            "estonian" => "Tere tulemast",
            "finnish" => "Tervetuloa",
            "flemish" => "Welgekomen",
            "french" => "Bienvenue",
            "german" => "Willkommen",
            "irish" => "Failte",
            "italian" => "Benvenuto",
            "latvian" => "Gaidits",
            "lithuanian" => "Laukiamas",
            "polish" => "Witamy",
            "spanish" => "Bienvenido",
            "swedish" => "Valkommen",
            "welsh" => "Croeso",
            _ => "Welcome"
        };


}
