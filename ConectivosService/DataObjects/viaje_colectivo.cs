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
    
    public partial class viaje_colectivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public viaje_colectivo()
        {
            this.viaje_pasajero = new HashSet<viaje_pasajero>();
        }
    
        public long id { get; set; }
        public long id_colectivo { get; set; }
        public long id_recorrido { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual colectivo colectivo { get; set; }
        public virtual recorrido recorrido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<viaje_pasajero> viaje_pasajero { get; set; }
    }
}
