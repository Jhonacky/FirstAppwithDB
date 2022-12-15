using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace PracticaAppconDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            List<Disco> lista = new List<Disco>();
            lista = negocio.listar();
            dgvDiscos.DataSource = lista;
            dgvDiscos.Columns["urlImagen"].Visible = false;
            
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco aux = new Disco();
            aux = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            try
            {
                pbxDiscos.Load(aux.urlImagen);
            }
            catch (Exception ex)
            {

                pbxDiscos.Load("https://http2.mlstatic.com/D_NQ_NP_778932-MLA43277274007_082020-O.jpg");
            }
        }
    }
}
