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
    
    public partial class AirplaneModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirplaneModel()
        {
            this.Airplane = new HashSet<Airplane>();
        }
    
        public int NumberModel { get; set; }
        public string Decoding { get; set; }
        public Nullable<int> CountSeats { get; set; }
        public Nullable<int> Speed { get; set; }
        public Nullable<int> LenghtFly { get; set; }
        public Nullable<int> MaxWeight { get; set; }
        public string MaxHeight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Airplane> Airplane { get; set; }
    }
}