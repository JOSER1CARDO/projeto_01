using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto02.Models;

namespace Projeto02.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Nome da tabela (opcional, se quiser personalizar)
            builder.ToTable("Categorias");

            // Chave primária
            builder.HasKey(c => c.Id);

            // Propriedade Nome
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100); // você pode ajustar esse tamanho conforme a necessidade
        }
    }
}
