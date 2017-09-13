using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GPSSampler
{
    public partial class Form1 : Form
    {
        USBCom usbcom;
        byte[] data, accdata;
        string aux;
        StreamWriter file;

        public Form1()
        {
            InitializeComponent();
            usbcom = new USBCom();
            cBoxAqType.SelectedIndex = 0;
            accdata = new byte[16384];
            tmerGeneral.Enabled = true;
        }

        private void btonAcquisition_Click(object sender, EventArgs e)
        {
            int i;
            file = new StreamWriter("ReadData.txt");
            usbcom.sendWritePkt("ALG", 0x10, (byte)cBoxAqType.SelectedIndex);
            usbcom.sendWritePkt("ALG", 0x11, 0x01);
            aux = null;
            for (i = 0; i < 16384; i += 256)
            {
                data = new byte[256];
                usbcom.sendReadPkt("BRM", i, out data);
                data.CopyTo(accdata, i);
            }

            for (i = 0; i < 16384; i ++)
            {
                aux += Convert.ToString(i, 2).PadLeft(8, '0');
                aux += "\r\n";
            }

            tboxReadData.Clear();
            tboxReadData.Text = aux;
            
            file.Write(aux);
            file.Close();
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
    }
}
