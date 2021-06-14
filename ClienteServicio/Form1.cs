using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using ClienteServicio.Models;
using ClienteServicio.Services;

namespace ClienteServicio
{
    public partial class Form1 : Form
    {
        List<Panel> listaPaneles = new List<Panel>();
        int index;
        public AreasService.Service1Client Client = new AreasService.Service1Client("BasicHttpsBinding_IService1");
        public AreasService.RingDTO Ring = new AreasService.RingDTO();
        
        public Square squareG;
        public Triangle triangleG;
        public readonly HttpClient client = new HttpClient();
        public static SquaresServices sqService;
        public static TrianglesServices trService;
        

        public async void ListSquares()
        {
            dynamic result = await sqService.ListSquares();
            Object myObject = result;
            if(myObject.GetType().Name == "String")
            {
                MessageBox.Show(result);
            }
            else
            {
                Console.WriteLine("Elementos listados.");
            }
        }

        public async void ListTriangles()
        {
            dynamic result = await trService.ListTriangles();
            Object myObject = result;
            if(myObject.GetType().Name == "String")
            {
                MessageBox.Show(result);
            }
            else
            {
                Console.WriteLine("Triangulos listados.");
            }
        }

        public async Task<dynamic> CreateSquare(Cuadrado sq)
        {
            dynamic result = await sqService.CreateSquares(sq);
            Object myObject = result;
            if (myObject.GetType().Name == "String")
            {
                MessageBox.Show(result);
                return null;
            }
            else
            {     
                MessageBox.Show("Elemento creado con el id: "+result.Id);
                squareG = result;
                return result;
            }
        }

        public async Task<dynamic> CreateTriangle(Triangle tr)
        {
            dynamic result = await trService.CreateTriangle(tr);
            Object myObject = result;
            if (myObject.GetType().Name == "String")
            {
                MessageBox.Show(result);
                return null;
            }
            else
            {
                MessageBox.Show("Elemento creado con el id: " + result.Id);
                triangleG = result;
                return result;
            }
        }

        public  Form1()
        {
            sqService = new SquaresServices(client);
            trService = new TrianglesServices(client);
            InitializeComponent();
            ListTriangles();
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

        private async void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Cuadrado square = new Cuadrado();
            square.lado = (float)nudLado.Value;
            dynamic result = await CreateSquare(square);
            Object myObject = result;
            lblRespuestaCuadrado.Visible = true;
            lblRespuestaCuadrado2.Visible = true;
            txtRespuestaCuadrado.Visible = true;
            txtRespuestaCuadradoPer.Visible = true;
            txtRespuestaCuadrado.Text = squareG.Area.ToString();
            txtRespuestaCuadradoPer.Text = squareG.Perimeter.ToString();
            

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

        private async void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            lblTriang.Visible = true;
            lblTriang2.Visible = true;
            txtTriang.Visible = true;
            txtTriangPer.Visible = true;
            Triangle triangle = new Triangle();
            triangle.Width = (long)nudWidth.Value;
            triangle.Height = (long)nudHeight.Value;
            dynamic result = await CreateTriangle(triangle);
            txtTriang.Text = triangleG.Area.ToString();
            txtTriangPer.Text = triangleG.Perimeter.ToString();
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
