using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 电子书阅读器0._9
{
    public partial class Form1 : Form
    {
        
        static string[] t = { "资本论（节选）.txt", "资本论（节选2）.txt", "资本论（节选3）.txt", "", "", "", "", "", "", "", "", "", "", "", "" };
        int hum=0;
        int start;
        int i = 3;
        int m;
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("资本论（节选）.txt");
            listBox1.Items.Add("资本论（节选2）.txt");
            listBox1.Items.Add("资本论（节选3）.txt");

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            //将列表listbox中选定项的索引加载到richTextBox1中
            if (listBox1.SelectedIndex >= 0)
            { 
                richTextBox1.LoadFile(t[this.listBox1.SelectedIndex], RichTextBoxStreamType.PlainText);
                hum = 0;
             }
            m = richTextBox1.TextLength / 485;
            textBox2.Text = "该书页数："+m;
            //if (this.richTextBox1.TextChanged)
               // hum = 0;
            
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < t.Length)
                hum = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //添加书本
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Application.StartupPath;  //默认目录为exe运行文件所在的文件夹
            fileDialog.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt";  //设置控件打开的文件类型
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;
           
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                t[i] = fileDialog.FileName;
                listBox1.Items.Add(fileDialog.FileName);  
                i++;
                richTextBox1.LoadFile(fileDialog.FileName, RichTextBoxStreamType.PlainText);

            }
            
        }

  
         
        private void button1_Click(object sender, EventArgs e)//上翻
        {
            
          if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < t.Length)
                if (File.Exists(t[listBox1.SelectedIndex]))
                {
                    if (m != 0)
                    {
                        if (hum <= 0)
                        {

                            //this.richTextBox1.Select(richTextBox1.Text.Length,richTextBox1.Text.Length);
                            start = this.richTextBox1.GetFirstCharIndexFromLine(0);
                            this.richTextBox1.SelectionStart = start;
                            this.richTextBox1.ScrollToCaret();

                        }
                        else
                        {

                            if (numericUpDown1.Value != 0)
                            {
                                numericUpDown1.Value--;
                            }
                            hum = hum - 25;
                            start = this.richTextBox1.GetFirstCharIndexFromLine(hum);
                            this.richTextBox1.SelectionStart = start;
                            this.richTextBox1.ScrollToCaret();
                        }
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)//下翻
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < t.Length)
                if (File.Exists(t[listBox1.SelectedIndex]))
            {
                if (m != 0)
                {
                    int x1;
                    x1 = richTextBox1.Text.Length / 22;
                    if (hum > x1)
                    {
                        this.richTextBox1.Select(richTextBox1.Text.Length, 0);
                        this.richTextBox1.ScrollToCaret();

                    }
                    else
                    {

                        if (numericUpDown1.Value != m)
                        {
                            numericUpDown1.Value++;
                        }
                        hum = hum + 25;
                        start = this.richTextBox1.GetFirstCharIndexFromLine(hum);
                        this.richTextBox1.SelectionStart = start;
                        this.richTextBox1.ScrollToCaret();

                    }
                    // this.richTextBox1.Select(richTextBox1.Text.Length, 0);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = m;
            numericUpDown1.Minimum = 0;
            StreamReader sr =null;
            string text = null;
            if(listBox1.SelectedIndex>=0 && listBox1.SelectedIndex<t.Length)
                if(File.Exists(t[listBox1.SelectedIndex]))
                {
                    sr=new StreamReader(t[listBox1.SelectedIndex],System.Text.Encoding.Default);
                    text=sr.ReadToEnd();
                    sr.Close();
                }
            if(listBox1.SelectedIndex!=-1)
            {
              if((int)numericUpDown1.Value<m && (int)numericUpDown1.Value>0)
              {
                  int gom = (int)numericUpDown1.Value * 25;
                  start = this.richTextBox1.GetFirstCharIndexFromLine(gom);
                  this.richTextBox1.SelectionStart = start;
                  this.richTextBox1.ScrollToCaret();
                  
              }
              else if(numericUpDown1.Value==0)
              {
                  start = this.richTextBox1.GetFirstCharIndexFromLine(0);
                  this.richTextBox1.SelectionStart = start;
                  this.richTextBox1.ScrollToCaret();
              }
            }
        }
         



        private void textBox2_TextChanged(object sender, EventArgs e) //当前页数
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       /* class Book
    {
        private int length;
        private string text;
            
        public void setLength(int length)
        {
            this.length = length;
        }
        public int getLength() 
        {
            return length;
        }
        public void setText(string text)
        {
            this.text = text;
        }
        public string getText()
        {
            return text;
        }
        public string getPage(int pageNumber,int a) //翻页  
        {
            if (length > 0)
            {
                // 总页数=1+【（总字数-不足一页的字数）】/每页字数
                int totalPages = ((length - text.Length % length) + text.Length) / length;
                //页码>0、页码<总页数、总页数>0
                if (pageNumber > 0 && pageNumber <= totalPages && totalPages > 0)
                {
                    // 跳至指定页，需要跳过多少字为pageTop
                    int pageTop = length * (pageNumber - 1);
                    //如果阅读页没有超过总字数，返回输入页数，否则返回
                    if (pageTop + length < text.Length)
                        return text.Substring(pageTop,a);
                    else
                        return text.Substring(pageTop, text.Length - pageTop);
                }
            }
                return null;
        }

      
    }
        */
    }
}

    

