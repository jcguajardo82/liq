using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebApplication4.Models
{
    public class Lista_ArticuloModel
    {
        public EstatusClienteModel Estatus { get; set; }
        public List<ArticuloModel> Items { get; set; }
        public ControlLista Control { get; set; }
    }

    public class ArticuloModel
    {
        public int Index { get; set; }
        public int Ranking { get; set; }
        public string ItemId { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string SalesUnit { get; set; }
        public DateTime publicationDate { get; set; }
        public string UrlImage { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal NormalSalePrice { get; set; } = 0;
        public decimal OfferSalePrice { get; set; } = 0;
        public DateTime OfferEntryDate { get; set; } = DateTime.MinValue;
        public DateTime OfferExitDate { get; set; } = DateTime.MinValue;
        public decimal DiscountPercentage { get; set; } = 0;
        public decimal IVA { get; set; }
        public decimal IEPS { get; set; }
    }

    public class ControlLista
    {
        public int idLista { get; set; }
        public string nombreLista { get; set; }
        public string descripLista { get; set; }
        public int Pagina { get; set; }
        public int cantRegPagina { get; set; }
        public int totalPaginas { get; set; }
        public int numRegistros { get; set; }
    }

    public class Articulos_Carrito
    {
        public string articulo { get; set; }
        public decimal cantidad { get; set; }
        public int unidadMedida { get; set; }
        public int idNumVisita { get; set; }
        public int idTienda { get; set; }
        public int identificador { get; set; }
    }

    public class Articulos_ListaCompras
    {
        public string articulo { get; set; }
        public decimal cantidad { get; set; }
        public int idNumVisita { get; set; }
        public int idTienda { get; set; }
        public int idLista { get; set; }
        public int identificador { get; set; }
    }

    public class CambioTienda_ModelReq
    {
        public string NumeroAplicacion { get; set; }
        public string NumeroTiendaNueva { get; set; }
        public string NumeroCarritoActual { get; set; }
        public string NumeroVisita { get; set; }
    }

    public class CambioTienda_ModelRes
    {
        public string NumCarritoActual { get; set; }
        public string NumTiendaNueva { get; set; }
        public string NumAplicacion { get; set; }
        public string NumCarritoNuevo { get; set; }
    }

    public class ArticulosEliminadosModel
    {
        public EstatusClienteModel Estatus { get; set; }
        public DataSet DetalleArticulosCarrito { get; set; } = new DataSet();
        public List<ArtEliminados> Eliminados { get; set; }
    }

    public class ArtEliminados
    {
        public string idArticulo { get; set; }
        public string descripArticulo { get; set; }
        public string articuloURL { get; set; }
        public string cantArticulo { get; set; }
        public string idTipoUniCompra { get; set; }
        public string descripTipoUniCompra { get; set; }
        public string idTipoUniCompra1 { get; set; }
        public string descripTipoUnCompra1 { get; set; }
        public string idTipoUniCompra2 { get; set; }
        public string descripTipoUnCompra2 { get; set; }
        public string precioArticulo { get; set; }
        public string precioConDescArticulo { get; set; }
        public string idComentarioArticulo { get; set; }
        public string descComentarioArticulo { get; set; }
        public string bitCarrito { get; set; }
        public string bitTienda { get; set; }
        public string bitPromocion { get; set; }
        public string bitConversion { get; set; }
        public string bitConversionActiva { get; set; }
        public string descUnidadVenta { get; set; }
        public string cantUnidadDefault { get; set; }
        public string cantPiezas { get; set; }
        public string relacionConversion { get; set; }
        public string descArtRedesSociales { get; set; }
        public string URL_AppStore { get; set; }
        public string URL_GooglePlay { get; set; }
    }

    public class ArticulosLista
    {
        public string Id_Num_SKU { get; set; }
        public int id_Num_LstComp { get; set; }
        public int identificador { get; set; }
    }

    public class ArticulosCanje_Req      {
        public string Id_Num_Sku { get; set; }
        public string Cantidad_Unidades { get; set; }
        public string Cant_PuntosCanje { get; set; }
        public string Id_Num_PromCanje { get; set; }
    }
}