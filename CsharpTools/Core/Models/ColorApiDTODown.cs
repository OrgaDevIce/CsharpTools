using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Hex
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("clean")]
        public string Clean { get; set; }
    }

    public class Fraction
    {
        [JsonProperty("r")]
        public double R { get; set; }

        [JsonProperty("g")]
        public double G { get; set; }

        [JsonProperty("b")]
        public double B { get; set; }

        [JsonProperty("h")]
        public int H { get; set; }

        [JsonProperty("s")]
        public double S { get; set; }

        [JsonProperty("l")]
        public double L { get; set; }

        [JsonProperty("v")]
        public double V { get; set; }

        [JsonProperty("c")]
        public int? C { get; set; }

        [JsonProperty("m")]
        public double? M { get; set; }

        [JsonProperty("y")]
        public double? Y { get; set; }

        [JsonProperty("k")]
        public double K { get; set; }

        [JsonProperty("X")]
        public double X { get; set; }

        [JsonProperty("Z")]
        public double Z { get; set; }
    }

    public class Rgb
    {
        [JsonProperty("fraction")]
        public Fraction Fraction { get; set; }

        [JsonProperty("r")]
        public int R { get; set; }

        [JsonProperty("g")]
        public int G { get; set; }

        [JsonProperty("b")]
        public int B { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Hsl
    {
        [JsonProperty("fraction")]
        public Fraction Fraction { get; set; }

        [JsonProperty("h")]
        public int H { get; set; }

        [JsonProperty("s")]
        public int S { get; set; }

        [JsonProperty("l")]
        public int L { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Hsv
    {
        [JsonProperty("fraction")]
        public Fraction Fraction { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("h")]
        public int H { get; set; }

        [JsonProperty("s")]
        public int S { get; set; }

        [JsonProperty("v")]
        public int V { get; set; }
    }

    public class Name
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("closest_named_hex")]
        public string ClosestNamedHex { get; set; }

        [JsonProperty("exact_match_name")]
        public bool ExactMatchName { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }
    }

    public class Cmyk
    {
        [JsonProperty("fraction")]
        public Fraction Fraction { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("c")]
        public int? C { get; set; }

        [JsonProperty("m")]
        public int? M { get; set; }

        [JsonProperty("y")]
        public int? Y { get; set; }

        [JsonProperty("k")]
        public int K { get; set; }
    }

    public class XYZ
    {
        [JsonProperty("fraction")]
        public Fraction Fraction { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("X")]
        public int X { get; set; }

        [JsonProperty("Y")]
        public int Y { get; set; }

        [JsonProperty("Z")]
        public int Z { get; set; }
    }

    public class Image
    {
        [JsonProperty("bare")]
        public string Bare { get; set; }

        [JsonProperty("named")]
        public string Named { get; set; }
    }

    public class Contrast
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Links
    {

        [JsonProperty("schemes")]
        public Schemes Schemes { get; set; }
    }

    public class Embedded
    {
    }

    public class Color
    {
        [JsonProperty("hex")]
        public Hex Hex { get; set; }

        [JsonProperty("rgb")]
        public Rgb Rgb { get; set; }

        [JsonProperty("hsl")]
        public Hsl Hsl { get; set; }

        [JsonProperty("hsv")]
        public Hsv Hsv { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("cmyk")]
        public Cmyk Cmyk { get; set; }

        [JsonProperty("XYZ")]
        public XYZ XYZ { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("contrast")]
        public Contrast Contrast { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }

    public class Seed
    {
        [JsonProperty("hex")]
        public Hex Hex { get; set; }

        [JsonProperty("rgb")]
        public Rgb Rgb { get; set; }

        [JsonProperty("hsl")]
        public Hsl Hsl { get; set; }

        [JsonProperty("hsv")]
        public Hsv Hsv { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("cmyk")]
        public Cmyk Cmyk { get; set; }

        [JsonProperty("XYZ")]
        public XYZ XYZ { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("contrast")]
        public Contrast Contrast { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }

    public class Schemes
    {
        [JsonProperty("monochrome")]
        public string Monochrome { get; set; }

        [JsonProperty("monochrome-dark")]
        public string MonochromeDark { get; set; }

        [JsonProperty("monochrome-light")]
        public string MonochromeLight { get; set; }

        [JsonProperty("analogic")]
        public string Analogic { get; set; }

        [JsonProperty("complement")]
        public string Complement { get; set; }

        [JsonProperty("analogic-complement")]
        public string AnalogicComplement { get; set; }

        [JsonProperty("triad")]
        public string Triad { get; set; }

        [JsonProperty("quad")]
        public string Quad { get; set; }
    }

    public class Root
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("colors")]
        public List<Color> Colors { get; set; }

        [JsonProperty("seed")]
        public Seed Seed { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }


}
