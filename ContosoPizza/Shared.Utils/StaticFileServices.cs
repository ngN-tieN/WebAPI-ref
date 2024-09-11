namespace ContosoPizza.Shared.Utils
{
    public static class StaticFileServices
    {
        public static string RandomizeFileName(string extension)
        {
            return string.Format("{0}{1}", Path.GetRandomFileName().Replace(".", string.Empty), Path.GetExtension(extension));
        }
    }
}
