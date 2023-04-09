using Emgu.CV.Structure;
using Emgu.CV;
using MySqlX.XDevAPI.Common;
using Roll_Call_And_Management_System.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using System.IO;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Roll_Call_And_Management_System.config;

namespace Roll_Call_And_Management_System.views.components.facial
{
    public partial class scan : UserControl
    {
        inputs.rollcall rollcall;
        public views.dashboard dashboard;
        public scan(views.dashboard dashboard, inputs.rollcall rollcall)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.rollcall = rollcall;
            dashboard.Prison.Inmate.dataSet = dashboard.Prison.Inmate.GetInmates();
            if (dashboard.Prison.Inmate.dataSet != null)
                foreach (DataRow dataRow in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
                {
                    if ((int)dataRow["dormitory_id"] == rollcall.DormitoryId)
                    {
                        sub.inmate row = new sub.inmate(this);
                        row.Cancel.Visible = false;
                        row.btnCheck.Location = row.Cancel.Location;
                        row.Icon.Image = Properties.Resources.human_head;
                        lblRemaining.Text = (Convert.ToInt32(lblRemaining.Text) + 1).ToString();
                        row.Name = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        row.lblInmate.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        row.lblInmate.Text += " - " + ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase);
                        row.lblInmate.Text += ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase);
                        row.lblInmate.Text += " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        this.flowLayoutPanelRemaining.Controls.Add(row);
                    }
                }
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
                ini.Alerts.ServerMessage(ex.ToString());
            }
        }

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
        string name, names = null;
        private void btnFinish_Click(object sender, EventArgs e) 
        {
            foreach (sub.inmate control in flowLayoutPanelScanned.Controls)
            {
                dashboard.Prison.Roll_Call = new Roll_Call(lblCode.Text, dashboard.Prison.Inmate.GetId(control.Name), 1, "Scanned", dashboard.Prison.User.Auth);
                dashboard.Prison.Roll_Call.SaveInmate();
            }
            foreach (sub.inmate control in flowLayoutPanelRemaining.Controls)
            {
                dashboard.Prison.Roll_Call = new Roll_Call(lblCode.Text, dashboard.Prison.Inmate.GetId(control.Name), 0, "Not Scanned", dashboard.Prison.User.Auth);
                dashboard.Prison.Roll_Call.SaveInmate();
            }
        }

        inputs.inmate inmate;
        int Id = 0;
        private void scan_Load(object sender, EventArgs e)
        {
            foreach(DataRow data in dashboard.Prison.Roll_Call.dataSet.Tables["result"].Rows) 
            {
                Id = (int)data["id"];
                lblCode.Text = (string)data["code"];
                dashboard.Prison.Dormitory.dataSet = dashboard.Prison.Dormitory.GetDormitoryDetails((int)data["dormitory_id"]);
                foreach (DataRow row in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                    lblDormitory.Text = ini.AES.Decrypt((string)row[1], Properties.Resources.PassPhrase);
                //Id = (string)data["status"];
                //Id = data["date_created"];
            }
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }
        string scannedface = "";
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
                    ini.Recognizer = new Recognizer(
                    CapturingImages.ToArray(),
                    inmates.ToArray(),
                    2500,
                    ref termCrit);

                    name = ini.Recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.FromArgb(26, 104, 255)));
                    foreach(sub.inmate control in flowLayoutPanelRemaining.Controls) 
                    {
                        scannedface = name.Split('-')[0].Trim();
                        if(control.Name == scannedface)
                        {
                            control.btnCheck_Click(sender, new EventArgs());
                        }
                    }
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
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
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
    }
}
