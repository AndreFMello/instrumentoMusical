using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstumentoMusical
{
    public partial class Default : System.Web.UI.Page
    {
        public object MessageBox { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void limpaCampos()
        {
            txtDataFab.Text = "";
            txtFamilia.Text = "";
            txtid.Text = "";
            txtnome.Text = "";
            txtTipo.Text = "";
            txtnome.Focus();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro i = new Cadastro()
            {
                nome = txtnome.Text,
                tipo = txtTipo.Text,
                familia = txtFamilia.Text,
                data_fab = txtDataFab.Text,
            };



            InstrumentosEntities ad = new InstrumentosEntities();
        
            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                ad.Cadastro.Add(i);
            }

            else {
                int id = Convert.ToInt32(valor);
                Cadastro cadastro = ad.Cadastro.First(c => c.id == id);
                cadastro.nome = i.nome;
                cadastro.tipo = i.tipo;
                cadastro.familia = i.familia;
                cadastro.data_fab = i.data_fab;
            }

            ad.SaveChanges();


        }
    }
}