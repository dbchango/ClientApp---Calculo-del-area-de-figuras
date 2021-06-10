using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteServicio
{
    public partial class Form1 : Form
    {
        List<Panel> listaPaneles = new List<Panel>();
        int index;
        AreasService.Service1Client Client = new AreasService.Service1Client("BasicHttpsBinding_IService1");
        AreasService.RingDTO Ring = new AreasService.RingDTO();

        public Form1()
        {
            InitializeComponent();
            lblAreaCirc.Visible = false;
            lblRectang.Visible = false;
            lblRespuestaCuadrado.Visible = false;
            txtRespuestaCuadrado.Text = "";
            txtRespRect.Text = "";
            txtRespCirc.Text = "";
            panelCuadrado.Visible = false;
            panelRectangulo.Visible = false;
            panelCirculo.Visible = false;
            listaPaneles.Add(panelCuadrado);
            listaPaneles.Add(panelRectangulo);
            listaPaneles.Add(panelCirculo);
            listaPaneles.Add(panelTriangulo);
            listaPaneles[index].BringToFront();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void sidemenu_Paint(object sender, PaintEventArgs e)
        {

        }
        //CUADRADO
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panelCuadrado.Visible = true;
            panelRectangulo.Visible = false;
            
            panelCirculo.Visible = false;
            panelTriangulo.Visible = false;
            listaPaneles[0].BringToFront();
        }

        //TRIANGULO
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panelTriangulo.Visible = true;
            panelCuadrado.Visible = false;
            panelRectangulo.Visible = false;
            panelCirculo.Visible = false;
            listaPaneles[1].BringToFront();
        }
     

        //CIRCULO

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            lblAreaCirc.Visible = true;
            lblAreaCirc2.Visible = true;
            txtRespCirc.Visible = true;
            txtRespCircPer.Visible = true;
            try
            {
                Ring.Radius = (double)nudRadio.Value;
                var temp = Client.CreateRing(Ring);
                txtRespCirc.Text = temp.Area.ToString();
                txtRespCircPer.Text = temp.Perimeter.ToString();
                MessageBox.Show("Proceso completado satisfactoriamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panelCirculo.Visible = true;
            panelCuadrado.Visible = false;
            panelRectangulo.Visible = false;
            panelTriangulo.Visible = false;
            listaPaneles[2].BringToFront();
        }
        //RECTANGULO
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panelRectangulo.Visible = true;
            panelCuadrado.Visible = false;
            panelCirculo.Visible = false;
            panelTriangulo.Visible = false;
            listaPaneles[3].BringToFront();
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            listaPaneles.Add(panelCuadrado);
            listaPaneles.Add(panelRectangulo);
            listaPaneles.Add(panelCirculo);
            listaPaneles.Add(panelTriangulo);
            listaPaneles[index].BringToFront();
        }

        private void panelRectangulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
