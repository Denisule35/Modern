using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern.Model
{
    public class Oameni
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly Abonament { get; set; }

        public string? Nivel {  get; set; }

        public string? PuncteTari { get; set; }

        public string? PuncteSlabe {  get; set; }

        public bool? ArePoza {  get; set; }

    }
}
