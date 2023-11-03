public class Helpers
{
    public static string GetLanguage(int id)
    {
        switch(id)
        {
            case 0:
                return "ENGLISH";
            case 1:
                return "ESPANOL";
            case 2:
                return "TÜRKÇE";
            default:
                return "English";
        }
    }
}