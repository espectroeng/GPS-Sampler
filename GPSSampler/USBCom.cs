using System;
using System.Text;
using CyUSB;

namespace GPSSampler
{
    public class USBCom
    {

        //Constantes*******************************************************
        const int MAXREADPKTSIZE = 262; // (256 bytes de dados do pacote + 6 cabeçalho)
        const int RESPWPKTSIZE = 11; // (0x80 0x00 0x00 DONE!\r\n 0x00)
        const int RESPRPKTSIZE = 14; // (0x80 0x00 0x00 READ:x??\r\n0x00)
        //*****************************************************************


        private USBDeviceList usbDevices = null;  //Objeto que ira conter a lista de dispositivos USB plugados ao sistema
        private CyUSBDevice myDevice = null; //Objeto que recebe um dispositivo da lista para os demais acessos
        private CyFX2Device fx2 = null; //objeto que recebe um dispositivo da lista para gravação do firmware na RAM
        private CyUSBEndPoint EndptOut, EndptIn; //objetos responsaveis pelos endpoints IN E OUT


        //Atributos *****************
        private bool uSBavaiable = false; //flag que indica se USB esta presente ou nao.

        public bool USBavaiable
        {
            get { return uSBavaiable; }
        }

        private int maxPkgSizeIn;

        public int MaxPkgSizeIn
        {
            get { return maxPkgSizeIn; }
            //set { maxPkgSizeIn = value; }
        }

        private int maxPkgSizeOut;

        public int MaxPkgSizeOut
        {
            get { return maxPkgSizeOut; }
        }

        private string firmFile = "firmbulk.hex"; //define caminho do firmware do mc cypress;

        public string FirmFile
        {
            get { return firmFile; }
            set { firmFile = value; }
        }

        private string errorMsg = null;

        public string ErrorMsg
        {
            get { return errorMsg; }
        }


        public bool Initialize()
        {
            int count = 0;

            CyConst.SetClassGuid("{CDBF8987-75F1-468e-8217-97197F88F773}");
            usbDevices = new USBDeviceList(CyConst.DEVICES_CYUSB);
            usbDevices.DeviceAttached += new EventHandler(usbDevices_DeviceAttached); //atribuindo evento de remoção física do dispositivo USB
            usbDevices.DeviceRemoved += new EventHandler(usbDevices_DeviceRemoved); //atribuindo evento de conecção física do dispositivo USB
            fx2 = usbDevices[0x04B4, 0x8613] as CyFX2Device; //criando objeto para dispositivo com VID/PID especificado

            if (fx2 != null) //caso dispositivo exista executa:
            {
                fx2.LoadRAM(firmFile);  //carregando arquivo do firmware para o chip cypress
                fx2.ReConnect(); //forca reconexao do dispositivo USB
                System.Threading.Thread.Sleep(1000); //aguarda 1 segundo para reenumeracao

            } //reenumeracao iniciada


            do //tenta atualizar os dipositivos ate encontrar um novo com PID diferente (apos reenumeracao)
            {
                System.Threading.Thread.Sleep(500); //atraso para espera da reenumeracao
                usbDevices.Dispose(); //destroi lista antiga de dispositivos
                usbDevices = new USBDeviceList(CyConst.DEVICES_CYUSB); //constroi uma lista nova
                usbDevices.DeviceAttached += new EventHandler(usbDevices_DeviceAttached); //atribuindo evento de remoção física do dispositivo USB
                usbDevices.DeviceRemoved += new EventHandler(usbDevices_DeviceRemoved); //atribuindo evento de conecção física do dispositivo USB
                myDevice = usbDevices[0x04B4, 0x1003] as CyUSBDevice; //instancia objeto com VID/PID especificado
                count++;
            }
            while (myDevice == null && count <= 6); //caso dispositivo nao exista para depois de 6 tentativas (3 seg)

            if (myDevice == null)
            {
                uSBavaiable = false;
                return false;
            }
            else
            {
                uSBavaiable = true;
                EndptOut = myDevice.EndPointOf(0x02) as CyBulkEndPoint;// Estabelecendo endpoint OUT
                EndptOut.Abort();
                EndptOut.Reset();
                EndptIn = myDevice.EndPointOf(0x86) as CyBulkEndPoint;// Estabelecendo endpoint IN
                EndptIn.Abort();
                EndptIn.Reset();
                maxPkgSizeIn = EndptIn.MaxPktSize;
                maxPkgSizeOut = EndptOut.MaxPktSize;
                //  EndptIn.XferMode = XMODE.

                EndptOut.TimeOut = 1000;
                EndptIn.TimeOut = 500;

                if (EndptIn == null || EndptOut == null) //verifica se houve erro.
                {
                    uSBavaiable = false; //indica USB off caso algum endpoint não esteja disponível
                    return false;
                }

                return true; //tudo ok na inicialização
            }

        }

        private void ClearBufferOut()
        {
            EndptOut.Abort();
            EndptOut.Reset();
        }

        private void ClearBufferIn()
        {
            EndptIn.Abort();
            EndptIn.Reset();
        }

        public void Dispose()
        {
            if (usbDevices != null)
            {
                usbDevices.DeviceRemoved -= usbDevices_DeviceRemoved;
                usbDevices.DeviceAttached -= usbDevices_DeviceAttached;
                myDevice.Dispose();
                usbDevices.Dispose();
            }

        }

