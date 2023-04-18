using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System
{
    internal class Calculate
    {
        public string Sentence(DateTimePicker Start, DateTimePicker End)
        {
            int years = End.Value.Year - Start.Value.Year;
            int mouths = End.Value.Month - Start.Value.Month;
            int days = End.Value.Day - Start.Value.Day;

            string plural = "s", sentence = "";

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
                        if (days != 0) sentence += ((12 + mouths) - 1) + " mouth" + plural + " ";
                        else sentence += "and " + ((12 + mouths) - 1) + " mouth" + plural + " ";
                    }
                    if (days == 1) plural = ""; else plural = "s";
                    if (days != 0) sentence += "and " + (MonthDays(Start.Value.Month) + days) + " day" + plural;
                }
                else
                {
                    if (mouths != 0)
                    {
                        if (mouths == 1) plural = ""; else plural = "s";
                        if (days != 0) sentence += (12 + mouths) + " mouth" + plural + " ";
                        else sentence += "and " + (12 + mouths) + " mouth" + plural + " ";
                    }
                    if (days == 1) plural = ""; else plural = "s";
                    if (days != 0) sentence += "and " + days + " day" + plural;
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
                    if (days != 0) sentence += mouths + " mouth" + plural + " ";
                    else sentence += "and " + mouths + " mouth" + plural + " ";
                }
                if (days == 1) plural = ""; else plural = "s";
                if (days != 0)
                    if(mouths != 0) sentence += "and " + (MonthDays(Start.Value.Month) + days) + " day" + plural;
                    else sentence += (MonthDays(Start.Value.Month) + days) + " day" + plural;
                else sentence = "0 Year";
            }
            else
            {
                if (years == 1) plural = ""; else plural = "s";
                sentence = years + " Year" + plural + " ";
                if (years == 0) sentence = "";
                if (mouths != 0)
                {
                    if (mouths == 1) plural = ""; else plural = "s";
                    if (days != 0) sentence += mouths + " mouth" + plural + " ";
                    else sentence += "and " + mouths + " mouth" + plural + " ";
                }
                if (days == 1) plural = ""; else plural = "s";
                if (days != 0)
                    if (mouths != 0) sentence += "and " + (MonthDays(Start.Value.Month) + days) + " day" + plural;
                    else sentence += (MonthDays(Start.Value.Month) + days) + " day" + plural;
                else sentence = "0 Year";
            }
            return sentence;
        }

        public int MonthDays(int month)
        {
            switch (month)
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
    }
}
