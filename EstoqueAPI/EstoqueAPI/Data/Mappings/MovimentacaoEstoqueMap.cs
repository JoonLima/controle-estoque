using EstoqueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueAPI.Data.Mappings
{
    public class MovimentacaoEstoqueMap : IEntityTypeConfiguration<MovimentacaoEstoque>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
        {
            builder.ToTable("movimentacao_estoque")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(e => e.DataMovimentacao)
                .HasColumnName("dataMovimentacao")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(e => e.TipoMovimentacao)
                .HasColumnName("tipoMovimentacao")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(e => e.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("VARCHAR");

            builder.HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.IdProduto);
        }
    }
}
