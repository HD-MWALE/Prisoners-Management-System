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

namespace Prisoners_Management_System.config
{
    public class ColorScheme
    {
        // declare and initialize theme text file
        public static string Path = config.Path + "\\settings\\theme.txt";
        // color variables for panels
        public static Color PanelBG;
        public static Color PanelFG;
        // color variables for buttons
        public static Color ButtonBG;
        public static Color ButtonFG;
        // color variables for textboxes
        public static Color TextBoxBG;
        public static Color TextBoxFG;
        // color variables for bunifu textboxes
        public static Color BunifuTextBoxFC;
        public static Color BunifuTextBoxFG;
        public static Color BunifuTextBoxBG;
        // color variables for flow layout panels
        public static Color FlowLayoutPanelBG;
        public static Color FlowLayoutPanelFG;
        // color variables for user control
        public static Color SearchUserControlBG;
        public static Color NotificationUserControlBG;
        public static Color CardUserControlBG;
        public static Color UserControlBG;
        public static Color UserControlFG;
        // color variables for bunifu flat button
        public static Color BunifuFlatButtonAC;
        public static Color BunifuFlatButtonTC;
        public static Color BunifuFlatButtonBG;
        public static Color BunifuFlatButtonNC;
        public static Color BunifuFlatButtonFG;
        public static Color BunifuFlatButtonHC;
        // color variables for bunifu image button
        public static Color CardBunifuImageButtonBG;
        public static Color CardBunifuImageButtonFG;
        public static Color BunifuImageButtonBG;
        public static Color BunifuImageButtonFG;
        // color variables for bunifu metro textbox
        public static Color BunifuMetroTextboxBG;
        public static Color BunifuMetroTextboxFG;
        // color variables for bunifu separator
        public static Color BunifuSeparatorBG;
        public static Color BunifuSeparatorFG;
        // color variables for bunifu date picker
        public static Color BunifuDatePickerBG;
        public static Color BunifuDatePickerFG;
        // color variables for bunifu dropdown
        public static Color BunifuDropdownC;
        public static Color BunifuDropdownBG;
        public static Color BunifuDropdownFG;
        // color variables for group box
        public static Color GroupBoxBG;
        public static Color GroupBoxFG;
        // color variables for rich text box
        public static Color RichTextBoxBG;
        public static Color RichTextBoxFG;
        // color variables for picture box
        public static Color PictureBoxBG;
        public static Color PictureBoxFG;
        // color variables for labels
        public static Color CardLabelBG;
        public static Color CardLabelFG;
        public static Color LabelBG;
        public static Color LabelFG;
        // color variables for whole system
        public static Color BG;
        public static Color FG;
        // set light theme function
        public static void LightTheme()
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
        // set dark theme function
        public static void DarkTheme()
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
        // set color on bunifu flat button 
        public static void BunifuFlatButton(BunifuFlatButton flatButton)
        {
            flatButton.Activecolor = BunifuFlatButtonAC;
            flatButton.Textcolor = BunifuFlatButtonTC;
            flatButton.BackColor = BunifuFlatButtonBG;
            flatButton.ForeColor = BunifuFlatButtonFG;
            flatButton.Normalcolor = BunifuFlatButtonBG;
            flatButton.OnHovercolor = BunifuFlatButtonHC;
        }
        // set color on search user control
        public static void SearchTheme(Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is FlowLayoutPanel)
                {
                    SearchTheme(component.Controls);
                    component.BackColor = SearchUserControlBG;
                    component.ForeColor = FlowLayoutPanelFG;
                }
        }
        // set color on notification user control
        public static void notificationTheme(Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is FlowLayoutPanel)
                {
                    notificationTheme(component.Controls);
                    component.BackColor = NotificationUserControlBG;
                    component.ForeColor = FlowLayoutPanelFG;
                }
                else if (component is Panel)
                {
                    notificationTheme(component.Controls);
                    component.BackColor = NotificationUserControlBG;
                    component.ForeColor = PanelFG;
                }
                else if (component is Label)
                {
                    component.BackColor = NotificationUserControlBG;
                    component.ForeColor = LabelFG;
                }
        }
        // set color on card user control
        public static void Card(Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is Label)
                {
                    component.BackColor = CardLabelBG;
                    component.ForeColor = CardLabelFG;
                }
                else if (component is Bunifu.Framework.UI.BunifuImageButton)
                {
                    component.BackColor = CardBunifuImageButtonBG;
                    component.ForeColor = CardBunifuImageButtonFG;
                }
        }
        // set color on user control
        public static void UserControl(UserControl userControl)
        {
            if (userControl.Name == "search")
            {
                SearchTheme(userControl.Controls);
                userControl.BackColor = SearchUserControlBG;
                userControl.ForeColor = UserControlFG;
            }
            else if (userControl.Name == "notifications")
            {
                notificationTheme(userControl.Controls);
                userControl.BackColor = NotificationUserControlBG;
                userControl.ForeColor = UserControlFG;
            }
            else if (userControl.Name == "menu")
            {
                ChangeTheme(userControl.Controls);
                userControl.BackColor = SearchUserControlBG;
                userControl.ForeColor = UserControlFG;
            }
            else if (userControl.Name == "card")
            {
                Card(userControl.Controls);
                userControl.BackColor = CardUserControlBG;
                userControl.ForeColor = UserControlFG;
            }
            else
            {
                ChangeTheme(userControl.Controls);
                userControl.BackColor = UserControlBG;
                userControl.ForeColor = UserControlFG;
            }
        }
        // set color on bunifu dropdown
        public static void BunifuDropdown(Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown)
        {
            bunifuDropdown.Color = BunifuDropdownC;
            bunifuDropdown.BackColor = BunifuDropdownBG;
            bunifuDropdown.IndicatorColor = BunifuDropdownFG;
            bunifuDropdown.ForeColor = BunifuDropdownFG;
        }
        // set color on bunifu date picker
        public static void BunifuDatePicker(BunifuDatePicker bunifuDatePicker)
        {
            bunifuDatePicker.Color = BunifuDropdownC;
            bunifuDatePicker.BackColor = BunifuDatePickerBG;
            bunifuDatePicker.ForeColor = BunifuDatePickerFG;
            bunifuDatePicker.Icon = Properties.Resources.calendar;
        }
        // set color on bunifu textbox
        public static void BunifuTextBox(BunifuTextBox bunifuTextBox)
        {
            bunifuTextBox.FillColor = BunifuTextBoxFC;
            bunifuTextBox.BackColor = BunifuTextBoxBG;
            bunifuTextBox.ForeColor = BunifuTextBoxFG;
        }
        // change theme function
        public static void ChangeTheme(Control.ControlCollection container)
        {
            foreach (Control component in container)
                if (component is Panel)
                {
                    ChangeTheme(component.Controls);
                    component.BackColor = PanelBG;
                    component.ForeColor = PanelFG;
                }
                else if (component is FlowLayoutPanel)
                {
                    ChangeTheme(component.Controls);
                    component.BackColor = FlowLayoutPanelBG;
                    component.ForeColor = FlowLayoutPanelFG;
                }
                else if (component is GroupBox)
                {
                    ChangeTheme(component.Controls);
                    component.BackColor = GroupBoxBG;
                    component.ForeColor = GroupBoxFG;
                }
                else if (component is BunifuFlatButton)
                {
                    BunifuFlatButton((BunifuFlatButton)component);
                }
                else if (component is Bunifu.Framework.UI.BunifuImageButton)
                {
                    component.BackColor = BunifuImageButtonBG;
                    component.ForeColor = BunifuImageButtonFG;
                }
                else if (component is BunifuMetroTextbox)
                {
                    component.BackColor = BunifuMetroTextboxBG;
                    component.ForeColor = BunifuMetroTextboxFG;
                }
                else if (component is BunifuTextBox)
                {
                    BunifuTextBox((BunifuTextBox)component);
                }
                else if (component is BunifuSeparator)
                {
                    //(BunifuSeparator)component.LineColor = BunifuSeparatorBG;
                    component.ForeColor = BunifuSeparatorFG;
                }
                else if (component is BunifuDatePicker)
                {
                    BunifuDatePicker((BunifuDatePicker)component);
                }
                else if (component is Bunifu.UI.WinForms.BunifuDropdown)
                {
                    BunifuDropdown((Bunifu.UI.WinForms.BunifuDropdown)component);
                }
                else if (component is RichTextBox)
                {
                    component.BackColor = RichTextBoxBG;
                    component.ForeColor = RichTextBoxFG;
                }
                else if (component is Button)
                {
                    component.BackColor = ButtonBG;
                    component.ForeColor = ButtonFG;
                }
                else if (component is TextBox)
                {
                    component.BackColor = TextBoxBG;
                    component.ForeColor = TextBoxFG;
                }
                else if (component is PictureBox)
                {
                    component.BackColor = PictureBoxBG;
                    component.ForeColor = PictureBoxFG;
                }
                else if (component is Label)
                {
                    component.BackColor = LabelBG;
                    component.ForeColor = LabelFG;
                }
                else if (component is UserControl)
                {
                    UserControl((UserControl)component);
                }
                else
                {
                    component.BackColor = BG;
                    component.ForeColor = FG;
                }
        }
        // load current theme
        public static void LoadTheme(Control.ControlCollection container)
        {
            if (Convert.ToBoolean(File.ReadAllText(Path)))
                LightTheme();
            else
                DarkTheme();
            ChangeTheme(container);
        }
    }
}
