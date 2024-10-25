//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Var9.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int IdProduct { get; set; }
        public string ProductArticleNumber { get; set; }
        public int ProductNameId { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategory { get; set; }
        public int ProductManufacturer { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<byte> ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public int ProductStatus { get; set; }
        public string ProductPhoto { get; set; }
        public Nullable<byte> MaxDiscountAmount { get; set; }
        public int UnitId { get; set; }
        public Nullable<int> Suplier { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductName ProductName { get; set; }
        public virtual ProductStatus ProductStatus1 { get; set; }
        public virtual Suplier Suplier1 { get; set; }
        public virtual Unit Unit { get; set; }

        public string CurrentPhoto
        {
            get
            {
                if (string.IsNullOrEmpty(ProductPhoto) || String.IsNullOrWhiteSpace(ProductPhoto))
                {
                    return "/Images/picture.png";
                }
                else
                {
                    return "/Images/" + ProductPhoto;
                }
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
