namespace AmazonClone.Application.Utils
{
    public class FileManager
    {
        public static async Task<string> SaveImageFromWebToPathAsync(string url, string wwwRootPath, string localDirectory)
        {
            using (var httpClient = new HttpClient())
            {
                // Download the image as a byte array
                var imgBytes = await httpClient.GetByteArrayAsync(url);

                // Convert the byte array to an image object
                using (var memoryStream = new MemoryStream(imgBytes))
                {
                    using (var image = System.Drawing.Image.FromStream(memoryStream))
                    {
                        string fileName = Guid.NewGuid().ToString() + ".png";
                        string profilePicturesPath = Path.Combine(wwwRootPath, localDirectory);

                        // Ensure the directory exists
                        if (!Directory.Exists(profilePicturesPath))
                        {
                            Directory.CreateDirectory(profilePicturesPath);
                        }

                        string filePath = Path.Combine(profilePicturesPath, fileName);

                        // Save the image as a PNG file
                        image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                        return @$"\{localDirectory}\{fileName}";
                    }
                }
            }
        }
    }
}
