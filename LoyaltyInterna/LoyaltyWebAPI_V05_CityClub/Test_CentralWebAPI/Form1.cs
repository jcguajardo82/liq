using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication4.BL_API_Soriana_APP;
using WebApplication4.Models;

using MBSLibrary;
using WebApplication4.Controllers;
using System.Net.Http;

namespace Test_CentralWebAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BL_SADAM_Carrito CarritoMetodos = new BL_SADAM_Carrito();
        BL_SADAM SadamMetodos = new BL_SADAM();
        static MBSLibrary.EngineType engine = new MBSLibrary.EngineType();

        private void btnDetalleCarrito_Click(object sender, EventArgs e)
        {
            string IdNumCte = "345605";
            var guid = Guid.NewGuid();

            //var Usuario_WS_SADAM1 = BL_SADAM_Metodos.WM_SADAM_ValidarCliente(UserName, Password, ClientID);

            var Usuario_WS_SADAM = CarritoMetodos.WM_SADAM_ObtenerTodosArticulosCarrito(int.Parse(IdNumCte), guid);

        }

        private void btn_CambioTda_Click(object sender, EventArgs e)
        {
            int IdNumCte = 0;
            int NumeroVisita = 0;
            int ClienteId = 0;
            int NumeroTiendaNueva = 0;

            IdNumCte = ObtenerCliente();

            var visita = SadamMetodos.WM_SADAM_ActualizarVisita(NumeroVisita, IdNumCte);

            var CmbTienda = CarritoMetodos.BL_CambioTienda(ClienteId, NumeroTiendaNueva, int.Parse(visita.idNumVisita), IdNumCte);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnToken_Click(object sender, EventArgs e)
        {
            string UserName = "jclo8413@test.com";
            string Password = "12345678";

            int ClientID = 23;

            BL_SADAM BL_SADAM_Metodos = new BL_SADAM();
            var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_ValidarCliente(UserName, Password, ClientID);
        }

        public int ObtenerCliente()
        {
            string UserName = "canelita6@gmail.com"; //"christopherobrgn@gmail.com";
            string Password = "12345678";               //"Soriana1q";

            int ClientID = 23;

            BL_SADAM BL_SADAM_Metodos = new BL_SADAM();
            var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_ValidarCliente(UserName, Password, ClientID);

            return int.Parse(Usuario_WS_SADAM.Cliente.Id_Num_Cte);
        }

        private void btnValidaCveReg_Click(object sender, EventArgs e)
        {
            VinculacionModel model = new VinculacionModel();
            BL_Vinculacion Vinculacion = new BL_Vinculacion();

            model.CveRegistro = "333343";

            var idNumCte = ObtenerCliente();

            var Resultado = Vinculacion.BL_ValidaCveRegistro(model, idNumCte);
        }

        private void brnCveRegRel_Click(object sender, EventArgs e)
        {
            VinculacionModel model = new VinculacionModel();
            BL_Vinculacion Vinculacion = new BL_Vinculacion();

            model.CveRegistro = "333343";

            var idNumCte = ObtenerCliente();

            var Resultado = Vinculacion.BL_RelacionCveRegistro(model, idNumCte);
        }

        private void btnTicketVinc_Click(object sender, EventArgs e)
        {
            VinculacionModel model = new VinculacionModel();
            BL_Vinculacion Vinculacion = new BL_Vinculacion();

            model.TarjetaNueva = "3086812801279489";
            model.Ticket = "00241109099307000407";

            model.CveRegistro = "333343";

            var idNumCte = ObtenerCliente();

            var Resultado = Vinculacion.BL_VincularconTicket(model, 355610);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EngineController buscador = new EngineController();
            Query query = new Query();

            query.StoreId = "24";
            query.Sentence = "coca cola";
            query.ItemsPerPage = 3;
            query.PageNumber = 4;
            query.BrandId = "";
            query.ResultLimit = 7000;
            query.OrderType = 0;
            query.Promotions = "";

            var respuesta = buscador.DoSearch(query);
           // var postResult = Post(query);
        }

        private void btnSession_Click(object sender, EventArgs e)
        {
            EngineController buscador = new EngineController();

            var result = buscador.GetSessionsInfo();
        }

        private void btnPrimertjta_Click(object sender, EventArgs e)
        {
            VinculacionModel model = new VinculacionModel();
            BL_Vinculacion Vinculacion = new BL_Vinculacion();

            var idNumCte = ObtenerCliente();

            PersonaClienteModel personaModel = new PersonaClienteModel();

            personaModel = Vinculacion.BL_ObtenerInfoCliente(idNumCte);

            RegisterBindingModel modelPrimerT = new RegisterBindingModel
            {
                clientId = idNumCte.ToString(),
                Nombre = personaModel.nomCte,
                ApellidoPaterno = personaModel.apPaternoCte,
                ApellidoMaterno = personaModel.apMaternoCte,
                Email = "juaneloMaldonado@software.com",
                Telefono = personaModel.celularCtev,
                TelefonoCelular = personaModel.celularCtev,
                Password = "12345678",
                ConfirmPassword = "12345678",
                LoyaltyAccount = "7845278965286571" //INVALIDA - ""      3086812825389254
            };

            var Resultado = Vinculacion.BL_VinculaPrimerTarjeta(modelPrimerT);
        }

        private void btnRegSimple_Click(object sender, EventArgs e)
        {
            BL_Vinculacion Vinculacion = new BL_Vinculacion();

            RegisterBindingModel modelRegCliente = new RegisterBindingModel
            {
                //clientId = IdNumCte.ToString(),
                Nombre = "Teodulo",
                ApellidoPaterno = "Nuñez",
                ApellidoMaterno = "Delgado",
                Email = "teos77@test.com",
                Telefono = "4491205699",
                TelefonoCelular = "4491205699",
                Password = "12345678",
                ConfirmPassword = "12345678",
                LoyaltyAccount = "",
            };

            var Resultado = Vinculacion.BL_RegistroCliente(modelRegCliente);       //347106
        }

        private void btnInfoCliente_Click(object sender, EventArgs e)
        {
            var InfoCliente = SadamMetodos.WM_SADAM_ObtenerInfoCliente(355610);
        }

        private void btnReposicion_Click(object sender, EventArgs e)
        {
            BL_Vinculacion Vinc = new BL_Vinculacion();
            VinculacionModel vinculacion = new VinculacionModel();
            vinculacion.TarjetaNueva = "3086812801279455";

            var idNumCte = ObtenerCliente();

            var Resultado = Vinc.BL_VinculaReposicionTarjeta(vinculacion, idNumCte);
        }

        private void btnDireccion_Click(object sender, EventArgs e)
        {
            Parametros RequestParam = new Parametros();
            BL_SADAM BL_SADAM_Metodos = new BL_SADAM();

            RequestParam.idTienda = 24;
            RequestParam.idCnscDirCte = 1;
            RequestParam.nomDirCte = "TEST";
            RequestParam.idTipoDomCte = 1;
            RequestParam.nomRecibeCte = "Roberto Villalba Hernandez";
            RequestParam.idEstadoCte = 1;
            RequestParam.nomCiudadCte = "Aguascalientes";
            RequestParam.nomColoniaCte = "Gremial";
            RequestParam.nomCalleCte = "Francisco Villa";
            RequestParam.numExtCalleCte = "114";
            RequestParam.numIntCalleCte_Opc = "";
            RequestParam.CPCte = "64610";
            RequestParam.telefonoCte = "4492221356";
            RequestParam.Latitud = "25.691055";
            RequestParam.Longitud = "-100.2946213";


            var idNumCte = ObtenerCliente();

            var Usuario_WS_SADAM = BL_SADAM_Metodos.WM_SADAM_ActualizarDirCliente(idNumCte, RequestParam.idTienda
                                , RequestParam.idCnscDirCte, RequestParam.nomDirCte, RequestParam.idTipoDomCte, RequestParam.nomRecibeCte, RequestParam.idEstadoCte, RequestParam.nomCiudadCte
                                , RequestParam.nomColoniaCte, RequestParam.nomCalleCte, RequestParam.numExtCalleCte, RequestParam != null ? RequestParam.numIntCalleCte_Opc : null
                                , RequestParam.CPCte, RequestParam.telefonoCte, RequestParam.Latitud, RequestParam.Longitud);
        }

        private void btnBorrarDir_Click(object sender, EventArgs e)
        {
            BL_SADAM BL_SADAM_Metodos = new BL_SADAM();

            var idNumCte = ObtenerCliente();

            var Respuesta = BL_SADAM_Metodos.WM_SADAM_BorrarDireccionCliente(idNumCte, 1);
        }
    }
}