        //Metodo que trata o evento de remocao do cabo USB
        private void usbDevices_DeviceRemoved(object sender, EventArgs e)
        {
            uSBavaiable = false;
            USBEventArgs usbEvent = e as USBEventArgs;
        }


        //Metodo que trata o evento de insercao do cabo USB
        private void usbDevices_DeviceAttached(object sender, EventArgs e)
        {
            USBEventArgs usbEvent = e as USBEventArgs;
            Initialize(); //inicializa o processo de reconhecimento do dispositivo
        }


        public void disposeDevice()
        {
            myDevice.Dispose();
            usbDevices.Dispose();

        }

        public bool sendWritePkt(string device, int address, int data)
        {
            string auxAddr, auxData;
            byte[] bufferOut, bufferIn;
            int len;

            auxAddr = address.ToString("X4");
            auxData = data.ToString("X2");
            bufferOut = new byte[] { 0x80, 0x00, 0x00, (byte)'W', 0x20, (byte)device[0], (byte)device[1], (byte)device[2], 0x20, (byte)auxAddr[0], (byte)auxAddr[1], (byte)auxAddr[2], (byte)auxAddr[3], 0x20, (byte)auxData[0], (byte)auxData[1], (byte)'\r', (byte)'\n', 0x00 };
            bufferIn = new byte[EndptIn.MaxPktSize];


            //limpando buffers*********
            ClearBufferOut();
            ClearBufferIn();
            //************************


            try
            {
                if (EndptOut != null) //Verifica se Endpoint existe
                {
                    len = bufferOut.Length;
                    if (uSBavaiable) //USB disponível?
                    {
                        //Escrevendo no device
                        if (EndptOut.XferData(ref bufferOut, ref len, false)) //retorna falso em caso de falha no envio
                        {
                            errorMsg = null;
                        }
                        else
                        {
                            errorMsg = "USB Error! Error to send. Error code = " + EndptOut.LastError.ToString();
                            return false;
                        }

                        //Checando retorno do device
                        len = EndptIn.MaxPktSize;
                        EndptIn.XferData(ref bufferIn, ref len);
                        if (bufferIn[3] != (char)'D')
                        {
                            errorMsg = "USB Error! Incorrect response from the device (response = " + Encoding.UTF8.GetString(bufferIn) + " )";
                            return false;
                        }

                        return true; //Escrita sem erros
                    }
                    else
                    {
                        errorMsg = "USB Error! USB is not avaiable. Please, check te cable connection";
                        return false;
                    }
                }
                else
                {
                    errorMsg = "USB Error! Endpoint is not avaiable";
                    return false; //Endpoint Inexistente
                }
            }
            catch (Exception ex)
            {
                errorMsg = "USB Error! " + ex.Message;
                return false;
            }

        }

        public bool sendReadPkt(string device, int address, out byte[] retData)
        {
            string auxAddr;
            byte[] bufferOut, bufferIn;
            int len, i;

            auxAddr = address.ToString("X4");
            bufferOut = new byte[] { 0x80, 0x00, 0x00, (byte)'R', 0x20, (byte)device[0], (byte)device[1], (byte)device[2], 0x20, (byte)auxAddr[0], (byte)auxAddr[1], (byte)auxAddr[2], (byte)auxAddr[3], (byte)'\r', (byte)'\n', 0x00 };
            bufferIn = new byte[MAXREADPKTSIZE];
            retData = null;

            //limpando buffers*********
            ClearBufferOut();
            ClearBufferIn();
            //************************


            try
            {
                if (EndptOut != null) //Verifica se Endpoint existe
                {
                    len = bufferOut.Length;
                    if (uSBavaiable) //USB disponível?
                    {
                        //Escrevendo no device
                        if (EndptOut.XferData(ref bufferOut, ref len, false)) //retorna falso em caso de falha no envio
                        {
                            errorMsg = null;
                        }
                        else
                        {
                            errorMsg = "USB Error! Error to send. Error code = " + EndptOut.LastError.ToString();
                            return false;
                        }

                        //Checando retorno do device
                        len = EndptIn.MaxPktSize;

                        EndptIn.XferData(ref bufferIn, ref len);
                        if (bufferIn[7] != (char)':' && bufferIn[3] != device[0])
                        {
                            errorMsg = "USB Error! Incorrect response from the device (response = " + Encoding.UTF8.GetString(bufferIn) + " )";
                            return false;
                        }

                        if (len == RESPRPKTSIZE && bufferIn[7] == ':') //READ:x??\r\n retornado
                        {
                            retData = new byte[1];
                            retData[0] = Convert.ToByte((((char)bufferIn[9]).ToString() + ((char)bufferIn[10]).ToString()), 16);
                        }
                        else
                        {
                            retData = new byte[256]; //256 bytes de dados retornados (+ cabeçalho de 6 bytes)
                            for (i = 6; i < 262; i++)
                                retData[i - 6] = (byte)bufferIn[i];
                        }
                        return true; //Escrita sem erros
                    }
                    else
                    {
                        errorMsg = "USB Error! USB is not avaiable. Please, check te cable connection";
                        return false;
                    }
                }
                else
                {
                    errorMsg = "USB Error! Endpoint is not avaiable";
                    return false; //Endpoint Inexistente
                }

            }
            catch (Exception ex)
            {
                errorMsg = "USB Error! " + ex.Message;
                return false;
            }

        }
    }
}
