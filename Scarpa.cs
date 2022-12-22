using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scarpe
{
    public class Scarpa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string Copertina { get; set; }   
        public string Dettaglio1 { get; set; }
        public string Dettaglio2 { get; set; }
        public bool Visibile { get; set; }
    }
}