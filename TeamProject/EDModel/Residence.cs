//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Residence
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public int stars { get; set; }
        public string phone { get; set; }
        public decimal price { get; set; }
    
        public virtual City City { get; set; }
    }
}
