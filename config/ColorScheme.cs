using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuTextbox;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System
{
    public class ColorScheme
    {
        public string Path = Application.StartupPath + "\\settings\\theme.txt"; 

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

        public void BunifuFlatButton(ColorScheme scheme, BunifuFlatButton flatButton)
        {
            flatButton.Activecolor = scheme.BunifuFlatButtonAC;
            flatButton.Textcolor = scheme.BunifuFlatButtonTC;
            flatButton.BackColor = scheme.BunifuFlatButtonBG;
            flatButton.ForeColor = scheme.BunifuFlatButtonFG;
            flatButton.Normalcolor = scheme.BunifuFlatButtonBG;
            flatButton.OnHovercolor = scheme.BunifuFlatButtonHC;
        }
        public void SearchTheme(ColorScheme scheme, Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is FlowLayoutPanel)
                {
                    SearchTheme(scheme, component.Controls);
                    component.BackColor = scheme.SearchUserControlBG;
                    component.ForeColor = scheme.FlowLayoutPanelFG;
                }
        }
        public void notificationTheme(ColorScheme scheme, Control.ControlCollection container)
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

        public void Card(ColorScheme scheme, Control.ControlCollection container)
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
        public void UserControl(ColorScheme scheme, UserControl userControl)
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
        public void BunifuDropdown(ColorScheme scheme, Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown)
        {
            bunifuDropdown.Color = scheme.BunifuDropdownC;
            bunifuDropdown.BackColor = scheme.BunifuDropdownBG;
            bunifuDropdown.IndicatorColor = scheme.BunifuDropdownFG;
            bunifuDropdown.ForeColor = scheme.BunifuDropdownFG;
        }
        public void BunifuDatePicker(ColorScheme scheme, BunifuDatePicker bunifuDatePicker)
        {
            bunifuDatePicker.Color = scheme.BunifuDropdownC;
            bunifuDatePicker.BackColor = scheme.BunifuDatePickerBG;
            bunifuDatePicker.ForeColor = scheme.BunifuDatePickerFG;
            bunifuDatePicker.Icon = Properties.Resources.calendar;
        }
        public void BunifuTextBox(ColorScheme scheme, BunifuTextBox bunifuTextBox)
        {
            bunifuTextBox.FillColor = scheme.BunifuTextBoxFC;
            bunifuTextBox.BackColor = scheme.BunifuTextBoxBG;
            bunifuTextBox.ForeColor = scheme.BunifuTextBoxFG;
        }
        public void ChangeTheme(ColorScheme scheme, Control.ControlCollection container)
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
        public void LoadTheme(Control.ControlCollection container)
        {
            if (Convert.ToBoolean(File.ReadAllText(Path)))
                LightTheme();
            else
                DarkTheme();
            ChangeTheme(this, container);
        }
    }
}
