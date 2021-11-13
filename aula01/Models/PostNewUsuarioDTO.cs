using System;
using System.ComponentModel.DataAnnotations;

namespace curso_aspnet.Models
{
    public class PostNewUsuarioDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}