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

            var stream = File.OpenReadStream();
            var reader = new StreamReader(stream);
            //var header = reader.ReadLine();

            string itens;
            while((itens = reader.ReadLine()) != null)
            {
                var item = itens.Split(';');

                var expending = new Expending
                {
                    Value = double.Parse(item[0]),
                    Description = item[1],
                    Inative = bool.Parse(item[2]),
                    DateExpiration = DateTime.Parse(item[3]),
                    DateRelease = DateTime.Parse(item[4]),
                    DatePayment = DateTime.Parse(item[5]),
                };

                file.Expendings.Add(expending);
            }

            file.NumberLines = file.Expendings.Count();
            file.DateUpload = DateTime.UtcNow;

            return file;
        }
    }
}
