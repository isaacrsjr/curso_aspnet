using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace curso_aspnet.Models
{
    public class Turma
    {
        public Turma()
        {
            Alunos = new List<Usuario>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int QuantidadeVagas { get; set; }

        [Required]
        public string ModalidadeEsportiva { get; set; }
        public List<Usuario> Alunos { get; private set; }
    }
}