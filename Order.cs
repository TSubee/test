//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ateler
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int CodeOrder { get; set; }
        public Nullable<int> CodeService { get; set; }
        public Nullable<int> CodePerson { get; set; }
        public Nullable<System.DateTime> DateOrder { get; set; }
        public Nullable<System.DateTime> DateFitting { get; set; }
        public Nullable<System.DateTime> DateReady { get; set; }
        public string Description { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Service Service { get; set; }
    }
}
