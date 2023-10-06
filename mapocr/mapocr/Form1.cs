using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.XPhoto;
using IronOcr;
using SixLabors.ImageSharp.Drawing.Processing;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Forms;
using static IronOcr.OcrResult;
using System.Text.Json;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using ColorMatrix = System.Drawing.Imaging.ColorMatrix;
using Pen = System.Drawing.Pen;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;
using Size = System.Drawing.Size;
using SolidBrush = System.Drawing.SolidBrush;
using System.Buffers.Text;
using System.Security.Policy;
using Gma.System.MouseKeyHook;
using Emgu.CV.ImgHash;

namespace mapocr
{
    public partial class Form1 : Form
    {
        Dictionary<string, Process> procs = new Dictionary<string, Process>();
        Bitmap mapsource;

        Dictionary<string, List<int>> west_south_regions = new Dictionary<string, List<int>>();
        Bitmap World;

        List<Map> maps = new List<Map>();
        List<string> maphash = new List<string>();

        protected void createRegions()
        {
            // West (W,S) style
            // top right, bottom left to create bounding box

            // West main land
            west_south_regions.Add("Karkasse Ridgelands", new List<int>() { 8, 10, 12, 12 });
            west_south_regions.Add("Gwren Forest", new List<int>() { 9, 12, 11, 13 });
            west_south_regions.Add("Lilly", new List<int>() { 6, 11, 9, 13 });
            west_south_regions.Add("Soils", new List<int>() { 5, 12, 7, 14 });
            west_south_regions.Add("Dewstone", new List<int>() { 8, 13, 10, 15 });
            west_south_regions.Add("White ard", new List<int>() { 9, 14, 12, 16 });
            west_south_regions.Add("Mari", new List<int>() { 9, 15, 10, 16 });
            west_south_regions.Add("Two crowns", new List<int>() { 7, 16, 9, 18 });
            west_south_regions.Add("Cindastone", new List<int>() { 5, 15, 7, 18 });
            west_south_regions.Add("Halcy", new List<int>() { 9, 19, 12, 18 });
            west_south_regions.Add("Halcy 2", new List<int>() { 11, 17, 13, 18 });
            west_south_regions.Add("Hellswamp", new List<int>() { 13, 17, 14, 20 });
            west_south_regions.Add("Hellswamp ", new List<int>() { 12, 20, 13, 20 });
            west_south_regions.Add("Sanddeep", new List<int>() { 10, 17, 11, 20 });
            west_south_regions.Add("Sanddeep 2", new List<int>() { 11, 18, 12, 19 });

            // Northen
            west_south_regions.Add("Marcala", new List<int>() { 1, 3, 2, 4 });
            west_south_regions.Add("Heedmar", new List<int>() { 0, 3, 2, 5 });
            west_south_regions.Add("D shore", new List<int>() { 0, 0, 3, 2 });
            west_south_regions.Add("Golden ruins", new List<int> { 3, 0, 5, 2 });

            west_south_regions.Add("JP", new List<int>() { 3, 12, 5, 14 });
            west_south_regions.Add("Pirate island", new List<int>() { 5, 4, 6, 6 });
            west_south_regions.Add("Free dick", new List<int>() { 0, 8, 1, 10 });
            west_south_regions.Add("West cont ?", new List<int>() { 5, 10, 14, 18 });

            west_south_regions.Add("Halcyona Gulf", new List<int>() { 6, 18, 11, 20 });
            west_south_regions.Add("Castaway Strait", new List<int>() { 2, 14, 5, 18 });
            west_south_regions.Add("Arcadian Sea", new List<int>() { 0, 5, 9, 14 });

        }

        public Form1()
        {
            Subscribe();
            InitializeComponent();
            createRegions();

            mapsource = global::mapocr.Properties.Resources.map;
            pictureBox2.BackgroundImage = mapsource;
            CurrentScreen = global::mapocr.Properties.Resources.test;
            pictureBox1.BackgroundImage = CurrentScreen;
            object_Image = mapsource.ToImage<Gray, Byte>();
            ocr.Configuration.WhiteListCharacters = "0123456789'\"`°WENS ,";
            World = global::mapocr.Properties.Resources.worldmap;
            //World = drawMapPoint(World, "W", "S", 0, 0, 0, 0, 0, 0); 
            // World = drawMapPoint(World, "W", "S", 0, 0, 0, 4, 0, 0);
            // World = drawMapPoint(World, "W", "S", 2, 0, 0, 2, 0, 0);
            //World = drawMapPoint(World, "E", "S", 2, 0, 0, 2, 0, 0);
            pictureBox4.BackgroundImage = World;
        }

