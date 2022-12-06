using System;

namespace API_Imc.Models
{
    public class Imc
    {
        public Imc() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public Usuario usuario { get; set; }
        public int? usuarioId { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public double ResultadoImc { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
