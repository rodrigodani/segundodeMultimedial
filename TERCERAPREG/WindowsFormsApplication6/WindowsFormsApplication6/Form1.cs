using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;
        int cR2, cG2, cB2;
        int cR3, cG3, cB3;
        int cR4, cG4, cB4;
        int cROr, cGOr, cBOr;
        string puntos = "";
        string fotoGuardada;
        List<String> Todoslospuntos = new List<String>();
        List<String> ColoresPuntos = new List<String>();
        List<String> nombresPuntos = new List<String>();
        bool guardado = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            //pictureBox1.Image = bmp;


            ///////
            //checkedListBox1.Items.Clear();
            Todoslospuntos.Clear();
            ColoresPuntos.Clear();
            nombresPuntos.Clear();
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "Image Files(*.BMP;*.PNG;*.JPG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
            string carpeta = @"fotos\\";
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\fotos\"; // <---
            if (Directory.Exists(appPath) == false)                                              // <---
            {                                                                                    // <---
                Directory.CreateDirectory(appPath);                                              // <---
            }                                                                                    // <---

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.SafeFileName;   // <---
                    string filepath = opFile.FileName;    // <---
                    File.Copy(filepath, appPath + iName); // <---
                    pictureBox1.Image = new Bitmap(opFile.OpenFile());
                    DataRowCollection idFotoGuardada = fotos.subirfoto(carpeta + iName).Rows;
                    fotoGuardada = idFotoGuardada[0].ItemArray[0].ToString();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }

        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(10, 10);
            //textBox1.Text = c.R.ToString();
            //textBox2.Text = c.G.ToString();
            //textBox3.Text = c.B.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cR = c.R;
            cG = c.G;
            cB = c.B;*/
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color color = new Color();
            int x, y, mR = 0, mG = 0, mB = 0;
            int mR2 = 0, mG2 = 0, mB2 = 0;
            int mR3 = 0, mG3 = 0, mB3 = 0;
            int mR4 = 0, mG4 = 0, mB4 = 0;
            int mROr = 0, mGOr = 0, mBOr = 0;
            //ponemos la posicion del raton
            x = e.X; y = e.Y;

            int x1, y1, x2, y2, x3, y3, x4, y4;






            x1 = x - 10;
            y1 = y - 10;

            x2 = x + 10;
            y2 = y - 10;

            x3 = x - 10;
            y3 = y + 10;

            x4 = x + 10;
            y4 = y + 10;


            for (int i = x; i < x + 10; i++)
            {
                for (int j = y; j < y + 10; j++)
                {
                    color = bmp.GetPixel(i, j);
                    mROr = mROr + color.R;
                    mGOr = mGOr + color.G;
                    mBOr = mBOr + color.B;
                }
            }






            for (int i = x1; i < x1 + 15; i++)
            {
                for (int j = y1; j < y1 + 15; j++)
                {
                    if (i > bmp.Width)
                    {
                        i = bmp.Width - 1;
                    }
                    if (j > bmp.Height)
                    {
                        j = bmp.Height - 1;
                    }
                    color = bmp.GetPixel(i, j);
                    mR = mR + color.R;
                    mG = mG + color.G;
                    mB = mB + color.B;
                }
            }

            for (int i = x2; i < x2 + 15; i++)
            {
                for (int j = y2; j < y2 + 15; j++)
                {
                    if (i > bmp.Width)
                    {
                        i = bmp.Width - 1;
                    }
                    if (j > bmp.Height)
                    {
                        j = bmp.Height - 1;
                    }
                    color = bmp.GetPixel(i, j);
                    mR2 = mR2 + color.R;
                    mG2 = mG2 + color.G;
                    mB2 = mB2 + color.B;
                }
            }
            for (int i = x3; i < x3 + 15; i++)
            {
                for (int j = y3; j < y3 + 15; j++)
                {
                    if (i > bmp.Width)
                    {
                        i = bmp.Width - 1;
                    }
                    if (j > bmp.Height)
                    {
                        j = bmp.Height - 1;
                    }
                    color = bmp.GetPixel(i, j);
                    mR3 = mR3 + color.R;
                    mG3 = mG3 + color.G;
                    mB3 = mB3 + color.B;
                }
            }
            for (int i = x4; i < x4 + 15; i++)
            {
                for (int j = y4; j < y4 + 15; j++)
                {
                    if (i > bmp.Width)
                    {
                        i = bmp.Width - 1;
                    }
                    if (j > bmp.Height)
                    {
                        j = bmp.Height - 1;
                    }
                    color = bmp.GetPixel(i, j);
                    mR4 = mR4 + color.R;
                    mG4 = mG4 + color.G;
                    mB4 = mB4 + color.B;
                }
            }




            mROr = mROr / 225;
            mGOr = mGOr / 225;
            mBOr = mBOr / 225;

            mR = mR / 225;
            mG = mG / 225;
            mB = mB / 225;

            mR2 = mR2 / 225;
            mG2 = mG2 / 225;
            mB2 = mB2 / 225;

            mR3 = mR3 / 225;
            mG3 = mG3 / 225;
            mB3 = mB3 / 225;

            mR4 = mR4 / 225;
            mG4 = mG4 / 225;
            mB4 = mB4 / 225;


            cROr = mROr;
            cGOr = mGOr;
            cBOr = mBOr;

            cR = mR;
            cG = mG;
            cB = mB;

            cR2 = mR2;
            cG2 = mG2;
            cB2 = mB2;

            cR3 = mR3;
            cG3 = mG3;
            cB3 = mB3;

            cR4 = mR4;
            cG4 = mG4;
            cB4 = mB4;







            //textBox1.Text = cR.ToString();
            //textBox2.Text = cG.ToString();
            //textBox3.Text = cB.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(c.R, 0, 0));
                }
            pictureBox2.Image = cpoa;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox2.Image = cpoa;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
            String nombreCapa = textBox2.Text;
            if (nombreCapa.Equals(""))
            {
                MessageBox.Show("no tiene un nombre");
                return;
            }
            //fotos.eliminaCapasdeFoto(fotoseleccionada.Text);
            guardado = false;


            puntos = "";
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.


            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                textBox1.BackColor = MyDialog.Color;

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = pictureBox1.Image;
                Bitmap cpoa = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            else
            {
                Bitmap cpoa = new Bitmap(pictureBox2.Image, pictureBox1.Width, pictureBox1.Height);
            }

            Color c = new Color();
            //

            //MessageBox.Show(bmp.Width+"");
            for (int i = 1; i < pictureBox1.Width - 1; i++)
            {
                for (int j = 1; j < pictureBox1.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cR - 12) < c.R) && (c.R < (cR + 12)) && ((cG - 12) < c.G) && (c.G < (cG + 12)) && ((cB - 12) < c.B) && (c.B < (cB + 12))
                        ||
                        ((cR2 - 12) < c.R) && (c.R < (cR2 + 12)) && ((cG2 - 12) < c.G) && (c.G < (cG2 + 12)) && ((cB2 - 12) < c.B) && (c.B < (cB2 + 12))
                        ||
                        ((cR3 - 12) < c.R) && (c.R < (cR3 + 12)) && ((cG3 - 12) < c.G) && (c.G < (cG3 + 12)) && ((cB3 - 12) < c.B) && (c.B < (cB3 + 12))
                        ||
                        ((cR4 - 12) < c.R) && (c.R < (cR4 + 12)) && ((cG4 - 12) < c.G) && (c.G < (cG4 + 12)) && ((cB4 - 12) < c.B) && (c.B < (cB4 + 12))
                        ||
                        ((cROr - 12) < c.R) && (c.R < (cROr + 12)) && ((cGOr - 12) < c.G) && (c.G < (cGOr + 12)) && ((cBOr - 12) < c.B) && (c.B < (cBOr + 12))
                        )
                    {
                        //cpoa.SetPixel(i, j, Color.Red);
                        puntos = puntos + i + "," + j + ";";

                    }
                    else
                    {
                        //cpoa.SetPixel(i, j, c);
                    }

                }
            }


            //pictureBox2.Image = cpoa;

            colorear(sender, e, textBox1.BackColor, nombreCapa);
             */
        }

        private void colorear(object sender, EventArgs e, Color color, string nombrecapa)
        {
            Todoslospuntos.Add(puntos);
            ColoresPuntos.Add(color.R + ";" + color.G + ";" + color.B + ";" + color.A);
            nombresPuntos.Add(nombrecapa);

            Bitmap cpoa = new Bitmap(pictureBox2.Image);

            Color c = new Color();

            //for (int i = 0; i < Todoslospuntos.Count; i++) {
            string[] pun = puntos.Split(';');
            for (int j = 0; j < pun.Length - 1; j++)
            {
                string[] xy = pun[j].Split(',');
                cpoa.SetPixel(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]), color);
            }

            //}
            pictureBox2.Image = cpoa;

            //checkedListBox1.Items.Add(nombrecapa, true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String nombreCapa = textBox2.Text;
            if (nombreCapa.Equals(""))
            {
                MessageBox.Show("no tiene un nombre");
                return;
            }
            //fotos.eliminaCapasdeFoto(fotoseleccionada.Text);
            guardado = false;

            puntos = "";
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.


            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                textBox1.BackColor = MyDialog.Color;

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = pictureBox1.Image;
                Bitmap cpoa = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            else
            {
                Bitmap cpoa = new Bitmap(pictureBox2.Image, pictureBox1.Width, pictureBox1.Height);
            }

            Color c = new Color();





            int meR, meG, meB;
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            //Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            //Color c = new Color();
            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;

                    if (((cR - 10) < meR) && (meR < (cR + 10)) && ((cG - 10) < meG) && (meG < (cG + 10)) && ((cB - 10) < meB) && (meB < (cB + 10)))
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                //cpoa.SetPixel(k, l, Color.Black);
                                puntos = puntos + k + "," + l + ";";
                            }

                    else
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                //cpoa.SetPixel(k, l, c);
                            }
                }
            //pictureBox2.Image = cpoa;}
            colorear(sender, e, textBox1.BackColor, nombreCapa);
        }

        private void Form1_Load(object sender, EventArgs e)
        { /*
            DataRowCollection datos = fotos.LeeDatos().Rows;
            ImageList misImagenes = new ImageList();
            misImagenes.ImageSize = new Size(70, 70);
            foreach (DataRow row in datos)
            {
                try
                {

                    misImagenes.Images.Add(new Bitmap(row[1] + ""));
                    listView1.Items.Add(new ListViewItem(row[0] + "", datos.IndexOf(row)));
                }
                catch
                {
                    MessageBox.Show("algo salio mal al cargar");

                }
            }





            //Obtener el listado de imagenes
            // string[] archivos = Directory.GetFiles("fotos");
            // cargamos los archivos




            listView1.SmallImageList = misImagenes;



            */
        }

        private void clicenfoto(object sender, MouseEventArgs e)
        {
            //fotoseleccionada.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        { /*
            if (!guardado && pictureBox2.Image != null)
            {
                MessageBox.Show("El mapa no esta guardado");
                return;
            }

            checkedListBox1.Items.Clear();
            Todoslospuntos.Clear();
            ColoresPuntos.Clear();
            nombresPuntos.Clear();
            string[] archivos = Directory.GetFiles("fotos");
            Bitmap bmp = new Bitmap(archivos[listView1.SelectedIndices[0]]);
            pictureBox1.Image = bmp;
            pictureBox2.Image = pictureBox1.Image;
            string cod = listView1.SelectedItems[0].SubItems[0].Text;

            DataRowCollection capasFoto = fotos.traerCapas(cod).Rows;

            foreach (DataRow capa in capasFoto)
            {
                puntos = capa[4] + "";
                string[] col = (capa[1] + "").Split(';');
                Color colr = Color.FromArgb(Convert.ToInt32(col[3]), Convert.ToInt32(col[0]), Convert.ToInt32(col[1]), Convert.ToInt32(col[2]));
                string nombre = capa[2] + "";
                colorear(sender, e, colr, nombre);
            }

            */

        }

        private void marcarODesmarcar(object sender, EventArgs e)
        {
            //MessageBox.Show(checkedListBox1.SelectedIndices[0]+"");

            //colorear(checkedListBox1.CheckedIndices);


        }

        private void colorear(CheckedListBox.CheckedIndexCollection checkedIndexCollection)
        {
            /*
            Bitmap cpoa = new Bitmap(pictureBox1.Image);
            foreach (int indexChecked in checkedIndexCollection)
            {
                string estado = checkedListBox1.GetItemCheckState(indexChecked).ToString();
                if (estado.Equals("Checked"))
                {
                    string[] pun = Todoslospuntos[indexChecked].Split(';');
                    string[] col = ColoresPuntos[indexChecked].Split(';');


                    for (int j = 0; j < pun.Length - 1; j++)
                    {
                        string[] xy = pun[j].Split(',');
                        cpoa.SetPixel(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]),
                            Color.FromArgb(Convert.ToInt32(col[3]), Convert.ToInt32(col[0]), Convert.ToInt32(col[1]), Convert.ToInt32(col[2])));
                    }

                }

            }
            pictureBox2.Image = cpoa;
             */
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int idfot;
            if (!guardado)
            {
                for (int i = 0; i < ColoresPuntos.Count; i++)
                {
                    
                    idfot = Convert.ToInt32(fotoGuardada);
                    DataRowCollection ultimoid = fotos.cargarCapa(idfot, ColoresPuntos[i], nombresPuntos[i]).Rows;
                    string id = ultimoid[0].ItemArray[0].ToString();
                    fotos.cargarPuntos(id, Todoslospuntos[i]);

                }
                guardado = true;
            }
            else
            {
                MessageBox.Show("El mapa ya esta guardado");
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!guardado && pictureBox2.Image != null)
            {
                MessageBox.Show("Debe Guardr El mapa primero");
                e.Cancel = true;
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }


    }
}
