using System;
using System.Collections.Generic;
using System.Text;

namespace Planning.Domain.Entities
{
    public class Setlist
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; } // El usuario que lo creó

        public string Name { get; set; } = string.Empty;
        public string AccessCode { get; set; } = string.Empty; // Código único (Ej: X7J9P)

        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Aquí está tu colección de items
        public List<SetlistItem> Items { get; set; } = new();
    }
}
