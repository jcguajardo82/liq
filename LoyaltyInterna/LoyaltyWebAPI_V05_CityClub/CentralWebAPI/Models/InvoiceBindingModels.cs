using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApplication4.Models
{
    // Models used as parameters to AccountController actions.

    public class InvoiceReceiverDataBindingModel
    {
        public string RFC { get; set; }

        public string Name { get; set; }

    }

    public class InvoiceRequestBindingModel
    {
        public string HSId { get; set; }

        public string TikcetId { get; set; }

        public InvoiceReceiverDataBindingModel Receptor { get; set; }
       
    }
    
}
