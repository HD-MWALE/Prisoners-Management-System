﻿using Emgu.CV.Structure;
using Emgu.CV;
using MySqlX.XDevAPI.Common;
using Prisoners_Management_System.classes;
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
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.dashboard;

namespace Prisoners_Management_System.views.components.facial
{
    public partial class scan : UserControl
    {
        inputs.rollcall rollcall;
        public views.dashboard dashboard;
        DataSet dsInmates = new DataSet();
        DataSet dsDormitories= new DataSet(); 
        DataSet dsRollCall = new DataSet(); 

        public scan(views.dashboard dashboard, inputs.rollcall rollcall)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.rollcall = rollcall;
            dsRollCall = rollcall.dsRoll_Call;
            dsInmates = dashboard.Prison.Inmate.GetInmates();
            if (dsInmates != null)
                foreach (DataRow dataRow in dsInmates.Tables["result"].Rows)
                {
                    if ((int)dataRow["dormitory_id"] == rollcall.DormitoryId)
                    {
                        sub.inmate row = new sub.inmate(this);
                        row.Cancel.Visible = false;
                        row.btnCheck.Location = row.Cancel.Location;
                        row.Icon.Image = Properties.Resources.human_head;
                        lblRemaining.Text = (Convert.ToInt32(lblRemaining.Text) + 1).ToString();
                        row.Name = dataRow["code"].ToString();
                        row.lblInmate.Text = dataRow["code"].ToString();
                        row.lblInmate.Text += " - " + dataRow["last_name"].ToString();
                        row.lblInmate.Text += ", " + dataRow["first_name"].ToString();
                        row.lblInmate.Text += " " + dataRow["middle_name"].ToString();
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
                config.config.Alerts.ServerMessage(ex.ToString());
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
            dashboard.Prison.Roll_Call = new Roll_Call(lblCode.Text, dashboard.Prison.User.Auth);
            if (dashboard.Prison.Roll_Call.SaveInmate(flowLayoutPanelScanned, flowLayoutPanelRemaining))
            {
                if (flowLayoutPanelRemaining.Controls.Count == 0)
                    config.config.Alerts.Popup("Roll Call was Successful...", alert.enmType.Success);
                else
                    config.config.Alerts.Popup(flowLayoutPanelRemaining.Controls.Count + " Inmate(s) not scanned.", alert.enmType.Warning);
            }
            else
            {
                config.config.Alerts.Popup("An error occured.", alert.enmType.Error);
            }
            grabber.Dispose();
            ImageBoxFrameGrabber.Dispose();
            Application.Idle -= new EventHandler(FrameGrabber);
        }

        inputs.inmate inmate;
        int Id = 0;
        private void scan_Load(object sender, EventArgs e)
        {
            foreach (DataRow data in dsRollCall.Tables["result"].Rows) 
            {
                Id = (int)data["id"];
                lblCode.Text = (string)data["code"];
                dsDormitories = dashboard.Prison.Dormitory.GetDormitoryDetails((int)data["dormitory_id"]);
                foreach (DataRow row in dsDormitories.Tables["result"].Rows)
                    lblDormitory.Text = (string)row[1];
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
            NameInmates.Add("");
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(600, 440, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();
            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT,  new Size(20, 20));
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
                    config.config.Recognizer = new Recognizer(CapturingImages.ToArray(), inmates.ToArray(), 2500, ref termCrit);
                    name = config.config.Recognizer.Recognize(result);
                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.FromArgb(26, 104, 255)));
                    foreach(sub.inmate control in flowLayoutPanelRemaining.Controls) 
                    {
                        scannedface = name.Split('-')[0].Trim();
                        if(control.Name == scannedface)
                            control.btnCheck_Click(sender, new EventArgs());
                    }
                }
                NameInmates[t - 1] = name;
                NameInmates.Add("");
                //Set the region of interest on the faces
                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(eye, 1.1, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
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
