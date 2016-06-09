using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication3 {

    public enum Colores {AZUL, AMARILLO, ROJO,VERDE};
    public enum Estados {SECUENCIA, ESPERANDO_ENTRADA, STOP, SEC_INVALIDA, NUEVO_COLOR};


    public partial class Form1 : Form {

        

        Random r = new Random();
        Timer timerSec = new Timer();
        Timer timerEntrada = new Timer();
        bool sw = false;
        List<Colores> secuencia = new List<Colores>();   //Secuencia aleatoria
        Queue<Colores> secEntrada = new Queue<Colores>();//Secuencia ingresada por el jugador
        IEnumerator<Colores> eSecuencia;            // Un enumerator para recorrer la secuencia aleatoria
        Colores currColor;
        Colores lastColor;
        Estados estado = Estados.STOP;
        Array values = Enum.GetValues(typeof(Colores));
        bool secHasNext = false; 


        public Form1() {
            InitializeComponent();
            currColor = 0 ;
            timerEntrada.Interval = 500;
            timerEntrada.Tick += new EventHandler(timerEntrada_Tick);
            timerEntrada.Enabled = false;

            timerSec.Interval = 500;
            timerSec.Tick += new EventHandler(timer_Tick);
            
        }

        void timerEntrada_Tick(object sender, EventArgs e) {
            switch (estado) {
                case Estados.ESPERANDO_ENTRADA:
                    if (!secHasNext) {
                        //Agrego un nuevo color a la secuencia:
                        Colores nuevo = (Colores)values.GetValue(r.Next(values.Length));
                        secuencia.Add(nuevo);
                        resetESecuencia();
                        progressBar1.Maximum = secuencia.Count;
                        estado = Estados.SECUENCIA;
                        timerSec.Enabled = true;
                        timerEntrada.Enabled = false;
                        Debug.WriteLine("ESPERANDO_ENTRADA Nuevo Color  :{0}", nuevo.ToString());
                        Debug.WriteLine("ESTADO:SECUENCIA");
                    }
                    break;

                case Estados.SEC_INVALIDA:

                    estado = Estados.STOP;
                    Debug.WriteLine("ESTADO:SECUENCIA INVALIDA");
                    break;

                default:
                    break;
            }
        }


        /*
         Enciendo AMARILLO
Prox : AMARILLO
The thread '<No Name>' (0x184) has exited with code 0 (0x0).
Enciendo AMARILLO
Prox : AMARILLO
Enciendo AMARILLO
Prox : AZUL
Enciendo AZUL
No mas botones - Curr: AZUL
ESTADO:esperando entrada...
         */
        void timer_Tick(object sender, EventArgs e) {

            switch (estado) { 
                case Estados.SECUENCIA:

                            if (secHasNext) {
                                if (sw) {
                                    //Enciendo el boton
                                    progressBar1.Value += 1;
                                    currColor = eSecuencia.Current;                                    
                                    Debug.WriteLine("Enciendo {0}", currColor);
                                    resaltarColor(currColor);
                                    lastColor = currColor;
                                    //Indico que debo apagar el boton en la prox Tick
                                    sw = false;
                                }
                                else {
                                    Debug.WriteLine("Apago : {0}", lastColor);
                                    opacarColor(lastColor);
                                    secHasNext = eSecuencia.MoveNext();
                                    
                                    sw = true;
                                }
                            }
                            else {
                                opacarColor(lastColor);
                                Debug.WriteLine("No mas botones - Curr: {0}", currColor);
                                //No hay mas botones, paso a otro estado
                                estado = Estados.ESPERANDO_ENTRADA;
                                timerEntrada.Enabled = true;
                                timerSec.Enabled = false;
                                resetESecuencia();
                                Debug.WriteLine("ESTADO:esperando entrada...");
                            }
                            break;
                
                case Estados.STOP:
                            Debug.WriteLine("ESTADO:STOP");
                            break;

                default:
                            break;
                        
            }
            

        }
        



        public void opacarColor(Colores c){

            switch(c){
                case Colores.AZUL:
                    buttonAz.BackColor = Color.Navy;
                    break;
                case Colores.AMARILLO:
                    buttonAm.BackColor= Color.DarkGoldenrod;
                    break;
                case Colores.ROJO:
                    buttonRo.BackColor = Color.Maroon;
                    break;
                case Colores.VERDE:
                    buttonVe.BackColor = Color.DarkGreen;
                    break;
                default:
                    break;
            }
        }

        private void resaltarColor(Colores c) {
            switch(c){
                case Colores.AZUL:
                    buttonAz.BackColor = Color.Blue;
                    Console.Beep(209, 300);                 
                    break;
                case Colores.AMARILLO:
                    buttonAm.BackColor= Color.Yellow;
                    Console.Beep(252, 300);
                    break;
                case Colores.ROJO:
                    buttonRo.BackColor = Color.Red;
                    Console.Beep(310, 300);
                    break;
                case Colores.VERDE:                
                    buttonVe.BackColor = Color.Green;
                    Console.Beep(415, 300);
                    break;
                default:
                    
                    break;
            }
        }

        

        private void buttonStart_Click(object sender, EventArgs e) {
            timerSec.Enabled = true;
            sw = true;
            secuencia.Clear();
            secuencia.Add((Colores)values.GetValue(r.Next(values.Length) - 1));
            resetESecuencia();
            estado = Estados.SECUENCIA;
        }

        private void checkRespuesta(Colores rta) {

            //Si hay valores en la secuencia
            if (secHasNext) {
                //Comparo el boton presionado con el que valor de la secuencia.
                if (rta == eSecuencia.Current) {
                    progressBar1.Value += 1;
                    secEntrada.Enqueue(eSecuencia.Current);
                    Debug.WriteLine("CheckRespuesta OK : {0} = {1}", rta.ToString(), eSecuencia.Current.ToString());
                    secHasNext = eSecuencia.MoveNext();
                }
                else {
                    //El último boton presionado no coincide con la secuencia... pedio :(
                    estado = Estados.SEC_INVALIDA;
                    Debug.WriteLine("CheckRespuesta ERROR : {0} != {1}", rta.ToString(), eSecuencia.Current.ToString());
                    resetearJuego();
                }
                
            }
        }

        private void resetESecuencia() {

            progressBar1.Value = 0;
            eSecuencia = secuencia.GetEnumerator();
            secHasNext = eSecuencia.MoveNext();
        }
        /*
        Green – 415 Hz
Red – 310 Hz
Yellow – 252 Hz
Blue – 209 Hz
        */
        private void buttonReset_Click(object sender, EventArgs e) {
            resetearJuego();
        }



        private void buttonVe_Click(object sender, EventArgs e) {
            checkRespuesta(Colores.VERDE);  
        }

        private void buttonAm_Click(object sender, EventArgs e) {
            checkRespuesta(Colores.AMARILLO);
        }

        private void buttonRo_Click(object sender, EventArgs e) {
            checkRespuesta(Colores.ROJO);
            
        }
        private void buttonAz_Click(object sender, EventArgs e) {
            checkRespuesta(Colores.AZUL);
        }


        private void resetearJuego() {
            estado = Estados.STOP;
            timerSec.Enabled = false;
            timerEntrada.Enabled = false;
            secuencia.Clear();
            resetESecuencia();
        }


        private void buttonAm_MouseUp(object sender, MouseEventArgs e) {
            opacarColor(Colores.AMARILLO);
        }

        private void buttonRo_MouseUp(object sender, MouseEventArgs e) {
            opacarColor(Colores.ROJO);
        }

        private void buttonVe_MouseUp(object sender, MouseEventArgs e) {
            opacarColor(Colores.VERDE);
        }

        private void buttonAz_MouseUp(object sender, MouseEventArgs e) {
            opacarColor(Colores.AZUL);
        }



        private void progressBar1_Click(object sender, EventArgs e) {
            
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void buttonAm_MouseClick(object sender, MouseEventArgs e) {
            resaltarColor(Colores.AMARILLO);
        }

        private void buttonRo_MouseClick(object sender, MouseEventArgs e) {
            resaltarColor(Colores.ROJO);
        }

        private void buttonAz_MouseClick(object sender, MouseEventArgs e) {
            resaltarColor(Colores.AZUL);
        }

        private void buttonVe_MouseClick(object sender, MouseEventArgs e) {
            resaltarColor(Colores.VERDE);
        }
     }

  }

