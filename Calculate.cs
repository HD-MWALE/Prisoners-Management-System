using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System
{
    internal class Calculate
    {
        public static string Sentence(DateTimePicker Start, DateTimePicker End)
        {
            int years = End.Value.Year - Start.Value.Year;
            int mouths = End.Value.Month - Start.Value.Month;
            int days = End.Value.Day - Start.Value.Day;

            string plural = "s";
            string sentence = "";

            if (mouths.ToString().Contains("-"))
            {
                if ((years - 1) == 1) plural = ""; else plural = "s";
                sentence = (years - 1) + " Year" + plural + " ";
                if ((years - 1) == 0) sentence = "";
                if (days.ToString().Contains("-"))
                {
                    if (mouths != 0)
                    {
                        if (mouths == 1) plural = ""; else plural = "s";
                        if (days != 0)
                            sentence += ((12 + mouths) - 1) + " mouth" + plural + " ";
                        else
                            sentence += "and " + ((12 + mouths) - 1) + " mouth" + plural + " ";
                    }
                    if (days == 1) plural = ""; else plural = "s";
                    if (days != 0)
                        sentence += "and " + (Config.MonthDays(Start.Value.Month) + days) + " day" + plural;
                }
                else
                {
                    if (mouths != 0)
                    {
                        if (mouths == 1) plural = ""; else plural = "s";
                        if (days != 0)
                            sentence += (12 + mouths) + " mouth" + plural + " ";
                        else
                            sentence += "and " + (12 + mouths) + " mouth" + plural + " ";
                    }
                    if (days == 1) plural = ""; else plural = "s";
                    if (days != 0)
                        sentence += "and " + days + " day" + plural;
                }
            }
            else if (days.ToString().Contains("-"))
            {
                if (years == 1) plural = ""; else plural = "s";
                sentence = years + " Year" + plural + " ";
                if (years == 0) sentence = "";
                if (mouths != 0)
                {
                    if (mouths == 1) plural = ""; else plural = "s";
                    if (days != 0)
                        sentence += mouths + " mouth" + plural + " ";
                    else
                        sentence += "and " + mouths + " mouth" + plural + " ";
                }
                if (days == 1) plural = ""; else plural = "s";
                if (days != 0)
                    sentence += "and " + (Config.MonthDays(Start.Value.Month) + days) + " day" + plural;
                else
                    sentence = "0 Year";
            }
            else
            {
                if (years == 1) plural = ""; else plural = "s";
                sentence = years + " Year" + plural + " ";
                if (years == 0) sentence = "";
                if (mouths != 0)
                {
                    if (mouths == 1) plural = ""; else plural = "s";
                    if (days != 0)
                        sentence += mouths + " mouth" + plural + " ";
                    else
                        sentence += "and " + mouths + " mouth" + plural + " ";
                }
                if (days == 1) plural = ""; else plural = "s";
                if (days != 0)
                    sentence += "and " + days + " day" + plural + "";
                else 
                    sentence = "0 Year";
            }
            return sentence;
        }
    }
}
