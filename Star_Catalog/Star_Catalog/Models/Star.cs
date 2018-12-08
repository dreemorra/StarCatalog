using System.Collections.Generic;
using Xamarin.Forms;

namespace Star_Catalog.Models
{
    public static class ToGreekExtension
    {
        public static string ToGreek(this string str)
        {
            var lower = str.ToLower();
            var dict = new Dictionary<string, string>
            {
                { "alp" , "α" },
                { "bet" , "β" },
                { "gam" , "γ" },
                { "del" , "δ" },
                { "eps" , "ε" },
                { "zet" , "ζ" },
                { "eta" , "η" },
                { "the" , "θ" },
                { "iot" , "ι" },
                { "kap" , "κ" },
                { "lam" , "λ" },
                { "mu" , "μ" },
                { "nu" , "ν" },
                { "xi" , "ξ" },
                { "omi" , "ο" },
                { "pi" , "π" },
                { "rho" , "ρ" },
                { "sig" , "σ" },
                { "tau" , "τ" },
                { "ups" , "υ" },
                { "phi" , "φ" },
                { "chi" , "χ" },
                { "psi" , "ψ" },
                { "ome" , "ω" }
            };
            var len = lower.Split('-')[0].Length;
            System.Diagnostics.Debug.WriteLine($"{lower} {lower.Substring(0, len)}");
            return dict.ContainsKey(lower.Substring(0, len)) ? (dict[lower.Substring(0, len)]+lower.Substring(len)) : lower;
        }
    }

    public static class ToColorExtension
    {
        public static Color blackBodyColor(this double temp)
        {
            float x = (float)(temp / 1000.0);
            float x2 = x * x;
            float x3 = x2 * x;
            float x4 = x3 * x;
            float x5 = x4 * x;

            float R, G, B = 0f;

            // red
            if (temp <= 6600)
                R = 1f;
            else
                R = 0.0002889f * x5 - 0.01258f * x4 + 0.2148f * x3 - 1.776f * x2 + 6.907f * x - 8.723f;

            // green
            if (temp <= 6600)
                G = -4.593e-05f * x5 + 0.001424f * x4 - 0.01489f * x3 + 0.0498f * x2 + 0.1669f * x - 0.1653f;
            else
                G = -1.308e-07f * x5 + 1.745e-05f * x4 - 0.0009116f * x3 + 0.02348f * x2 - 0.3048f * x + 2.159f;

            // blue
            if (temp <= 2000f)
                B = 0f;
            else if (temp < 6600f)
                B = 1.764e-05f * x5 + 0.0003575f * x4 - 0.01554f * x3 + 0.1549f * x2 - 0.3682f * x + 0.2386f;
            else
                B = 1f;

            return Color.FromRgba(R, G, B, 1f);
        }
    }

    public class Star
    {
        public string Name
        {
            get
            {
                if (proper != null)
                    return proper;
                if (bayer != null && con != null)
                    return $"{bayer.ToGreek()} {con}";
                return $"HIP{hip}";
            }
        }

        public double Temperature
        {
            get
            {
                var t = 4600 * ((1 / ((0.92 * ci) + 1.7)) + (1 / ((0.92 * ci) + 0.62)));
                return t == null ? 42000 : (double)t;
            }
        }
        public Color Color
        {
            get
            {
                return Temperature.blackBodyColor();
            }
        }

        public double? absmag { get; set; }
        public string @base { get; set; }
        public string bayer { get; set; }
        public string bf { get; set; }
        public double? ci { get; set; }
        public int? comp { get; set; }
        public int? comp_primary { get; set; }
        public string con { get; set; }
        public double? dec { get; set; }
        public double? decrad { get; set; }
        public double? dist { get; set; }
        public string flam { get; set; }
        public string gl { get; set; }
        public string hd { get; set; }
        public string hip { get; set; }
        public string hr { get; set; }
        public int id { get; set; }
        public double? lum { get; set; }
        public double? mag { get; set; }
        public double? pmdec { get; set; }
        public double? pmdecrad { get; set; }
        public double? pmra { get; set; }
        public double? pmrarad { get; set; }
        public string  proper { get; set; }
        public double? ra { get; set; }
        public double? rarad { get; set; }
        public double? rv { get; set; }
        public string spect { get; set; }
        public string var { get; set; }
        public string var_max { get; set; }
        public string var_min { get; set; }
        public double? vx { get; set; }
        public double? vy { get; set; }
        public double? vz { get; set; }
        public double? x { get; set; }
        public double? y { get; set; }
        public double? z { get; set; }
    }
}
