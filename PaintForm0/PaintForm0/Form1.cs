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


        /*************************************/
        //Font fuente =
        Font estiloFuente;
        Color colorFuente;

        

        public Form1()
        {
            InitializeComponent();
            fontDialog1.FontMustExist = true;
            fontDialog1.AllowVerticalFonts = false;
            fontDialog1.ScriptsOnly = true;
            fontDialog1.ShowApply = false;
            fontDialog1.ShowHelp = false;
            fontDialog1.ShowColor = true;
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void pictureBox1_Paint_1(object sender, System.Windows.Forms.PaintEventArgs e)
        {
           this.g = e.Graphics;
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
            //g = pictureBox1.CreateGraphics();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
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
            ep = e.Location;
            bClickIzq = (e.Button == MouseButtons.Left) ? true : false;
            /********************************************************/
            if (herrSeleccionada == Herramientas.Texto) { 

               
                TextBox textBoxPaint1 = new TextBox();
                textBoxPaint1.Location = sp;
                textBoxPaint1.Name = "textBoxPaint1";
                textBoxPaint1.Size = new System.Drawing.Size(100, 20);
                textBoxPaint1.Font = estiloFuente;
                textBoxPaint1.ForeColor = colorFuente;
                textBoxPaint1.Leave += new EventHandler(textBoxPaint_Leave);        
                textBoxPaint1.DoubleClick += new EventHandler(textBoxPaint1_DoubleClick);
                textBoxPaint1.Disposed += new EventHandler(textBoxPaint1_Disposed);
                pictureBox1.Controls.Add(textBoxPaint1);
               
            }

        }

        void textBoxPaint1_Disposed(object sender, EventArgs e) {

            
        }    

        private void textBoxPaint1_DoubleClick(object sender, EventArgs e) {
            textBoxPaint_Leave(sender, e);
        }

        private void textBoxPaint_Leave(object sender, EventArgs e) {

            textBox1.Text = "PointText: " + ((TextBox)sender).Location.ToString();
            textBox1.Text += "\n sp: " + sp.ToString();
            textBox1.Text += "\n  ep: " + ep.ToString();
            string aux = ((TextBox)sender).Text;
            Point p = ((TextBox)sender).Location;
            

            ((TextBox)sender).Leave -= new EventHandler(textBoxPaint_Leave);
            pictureBox1.Controls.Remove((TextBox)sender);
            ((TextBox)sender).Dispose();


            /*
                Hay un problema con el dibujado de las letras..
             *  Cuando se remueve el texbox , las letras debajo de esa
             *  area no se ven. Por ahora lo solucionamos escribiendo 
             *  en la coordenada debajo del texbox. py + Height
             */
            g = pictureBox1.CreateGraphics();
            SolidBrush brush = new SolidBrush(colorFuente);
            g.DrawString(aux, ((TextBox)sender).Font, brush, p.X, p.Y + estiloFuente.Height); 
                
        }

        /**
         * El mouse de mueve sobre el area de dibujo
         */
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
    
            if (bClickIzq && herrSeleccionada == Herramientas.Lapiz)
            {
                ep = e.Location;
                g = pictureBox1.CreateGraphics();
                g.DrawLine(p, sp, ep);
                sp = ep;
            }
            
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


            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                estiloFuente = fontDialog1.Font;
                colorFuente = fontDialog1.Color;
            }


        }

        private void LapizButton_Click(object sender, EventArgs e) {

            herrSeleccionada = Herramientas.Lapiz; 
        }

        private void SeleccionButton_Click(object sender, EventArgs e) {
            herrSeleccionada = Herramientas.Seleccion;
        }

        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e) { 
            
        }

        private void fontDialog1_Apply(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }

}
