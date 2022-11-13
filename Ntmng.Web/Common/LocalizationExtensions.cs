namespace Ntmng.Web.Common;

public static class LocalizationExtensions
{
    public static IApplicationBuilder UseLocalizations(this IApplicationBuilder app)
    {
        var languages = new List<Languages>();

        var english = new Languages()
        {
            Code = "en-EN",
            Name = "English",
            Translation = new Translation()
        };

        var polish = new Languages()
        {
            Code = "pl-PL",
            Name = "Polski",
            Translation = TranslationJson.GetTranslation("polish.json")!
        };

        TranslationJson.GetTranslation("polish.json");
        TranslationJson.FlushTranslation(polish.Translation, "polish.json");

        languages.Add(english);
        languages.Add(polish);

        _ = new Localization(languages, polish.Code);

        return app;
    }
}