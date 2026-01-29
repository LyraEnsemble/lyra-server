using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Part
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        public string StoragePath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
