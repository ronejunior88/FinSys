using CsvHelper.Configuration;
using CsvHelper;
using FinSys.Command.Domain;
using FinSys.Command.UploadExpendingCommand;
using System.Globalization;
using System.Text;
using System.Reflection;

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
            var linhas = File.Headers.Count();

            file.Name = File.FileName;
            file.NumberLines = File.Headers.Count();

            using (var reader = new StreamReader(File.OpenReadStream(), Encoding.UTF8))
            {
                var conteudoArquivo = reader.ReadToEnd();

                while (linhas != 0)
                {
                    var leitura = conteudoArquivo.Split(',');

                    var expending = new Expending
                    {
                        Value = double.Parse(leitura[0]),
                        Description = leitura[1],
                        Inative = bool.Parse(leitura[2]),
                        DateExpiration = DateTime.Parse(leitura[3]),
                        DateRelease = DateTime.Parse(leitura[4]),
                        DatePayment = DateTime.Parse(leitura[5]),
                    };
                    linhas--;
                    file.Expendings.Add(expending);
                }

            }

            file.DateUpload = DateTime.UtcNow;

            return file;
        }
    }
}
