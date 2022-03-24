using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{

    public class TicketListItemViewModel
    {
        public string UserId { get; set; }
        public string TicketId { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string TicketDate { get; set; }
        public string TicketAmount { get; set; }
        public bool TicketInvoiced { get; set; }
        public TicketViewModel Ticket { get; set; }
    }

    public class TicketListViewModel
    {
        public string tokenCard { get; set; }
        public string maskCard { get; set; }
        public string Cuenta { get; set; }
        public int[] UserId { get; set; }
        public int ActualPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsByPage { get; set; }
        public int TotalItems { get; set; }
        public TicketViewModel[] Tickets { get; set; }
    }

    public class TicketLineViewModel
    {
        public int TextAlignment { get; set; }
        public bool TextBold { get; set; }
        public bool TextDoubleHeight { get; set; }
        public string Text { get; set; }
    }

    public class TicketViewModel
    {
        public string UserId { get; set; }
        public string TicketId { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string TicketDate { get; set; }
        public TicketLineViewModel[] TicketLines { get; set; } = { };
        public string TicketAmount { get; set; }
        public bool TicketInvoiced { get; set; }
    }

    public class TicketViewCloudModel
    {
        public string UserId { get; set; }
        public string TicketId { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string TicketDate { get; set; }
        public string[] Clientes { get; set; }
        public TicketLineViewModel[] TicketLines { get; set; } = { };
        public string TicketAmount { get; set; }
        public bool TicketInvoiced { get; set; }
        public string TokenTarjeta { get; set; }
        public string IdTarjeta { get; set; }
    }

}