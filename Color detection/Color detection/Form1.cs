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
namespace Color_detection
{
   
    public partial class Form1 : Form
    {
        Bitmap newBitmap1;
        Bitmap newBitmap2;
        Bitmap newBitmap3;
        Bitmap newBitmap4;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox2.Hide();
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            label15.Text = "0";
            label16.Text = "0";
            label17.Text = "0";
            label18.Text = "0";
            try
            {
                //newBitmap1 = new Bitmap(OpenFileDialog1.FileName);
               // Color newColor1 = new Color();

                int posX = MousePosition.X;
                int posY = MousePosition.Y;
                positionX_lbl.Text = posX.ToString();
                positionY_lbl.Text = posY.ToString();
                Color Get_Color = newBitmap1.GetPixel(posX, posY);
                int a = Get_Color.A;
                int r = Get_Color.R; 
                int g = Get_Color.G;
                int b = Get_Color.B;
                Color _color = Color.FromArgb(a, r, g, b);
                label3.Text = a.ToString();
                label4.Text = r.ToString();
                label5.Text = g.ToString();
                label6.Text = b.ToString();
                newBitmap2=new Bitmap(selected_color.Image);
                for (int i = 0; i < newBitmap2.Width;i++ )
                {
                    for (int j = 0; j < newBitmap2.Height; j++)
                    {
                        newBitmap2.SetPixel(i,j,_color);
                    }
                }
                selected_color.Image = newBitmap2;
                pictureBox4.Image = newBitmap2;
                
            }
            catch
            {
                MessageBox.Show("Please Open a picture .","Notice ");
            }


            


           
        }

        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "All Files|*.*|JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            label15.Text = "0";
            label16.Text = "0";
            label17.Text = "0";
            label18.Text = "0";
            pictureBox2.Hide();
           
            if(OpenFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation=pictureBox3.ImageLocation = OpenFileDialog1.FileName;

                newBitmap1 = new Bitmap(OpenFileDialog1.FileName);
            }
        }

        private void positionY_lbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
               
                int trac_a = int.Parse(label15.Text);   
                int trac_r = int.Parse(label16.Text);
                int trac_g = int.Parse(label17.Text);
                int trac_b = int.Parse(label18.Text);

                newBitmap3 = new Bitmap(OpenFileDialog1.FileName);
                int _a = int.Parse(label3.Text);
                int _r = int.Parse(label4.Text);
                int _g = int.Parse(label5.Text);
                int _b = int.Parse(label6.Text);
                for (int i = 0; i < newBitmap3.Width; i++)
                {
                    
                    for (int j = 0; j < newBitmap3.Height; j++)
                    {
                        Color Get_Color = newBitmap1.GetPixel(i, j);
                        int a = Get_Color.A;
                        int r = Get_Color.R;
                        int g = Get_Color.G;
                        int b = Get_Color.B;
                        Color _color = Color.FromArgb(a, r, g, b);
                        Color color4 = Color.FromArgb(_a, _r, _g, _b);
                        newBitmap3.SetPixel(i, j, _color);
                        if (_color == color4)
                        {
                            newBitmap3.SetPixel(i, j, Color.FromArgb(trac_a, trac_r, trac_g, trac_b));

                        }
                        else
                        {
                            newBitmap3.SetPixel(i, j, _color);
                        }
                       
                    }

                   
                    
                }
                pictureBox2.Image = newBitmap3;
                pictureBox2.Show();

                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "The Color has been changed .";
                notifyIcon1.ShowBalloonTip(1000);
            }
            catch(Exception ex1)
            {
                MessageBox.Show("Process......."+ex1,"Notice");
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label16.Text = trackBar2.Value.ToString();
            newBitmap4 = new Bitmap(pictureBox4.Image);

            int trac_a = int.Parse(label15.Text);
            int trac_r = int.Parse(label16.Text);
            int trac_g = int.Parse(label17.Text);
            int trac_b = int.Parse(label18.Text);
            for (int i = 0; i < newBitmap4.Width; i++)
            {
                for (int j = 0; j < newBitmap4.Height; j++)
                {
                    newBitmap4.SetPixel(i, j, Color.FromArgb(trac_a, trac_r, trac_g, trac_b));
                }
               
            }
            pictureBox4.Image = newBitmap4;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            newBitmap4 = new Bitmap(pictureBox4.Image);
            
           label15.Text = trackBar1.Value.ToString();
            int trac_a = int.Parse(label15.Text);
            int trac_r = int.Parse(label16.Text);
            int trac_g = int.Parse(label17.Text);
            int trac_b = int.Parse(label18.Text);
            for (int i = 0; i < newBitmap4.Width; i++)
            {
                for (int j = 0; j < newBitmap4.Height; j++)
                {
                    newBitmap4.SetPixel(i,j,Color.FromArgb(trac_a,trac_r,trac_g,trac_b));
                }
            }
            pictureBox4.Image = newBitmap4;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label17.Text = trackBar3.Value.ToString();
            newBitmap4 = new Bitmap(pictureBox4.Image);
          
            int trac_a = int.Parse(label15.Text);
            int trac_r = int.Parse(label16.Text);
            int trac_g = int.Parse(label17.Text);
            int trac_b = int.Parse(label18.Text);
            for (int i = 0; i < newBitmap4.Width; i++)
            {
                for (int j = 0; j < newBitmap4.Height; j++)
                {
                    newBitmap4.SetPixel(i, j, Color.FromArgb(trac_a, trac_r, trac_g, trac_b));
                }
            }
            pictureBox4.Image = newBitmap4;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label18.Text = trackBar4.Value.ToString();
            newBitmap4 = new Bitmap(pictureBox4.Image);
           
            int trac_a = int.Parse(label15.Text);
            int trac_r = int.Parse(label16.Text);
            int trac_g = int.Parse(label17.Text);
            int trac_b = int.Parse(label18.Text);
            for (int i = 0; i < newBitmap4.Width; i++)
            {
                for (int j = 0; j < newBitmap4.Height; j++)
                {
                    newBitmap4.SetPixel(i, j, Color.FromArgb(trac_a, trac_r, trac_g, trac_b));
                }
            }
            pictureBox4.Image = newBitmap4;
        }
        SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog1.Filter = "Save file(*.jpg)|*.jpg|All files(*.*)|*.*";
            if(SaveFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                //pictureBox2.Image = SaveFileDialog1.FileName;
               
            }
        }
    }
}
