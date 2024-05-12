using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs.ProductRoomDto
{
    public record ProductRoomDto
    {
        public int ProductRoomId { get; init; }
        public int ProductId { get; init; }
        public Product? Product { get; init; }
    }
}
