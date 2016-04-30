using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace PageCapture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string unique = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
                string content = GetHtmlPage(tbUrl.Text.ToString());

                string path = "C:\\Users\\User\\Desktop\\Research\\sample_" + unique + ".txt";
                File.WriteAllText(path, content);
                MessageBox.Show("Saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private string GetHtmlPage(string strURL)
        {

            String strResult;
            WebResponse objResponse;
            WebRequest objRequest = HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();

                sr.Close();
            }
            // strResult = strResult.Remove(0, strResult.LastIndexOf("<table>"));
            string[] values = strResult.Split(new string[] { "<tbody>", "</tbody>" }, StringSplitOptions.RemoveEmptyEntries);


            return strResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
