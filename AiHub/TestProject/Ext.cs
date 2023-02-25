using System.Text.Json;

namespace Test
{
    public static class Ext
    {
        public static bool IsJsonValid(this string txt)
        {
            try { return JsonDocument.Parse(txt) != null; } catch { }

            return false;
        }
    }
}
