using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Google.Protobuf.WellKnownTypes;
using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.facial
{
    public partial class capture : UserControl
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        public Capture grabber;
        HaarCascade face, eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, FaceCaptured, gray = null;
        List<Image<Gray, byte>> CapturingImages = new List<Image<Gray, byte>>();
        List<string> inmates = new List<string>();
        List<string> NameInmates = new List<string>();
        int Countface, NumNames, t;  

        private void capture_Load(object sender, EventArgs e)
        {
            lblCode.Text = inmate.txtCode.Text;
            lblFullname.Text = inmate.txtLastName.Text + ", " + inmate.txtFirstName.Text + " " + inmate.txtMiddleName.Text;
            
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        string name, names = null;
        inputs.inmate inmate;
        public capture(inputs.inmate inmate)
        {
            InitializeComponent();
            this.inmate = inmate;
            classes.Inmate Inmate = new classes.Inmate();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Inmatesinfo = File.ReadAllText(Application.StartupPath + "/Face/Inmates.txt");
                string[] Inmates = Inmatesinfo.Split('%');
                NumNames = Convert.ToInt16(Inmates[0]);
                Countface = NumNames;
                string LoadFaces;

                for (int i = 1; i < NumNames + 1; i++)
                {
                    LoadFaces = "Inmate" + i + ".bmp";
                    CapturingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Face/" + LoadFaces));
                    inmates.Add(Inmates[i]);
                }
            }
            catch (Exception ex) 
            {
                config.config.Alerts.ServerMessage(ex.ToString());
            }
        }
        public void FrameGrabber(object sender, EventArgs e)
        {
            //label3.Text = "0";
            //label4.Text = "";
            NameInmates.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(600, 440, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
              face,
              1.2,
              10,
              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT,
              new Size(20, 20));

            /*
                 //Profile Detector
                 MCvAvgComp[][] profilefaceDetected = gray.DetectHaarCascade( 
                   profileface,
                   1.2,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.,
                   new Size(25, 25));*/

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.FromArgb(26, 104, 255)), 2);

                if (CapturingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(Countface, 0.001);

                    //Eigen face recognizer
                    config.config.Recognizer = new Recognizer(
                    CapturingImages.ToArray(),
                    inmates.ToArray(),
                    2500,
                    ref termCrit);

                    name = config.config.Recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.FromArgb(26, 104, 255)));
                }

                NameInmates[t - 1] = name;
                NameInmates.Add("");


                //Set the number of faces detected on the scene
                //label3.Text = facesDetected[0].Length.ToString();


                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.FromArgb(26, 104, 255)), 2);
                }


            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NameInmates[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            ImageBoxFrameGrabber.Image = currentFrame;
            //label4.Text = names;
            names = "Unknown Face";
            //Clear the list(vector) of names
            NameInmates.Clear();

        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Sound.Click();
            try
            {
                //Captured face counter
                Countface = Countface + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(600, 440, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    FaceCaptured = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                FaceCaptured = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                CapturingImages.Add(FaceCaptured);
                inmates.Add(lblCode.Text + " - " + lblFullname.Text);

                //Show face added in gray scale
                imageBox1.Image = FaceCaptured;

                //inmate.ibxFace.Image = FaceCaptured;

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/Face/Inmates.txt", CapturingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < CapturingImages.ToArray().Length + 1; i++)
                {
                    CapturingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Face/Inmate" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/Face/Inmates.txt", inmates.ToArray()[i - 1] + "%");

                    //string src = Application.StartupPath + "/Face/" + lblCode.Text + " - " + lblFullname.Text + " - " + i + ".bmp";
                    /*Color[] colors = ColorBuilder.GetColorDiagram(new List<ControlPoint>());
                    for (int ii = 0; ii < imageBox1.Image.Bitmap.Width; ii++)
                    {
                        for (int j = 0; j < imageBox1.Image.Bitmap.Height; j++)
                        {
                            int level = imageBox1.Image.Bitmap.GetPixel(ii, j).B;
                            imageBox1.Image.Bitmap.SetPixel(ii, j, colors[level]);
                        }
                    }
                    inmate.pictureBox1.Image = imageBox1.Image.Bitmap;*/
                }
                config.config.Alerts.Popup("Face Characteristics Captured.", dashboard.alert.enmType.Success);
            }
            catch
            {
                this.Enabled = false;
                MessageBox.Show(" :(");
                this.Enabled = true;
                config.config.Alerts.Popup("Enable the face detection first.", dashboard.alert.enmType.Error);
            }
            inmate.popup.btnClose_Click(sender, new EventArgs());
        }
    }
}
