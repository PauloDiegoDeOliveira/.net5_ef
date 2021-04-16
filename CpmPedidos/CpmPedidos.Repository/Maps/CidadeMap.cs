using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class CidadeMap : BaseDomainMap<Cidade>
    {
        public CidadeMap() : base("tb_cidade") { }

        //override, sobrepor da BaseDomainMap
        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            //Chama herança
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Uf).HasColumnName("uf").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}