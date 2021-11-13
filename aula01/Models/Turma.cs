using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public void AdicionarAluno(Usuario aluno)
        {
            if (!Alunos.Any(u => u.Id == aluno.Id))
                Alunos.Add(aluno);
        }
    }
}