        protected string nameRegion(string Xstyle, string Ystyle, int X1, int Y1)
        {
            if ((Xstyle == "W") && (Ystyle == "S"))
            {
                return findRegion(west_south_regions, X1, Y1);
            }
            return "?";
        }

        protected string findRegion(Dictionary<string, List<int>> source, int X1, int Y1)
        {
            string regionname = "?";
            foreach (KeyValuePair<string, List<int>> entry in source)
            {
                if ((X1 >= entry.Value[0]) && (X1 <= entry.Value[2]))
                {
                    if ((Y1 >= entry.Value[1]) && (Y1 <= entry.Value[3]))
                    {
                        regionname = entry.Key;
                        break;
                    }
                }
            }
            return regionname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processCollection = Process.GetProcesses();
            int loop = 1;
            foreach (Process process in processCollection)
            {
                if (process.ProcessName.Contains("archeage") == true)
                {
                    comboBox1.Items.Add(process.ProcessName + "x" + loop.ToString());
                    procs.Add(process.ProcessName + "x" + loop.ToString(), process);
                    loop++;
                }
            }
            if (comboBox1.Items.Count == 1)
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Update();
                button1.Enabled = false;
                comboBox1.Enabled = false;
                updateNow();
            }

        }

        private void merge()
        {

        }

        private Bitmap Invert(Bitmap bmp)
        {
            for (int y = 0; (y <= (bmp.Height - 1)); y++)
            {
                for (int x = 0; (x <= (bmp.Width - 1)); x++)
                {
                    Color inv = bmp.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    bmp.SetPixel(x, y, inv);
                }
            }
            return bmp;
        }

        private void updateNow()
        {
            timer1.Enabled = true;
            timer1.Interval = 500;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateNowSingle();
        }

        private IronTesseract ocr = new IronTesseract();
        private void timer1_Tick(object sender, EventArgs e)
        {
            updateNowSingle();
            findInImage();
        }

