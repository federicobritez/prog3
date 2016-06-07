using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintForm0
{
    public enum Herramientas { Lapiz , PintarFondo, Gotero, Borrador, Seleccion, Texto, ZoomIn, ZoomOut};


    public partial class Form1 : Form
    {
        /*************************************/
        //dibujar con lapiz
        Graphics g;
        Pen p = new Pen(Color.Black, 1);
        Point sp = new Point(0, 0);   //Cordenada X del puntero donde comienza la linea/pincel
        Point ep = new Point(0, 0);   //Cordenada Y del puntero donde termina la linea/pincel      
        bool bClickIzq = false;  // Variable para saber si el click esta activado

        Herramientas herrSeleccionada = Herramientas.Lapiz; //Por default la herramienta es el lapiz
        /*************************************/


        /*************************************/
        //cortar
        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        int oCropX;
        int oCropY;
        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        /*************************************/

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }


        /**
         * Apertura de archivos:
         * 
         * TODO: Filtrar solo los bmp y los jpg
         */
        private void buttAbrir_Click(object sender, EventArgs e)
        {

            OpenFileDialog Dlg = new OpenFileDialog();//funciona esto
            
            if (Dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(Dlg.FileName);
            }

            //para centrar la imagen donde corresponde
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        /**
         * El mouse se preciona sobre el arae de dibujo
         */
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            /********************************************************/
            //dibujar
            sp = e.Location;
            bClickIzq = (e.Button == MouseButtons.Left) ? true : false;
            /********************************************************/

        }

        /**
         * El mouse de mueve sobre el are de dibujo
         */
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bClickIzq && herrSeleccionada == Herramientas.Lapiz)
            {
                ep = e.Location;
                g = pictureBox1.CreateGraphics();
                g.DrawLine(p, sp, ep);
            }
            sp = ep;

            /********************************************************/
            //cortar

            /********************************************************/

        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bClickIzq =false;

        }
        private void ButtCortar_Click(object sender, EventArgs e)
        {
            //private void cropping()

           // {

            
        }


        /**
         * Paleta de Colores
         */
        private void pictureBoxRojo_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxRojo.BackColor;
            pictureBoxDefault.BackColor = pictureBoxRojo.BackColor;
        }

        private void pictureBoxVerde_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxVerde.BackColor;
            pictureBoxDefault.BackColor = pictureBoxVerde.BackColor;
        }

        private void pictureBoxAzul_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxAzul.BackColor;
            pictureBoxDefault.BackColor = pictureBoxAzul.BackColor;

        }

        private void pictureBoxNegro_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxNegro.BackColor;
            pictureBoxDefault.BackColor = pictureBoxNegro.BackColor;

        }

        private void pictureBoxBlanco_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxBlanco.BackColor;
            pictureBoxDefault.BackColor = pictureBoxBlanco.BackColor;

        }

        private void pictureBoxAmarillo_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxAmarillo.BackColor;
            pictureBoxDefault.BackColor = pictureBoxAmarillo.BackColor;

        }

        private void pictureBoxRosa_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxRosa.BackColor;
            pictureBoxDefault.BackColor = pictureBoxRosa.BackColor;


        }

        private void pictureBoxGris_Click(object sender, EventArgs e)
        {
            p.Color = pictureBoxGris.BackColor;
            pictureBoxDefault.BackColor = pictureBoxGris.BackColor;

        }



        /**
         * Tamaño del trazo de lapiz 
         */
        private void trackBarTrazo_Scroll(object sender, EventArgs e)
        {
            int ancho = trackBarTrazo.Value;
            this.p = new Pen(this.pictureBoxDefault.BackColor, ancho);
        }





        #region Botones de Herramientas
        /**
         * Inserción de Texto en area de dibujo
         */
        private void TextoButton_Click(object sender, EventArgs e) {

            herrSeleccionada = Herramientas.Texto;          
        }

        private void LapizButton_Click(object sender, EventArgs e) {

            herrSeleccionada = Herramientas.Lapiz; 
        }

        private void SeleccionButton_Click(object sender, EventArgs e) {
            herrSeleccionada = Herramientas.Seleccion;
        }

        #endregion
    }

}
