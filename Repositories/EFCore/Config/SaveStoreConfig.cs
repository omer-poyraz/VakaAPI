using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class SaveStoreConfig : IEntityTypeConfiguration<SaveStore>
    {
        public void Configure(EntityTypeBuilder<SaveStore> builder)
        {

        }
    }
}
