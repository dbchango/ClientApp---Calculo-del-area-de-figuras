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
        AreasService.Service1Client Client = new AreasService.Service1Client();
        AreasService.TriangleDTO Triangle = new AreasService.TriangleDTO();
        AreasService.SquareDTO Square = new AreasService.SquareDTO();
        AreasService.RingDTO Ring = new AreasService.RingDTO();
        AreasService.RectangleDTO Rectangle = new AreasService.RectangleDTO();

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

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            lblRespuestaCuadrado.Visible = true;
            txtRespuestaCuadrado.Visible = true;
            txtRespuestaCuadradoPer.Visible = true;
            lblRespuestaCuadrado2.Visible = true;

            try {
                Square.Side = (double)nudLado.Value;
                var temp = Client.CreateSquare(Square);
                txtRespuestaCuadrado.Text = temp.Area.ToString();
                txtRespuestaCuadradoPer.Text = temp.Perimeter.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            lblTriang.Visible = true;
            lblTriang2.Visible = true;
            txtTriang.Visible = true;
            txtTriangPer.Visible = true;
            try
            {
                Triangle.SideA = (double)nudA.Value;
                Triangle.SideB = (double)nudB.Value;
                Triangle.SideC = (double)nudC.Value;
                var temp = Client.CreateTriangle(Triangle);
                txtTriang.Text = temp.Area.ToString();
                txtTriangPer.Text = temp.Perimeter.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            lblRectang.Visible = true;
            txtRespRect.Visible = true;
            lblRectangulo2.Visible = true;
            txtRespRectPer.Visible = true;
            try
            {
                Rectangle.Width = (double)nudBaseRect.Value;
                Rectangle.Height = (double)nudAlturaRect.Value;
                var temp = Client.CreateRectangle(Rectangle);
                txtRespRect.Text = temp.Area.ToString();
                txtRespRectPer.Text = temp.Perimeter.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
