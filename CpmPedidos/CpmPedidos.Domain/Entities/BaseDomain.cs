using System;

namespace CpmPedidos.Domain
{
    //Abstract: apenas herdar, não pode instanciar a classe
    public abstract class BaseDomain
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}