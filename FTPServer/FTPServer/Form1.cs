using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;


namespace FTPServer
{
    public partial class Form1 : Form
    {
        private TcpClient cmdServer;
        private TcpClient dataServer;
        private NetworkStream cmdStrmWtr;
        private StreamReader cmdStrmRdr;
        private NetworkStream dataStrmWtr;
        private StreamReader dataStrmRdr;
        private String cmdData;
        private byte[] szData;
        private const String CRLF = "\r\n";
        
        public Form1()
        {
            InitializeComponent();
        }
        #region  Private Functions

        /// <summary>
        /// 获取命令端口返回结果，并记录在lsb_status上
        /// </summary>
        private String getSatus()
        {

            String ret = cmdStrmRdr.ReadLine();
            lsb_status.Items.Add(ret);
            lsb_status.SelectedIndex = lsb_status.Items.Count - 1;
            return ret;
        }

        /// <summary>
        /// 进入被动模式，并初始化数据端口的输入输出流
        /// </summary>
        private void openDataPort()
        {
            string retstr;
            string[] retArray;
            int dataPort;

            // Start Passive Mode 
            cmdData = "PASV" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            retstr = this.getSatus();

            // Calculate data's port
            retArray = Regex.Split(retstr, ",");
            if (retArray[5][2] != ')') retstr = retArray[5].Substring(0, 3);
            else retstr = retArray[5].Substring(0, 2);
            dataPort = Convert.ToInt32(retArray[4]) * 256 + Convert.ToInt32(retstr);
            lsb_status.Items.Add("Get dataPort=" + dataPort);


            //Connect to the dataPort
            dataServer = new TcpClient(tb_IP.Text, dataPort);
            dataStrmRdr = new StreamReader(dataServer.GetStream());
            dataStrmWtr = dataServer.GetStream();
        }

        /// <summary>
        /// 断开数据端口的连接
        /// </summary>
        private void closeDataPort()
        {
            dataStrmRdr.Close();
            dataStrmWtr.Close();
            this.getSatus();

            cmdData = "ABOR" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

        }

        /// <summary>
        /// 获得/刷新 右侧的服务器文件列表
        /// </summary>
        private void freshFileBox_Right()
        {

            openDataPort();

            string absFilePath;

            //List
            cmdData = "LIST" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

            lsb_server.Items.Clear();
            while ((absFilePath = dataStrmRdr.ReadLine()) != null)
            {
                string[] temp = Regex.Split(absFilePath, " ");
                lsb_server.Items.Add(temp[temp.Length - 1]);
            }

            closeDataPort();
        }

        /// <summary>
        /// 获得/刷新 左侧的本地文件列表
        /// </summary>
        private void freshFileBox_Left()
        {
            lsb_local.Items.Clear();
            if (tb_path.Text == "") return;
            var files = Directory.GetFiles(tb_path.Text, "*.*");
            foreach (var file in files)
            {
                Console.WriteLine(file);
                string[] temp = Regex.Split(file, @"\\");
                lsb_local.Items.Add(temp[temp.Length - 1]);
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (btn_conn.Text == "连接")
            {
                Cursor cr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                cmdServer = new TcpClient(tb_IP.Text, Convert.ToInt32(tb_port.Text));
                lsb_status.Items.Clear();
                try
                {
                    cmdStrmRdr = new StreamReader(cmdServer.GetStream());
                    cmdStrmWtr = cmdServer.GetStream();
                    this.getSatus();

                    string retstr;

                    //Login
                    cmdData = "USER " + tb_username.Text + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    this.getSatus();

                    cmdData = "PASS " + tb_password.Text + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    retstr = this.getSatus().Substring(0, 3);
                    if (Convert.ToInt32(retstr) == 530) throw new InvalidOperationException("帐号密码错误");

                    this.freshFileBox_Right();

                    lb_IP.Text = tb_IP.Text + ":";
                    btn_conn.Text = "断开";
                    btn_upload.Enabled = true;
                    btn_download.Enabled = true;
                }
                catch (InvalidOperationException err)
                {
                    lsb_status.Items.Add("ERROR: " + err.Message.ToString());
                }
                finally
                {
                    Cursor.Current = cr;
                }
            }
            else
            {
                Cursor cr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                //Logout

                cmdData = "QUIT" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.getSatus();


                cmdStrmWtr.Close();
                cmdStrmRdr.Close();

                lb_IP.Text = "";
                btn_conn.Text = "连接";
                btn_upload.Enabled = false;
                btn_download.Enabled = false;
                lsb_server.Items.Clear();

                Cursor.Current = cr;
            }
        }

        private void btn_setPath_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                lsb_status.Items.Add("选中本地路径:" + path);
            }

            tb_path.Text = path;
            freshFileBox_Left();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (tb_path.Text == "" || lsb_local.SelectedIndex < 0)
            {
                MessageBox.Show("请选择上传的文件", "ERROR");
                return;
            }

            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string fileName = lsb_local.Items[lsb_local.SelectedIndex].ToString();
            string filePath = tb_path.Text + "\\" + fileName;

            this.openDataPort();

            cmdData = "STOR " + fileName + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

            FileStream fstrm = new FileStream(filePath, FileMode.Open);
            byte[] fbytes = new byte[1030];
            int cnt = 0;
            while ((cnt = fstrm.Read(fbytes, 0, 1024)) > 0)
            {
                dataStrmWtr.Write(fbytes, 0, cnt);
            }
            fstrm.Close();

            this.closeDataPort();

            this.freshFileBox_Right();

            Cursor.Current = cr;
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (tb_path.Text == "" || lsb_server.SelectedIndex < 0)
            {
                MessageBox.Show("请选择目标文件和下载路径", "ERROR");
                return;
            }

            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string fileName = lsb_server.Items[lsb_server.SelectedIndex].ToString();
            string filePath = tb_path.Text + "\\" + fileName;

            this.openDataPort();

            cmdData = "RETR " + fileName + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

            FileStream fstrm = new FileStream(filePath, FileMode.OpenOrCreate);
            char[] fchars = new char[1030];
            byte[] fbytes = new byte[1030];
            int cnt = 0;
            while ((cnt = dataStrmWtr.Read(fbytes, 0, 1024)) > 0)
            {
                fstrm.Write(fbytes, 0, cnt);
            }
            fstrm.Close();

            this.closeDataPort();

            this.freshFileBox_Left();

            Cursor.Current = cr;
        }
    }
}