        private void findInImage()
        {
            textBox1.Text = "-";
            Object_Location = new Point(0, 0);
            if (Detect_objects() == true)
            {
                X1 = Object_Location.X;
                Y1 = Object_Location.Y - 29;
                if (Y1 < 0)
                {
                    Y1 = 1;
                }

                Bitmap baseImage = CurrentScreen.Clone(new System.Drawing.Rectangle(X1, Y1, 160, 20), CurrentScreen.PixelFormat);
                pictureBox3.BackgroundImage = baseImage;

                textBox1.Text = "?";
                textBox5.Text = "";
                List<string> list = new List<string>() {
                    "grayscale", "invert", "resize", "grayscale+resize", "grayscale+recolor",
                    "grayscale+recolor+invert", "grayscale+recolor+invert+resize", "grayscale+resize+recolor+invert",
                    "grayscale+resize+resize+recolor+invert" };
                foreach (string A in list)
                {
                    Bitmap work = baseImage.Clone(new Rectangle(0, 0, baseImage.Width, baseImage.Height), baseImage.PixelFormat);
                    List<string> steps = A.Split('+').ToList();
                    textBox5.Text = textBox5.Text + " @@ ";
                    foreach (string S in steps)
                    {
                        if (S == "grayscale")
                        {
                            work = MakeGrayscale3(work);
                        }
                        else if (S == "resize")
                        {
                            work = ScaleImage(work, work.Width + trackBar3.Value, work.Height + trackBar3.Value);
                        }
                        else if (S == "recolor")
                        {
                            work = ColorReplace(work, trackBar2.Value, Color.FromArgb(44, 44, 44), Color.FromArgb(0, 0, 0));
                        }
                        else if (S == "invert")
                        {
                            work = Invert(work);
                        }
                        textBox5.Text = textBox5.Text + S + " | ";
                    }
                    using (var input = new OcrInput(work))
                    {
                        input.Sharpen();
                        input.EnhanceResolution();
                        var ocrResult = ocr.Read(input);
                        textBox2.Text = ocrResult.Text + " == " + ocrResult.Confidence.ToString();
                        string[] bits = ocrResult.Text.Split(new char[] { '"', '\'', '`', '°', ',', '.', '°', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        // E@1@52@0@
                        // S@21@2@2
                        textBox6.Text = "? " + bits.Count().ToString() + " == " + String.Join(" ", bits);
                        string AAA = String.Join(" ", bits);
                        if (AAA != proA)
                        {
                            proA = AAA;
                            if (bits.Count() == 8)
                            {
                                textBox1.Text = AAA;
                                textBox6.Text = nameRegion(bits[0], bits[4], int.Parse(bits[1]), int.Parse(bits[5]));
                                pictureBox2.BackgroundImage = work;

                                Bitmap drawmap = World.Clone(new Rectangle(0, 0, World.Width, World.Height), baseImage.PixelFormat);
                                currentMapRead = AAA;
                                drawmap = drawMapPoint(drawmap, bits[0], bits[4],
                                    int.Parse(bits[1]), int.Parse(bits[2]), int.Parse(bits[3]),
                                    int.Parse(bits[5]), int.Parse(bits[6]), int.Parse(bits[7])
                                    );
                                pictureBox4.BackgroundImage = drawmap;
                                break;
                            }
                        }
                    }
                    GC.Collect();
                }
            }
        }
        private Map? currentLoaded = null;
        private string currentMapRead = "";
        string proA = "";
        protected Bitmap drawMapPoint(Bitmap Map, string Xmode, string Ymode, int Xh, int Xm, int Xs, int Yh, int Ym, int Ys)
        {

            int dirX = 1;
            int dirY = -1;
            if (Xmode == "W")
            {
                dirX = -1;
            }
            if (Ymode == "S")
            {
                dirY = 1;
            }
            currentLoaded = new Map() { r1 = Xh, m1 = Xm, s1 = Xs, r2 = Yh, m2 = Ym, s2 = Ys, ns = dirY, we = dirX };

            var dotSize = 50;
            var centerPointX = 1033;
            var centerPointY = 460;
            var scaleHX = 49;
            var scaleMX = (scaleHX / 100);
            var scaleSX = (scaleMX / 100);
            var scaleHY = 46;
            var scaleMY = (scaleHY / 100);
            var scaleSY = (scaleMY / 100);

            var WESecond = Xh * scaleHX + Xm * scaleMX + Xs * scaleSX;
            var WEPxl = WESecond * dirX;

            var NSSecond = Yh * scaleHY + Ym * scaleMY + Ys * scaleSY;
            var NSPxl = NSSecond * dirY;

            int XposReal = (int)Math.Round((double)(centerPointX + WEPxl) - (dotSize / 2));
            int YposReal = (int)Math.Round((double)(centerPointY + NSPxl) - (dotSize / 2));
            return DrawDot(Map, XposReal, YposReal, dotSize);

        }

        public Bitmap DrawDot(Bitmap Map, int X, int Y, int dotSize)
        {
            Bitmap btm = Map.Clone(new Rectangle(0, 0, Map.Width, Map.Height), Map.PixelFormat);
            using (Graphics grf = Graphics.FromImage(btm))
            {
                using (Brush brsh = new SolidBrush(Color.FromArgb(rnd.Next(128, 225), rnd.Next(128, 225), rnd.Next(128, 225))))
                {
                    grf.FillEllipse(brsh, X, Y, dotSize, dotSize);
                }
                using (Pen myPen = new Pen(Color.Black, 3))
                {
                    grf.DrawEllipse(myPen, X, Y, dotSize, dotSize);
                }
                ;
            }
            return btm;
        }

        Random rnd = new Random();
        public Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        public Bitmap ColorReplace(Bitmap inputImage, int tolerance, Color oldColor, Color NewColor)
        {
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);
            Graphics G = Graphics.FromImage(outputImage);
            G.DrawImage(inputImage, 0, 0);
            for (Int32 y = 0; y < outputImage.Height; y++)
                for (Int32 x = 0; x < outputImage.Width; x++)
                {
                    Color PixelColor = outputImage.GetPixel(x, y);
                    if (PixelColor.R > oldColor.R - tolerance && PixelColor.R < oldColor.R + tolerance && PixelColor.G > oldColor.G - tolerance && PixelColor.G < oldColor.G + tolerance && PixelColor.B > oldColor.B - tolerance && PixelColor.B < oldColor.B + tolerance)
                    {
                        int RColorDiff = oldColor.R - PixelColor.R;
                        int GColorDiff = oldColor.G - PixelColor.G;
                        int BColorDiff = oldColor.B - PixelColor.B;

                        if (PixelColor.R > oldColor.R) RColorDiff = NewColor.R + RColorDiff;
                        else RColorDiff = NewColor.R - RColorDiff;
                        if (RColorDiff > 255) RColorDiff = 255;
                        if (RColorDiff < 0) RColorDiff = 0;
                        if (PixelColor.G > oldColor.G) GColorDiff = NewColor.G + GColorDiff;
                        else GColorDiff = NewColor.G - GColorDiff;
                        if (GColorDiff > 255) GColorDiff = 255;
                        if (GColorDiff < 0) GColorDiff = 0;
                        if (PixelColor.B > oldColor.B) BColorDiff = NewColor.B + BColorDiff;
                        else BColorDiff = NewColor.B - BColorDiff;
                        if (BColorDiff > 255) BColorDiff = 255;
                        if (BColorDiff < 0) BColorDiff = 0;

                        outputImage.SetPixel(x, y, Color.FromArgb(RColorDiff, GColorDiff, BColorDiff));
                    }
                }
            return outputImage;
        }



        public Bitmap ScaleImage(Bitmap bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }


        Point Object_Location;
        Image<Gray, Byte> object_Image;
        double detectscore = 0;
        private bool Detect_objects()
        {
            Image<Gray, Byte> Input_Image = CurrentScreen.ToImage<Gray, Byte>();

            Point dftSize = new Point(Input_Image.Width + (object_Image.Width * 2), Input_Image.Height + (object_Image.Height * 2));
            bool Success = false;
            using (Image<Gray, Byte> pad_array = new Image<Gray, Byte>(dftSize.X, dftSize.Y))
            {
                //copy centre
                pad_array.ROI = new Rectangle(object_Image.Width, object_Image.Height, Input_Image.Width, Input_Image.Height);
                CvInvoke.cvCopy(Input_Image.Convert<Gray, Byte>(), pad_array, IntPtr.Zero);
                // CvInvoke.cvMatchTemplate
                //CvInvoke.cvShowImage("pad_array", pad_array);
                pad_array.ROI = (new Rectangle(0, 0, dftSize.X, dftSize.Y));
                using (Image<Gray, float> result_Matrix = pad_array.MatchTemplate(object_Image, TemplateMatchingType.Ccoeff))
                {
                    result_Matrix.ROI = new Rectangle(object_Image.Width, object_Image.Height, Input_Image.Width, Input_Image.Height);

                    Point[] MAX_Loc, Min_Loc;
                    double[] min, max;
                    result_Matrix.MinMax(out min, out max, out Min_Loc, out MAX_Loc);

                    using (Image<Gray, double> RG_Image = result_Matrix.Convert<Gray, double>().Copy())
                    {
                        //#TAG WILL NEED TO INCREASE SO THRESHOLD AT LEAST 0.8...used to have 0.7

                        if (max[0] > ((12000000 / 100) * trackBar1.Value))
                        {
                            Object_Location = MAX_Loc[0];
                            detectscore = max[0];
                            Success = true;
                        }
                    }

                }
            }
            return Success;
        }

        protected Bitmap CurrentScreen;
        private void updateNowSingle()
        {
            CurrentScreen = CaptureApplication(procs[comboBox1.Text]);
            pictureBox1.BackgroundImage = ScaleImage(CurrentScreen, 640, 360);

        }

        public Bitmap CaptureApplication(Process proc)
        {
            var rect = new User32.Rect();
            User32.GetWindowRect(proc.MainWindowHandle, ref rect);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            }
            return bmp;
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        }

