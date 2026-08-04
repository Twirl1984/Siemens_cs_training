using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (identifier == null) throw new ArgumentNullException(nameof(identifier));
        identifier = identifier.Replace(" ", "_");
        identifier = identifier.Replace("\0", "CTRL");
        identifier = KebabToCamelCase(identifier);
        identifier = RemoveNonLetters(identifier);

        return identifier;
    }

    private static string KebabToCamelCase(string text)
    {
        var sb = new StringBuilder();
        bool upperNext = false;

        foreach (char c in text)
        {
            if (c == '-')
            {
                upperNext = true;
                continue;
            }

            sb.Append(upperNext ? char.ToUpperInvariant(c) : c);
            upperNext = false;
        }

        return sb.ToString();
    }

    private static string RemoveNonLetters(string text)
    {
        var sb = new StringBuilder();

        foreach (char c in text)
        {
            bool isUnderscore = c == '_';
            bool isLetter = char.IsLetter(c);
            bool isGreekLower = c >= 'α' && c <= 'ω';
            if (isUnderscore || (isLetter && !isGreekLower))
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}

