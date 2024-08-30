using EstoqueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueAPI.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR");

            builder.Property(p => p.Preco)
                .HasColumnName("preco")
                .HasColumnType("double precision")
                .IsRequired();

            builder.Property(p => p.QuantidadeEstoque)
                .HasColumnName("quantidadeEstoque")
                .HasColumnType("integer")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);            
        }
    }
}
