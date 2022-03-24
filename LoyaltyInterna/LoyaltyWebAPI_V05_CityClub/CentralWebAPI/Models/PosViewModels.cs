using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    // Models returned by AccountController actions.

    public class ItemPromotionalTemplateViewModel
    {
        public string Id { get; set; }
        public string Template { get; set; }
    }

    public class ItemViewModel
    {
        public string ItemId { get; set; }
        public string Description { get; set; }
        public double NormalPrice { get; set; }
        public double OfferPrice { get; set; }
        public string ValidTo { get; set; }
        public double POSDiscount { get; set; }
        public bool OwnBrand { get; set; }
        public double ForeignExchangeRate { get; set; }
        public double ForeignNormalPrice { get; set; }
        public double ForeignOfferPrice { get; set; }
        public string Id_Num_SKU { get; set; }
        public ItemPromotionalTemplateViewModel[] Templates { get; set; } = { };
    }

    public class ItemModel_Req
    {
        public short storeId { get; set; }
        public string itemId { get; set; }
    }
    
}
