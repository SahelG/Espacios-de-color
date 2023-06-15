namespace EspaciosDeColor;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 810);
        this.Text = "Espacio de color";
        this.StartPosition = FormStartPosition.CenterScreen; //se centra el frame

        InstanciarObjetos();
        DiseñoComponentes();

        //se le asigna un nombre a los componentes
        originalPicBox.Name = "originalPicBox";
        CMYKPicBox.Name = "CMYKPicBox";
        YUVPicBox.Name = "YUVPicBox";
        BGRPicBox.Name = "BGRPicBox";

        lbl1.Name = "lbl1";
        lbl2.Name = "lbl2";
        lbl3.Name = "lbl3";
        lbl4.Name = "lbl4";

        btn.Name = "btn";
        btn.Text = "Buscar";

        lbl1.Text = "RGB";
        lbl2.Text = "CMYK";
        lbl3.Text = "YUV";
        lbl4.Text = "BGR";

        //se estable el lugar donde estara el componente
        originalPicBox.Location = new System.Drawing.Point(30,30);
        CMYKPicBox.Location = new System.Drawing.Point(420,30);
        YUVPicBox.Location = new System.Drawing.Point(30, 410);
        BGRPicBox.Location = new System.Drawing.Point(420, 410);

        lbl1.Location = new System.Drawing.Point(170,10);
        lbl2.Location = new System.Drawing.Point(560, 10);
        lbl3.Location = new System.Drawing.Point(170, 390);
        lbl4.Location = new System.Drawing.Point(560, 390);


        btn.Location = new System.Drawing.Point(360,770);

        //se añaden al frame
        this.Controls.Add(originalPicBox);
        this.Controls.Add(CMYKPicBox);
        this.Controls.Add(YUVPicBox);
        this.Controls.Add(BGRPicBox);

        this.Controls.Add(lbl1);
        this.Controls.Add(lbl2);
        this.Controls.Add(lbl3);
        this.Controls.Add(lbl4);
        
        this.Controls.Add(btn);

    }

    private void InstanciarObjetos () {
        originalPicBox = new PictureBox();
        CMYKPicBox = new PictureBox();
        YUVPicBox = new PictureBox();
        BGRPicBox = new PictureBox();

        lbl1 = new Label();
        lbl2 = new Label();
        lbl3 = new Label();
        lbl4 = new Label();

        openFileDialog1 = new OpenFileDialog();
        btn = new Button();
    }

    private void DiseñoComponentes () {
        //tamaño de las cajas
        originalPicBox.Size = new System.Drawing.Size(350,350);
        CMYKPicBox.Size = new System.Drawing.Size(350,350);
        YUVPicBox.Size = new System.Drawing.Size(350,350);
        BGRPicBox.Size = new System.Drawing.Size(350,350);


        //asignacion de bordes
        originalPicBox.BorderStyle = BorderStyle.FixedSingle;
        CMYKPicBox.BorderStyle = BorderStyle.FixedSingle;
        YUVPicBox.BorderStyle = BorderStyle.FixedSingle;
        BGRPicBox.BorderStyle = BorderStyle.FixedSingle;


        //la imagen tendra el mismo tamaño que la caja
        originalPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        CMYKPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        YUVPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        BGRPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

        lbl1.Font = new Font("Arial", 13);
        lbl2.Font = new Font("Arial", 13);
        lbl3.Font = new Font("Arial", 13);
        lbl4.Font = new Font("Arial", 13);
        
    }


    private PictureBox originalPicBox;
    private PictureBox CMYKPicBox;
    private PictureBox YUVPicBox;
    private PictureBox BGRPicBox;

    private Label lbl1;
    private Label lbl2;
    private Label lbl3;
    private Label lbl4;

    private OpenFileDialog openFileDialog1;
    private Button btn;

    #endregion
}
