namespace Shared.Utils
{
    public class GetEnvVar
    {
        private static void Load(string path)
        {
            if (!File.Exists(path))
                return;
            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);
                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
        private static string GetEnvFile()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), ".env"); 
        }
        /// <summary>
        /// Input the environment key as argument
        /// </summary>
        /// <param name="key"></param>
        /// <returns>String type of environment string</returns>
        public static string GetEnvString(string key)
        {
            
            Load(GetEnvFile());
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
