using LanguageExt;
using Microsoft.AspNetCore.Components.Forms;

namespace AppealManager.Presentation.Services
{
    public class TextFileReader
    {
        private readonly string fileType = "text/plain";
        private readonly long allowedSize = 512 * 1024;

        /// <summary>
        /// Читает файл
        /// </summary>
        /// <param name="file">Файл</param>
        /// <returns>
        /// Возвращает Some(text), если тип файла text/plain,
        /// иначе None
        /// </returns>
        public async Task<Option<string>> ReadFileAsync(IBrowserFile file)
        {
            if (file.ContentType != fileType
                || file.Size > allowedSize)
                return Option<string>.None;

            using (var content = new StreamContent(file.OpenReadStream()))
            {
                var bytes = await content.ReadAsByteArrayAsync();
                var text = System.Text.Encoding.UTF8.GetString(bytes);

                return text;
            }
        }
    }
}
