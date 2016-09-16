using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulkMessagingAppPC
{
    class SmsEngine
    {
        SerialPort serialPort;
        Random rnd = new Random();
        int interval = 0;
        public SmsEngine(string comPort, int interval)
        {
            this.serialPort = new SerialPort();
            this.serialPort.PortName = comPort;
            this.serialPort.BaudRate = 9600;
            this.serialPort.Parity = Parity.None;
            this.serialPort.DataBits = 8;
            this.serialPort.StopBits = StopBits.One;
            this.serialPort.Handshake = Handshake.RequestToSend;
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            this.serialPort.NewLine = System.Environment.NewLine;
            this.interval = interval;

        }

        public bool sendSms(string number, string message)
        {
            Application.DoEvents();
            string messages = null;
            messages = message;
            if (this.serialPort.IsOpen == true)
            {
                try
                {
                    Application.DoEvents();
                    switch (interval)
                    {
                        case 0:
                            Thread.Sleep(rnd.Next(1000, 2000));
                            break;
                        case 1:
                            Thread.Sleep(rnd.Next(2000, 3000));
                            break;

                        case 2:
                            Thread.Sleep(rnd.Next(3000, 4000));
                            break;

                        case 3:
                            Thread.Sleep(rnd.Next(4000, 5000));
                            break;
                        case 4:
                            Thread.Sleep(rnd.Next(5000, 6000));
                            break;
                        case 5:
                            Thread.Sleep(rnd.Next(6000, 7000));
                            break;

                        default:
                            Thread.Sleep(4000);
                            break;
                    }

                    this.serialPort.WriteLine("AT" + (char)(13));
                    Thread.Sleep(4);
                    this.serialPort.WriteLine("AT+CMGF=1" + (char)(13));
                    Thread.Sleep(5);
                    this.serialPort.WriteLine("AT+CMGS=\"" + number + "\"");
                    Thread.Sleep(10);
                    this.serialPort.WriteLine("" + messages + (char)(26));
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Source);
                }
                return true;
            }
            else
                return false;
        }
        public bool sendSms(string cellNo, string sms, int times)
        {
            string messages = null;
            messages = sms;
            if (this.serialPort.IsOpen == true)
            {
                for(int i = times; times > 0; times--)
                {
                    try
                    {
                        Application.DoEvents();
                        this.serialPort.WriteLine("AT" + (char)(13));
                        Thread.Sleep(4);
                        this.serialPort.WriteLine("AT+CMGF=1" + (char)(13));
                        Thread.Sleep(5);
                        this.serialPort.WriteLine("AT+CMGS=\"" + cellNo + "\"");
                        Thread.Sleep(10);
                        this.serialPort.WriteLine("" + messages + (char)(26));
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Source);
                    }
                }
                return true;
            }
            else
                return false;
        }



        public void openPort()
        {
            if (this.serialPort.IsOpen == false)
            {
                this.serialPort.Open();
            }
        }

        public void closePort()
        {
            if (this.serialPort.IsOpen == true)
            {
                this.serialPort.Close();
            }
        }
    }


}
