namespace EspaciosDeColor;

public partial class Form1 : Form
{
    string imgPath;
    public Form1()
    {
        InitializeComponent();
        imgPath = "";
        btn.Click += new EventHandler(btn_Click);
    }

    private void btn_Click (object? sender, EventArgs e) {
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            imgPath = openFileDialog1.FileName;  
            originalPicBox.Image = Image.FromFile(imgPath);
            CMYK();
            YUV();
            BGR();
        }else
            MessageBox.Show("Por favor seleccione una imagen");
    }

    public void CMYK () {
        Bitmap bmp = new Bitmap(imgPath); //matriz de la img original

        //para los colores del espacio
        Bitmap bmpC = new Bitmap(bmp);
        Bitmap bmpM = new Bitmap(bmp);
        Bitmap bmpY = new Bitmap(bmp);
        Bitmap bmpK = new Bitmap(bmp);
        Bitmap mezcla = new Bitmap(bmp);

        Color p;

        //altura y ancho de la matriz
        int width = bmp.Width;
        int height = bmp.Height;

        //convertir de 0 a 1
        double red;
        double green;
        double blue;
        //
        double cyan;
        double magenta;
        double yellow;
        double key; //negro

        //
        int cCyan;
        int cMagenta;
        int cYellow;
        int cKey;

        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                p = bmp.GetPixel(j, i);

                
                red = p.R / 255.0;
                green = p.G / 255.0;
                blue = p.B / 255.0;

                key = 1.0 - Math.Max(red, Math.Max(green, blue));
                cyan = (1 - red - key) / (1 - key + 0.000000000001);
                magenta = (1 - green - key) / (1 - key + 0.000000000001);
                yellow = (1 - blue - key) / (1 - key + 0.000000000001);

                cKey = Convert.ToInt32(key * 255);
                cCyan = Convert.ToInt32(cyan * 255);
                cMagenta = Convert.ToInt32(magenta * 255);
                cYellow = Convert.ToInt32(yellow * 255);

                bmpC.SetPixel(j, i, Color.FromArgb(cCyan, Color.Cyan));
                bmpM.SetPixel(j, i, Color.FromArgb(cMagenta, Color.Magenta));
                bmpY.SetPixel(j, i, Color.FromArgb(cYellow, Color.Yellow));
                bmpK.SetPixel(j, i, Color.FromArgb(cKey, Color.Black));

                //mezcla.SetPixel(j, i, Color.FromArgb(cKey,cCyan, cMagenta, cYellow));
            }
        }

        //se mezclan lo colores para obtener el final
        Graphics gr = Graphics.FromImage(mezcla);
        gr.DrawImage(bmpC,0,0,width, height);
        gr.DrawImage(bmpM,0,0,width, height);
        gr.DrawImage(bmpY,0,0,width, height);
        gr.DrawImage(bmpK,0,0,width, height);

        CMYKPicBox.Image = mezcla;
    }

    public void YUV () {
        Bitmap bmp = new Bitmap(imgPath); //matriz de la img original

        //para los colores del espacio
        Bitmap bmpY = new Bitmap(bmp);
        Bitmap bmpU = new Bitmap(bmp);
        Bitmap bmpV = new Bitmap(bmp);
        Bitmap combinate = new Bitmap(bmp);

        Color p;

        //altura y ancho de la matriz
        int width = bmp.Width;
        int height = bmp.Height;

        double red;
        double green;
        double blue;

        double y;
        double u;
        double v;

        int yRed;
        int uGreen;
        int vBlue;

        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                p = bmp.GetPixel(j, i);

                red = p.R / 255.0;
                green = p.G / 255.0;
                blue = p.B / 255.0;

                y = 0.299*red + 0.587*green + 0.114*blue;
                u = -0.14713*red - 0.28886*green + 0.436*blue;
                v = 0.615*red - 0.51499*green - 0.10001*blue;

                yRed = Convert.ToInt32((y + 1.139837398373983740*v)*255);
                uGreen = Convert.ToInt32((y - 0.3946517043589703515*u - 0.5805986066674976801*v)*255);
                vBlue = Convert.ToInt32((y + 2.032110091743119266*u)*255);
    
                
                bmpY.SetPixel(j, i, Color.FromArgb(yRed, Color.Red));
                bmpU.SetPixel(j, i, Color.FromArgb(uGreen, Color.Green));
                bmpV.SetPixel(j, i, Color.FromArgb(vBlue, Color.Blue));
            }
        }
        Graphics gr = Graphics.FromImage(combinate);
        gr.DrawImage(bmpY, 0, 0, width, height);
        gr.DrawImage(bmpU, 0, 0, width, height);
        gr.DrawImage(bmpV, 0, 0, width, height);

        YUVPicBox.Image = combinate;

        bmpY.Save("a.png", System.Drawing.Imaging.ImageFormat.Png);
        bmpU.Save("b.png", System.Drawing.Imaging.ImageFormat.Png);
        bmpV.Save("c.png", System.Drawing.Imaging.ImageFormat.Png);
    }

    public void BGR () {
        Bitmap bmp = new Bitmap(imgPath); //matriz de la img original

        //para los colores del espacio
        Bitmap bmpR = new Bitmap(bmp);
        Bitmap bmpG = new Bitmap(bmp);
        Bitmap bmpB = new Bitmap(bmp);
        Bitmap mezcla = new Bitmap(bmp);

        Color p;

        //altura y ancho
        int width = bmp.Width;
        int height = bmp.Height;

        int red;
        int green;
        int blue;

        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                p = bmp.GetPixel(j, i);
                
                red = p.R;
                green = p.G;
                blue = p.B;
                
                bmpB.SetPixel(j, i, Color.FromArgb(0, 0, blue));
                bmpG.SetPixel(j, i, Color.FromArgb(0, green, 0));
                bmpR.SetPixel(j, i, Color.FromArgb( red, 0, 0));

                mezcla.SetPixel(j, i, Color.FromArgb(blue, green, red));
            }
        }

        //se mezclan lo colores para obtener el final
        /*Graphics gr = Graphics.FromImage(mezcla);
        gr.DrawImage(bmpB,0,0,width, height);
        gr.DrawImage(bmpG,0,0,width, height);
        gr.DrawImage(bmpR,0,0,width, height);*/

        BGRPicBox.Image = mezcla;

        bmpB.Save("a1.png", System.Drawing.Imaging.ImageFormat.Png);
        bmpG.Save("b1.png", System.Drawing.Imaging.ImageFormat.Png);
        bmpR.Save("c1.png", System.Drawing.Imaging.ImageFormat.Png);
    }

    
}
