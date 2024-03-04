using FinSys.Command.Domain;
using FinSys.Command.UploadExpendingCommand;
using System.Text;

namespace FinSys.Uploads
{
    public class UploadExpending
    {
        public UploadExpending(IFormFile file)
        {
            this.File = file;
        }

        public IFormFile File { get; set; }

        public UploadExpendingCommand GetFileAsync()
        {
            UploadExpendingCommand file = new UploadExpendingCommand();

            file.Name = File.FileName;
            file.NumberLines = File.Headers.Count();

            using (var stream = File.OpenReadStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string linha = reader.ReadLine();
                    file.Expendings.Add(ConvertLineForObject(linha));
                }

            }

            file.DateUpload = DateTime.UtcNow;

            return file;
        }

        public static Expending ConvertLineForObject(string lines)
        {
            string[] colunm = lines.Split(';');
            return new Expending
            {
                Value = double.Parse(colunm[0]),
                Description = colunm[1],
                Inative = bool.Parse(colunm[2]),
                DateExpiration = DateTime.Parse(colunm[3]),
                DateRelease = DateTime.Parse(colunm[4]),
                DatePayment = DateTime.Parse(colunm[5]),
            };
        }
    }
}
