namespace ContosoPizza.Shared.Utils
{
    public interface IFileService
    {
        Task<bool> SaveFile(IFormFile file, string path, string fileName);
    }
    public class FileServices : IFileService
    {
        

        public async Task<bool> SaveFile(IFormFile file, string path, string fileName)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(path, fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return true;

            }
            return false;
            
        }
    }
}
