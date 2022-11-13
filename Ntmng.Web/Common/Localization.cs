namespace Ntmng.Web.Common;

public class Localization
{
    private static List<Languages> _languages;
    private static string _defaultLanguage;

    public Localization(List<Languages> languages, string defaultLanguage)
    {
        _languages = languages;
        _defaultLanguage = defaultLanguage;
    }

    public static Translation GetTranslation(string? code = null)
    {
        var language = _languages.FirstOrDefault(x => x.Code == code);

        if (language == null)
            language = _languages.FirstOrDefault(x => x.Code == _defaultLanguage);

        if (null == language)
            throw new Exception("Language null excpetion.");

        return language.Translation;
    }
}