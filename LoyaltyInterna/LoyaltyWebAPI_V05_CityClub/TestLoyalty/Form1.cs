using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication4.BL;
using WebApplication4.Models;

namespace TestLoyalty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL_Loyalty loyal = new BL_Loyalty();
            LinkCard_Req req = new LinkCard_Req();
            req.ClientId = "abGAX5TMR4Z5pPxkoZ9wMWV7gV";
            req.LoyaltyAccount = "";  //3086812824889264
            req.Nombre = "Roberto";
            req.Paterno = "Villalba";
            req.Materno = "Hernandez";
            req.Email = "t_robertovh@soriana.com.mx";

            loyal.BL_LinkCard(req);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BL_Loyalty loyal = new BL_Loyalty();
            LinkCard_Req req = new LinkCard_Req();
            req.ClientId = "9000";
            req.LoyaltyAccount = "";
            req.Nombre = "Frida";
            req.Paterno = "Almazan";
            req.Materno = "Almazan";
            req.Email = "faa@outlook.com";

            loyal.BL_LinkVirtualCard(req);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BL_Loyalty loyal = new BL_Loyalty();
            LoyaltyReq_Base req = new LoyaltyReq_Base();
            req.ClientId = "bcMxutz3yuQCdjZBvxaoaQc6Xv";
            req.tokenCard = "BE93EAC3-C47F-47CB-95EC-45C9EA3E46D7";


            //{ "Action": "4", "tokenCard": "09FB90FC-785C-4E58-8287-0C6A0B1AB2E9", "ClientId": "bcMxutz3yuQCdjZBvxaoaQc6Xv" }


            loyal.BL_Balances(req);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BL_Loyalty loyal = new BL_Loyalty();
            ReplaceCard_Req req = new ReplaceCard_Req();
            req.idNumCte = "adbn7c2RYTZ0Opb5kATPm6aDBi";
            req.ReplacementLoyaltyAccount = "3086812824892888";                  //2000100011942806
            req.tokenCard = "5A7E8B5A-C9B4-4E61-B388-F3B4A6510203";
            //req.ticketId = "00241003099307001302";

            /*
  "Action" : "3",
  "ClientId" : "bcMxutz3yuQCdjZBvxaoaQc6Xv",
  "tokenCard": "BE93EAC3-C47F-47CB-95EC-45C9EA3E46D7",
  "ReplacementLoyaltyAccount" : "2000100154911634"
  
            "Action" : "3",
  "ClientId" : "fcMxutz3yuQCdjZBvxaoaQc6Xv",
  "tokenCard": "5A7E8B5A-C9B4-4E61-B388-F3B4A6510203",
  "ReplacementLoyaltyAccount" : "2000100011942806"

            {
  "Action" : "3",
  "ClientId" : "adbn7c2RYTZ0Opb5kATPm6aDBi",
  "tokenCard": "92281CDB-FAA5-485D-BCEC-3AD2D0F62F7E",
  "ReplacementLoyaltyAccount" : "3086812808008113"
}
             */

            loyal.BL_CardReplacement(req);
        }

        /*
    "Action": "3",
    "ClientId" : "abQYF72lZE9Nshde5t6RQ2GKlI",
    "tokenCard" : "749B3782-22EE-4EC1-A920-6784C70C72A3",
    "ReplacementLoyaltyAccount": "3086812824892888"
}
*/

        private void button5_Click(object sender, EventArgs e)
        {
            BL_Loyalty loyal = new BL_Loyalty();
            RedencionSaldoRequest_Model req = new RedencionSaldoRequest_Model();

            req.Cant_Puntos = "300";
            req.Id_Cve_CteInet = "0E2665D2-5F38-47CD-AC55-D10B6E1D2189";
            req.Id_Cve_Orden = "12345678908";
            req.Imp_Comp = "50";
            req.Imp_DE = "20";
            req.Imp_Efvo = "30";
            req.Imp_Vta = "120";

            /*    @pId_Cve_Orden        = '12345678908'
                ,@pId_Cve_TokenCta    = '0E2665D2-5F38-47CD-AC55-D10B6E1D2189'
                ,@pCve_Operacion    = 'COMPRA'
                ,@pImp_Vta        = 120
                ,@pCant_Puntos        = 300
                ,@pImp_Comp        = 50
                ,@pImp_Efvo        = 30
                ,@pImp_DE        = 20*/

            loyal.BL_RedemptionBalances(req);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BL_Loyalty loyal = new BL_Loyalty();

            ReplaceCard_Req req = new ReplaceCard_Req();
            req.idNumCte = "9b002a8878151487b656737b18d8b04f";
            req.ReplacementLoyaltyAccount = "2000100154911634";
            req.tokenCard = "BE09065B-3EA7-4D7C-8618-EEE2486F7A3D";
            req.ticketId = "00241003099307001302";

            loyal.BL_ReplacementByTicket(req);

            /*  "tokernCard": "BE09065B-3EA7-4D7C-8618-EEE2486F7A3D",
     "ClientId" : "9b002a8878151487b656737b18d8b04f",
     "ticketId": "00241003099307001302"*/

       }
    }
}


