using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;
using Prisoners_Management_System.views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Color = System.Drawing.Color;

namespace Prisoners_Management_System
{
    internal class Validate 
    {
        // Regular expression used to validate.
        public const string PhoneNumberRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public bool IsNull(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            else
                return false;
        }
        public bool IsTextNumber(string value) 
        {
            if (IsNull(value))
                return false;
            else
            {
                foreach (char c in value)
                {
                    if (!Char.IsLetterOrDigit(c))
                        return false;
                }
                return true;
            }
        }
        public bool IsText(string name)   
        {
            if (IsNull(name))
                return false;
            else
            {
                foreach (char c in name)
                {
                    if (!Char.IsLetter(c))
                        return false;
                }
                return true;
            }
        }
        public bool IsNumber(string number)  
        {
            if (IsNull(number))
                return false;
            else
            {
                foreach (Char c in number)
                {
                    if (!Char.IsDigit(c))
                        return false;
                }
                return true;
            }
        }
        public bool IsEmail(string email) 
        {
            if (IsNull(email))
                return false;
            else
                if(email.Contains("."))
                    return new EmailAddressAttribute().IsValid(email);
                else
                    return false;
        }
        public bool IsPassword(string password) 
        {
            if (IsNull(password))
                return false;
            else
            {
                if (password.Length <= 7)
                    return false;
                if (password.Length >= 17)
                    return false;
                if (IsUpperCase(password) <= 0 || IsLowerCase(password) <= 0)
                    return false;
                return true;
            }
        }
        public bool IsPhoneNumber(string number)
        {
            if (IsNull(number))
                return false;
            else
                return Regex.IsMatch(number, PhoneNumberRegex); 
        }
        public int IsUpperCase(string value) 
        {
            var countUpper = 0;
            foreach (var c in value)
            {
                if (char.IsUpper(c))
                {
                    countUpper++;
                }
            }
            return countUpper;
        }
        public int IsLowerCase(string value) 
        {
            var countLower = 0;
            foreach (var c in value)
            {
                if (char.IsLower(c))
                {
                    countLower++;
                }
            }
            return countLower;
        }
    }
}
