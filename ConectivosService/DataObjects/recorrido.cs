//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConectivosService.DataObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class recorrido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recorrido()
        {
            this.recorrido_parada = new HashSet<recorrido_parada>();
            this.viaje_colectivo = new HashSet<viaje_colectivo>();
        }
    
        public long id { get; set; }
        public string ramal { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public Nullable<int> estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recorrido_parada> recorrido_parada { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<viaje_colectivo> viaje_colectivo { get; set; }
    }
}
