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

            file.Name = File.FileName;
            file.NumberLines = File.Headers.Count();

            using (var reader = new StreamReader(File.OpenReadStream(), Encoding.UTF8))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    file.Expendings.Add(ConverterLinhaParaObjeto(linha));
                }                              
            }

            file.DateUpload = DateTime.UtcNow;

            return file;
        }

        static Expending ConverterLinhaParaObjeto(string linha)
        {
            string[] colunas = linha.Split(',');
            return new Expending
            {
                Value = double.Parse(colunas[0]),
                Description = colunas[1],
                Inative = bool.Parse(colunas[2]),
                DateExpiration = DateTime.Parse(colunas[3]),
                DateRelease = DateTime.Parse(colunas[4]),
                DatePayment = DateTime.Parse(colunas[5]),
            };
        }
    }
}
