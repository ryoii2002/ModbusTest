using System.Net.Sockets;

namespace ModbusTest
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
            tcpClient = new TcpClient("127.0.0.1", 502); // 소켓 초기화
            stream = tcpClient.GetStream();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        int nTranscation = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] send = new byte[128];
            byte[] recv = new byte[128];

            send[0] = (byte)(nTranscation / 256);
            send[1] = (byte)(nTranscation % 256);
            send[2] = 0;
            send[3] = 0;
            send[4] = 0;
            send[5] = 6;
            send[6] = 1; //slave ID
            send[7] = 1; //Read Coil
            send[8] = 0; //Start address
            send[9] = 0; //start address
            send[10] = 0;
            send[11] = 1; //요청 data 수

            stream.Write(send, 0, send.Length); //데이터 보내기
            stream.Read(recv, 0, recv.Length); //데이터 받기

            if (recv[9] == 1) MessageBox.Show("true");
            if (recv[9] == 0) MessageBox.Show("false");

            nTranscation++;
        }
    }
}
