using System;
using System.Collections.Generic;
using System.Text;

namespace Planning.Domain.Entities
{
    public class SetlistItem
    {
        public Guid Id { get; set; }

        // Relación con el Papá (Setlist)
        public Guid SetlistId { get; set; }
        // public Setlist Setlist { get; set; } // Opcional: Navegación inversa si la necesitas

        // Referencia al otro módulo (Solo el ID, no el objeto Part)
        public Guid PartId { get; set; }

        // EL DATO CLAVE: El orden en la lista (1, 2, 3...)
        public int OrderIndex { get; set; }

        // Opcional: Notas específicas para este concierto
        // Ej: "Tocar 2 semitonos abajo", "Saltar la intro"
        public string? PerformanceNote { get; set; }
    }
}
