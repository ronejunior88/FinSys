using MediatR;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IRequest
    {
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "O campo Mensagem é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo Mensagem deve ter no máximo 150 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo inativo é obrigatório.")]
        public bool Inative { get; set; }

        [Required(ErrorMessage = "O campo Mensagem é obrigatório.")]
        public DateTime DateExpiration { get; set; }

        [Required(ErrorMessage = "O campo Mensagem é obrigatório.")]
        public DateTime DateRelease { get; set; }

        public DateTime? DatePayment { get; set; }
    }
}