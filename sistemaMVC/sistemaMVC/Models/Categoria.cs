using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaMVC.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preenchimento obrigatório!")]
        public string Descricao { get; set; }
        //public List<Produto> Produtos { get; set; }
    }
}
