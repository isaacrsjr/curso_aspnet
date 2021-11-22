using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace curso_aspnet.Models
{
    public class PostNewTurmaDTO
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public int QuantidadeVagas { get; set; }

        [Required]
        public string ModalidadeEsportiva { get; set; }
    }
}