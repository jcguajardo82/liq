using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class DoSearchModel
    {
        public int idCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int idCategoriaPadre { get; set; }
        public string urlImg { get; set; }
        public string Categorias { get; set; }
        public bool BitNavegable { get; set; }
        public List<QueryResultItem> Articulos { get; set; }
    }

    public class QueryResultItem
    {
        public string Index { get; set; }
        public string Ranking { get; set; }
        public string ItemId { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string SalesUnit { get; set; }
        public string PublicationDate { get; set; }
        public string UrlImage { get; set; }
        public string UpdateDate { get; set; }
        public string NormalSalePrice { get; set; }
        public string OfferSalePrice { get; set; } 
        public string OfferEntryDate { get; set; } 
        public string OfferExitDate { get; set; } 
        public string DiscountPercentage { get; set; } 
        public string IVA { get; set; }
        public string IEPS { get; set; }
        public QueryResultItemConversionRule ConversionRule { get; set; }
    }

    public class QueryResultItemConversionRule
    {
        public int BaseUnit { get; set; }
        public int EquivalentUnit { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool AllowFraction { get; set; }
    }

}