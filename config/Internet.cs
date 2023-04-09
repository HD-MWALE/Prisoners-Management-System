using Roll_Call_And_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.config
{
    internal class Internet
    {
        private string Path = Application.StartupPath;

        public bool IsInternetConnectionAvailable()
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

        public void RollCallEmail((string, DataSet, int) htmlString, string ToMailAddress)
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
                        var converter = new GroupDocs.Conversion.Converter(Path + "\\Face\\" + ini.AES.Decrypt(dataRow["code"].ToString(), Resources.PassPhrase) + ".bmp");
                        var convertOptions = converter.GetPossibleConversions()["svg"].ConvertOptions;
                        converter.Convert(Path + "\\Face\\svg.svg", convertOptions);

                        inmate = "<font>" + File.ReadAllText(Path + "\\Face\\svg.svg") + "</font><br><br>";
                        inmate += "<font>Inmate Code : <strong>" + ini.AES.Decrypt(dataRow["code"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Dormitory : <strong>" + ini.AES.Decrypt(Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Fullname : <strong>" + ini.AES.Decrypt(dataRow["last_name"].ToString(), Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Gender : <strong>" + ini.AES.Decrypt(dataRow["gender"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Date of Birth : <strong>" + Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy") + "</strong></font><br>";
                        inmate += "<font>Address : <strong>" + ini.AES.Decrypt(dataRow["address"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Marital Status : <strong>" + ini.AES.Decrypt(dataRow["marital_status"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Eye Color : <strong>" + ini.AES.Decrypt(dataRow["eye_color"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Complexion : <strong>" + ini.AES.Decrypt(dataRow["complexion"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        bool Isfirst = true;
                        string crimes = "";
                        Committed.dataSet = Committed.GetAll();
                        if (Committed.dataSet != null)
                            foreach (DataRow data in Committed.dataSet.Tables["result"].Rows)
                            {
                                if (Convert.ToInt32(dataRow["id"]) == Convert.ToInt32(data["inmate_id"]))
                                {
                                    if (Isfirst)
                                    {
                                        crimes = ini.AES.Decrypt(data["name"].ToString(), Resources.PassPhrase);
                                        Isfirst = false;
                                    }
                                    else
                                        crimes = crimes + ", " + ini.AES.Decrypt(data["name"].ToString(), Resources.PassPhrase);
                                }
                            }
                        inmate += "<font>Crimes Committed : <strong>" + crimes + "</strong></font><br>";
                        inmate += "<font>Sentence Start Date : <strong>" + Convert.ToDateTime(dataRow["start_date"]).ToString("dd/MM/yyyy") + "</strong></font><br>";
                        inmate += "<font>Sentence End Date : <strong>" + Convert.ToDateTime(dataRow["end_date"]).ToString("dd/MM/yyyy") + "</strong></font><br>";

                        DateTimePicker Start = new DateTimePicker();
                        DateTimePicker End = new DateTimePicker();
                        Start.Value = Convert.ToDateTime(dataRow["start_date"]);
                        End.Value = Convert.ToDateTime(dataRow["end_date"]);

                        inmate += "<font>Sentence : <strong>" + ini.Calculate.Sentence(Start, End) + "</strong></font><br>";
                        inmate += "<font>Emergency Name : <strong>" + ini.AES.Decrypt(dataRow["emergency_name"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Emergency Contact : <strong>" + ini.AES.Decrypt(dataRow["emergency_contact"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
                        inmate += "<font>Emergency Relation : <strong>" + ini.AES.Decrypt(dataRow["emergency_relation"].ToString(), Resources.PassPhrase) + "</strong></font><br>";
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
                ini.Alerts.ServerMessage(ex.ToString());
            }
        }
        public void Email((string, string) htmlString, string ToMailAddress)
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
                ini.Alerts.ServerMessage(ex.ToString());
            }
        }
    }
}
