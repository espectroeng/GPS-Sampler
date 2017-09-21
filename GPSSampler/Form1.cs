using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GPSSampler
{
    public partial class Form1 : Form
    {
        USBCom usbcom;
        int timerCont = 0;
        private ulong cont = 0;
        private bool threadAtiva = false;

        //byte[] data, accdata;
        //string aux;
        //StreamWriter file;

        public Form1()
        {
            InitializeComponent();
            //usbcom = new USBCom();
            //usbcom.Initialize();
            //cBoxAqType.SelectedIndex = 0;
            //accdata = new byte[16384];
            //tmerGeneral.Enabled = true;
        }

        private void btonAcquisition_Click(object sender, EventArgs e)
        {

            
            bool status = false;
            byte[] bufferIn = new byte[512];
            

            //usbcom.sendWritePkt("ALG", 0x10, (byte)cBoxAqType.SelectedIndex);
            //usbcom.sendWritePkt("ALG", 0x11, 0x01);

            if (btonAcquisition.Text == "START")
            {
                
                btonAcquisition.Text = "STOP";
                btonAcquisition.BackColor = System.Drawing.Color.Red;
                status = usbcom.sendWritePkt("BRM", 0, 1);
                tboxReadData.Clear();
                timerRead.Enabled = status;                
                timerWatch.Enabled = status;
                threadAtiva = status;                
             } 
            else
            {
                btonAcquisition.Text = "START";
                btonAcquisition.BackColor = System.Drawing.Color.PaleGreen;
                status = usbcom.sendWritePkt("BRM", 0, 0);
                timerRead.Enabled = false;
                timerWatch.Enabled = false;
                threadAtiva = false;
                timerCont = 0;
                cont = 0;

                if (!status)
                {
                    MessageBox.Show("Não foi possivel enviar comando (BRM,0000, 00) para parar a leitura");
                }
            }

           
          

         }


        /// <summary>
        /// Metodo do programa original para escrita e leitura de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btonAcquisition_Click(object sender, EventArgs e)
        //{
        //    int i;
        //    file = new StreamWriter("ReadData.txt");
        //    usbcom.sendWritePkt("ALG", 0x10, (byte)cBoxAqType.SelectedIndex);
        //    usbcom.sendWritePkt("ALG", 0x11, 0x01);
        //    aux = null;
        //    for (i = 0; i < 16384; i += 500) //16384
        //    {
        //        data = new byte[256];
        //        usbcom.sendReadPkt("BRM", i, out data);
        //        data.CopyTo(accdata, i);
        //    }

        //    for (i = 0; i < 4000; i++)
        //    {
        //        aux += Convert.ToString(i, 2).PadLeft(8, '0');
        //        aux += "\r\n";
        //    }

        //    tboxReadData.Clear();
        //    tboxReadData.Text = aux;

        //    file.Write(aux);
        //    file.Close();

        //}


        private void cBoxAqType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            usbcom = new USBCom();
            usbcom.Initialize();
            cBoxAqType.SelectedIndex = 0;
            //accdata = new byte[16384];
            //accdata = new byte[8192];
            tmerGeneral.Enabled = true;
            timerRead.Enabled = false;
            timerWatch.Enabled = false;
           
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            //bool read = false;
            //byte[] retD = new byte[500];
            
            //read = usbcom.receivedPkt(out retD);
            
            //tboxReadData.AppendText(read.ToString() + Environment.NewLine);

            Thread processo = new Thread(new ThreadStart(ExecutaThread));
            processo.Start();
                       
            if (!threadAtiva)
            {
                processo.Abort();                
            }


           // threadAtiva = true;
        }

        private void tmerGeneral_Tick(object sender, EventArgs e)
        {
            if (usbcom.USBavaiable)
            {
                toolStriplbelStatus1.Text = "USB : Conectado";
                btonAcquisition.Enabled = true;
            }
            else
            {
                toolStriplbelStatus1.Text = "USB : Desconectado";
                btonAcquisition.Enabled = false;
               
            }
        }

        private void timerWatch_Tick(object sender, EventArgs e)
        {
            timerCont += 1;
            labelTM.Text = Convert.ToString(timerCont);
           

        }


        void ExecutaThread()
         {
            bool read = false;
            //byte[] retD = new byte[500];

            byte[] retD = new byte[512];

            while (threadAtiva)
            {
                read = usbcom.receivedPkt(out retD);
                cont += 1;
            }
            this.Invoke(new MethodInvoker(delegate ()
            {
                tboxReadData.AppendText(read.ToString() + Environment.NewLine);                                
                labelCont.Text = Convert.ToString(cont);
            }));



        }



    }
}
