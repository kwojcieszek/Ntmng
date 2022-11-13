using Newtonsoft.Json;

namespace Ntmng.Web.Common;

public static class TranslationJson
{
    public static Translation? GetTranslation(string path)
    {
        var json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<Translation>(json);
    }

    public static void FlushTranslation(Translation translation,string path)
    {
        var json = JsonConvert.SerializeObject(translation);

        File.WriteAllText(path, json);
    }
}