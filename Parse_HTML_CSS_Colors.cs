using System.Collections.Generic;

namespace CodingChallenges;
[TestClass]
public class Parse_HTML_CSS_Colors {

    /*

    Parse HTML/CSS Colors

    In this kata you parse RGB colors represented by strings. The formats are primarily used in HTML and CSS. Your task is to implement a function which takes a color as a string and returns the parsed color as a map (see Examples).

    Input:
    The input string represents one of the following:

    6-digit hexadecimal - "#RRGGBB"
    e.g. "#012345", "#789abc", "#FFA077"
    Each pair of digits represents a value of the channel in hexadecimal: 00 to FF

    3-digit hexadecimal - "#RGB"
    e.g. "#012", "#aaa", "#F5A"
    Each digit represents a value 0 to F which translates to 2-digit hexadecimal: 0->00, 1->11, 2->22, and so on.

    Preset color name
    e.g. "red", "BLUE", "LimeGreen"
    You have to use the predefined map PRESET_COLORS (JavaScript, Python, Ruby), presetColors (Java, C#, Haskell), or preset-colors (Clojure). The keys are the names of preset colors in lower-case and the values are the corresponding colors in 6-digit hexadecimal (same as 1. "#RRGGBB").

    Examples:
    Parse("#80FFA0")   === new RGB(128, 255, 160))
    Parse("#3B7")      === new RGB( 51, 187, 119))
    Parse("LimeGreen") === new RGB( 50, 205,  50))

    // RGB struct is defined as follows:
    struct RGB
    {
        public byte r, g, b;
        public RGB(byte r, byte g, byte b);
    }

    */

    [TestMethod]
    public void Test() {
        ShouldParse("#80FFA0", new RGB(128, 255, 160));
        ShouldParse("#3B7", new RGB(51, 187, 119));
        ShouldParse("lime", new RGB(0, 255, 0));
    }

    private void ShouldParse(string color, RGB expected) {
        Assert.AreEqual(expected, Parse(color), $"input: \"{color}\"");
    }

    // ----------------------------- PARSE METHOD --------------------------
    public RGB Parse(string color) {
        // if color is null or empty string return empty RGB struct
        if (string.IsNullOrEmpty(color)) return new RGB();

        // if presetColors contains the input color, get it
        if (presetColors.ContainsKey(color.ToLower())) 
            color = presetColors[color.ToLower()];

        // if input is a 3 digit hex color, convert it to 6 digit hex color
        if (color.Length == 4) 
            color = $"#{color[1]}{color[1]}{color[2]}{color[2]}{color[3]}{color[3]}";

        // if input is a hex color, return it in the form of a RGB struct
        return color.Length == 7 && color[0] == '#'
            ? new RGB(
                byte.Parse(color.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(color.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(color.Substring(5, 2), System.Globalization.NumberStyles.HexNumber) )
            : new RGB();
    }

    public struct RGB {
        public byte r, g, b;
        public RGB(byte r, byte g, byte b) => (this.r, this.g, this.b) = (r, g, b);
    }

    private readonly Dictionary<string, string> presetColors = new() {
        {"black", "#000000"},
        {"silver", "#C0C0C0"},
        {"gray", "#808080"},
        {"white", "#FFFFFF"},
        {"maroon", "#800000"},
        {"red", "#FF0000"},
        {"purple", "#800080"},
        {"fuchsia", "#FF00FF"},
        {"green", "#008000"},
        {"lime", "#00FF00"}
    };

}
