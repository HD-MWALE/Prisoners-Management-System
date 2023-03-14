using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuTextbox;
using DocumentFormat.OpenXml.Office2010.Excel;
using Emgu.CV.Structure;
using Google.Protobuf.WellKnownTypes;
using Roll_Call_And_Management_System.Properties;
using Roll_Call_And_Management_System.views.components.dashboard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roll_Call_And_Management_System.views.components.dashboard.alert;
using Color = System.Drawing.Color;

namespace Roll_Call_And_Management_System
{
    internal class Config
    {
        public static string startupPath = Application.StartupPath;
        public static string UserRole = startupPath + "\\auth\\role.txt";  
        public static string Backup = startupPath + "\\backup\\backup.sql";
        public static string theme = startupPath + "\\settings\\theme.txt";
        public static string sound = startupPath + "\\settings\\sound.txt"; 
        static ColorScheme scheme = new ColorScheme();

        // Generate a 6-digit OTP
        public static Random Random = new Random();
        static SoundPlayer player = new SoundPlayer();
        
        public static void ClickSound() 
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + startupPath + "\\audio\\click-tone.wav";
                player.Play();
            }
        }

        public static void CaptureSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + startupPath + "\\audio\\select-click.wav";
                player.Play();
            }
        }

        public static void RemoveSound()   
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + startupPath + "\\audio\\select-click.wav";
                player.Play();
            }
        }

        public static void InputErrorSound() 
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + startupPath + "\\audio\\click-error.wav";
                player.Play();
            }
        }
        public static int MonthDays(int month)
        {
            switch(month)
            {
                case 1: return 31;
                case 2: return 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
            }
            return 0;
        }
        public static void Sound()
        {
            //player.Play();
            player.SoundLocation = @"" + startupPath + "\\audio\\click-tone.wav";
            player.SoundLocation = @"" + startupPath + "\\audio\\alert-bells-echo.wav";
            player.Play();
            player.SoundLocation = @"" + startupPath + "\\audio\\select-click.wav";
            //player.Play();
            //player.Play();
        }
        public static void AlertSound(enmType type)   
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                switch (type)
                {
                    case enmType.Success:
                        player.SoundLocation = @"" + startupPath + "\\audio\\notification.wav";
                        break;
                    case enmType.Error:
                        player.SoundLocation = @"" + startupPath + "\\audio\\click-error.wav";
                        break;
                    case enmType.Info:
                        player.SoundLocation = @"" + startupPath + "\\audio\\alert-bells-echo.wav";
                        break;
                    case enmType.Warning:
                        player.SoundLocation = @"" + startupPath + "\\audio\\click-error.wav";
                        break;
                }
                player.Play();
            }
        }
        public static bool CheckForInternetConnection()
        {
            return true;
        }
        public static bool IsInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }                   
            }
            catch
            {
                return false;
            }
        }
        public static void RollCallEmail((string, DataSet, int) htmlString, string ToMailAddress) 
        {
            try
            {
                string inmate = "";
                foreach (DataRow dataRow in htmlString.Item2.Tables["result"].Rows)
                {
                    if (Convert.ToInt32(dataRow["id"]) == htmlString.Item3)
                    {
                        //Id = Convert.ToInt32(dataRow["id"].ToString());
                        classes.Dormitory Dormitory = new classes.Dormitory();
                        classes.Crimes_Committed Committed = new classes.Crimes_Committed();
                        var converter = new GroupDocs.Conversion.Converter(startupPath + "\\Face\\" + AES.Decrypt(dataRow["code"].ToString(), Resources.PassPhrase) + ".bmp");
                        var convertOptions = converter.GetPossibleConversions()["svg"].ConvertOptions;
                        converter.Convert(startupPath + "\\Face\\svg.svg", convertOptions);

                        inmate = "<font>" + File.ReadAllText(startupPath + "\\Face\\svg.svg") + "</font><br><br>";
                        inmate += "<font>Inmate Code : <strong>" + AES.Decrypt(dataRow["code"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Dormitory : <strong>" + AES.Decrypt(Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Fullname : <strong>" + AES.Decrypt(dataRow["last_name"].ToString(), Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Gender : <strong>" + AES.Decrypt(dataRow["gender"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Date of Birth : <strong>" + Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy") + "</strong></font><br>";
                        inmate += "<font>Address : <strong>" + AES.Decrypt(dataRow["address"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Marital Status : <strong>" + AES.Decrypt(dataRow["marital_status"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Eye Color : <strong>" + AES.Decrypt(dataRow["eye_color"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Complexion : <strong>" + AES.Decrypt(dataRow["complexion"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        bool Isfirst = true;
                        string crimes = "";
                        Committed.dataSet = Committed.GetCrimes();
                        if (Committed.dataSet != null)
                            foreach (DataRow data in Committed.dataSet.Tables["result"].Rows)
                            {
                                if (Convert.ToInt32(dataRow["id"]) == Convert.ToInt32(data["inmate_id"]))
                                {
                                    if (Isfirst)
                                    {
                                        crimes = AES.Decrypt(data["name"].ToString(), Resources.PassPhrase);
                                        Isfirst = false;
                                    }
                                    else
                                        crimes = crimes + ", " + AES.Decrypt(data["name"].ToString(), Resources.PassPhrase);
                                }
                            }
                        inmate += "<font>Crimes Committed : <strong>" + crimes + "</strong></font><br>";
                        inmate += "<font>Sentence Start Date : <strong>" + Convert.ToDateTime(dataRow["start_date"]).ToString("dd/MM/yyyy") + "</strong></font><br>";
                        inmate += "<font>Sentence End Date : <strong>" + Convert.ToDateTime(dataRow["end_date"]).ToString("dd/MM/yyyy") + "</strong></font><br>";

                        DateTimePicker Start = new DateTimePicker();
                        DateTimePicker End = new DateTimePicker();
                        Start.Value = Convert.ToDateTime(dataRow["start_date"]);
                        End.Value = Convert.ToDateTime(dataRow["end_date"]);

                        inmate += "<font>Sentence : <strong>" + Calculate.Sentence(Start, End) + "</strong></font><br>";
                        inmate += "<font>Emergency Name : <strong>" + AES.Decrypt(dataRow["emergency_name"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Emergency Contact : <strong>" + AES.Decrypt(dataRow["emergency_contact"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Emergency Relation : <strong>" + AES.Decrypt(dataRow["emergency_relation"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                    }
                }
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(Resources.SenderEmail);
                message.To.Add(new MailAddress(ToMailAddress));
                message.Subject = "Inmate Details - Escaped";
                message.IsBodyHtml = true; //to make message body as html
                message.Body = "<font>Roll Call Code : <strong>" + htmlString.Item1 + "</strong></font><br><br>";
                message.Body += inmate + "<br>";
                message.Body += "<font>Please do not reply for this email was auto-generated by the Maula Prisoners Management System.</font><br><br>";
                message.Body += "<font>Regards</font><br>";
                message.Body += "<font><strong>Maula Prisoners Management System</strong></font>";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Resources.SenderEmail, Resources.SenderPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                ServerMessage(ex.ToString());
            }
        }
        public static void Email((string, string) htmlString, string ToMailAddress)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(Resources.SenderEmail);
                message.To.Add(new MailAddress(ToMailAddress));
                message.Subject = Resources.OTPSubject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = "<font>This is your Username: <strong>" + htmlString.Item1 + "</strong></font><br>";
                message.Body += "<font>This is your One-Time Password: <strong>" + htmlString.Item2 + "</strong></font><br><br>";
                message.Body += "<font>Use them to log in into the Maula Prison Roll Call and Management System.</font><br>";
                message.Body += "<font>After providing these details you need to set a new password.</font><br>";
                message.Body += "<font>Please do not reply for this mail was auto-generated by the Maula Prison Roll Call and Management System.</font><br>";
                message.Body += "<font>Regards</font>";
                message.Body += "<font><strong>The Officer In Charge (OC)</strong></font>";
                message.Body += "<font><strong>Bright Mwale</strong></font>";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Resources.SenderEmail, Resources.SenderPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) 
            {
                ServerMessage(ex.ToString());
            }
        }
        public static void Alert(string msg, enmType type)
        {
            alert alert = new alert();
            alert.TopMost = true;
            alert.showAlert(msg, type);
        }
        public static Size AppSize;
        public static Point AppLocation;
        public static Size PopupSize;
        public static Point GetLocation(Size app, Size popup, Point applocation)
        {
            return new Point(
                applocation.X + ((app.Width / 2) - (popup.Width / 2)),
                applocation.Y + ((app.Height / 2) - (popup.Height / 2)));
        }
        public static Point LoaderLocation(Size app, Point applocation) 
        {
            return new Point(
                applocation.X + ((app.Width / 2)),
                applocation.Y + ((app.Height / 2)));
        }
        public static void ServerMessage(string message)
        {
            MessageBox.Show("Server Error : " + message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        public static void BunifuFlatButton(ColorScheme scheme, BunifuFlatButton flatButton)
        {
            flatButton.Activecolor = scheme.BunifuFlatButtonAC;
            flatButton.Textcolor = scheme.BunifuFlatButtonTC;
            flatButton.BackColor = scheme.BunifuFlatButtonBG;
            flatButton.ForeColor = scheme.BunifuFlatButtonFG;
            flatButton.Normalcolor = scheme.BunifuFlatButtonBG;
            flatButton.OnHovercolor = scheme.BunifuFlatButtonHC;
        }
        public static void SearchTheme(ColorScheme scheme, Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is FlowLayoutPanel)
                {
                    SearchTheme(scheme, component.Controls);
                    component.BackColor = scheme.SearchUserControlBG;
                    component.ForeColor = scheme.FlowLayoutPanelFG;
                }
        }
        public static void notificationTheme(ColorScheme scheme, Control.ControlCollection container)
        {
            foreach (Control component in container) 
                if (component is FlowLayoutPanel)
                {
                    notificationTheme(scheme, component.Controls);
                    component.BackColor = scheme.NotificationUserControlBG;
                    component.ForeColor = scheme.FlowLayoutPanelFG;
                }
                else if (component is Panel)
                {
                    notificationTheme(scheme, component.Controls);
                    component.BackColor = scheme.NotificationUserControlBG;
                    component.ForeColor = scheme.PanelFG;
                }
                else if (component is Label)
                {
                    component.BackColor = scheme.NotificationUserControlBG;
                    component.ForeColor = scheme.LabelFG;
                }
        }

        public static void Card(ColorScheme scheme, Control.ControlCollection container)
        {
            foreach (Control component in container) 
                if (component is Label)
                {
                    component.BackColor = scheme.CardLabelBG; 
                    component.ForeColor = scheme.CardLabelFG; 
                }
                else if (component is Bunifu.Framework.UI.BunifuImageButton)
                {
                    component.BackColor = scheme.CardBunifuImageButtonBG;
                    component.ForeColor = scheme.CardBunifuImageButtonFG;
                }
        }
        public static void UserControl(ColorScheme scheme, UserControl userControl)
        {
            if (userControl.Name == "search")
            {
                SearchTheme(scheme, userControl.Controls); 
                userControl.BackColor = scheme.SearchUserControlBG;
                userControl.ForeColor = scheme.UserControlFG;
            }
            else if (userControl.Name == "notifications")
            {
                notificationTheme(scheme, userControl.Controls);
                userControl.BackColor = scheme.NotificationUserControlBG;
                userControl.ForeColor = scheme.UserControlFG;
            }
            else if (userControl.Name == "menu") 
            {
                ChangeTheme(scheme, userControl.Controls);
                userControl.BackColor = scheme.SearchUserControlBG;
                userControl.ForeColor = scheme.UserControlFG;
            }
            else if (userControl.Name == "card")
            {
                Card(scheme, userControl.Controls); 
                userControl.BackColor = scheme.CardUserControlBG;
                userControl.ForeColor = scheme.UserControlFG;
            }
            else
            {
                ChangeTheme(scheme, userControl.Controls);
                userControl.BackColor = scheme.UserControlBG;
                userControl.ForeColor = scheme.UserControlFG;
            }
        }
        public static void BunifuDropdown(ColorScheme scheme, Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown)
        {
            bunifuDropdown.Color = scheme.BunifuDropdownC;
            bunifuDropdown.BackColor = scheme.BunifuDropdownBG;
            bunifuDropdown.IndicatorColor = scheme.BunifuDropdownFG;
            bunifuDropdown.ForeColor = scheme.BunifuDropdownFG;
        }
        public static void BunifuDatePicker(ColorScheme scheme, BunifuDatePicker bunifuDatePicker)
        {
            bunifuDatePicker.Color = scheme.BunifuDropdownC;
            bunifuDatePicker.BackColor = scheme.BunifuDatePickerBG;
            bunifuDatePicker.ForeColor = scheme.BunifuDatePickerFG;
            bunifuDatePicker.Icon = Properties.Resources.calendar;
        }
        public static void BunifuTextBox(ColorScheme scheme, BunifuTextBox bunifuTextBox)  
        {
            bunifuTextBox.FillColor = scheme.BunifuTextBoxFC;
            bunifuTextBox.BackColor = scheme.BunifuTextBoxBG;
            bunifuTextBox.ForeColor = scheme.BunifuTextBoxFG; 
        }
        public static void ChangeTheme(ColorScheme scheme, Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is Panel)
                {
                    ChangeTheme(scheme, component.Controls);
                    component.BackColor = scheme.PanelBG;
                    component.ForeColor = scheme.PanelFG;
                }
                else if (component is FlowLayoutPanel)
                {
                    ChangeTheme(scheme, component.Controls);
                    component.BackColor = scheme.FlowLayoutPanelBG;
                    component.ForeColor = scheme.FlowLayoutPanelFG;
                }
                else if (component is GroupBox)
                {
                    ChangeTheme(scheme, component.Controls);
                    component.BackColor = scheme.GroupBoxBG;
                    component.ForeColor = scheme.GroupBoxFG;
                }
                else if (component is BunifuFlatButton)
                {
                    BunifuFlatButton(scheme, (BunifuFlatButton)component);
                }
                else if (component is Bunifu.Framework.UI.BunifuImageButton)
                {
                    component.BackColor = scheme.BunifuImageButtonBG;
                    component.ForeColor = scheme.BunifuImageButtonFG;
                }
                else if (component is BunifuMetroTextbox)
                {
                    component.BackColor = scheme.BunifuMetroTextboxBG;
                    component.ForeColor = scheme.BunifuMetroTextboxFG;
                }
                else if (component is BunifuTextBox)
                {
                    BunifuTextBox(scheme, (BunifuTextBox)component);
                }
                else if (component is BunifuSeparator)
                {
                    //(BunifuSeparator)component.LineColor = scheme.BunifuSeparatorBG;
                    component.ForeColor = scheme.BunifuSeparatorFG;
                }
                else if (component is BunifuDatePicker)
                {
                    BunifuDatePicker(scheme, (BunifuDatePicker)component);
                }
                else if (component is Bunifu.UI.WinForms.BunifuDropdown)
                {
                    BunifuDropdown(scheme, (Bunifu.UI.WinForms.BunifuDropdown)component);
                }
                else if (component is RichTextBox)
                {
                    component.BackColor = scheme.RichTextBoxBG;
                    component.ForeColor = scheme.RichTextBoxFG;
                }
                else if (component is Button)
                {
                    component.BackColor = scheme.ButtonBG;
                    component.ForeColor = scheme.ButtonFG;
                }
                else if (component is TextBox)
                {
                    component.BackColor = scheme.TextBoxBG;
                    component.ForeColor = scheme.TextBoxFG;
                }
                else if (component is PictureBox)
                {
                    component.BackColor = scheme.PictureBoxBG;
                    component.ForeColor = scheme.PictureBoxFG;
                }
                else if (component is Label)
                {
                    component.BackColor = scheme.LabelBG;
                    component.ForeColor = scheme.LabelFG;
                }
                else if (component is UserControl)
                {
                    UserControl(scheme, (UserControl)component);
                }
                else
                {
                    component.BackColor = scheme.BG;
                    component.ForeColor = scheme.FG;
                }
        }
        public static void LoadTheme(Control.ControlCollection container)
        {
            if (Convert.ToBoolean(File.ReadAllText(theme)))
            {
                scheme.LightTheme();
            }
            else
            {
                scheme.DarkTheme();
            }
            ChangeTheme(scheme, container);
        }
    }
    public class ColorScheme
    {
        public Color PanelBG;
        public Color PanelFG;

        public Color ButtonBG;
        public Color ButtonFG;

        public Color TextBoxBG;
        public Color TextBoxFG;

        public Color BunifuTextBoxFC; 
        public Color BunifuTextBoxFG; 
        public Color BunifuTextBoxBG;

        public Color FlowLayoutPanelBG;
        public Color FlowLayoutPanelFG;

        public Color SearchUserControlBG;
        public Color NotificationUserControlBG; 
        public Color CardUserControlBG;  
        public Color UserControlBG;
        public Color UserControlFG;

        public Color BunifuFlatButtonAC;
        public Color BunifuFlatButtonTC;
        public Color BunifuFlatButtonBG;
        public Color BunifuFlatButtonNC;
        public Color BunifuFlatButtonFG;
        public Color BunifuFlatButtonHC;

        public Color CardBunifuImageButtonBG; 
        public Color CardBunifuImageButtonFG; 
        public Color BunifuImageButtonBG;
        public Color BunifuImageButtonFG;

        public Color BunifuMetroTextboxBG;
        public Color BunifuMetroTextboxFG;

        public Color BunifuSeparatorBG;
        public Color BunifuSeparatorFG;

        public Color BunifuDatePickerBG;
        public Color BunifuDatePickerFG;

        public Color BunifuDropdownC;
        public Color BunifuDropdownBG;
        public Color BunifuDropdownFG;

        public Color GroupBoxBG;
        public Color GroupBoxFG;

        public Color RichTextBoxBG;
        public Color RichTextBoxFG;

        public Color PictureBoxBG;
        public Color PictureBoxFG; 

        public Color CardLabelBG;   
        public Color CardLabelFG;
        public Color LabelBG;
        public Color LabelFG;

        public Color BG;
        public Color FG;

        public void LightTheme()
        {
            PanelFG = Color.FromArgb(42, 42, 49);
            PanelBG = Color.WhiteSmoke;

            ButtonFG = Color.FromArgb(26, 104, 255);
            ButtonBG = Color.White;

            TextBoxFG = Color.FromArgb(42, 42, 49);
            TextBoxBG = Color.White;

            BunifuTextBoxFG = Color.FromArgb(42, 42, 49);
            BunifuTextBoxFC = Color.White;
            BunifuTextBoxBG = Color.White;

            FlowLayoutPanelFG = Color.FromArgb(42, 42, 49);
            FlowLayoutPanelBG = Color.White;

            CardUserControlBG = Color.White;
            SearchUserControlBG = Color.White;
            NotificationUserControlBG = Color.White;
            UserControlFG = Color.FromArgb(42, 42, 49); 
            UserControlBG = Color.WhiteSmoke;

            BunifuFlatButtonTC = Color.FromArgb(17, 17, 18);
            BunifuFlatButtonBG = Color.White;
            BunifuFlatButtonNC = Color.White;
            BunifuFlatButtonAC = Color.FromArgb(26, 104, 255);
            BunifuFlatButtonFG = Color.FromArgb(17, 17, 18);
            BunifuFlatButtonHC = Color.FromArgb(26, 104, 255);

            CardBunifuImageButtonBG = Color.White;
            CardBunifuImageButtonFG = Color.FromArgb(42, 42, 49);
            BunifuImageButtonFG = Color.FromArgb(42, 42, 49);
            BunifuImageButtonBG = Color.WhiteSmoke;

            BunifuMetroTextboxFG = Color.FromArgb(42, 42, 49);
            BunifuMetroTextboxBG = Color.White;

            BunifuSeparatorFG = Color.FromArgb(42, 42, 49);
            BunifuSeparatorBG = Color.White;

            BunifuDatePickerFG = Color.FromArgb(42, 42, 49);
            BunifuDatePickerBG = Color.White;

            BunifuDropdownC = Color.White;
            BunifuDropdownFG = Color.FromArgb(42, 42, 49);
            BunifuDropdownBG = Color.White;

            GroupBoxFG = Color.FromArgb(42, 42, 49);
            GroupBoxBG = Color.WhiteSmoke;

            RichTextBoxFG = Color.FromArgb(42, 42, 49);
            RichTextBoxBG = Color.White;

            PictureBoxBG = Color.WhiteSmoke;
            PictureBoxFG = Color.FromArgb(32, 32, 36);

            CardLabelBG = Color.White;
            CardLabelFG = Color.FromArgb(42, 42, 49);
            LabelFG = Color.FromArgb(42, 42, 49);
            LabelBG = Color.WhiteSmoke;

            FG = Color.FromArgb(42, 42, 49);
            BG = Color.White;
        }
        public void DarkTheme()
        {
            PanelFG = Color.White;
            PanelBG = Color.FromArgb(32, 32, 36);

            ButtonBG = Color.FromArgb(26, 104, 255);
            ButtonFG = Color.White;

            TextBoxBG = Color.FromArgb(42, 42, 49);
            TextBoxFG = Color.White;

            BunifuTextBoxFC = Color.FromArgb(42, 42, 49);
            BunifuTextBoxFG = Color.White;
            BunifuTextBoxBG = Color.FromArgb(42, 42, 49);

            FlowLayoutPanelBG = Color.FromArgb(32, 32, 36);
            FlowLayoutPanelFG = Color.White;

            CardUserControlBG = Color.FromArgb(42, 42, 49);
            SearchUserControlBG = Color.FromArgb(42, 42, 49);
            NotificationUserControlBG = Color.FromArgb(42, 42, 49);
            UserControlFG = Color.White;
            UserControlBG = Color.FromArgb(32, 32, 36);

            BunifuFlatButtonTC = Color.White;
            BunifuFlatButtonBG = Color.FromArgb(42, 42, 49);
            BunifuFlatButtonNC = Color.FromArgb(42, 42, 49);
            BunifuFlatButtonAC = Color.FromArgb(17, 17, 18);
            BunifuFlatButtonFG = Color.White;
            BunifuFlatButtonHC = Color.FromArgb(17, 17, 18);

            CardBunifuImageButtonBG = Color.FromArgb(42, 42, 49);
            CardBunifuImageButtonFG = Color.White;
            BunifuImageButtonBG = Color.FromArgb(32, 32, 36);
            BunifuImageButtonFG = Color.White;

            BunifuMetroTextboxBG = Color.FromArgb(42, 42, 49);
            BunifuMetroTextboxFG = Color.White;

            BunifuSeparatorBG = Color.FromArgb(42, 42, 49);
            BunifuSeparatorFG = Color.White;

            BunifuDatePickerBG = Color.FromArgb(42, 42, 49);
            BunifuDatePickerFG = Color.White;

            BunifuDropdownC = Color.FromArgb(42, 42, 49);
            BunifuDropdownBG = Color.FromArgb(42, 42, 49);
            BunifuDropdownFG = Color.White;

            GroupBoxBG = Color.FromArgb(32, 32, 36);
            GroupBoxFG = Color.White;

            RichTextBoxBG = Color.FromArgb(42, 42, 49);
            RichTextBoxFG = Color.White;

            PictureBoxBG = Color.FromArgb(32, 32, 36);
            PictureBoxFG = Color.White;

            CardLabelBG = Color.FromArgb(42, 42, 49);
            CardLabelFG = Color.White;
            LabelBG = Color.FromArgb(32, 32, 36);
            LabelFG = Color.White;

            BG = Color.FromArgb(42, 42, 49);
            FG = Color.White;
        }
    }

    internal class AES
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}

namespace Emgu.CV
{
    /// <summary>
    /// An object recognizer using PCA (Principle Components Analysis)
    /// </summary>
    [Serializable]
    public class Recognizer
    {
        private Image<Gray, Single>[] _eigenImages;
        private Image<Gray, Single> _avgImage;
        private Matrix<float>[] _eigenValues;
        private string[] _labels;
        private double _eigenDistanceThreshold;

        /// <summary>
        /// Get the eigen vectors that form the eigen space
        /// </summary>
        /// <remarks>The set method is primary used for deserialization, do not attemps to set it unless you know what you are doing</remarks>
        public Image<Gray, Single>[] EigenImages
        {
            get { return _eigenImages; }
            set { _eigenImages = value; }
        }

        /// <summary>
        /// Get or set the labels for the corresponding training image
        /// </summary>
        public String[] Labels
        {
            get { return _labels; }
            set { _labels = value; }
        }

        /// <summary>
        /// Get or set the eigen distance threshold.
        /// The smaller the number, the more likely an examined image will be treated as unrecognized object. 
        /// Set it to a huge number (e.g. 5000) and the recognizer will always treated the examined image as one of the known object. 
        /// </summary>
        public double EigenDistanceThreshold
        {
            get { return _eigenDistanceThreshold; }
            set { _eigenDistanceThreshold = value; }
        }

        /// <summary>
        /// Get the average Image. 
        /// </summary>
        /// <remarks>The set method is primary used for deserialization, do not attemps to set it unless you know what you are doing</remarks>
        public Image<Gray, Single> AverageImage
        {
            get { return _avgImage; }
            set { _avgImage = value; }
        }

        /// <summary>
        /// Get the eigen values of each of the training image
        /// </summary>
        /// <remarks>The set method is primary used for deserialization, do not attemps to set it unless you know what you are doing</remarks>
        public Matrix<float>[] EigenValues
        {
            get { return _eigenValues; }
            set { _eigenValues = value; }
        }

        private Recognizer()
        {
        }


        /// <summary>
        /// Create an object recognizer using the specific tranning data and parameters, it will always return the most similar object
        /// </summary>
        /// <param name="images">The images used for training, each of them should be the same size. It's recommended the images are histogram normalized</param>
        /// <param name="termCrit">The criteria for recognizer training</param>
        public Recognizer(Image<Gray, Byte>[] images, ref MCvTermCriteria termCrit)
           : this(images, GenerateNames(images.Length), ref termCrit)
        {
        }

        private static String[] GenerateNames(int size)
        {
            String[] names = new string[size];
            for (int i = 0; i < size; i++)
                names[i] = i.ToString();
            return names;
        }

        /// <summary>
        /// Create an object recognizer using the specific tranning data and parameters, it will always return the most similar object
        /// </summary>
        /// <param name="images">The images used for training, each of them should be the same size. It's recommended the images are histogram normalized</param>
        /// <param name="labels">The labels corresponding to the images</param>
        /// <param name="termCrit">The criteria for recognizer training</param>
        public Recognizer(Image<Gray, Byte>[] images, String[] labels, ref MCvTermCriteria termCrit)
           : this(images, labels, 0, ref termCrit)
        {
        }

        /// <summary>
        /// Create an object recognizer using the specific tranning data and parameters
        /// </summary>
        /// <param name="images">The images used for training, each of them should be the same size. It's recommended the images are histogram normalized</param>
        /// <param name="labels">The labels corresponding to the images</param>
        /// <param name="eigenDistanceThreshold">
        /// The eigen distance threshold, (0, ~1000].
        /// The smaller the number, the more likely an examined image will be treated as unrecognized object. 
        /// If the threshold is &lt; 0, the recognizer will always treated the examined image as one of the known object. 
        /// </param> 
        /// <param name="termCrit">The criteria for recognizer training</param>
        public Recognizer(Image<Gray, Byte>[] images, String[] labels, double eigenDistanceThreshold, ref MCvTermCriteria termCrit)
        {
            Debug.Assert(images.Length == labels.Length, "The number of images should equals the number of labels");
            Debug.Assert(eigenDistanceThreshold >= 0.0, "Eigen-distance threshold should always >= 0.0");

            CalcEigenObjects(images, ref termCrit, out _eigenImages, out _avgImage);


            _avgImage.SerializationCompressionRatio = 9;

            foreach (Image<Gray, Single> img in _eigenImages)
                //Set the compression ration to best compression. The serialized object can therefore save spaces
                img.SerializationCompressionRatio = 9;


            _eigenValues = Array.ConvertAll<Image<Gray, Byte>, Matrix<float>>(images,
                delegate (Image<Gray, Byte> img)
                {
                    return new Matrix<float>(EigenDecomposite(img, _eigenImages, _avgImage));
                });

            _labels = labels;

            _eigenDistanceThreshold = eigenDistanceThreshold;
        }

        #region static methods
        /// <summary>
        /// Caculate the eigen images for the specific traning image
        /// </summary>
        /// <param name="trainingImages">The images used for training </param>
        /// <param name="termCrit">The criteria for tranning</param>
        /// <param name="eigenImages">The resulting eigen images</param>
        /// <param name="avg">The resulting average image</param>
        public static void CalcEigenObjects(Image<Gray, Byte>[] trainingImages, ref MCvTermCriteria termCrit, out Image<Gray, Single>[] eigenImages, out Image<Gray, Single> avg)
        {
            int width = trainingImages[0].Width;
            int height = trainingImages[0].Height;

            IntPtr[] inObjs = Array.ConvertAll<Image<Gray, Byte>, IntPtr>(trainingImages, delegate (Image<Gray, Byte> img) { return img.Ptr; });

            if (termCrit.max_iter <= 0 || termCrit.max_iter > trainingImages.Length)
                termCrit.max_iter = trainingImages.Length;

            int maxEigenObjs = termCrit.max_iter;

            #region initialize eigen images
            eigenImages = new Image<Gray, float>[maxEigenObjs];
            for (int i = 0; i < eigenImages.Length; i++)
                eigenImages[i] = new Image<Gray, float>(width, height);
            IntPtr[] eigObjs = Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; });
            #endregion

            avg = new Image<Gray, Single>(width, height);

            CvInvoke.cvCalcEigenObjects(
                inObjs,
                ref termCrit,
                eigObjs,
                null,
                avg.Ptr);
        }

        /// <summary>
        /// Decompose the image as eigen values, using the specific eigen vectors
        /// </summary>
        /// <param name="src">The image to be decomposed</param>
        /// <param name="eigenImages">The eigen images</param>
        /// <param name="avg">The average images</param>
        /// <returns>Eigen values of the decomposed image</returns>
        public static float[] EigenDecomposite(Image<Gray, Byte> src, Image<Gray, Single>[] eigenImages, Image<Gray, Single> avg)
        {
            return CvInvoke.cvEigenDecomposite(
                src.Ptr,
                Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; }),
                avg.Ptr);
        }
        #endregion

        /// <summary>
        /// Given the eigen value, reconstruct the projected image
        /// </summary>
        /// <param name="eigenValue">The eigen values</param>
        /// <returns>The projected image</returns>
        public Image<Gray, Byte> EigenProjection(float[] eigenValue)
        {
            Image<Gray, Byte> res = new Image<Gray, byte>(_avgImage.Width, _avgImage.Height);
            CvInvoke.cvEigenProjection(
                Array.ConvertAll<Image<Gray, Single>, IntPtr>(_eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; }),
                eigenValue,
                _avgImage.Ptr,
                res.Ptr);
            return res;
        }

        /// <summary>
        /// Get the Euclidean eigen-distance between <paramref name="image"/> and every other image in the database
        /// </summary>
        /// <param name="image">The image to be compared from the training images</param>
        /// <returns>An array of eigen distance from every image in the training images</returns>
        public float[] GetEigenDistances(Image<Gray, Byte> image)
        {
            using (Matrix<float> eigenValue = new Matrix<float>(EigenDecomposite(image, _eigenImages, _avgImage)))
                return Array.ConvertAll<Matrix<float>, float>(_eigenValues,
                    delegate (Matrix<float> eigenValueI)
                    {
                        return (float)CvInvoke.cvNorm(eigenValue.Ptr, eigenValueI.Ptr, Emgu.CV.CvEnum.NORM_TYPE.CV_L2, IntPtr.Zero);
                    });
        }

        /// <summary>
        /// Given the <paramref name="image"/> to be examined, find in the database the most similar object, return the index and the eigen distance
        /// </summary>
        /// <param name="image">The image to be searched from the database</param>
        /// <param name="index">The index of the most similar object</param>
        /// <param name="eigenDistance">The eigen distance of the most similar object</param>
        /// <param name="label">The label of the specific image</param>
        public void FindMostSimilarObject(Image<Gray, Byte> image, out int index, out float eigenDistance, out String label)
        {
            float[] dist = GetEigenDistances(image);

            index = 0;
            eigenDistance = dist[0];
            for (int i = 1; i < dist.Length; i++)
            {
                if (dist[i] < eigenDistance)
                {
                    index = i;
                    eigenDistance = dist[i];
                }
            }
            label = Labels[index];
        }

        /// <summary>
        /// Try to recognize the image and return its label
        /// </summary>
        /// <param name="image">The image to be recognized</param>
        /// <returns>
        /// String.Empty, if not recognized;
        /// Label of the corresponding image, otherwise
        /// </returns>
        public String Recognize(Image<Gray, Byte> image)
        {
            int index;
            float eigenDistance;
            String label;
            FindMostSimilarObject(image, out index, out eigenDistance, out label);

            return (_eigenDistanceThreshold <= 0 || eigenDistance < _eigenDistanceThreshold) ? _labels[index] : String.Empty;
        }
    }
}

