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
    
    public partial class Residense
    {
        public int ID { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Raiting { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
    
        public virtual City City { get; set; }
    }
}