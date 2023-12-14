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
            file.Name = File.Name;
            file.NumberLines = File.Length;

            using (var reader = new StreamReader(File.OpenReadStream(), Encoding.UTF8))
            {
                var conteudoArquivo =  reader.ReadToEnd();


                foreach (var item in conteudoArquivo)
                {
                    var valores = conteudoArquivo.Split(',');

                    if (valores.Length == 7)
                    {
                        var expending = new Expending
                        {
                            Value = double.Parse(valores[0]),
                            Description = valores[1],
                            Inative = bool.Parse(valores[2]),
                            DateExpiration = DateTime.Parse(valores[3]),
                            DateRelease = DateTime.Parse(valores[4]),
                            DatePayment = DateTime.Parse(valores[5]),
                        };
                        file.Expendings.Add(expending);
                    }
                }
            }           

            file.DateUpload = DateTime.UtcNow;

            return file;
        }
    }
}
