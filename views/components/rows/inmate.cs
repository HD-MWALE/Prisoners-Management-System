﻿using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.rows
{
    public partial class inmate : UserControl
    {
        public inmate(views.dashboard dashboard, inmates inmates)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.inmates = inmates;
            ActionId = this.dashboard.RollCallInmateId;
            Id = ActionId.Item2;
            Config.LoadTheme(this.Controls);
        }
        public int Id = 0;
        public (string, int) ActionId = ("-", 0); 
        public int status = 1;
        private views.dashboard dashboard;
        private inmates inmates;

        private void inmate_Load(object sender, EventArgs e) 
        {
            if(ActionId.Item2 != 0)
            {
                if (ActionId.Item1 == "Edit")
                    btnEdit_Click(sender, e);
                else if(ActionId.Item1 == "View")
                    btnView_Click(sender, e);
                ActionId.Item2 = 0;
                ActionId.Item1 = "-";
                specifier = "-";
            }
        }

        private void inmate_MouseHover(object sender, EventArgs e) 
        {
            RowHover();
        }

        private void inmate_MouseLeave(object sender, EventArgs e) 
        {
            RowLeave();
        }
        private void RowHover()
        {
        }
        private void RowLeave()
        {
        }
        inputs.inmate _inmate;
        public string specifier = "";
        modal.dialog dialog;
        classes.Inmate Inmate = new classes.Inmate();
       

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            RowHover();
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            RowHover();
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            RowLeave();
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            RowLeave();
        }

        private void inmate_Click(object sender, EventArgs e) 
        {
            View_Inmate();
        }
        private void View_Inmate()
        {/*
            Dashboard.Blur(false);
            Popup popup = new Popup();
            //MessageBox.Show("This is the id = " + lblId.Text);
            Popup.size = new int[2] { 261, 420 };
            Popup.load = 3;
            Popup.title = "View Inmate";
            Views.Controls.Inmates.View.id = lblId.Text;
            Views.Controls.Inmates.View.inmatecode = lblInmateCode.Text;
            Views.Controls.Inmates.View.firstname = lblFirstname.Text;
            Views.Controls.Inmates.View.middlename = lblMiddlename.Text;
            Views.Controls.Inmates.View.familyname = lblFamilyname.Text;
            Views.Controls.Inmates.View.gender = lblGender.Text;
            Views.Controls.Inmates.View.dob = lblDoB.Text;
            popup.ShowDialog();
            Dashboard.Blur(true);*/
        }
        ArrayList Crimes = new ArrayList();
        view.inmate viewinmate;  
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (specifier == "rollcall1")
            {
                dashboard.RollCallInmateId = ("Edit", Id);
                dashboard.btnInmate_Click(sender, e);
            }
            else
            {
                dashboard.SetLoading(true);
                Config.ClickSound();
                _inmate = new inputs.inmate(inmates);
                _inmate.Id = Id;
                dashboard.PathSeparator.Visible = true;
                dashboard.lblAction.Visible = true;
                dashboard.lblAction.Text = "Edit";
                this.inmates.Controls.Add(_inmate);
                _inmate.Dock = DockStyle.Fill;
                _inmate.BringToFront();
                dashboard.SetLoading(false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (specifier == "rollcall1")
            {
                dashboard.RollCallInmateId = ("View", Id);
                dashboard.btnInmate_Click(sender, e);
            }
            else
            {
                dashboard.SetLoading(true);
                Config.ClickSound();
                viewinmate = new view.inmate(dashboard, this.inmates);
                viewinmate.Id = Id;
                dashboard.PathSeparator.Visible = true;
                dashboard.lblAction.Visible = true;
                dashboard.lblAction.Text = "View";
                this.inmates.Controls.Add(viewinmate);
                viewinmate.Dock = DockStyle.Fill;
                viewinmate.AutoScroll = true;
                viewinmate.BringToFront();
                dashboard.SetLoading(false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) 
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Inmate";
            dialog.Message.Text = "You are about to delete a Inmate?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Inmate.Delete(Id);
            inmates.inmates_Load(sender, e);
            Config.Alert("Inmate Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }
    }
}