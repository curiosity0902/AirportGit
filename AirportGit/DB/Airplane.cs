//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportGit.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Airplane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airplane()
        {
            this.Flight = new HashSet<Flight>();
        }
    
        public int IDAirplane { get; set; }
        public Nullable<int> IDAirplaneModel { get; set; }
        public Nullable<int> IDTeam { get; set; }
        public Nullable<int> IDAircompany { get; set; }
    
        public virtual Aircompany Aircompany { get; set; }
        public virtual AirplaneModel AirplaneModel { get; set; }
        public virtual Team Team { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
