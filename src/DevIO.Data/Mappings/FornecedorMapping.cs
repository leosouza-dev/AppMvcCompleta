using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Documento).IsRequired().HasColumnType("varchar(14)");

            //relacionamento no Fluent Api
            builder.HasOne(p => p.Endereco).WithOne(e => e.Fornecedor).HasForeignKey<Endereco>(e => e.ForecedorId); // 1 : 1 = Forecedor : Endereço
            builder.HasMany(p => p.Produtos).WithOne(p => p.Fornecedor).HasForeignKey(p => p.FornecedorId);// 1 : n = Fornecedor : Produto

            builder.ToTable("Fornecedores");
        }
    }
}
