using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.WebAPI.Models;

namespace Project.WebAPI.Configurations
{
    internal class CodeConfiguration : IEntityTypeConfiguration<Code>
    {
        public void Configure(EntityTypeBuilder<Code> builder)
        {
            // id kolonlarını isimlendirmesini ef core ile uyumlu yaptığımız takdirde configür'de belirtmemize gerek yoktur, ef core kendi otomatik bu ayarlar ile configür'de edebilir.
           builder.HasKey(c => c.Id);
           builder.Property(c => c.Id).UseIdentityColumn();

            // özellikle dbye aktarmak istediğimiz configür ayarları varsa tek tek belirtmemiz gerekir.
            builder.Property(c => c.Name).IsRequired();

            
        }
    }
}