        bool enableBox = false;
        bool boxReady = false;
        int boxStep = 0;
        int X1 = 0;
        int Y1 = 0;
        int X2 = 0;
        int Y2 = 0;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = trackBar3.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maps.Clear();
            maphash.Clear();
            label7.Text = "0";
            listBox1.Items.Clear();
        }

        private IKeyboardMouseEvents? m_GlobalHook = null;
        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }
        protected char? keyboard_trigger = null;
        protected bool awaitingBind = false;
        private void GlobalHookKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (keyboard_trigger == null)
            {
                if (awaitingBind == true)
                {
                    keyboard_trigger = e.KeyChar;
                    textBox3.Text = keyboard_trigger.ToString();
                    awaitingBind = false;
                    button4.Enabled = true;
                }
            }
            else if(keyboard_trigger == e.KeyChar) 
            {
                if (currentLoaded != null) {
                    if (maps.Contains(currentLoaded) == false)
                    {
                        maps.Add(currentLoaded);
                        label7.Text = maps.Count().ToString();
                        listBox1.Items.Add(currentMapRead);
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (maps.Count > 0)
            {
                var options = new JsonSerializerOptions()
                {
                    IncludeFields = true,
                };
                var json = JsonSerializer.Serialize(maps, options);
                json = Base64Encode(json);
                var url = "https://basestr.github.io/archeagemap/index.html?m=" + json;
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            awaitingBind = true;
            keyboard_trigger = null;
            textBox3.Text = "~~~ NONE ~~~";
            button4.Enabled = false;
        }
    }

    public class Map
    {
        public int we = 0;
        public int ns = 0;
        public int r1 = 0;
        public int m1 = 0;
        public int s1 = 0;
        public int r2 = 0;
        public int m2 = 0;
        public int s2 = 0;
    }
}