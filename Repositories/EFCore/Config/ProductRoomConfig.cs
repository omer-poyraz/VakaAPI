using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class ProductRoomConfig : IEntityTypeConfiguration<ProductRoom>
    {
        public void Configure(EntityTypeBuilder<ProductRoom> builder)
        {

        }
    }
}
