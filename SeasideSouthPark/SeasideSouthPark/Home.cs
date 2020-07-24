using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SeasideSouthPark
{
    public partial class formHome : Form
    {
        string usrname,chkin,chkout;
        int rooms;
        int adults;
        int children;

        public void hidePanels()
        {
            pnlWelcome.Visible = false;
            pnlBook.Visible = false;
        }

        public formHome(string username)
        {
            InitializeComponent();
            lblUser.Text = username;
            usrname = username;
        }

        private void formHome_Load(object sender, EventArgs e)
        {
            hidePanels();
            pnlWelcome.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Size = new Size(21, 21);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Size = new Size(20, 20);
        }

        private void linkSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formLogin frmLogin = new formLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void linkManageAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formAccount frmAccount = new formAccount(lblUser.Text);
            frmAccount.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formAbout frmAbout = new formAbout();
            frmAbout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkin = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            chkout = dateTimePicker2.Value.ToString("yyyy/MM/dd");
                         
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Downloads\Documents\GitHub\CRUD-Operations-App\SeasideSouthPark\SeasideDB.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "SELECT * FROM tblRooms WHERE Checkin='" +chkin+ "'and Checkout='" + chkout + "'";
            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable ds = new DataTable();
            sda.Fill(ds);
           
            try
            {
                if (ds.Rows.Count == 1)
               
                {
                    if (txtAdults.Text == "" || txtChildren.Text == "" || txtRoom.Text=="")
                    {
                        MessageBox.Show("Please Fill All Fields.");
                    }
                    else 
                    {
                        MessageBox.Show("Sorry we are not Available");
                    }
                }
                
                else

                {
                    if (txtAdults.Text == "" || txtChildren.Text == "" || txtRoom.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Fields.");
                    }
                    else
                    {
                        hidePanels();
                        pnlBook.Visible = true;
                        adults = Int32.Parse(txtAdults.Text);
                        children = Int32.Parse(txtChildren.Text);
                        rooms = Int32.Parse(txtRoom.Text);
                    }
                }
            }
            catch
            {
               
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pnlWelcome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void book_Click(object sender, EventArgs e)
        {

        }

        private void pnlBook_Paint(object sender, PaintEventArgs e)
        {
            //pictureBox1.Visible = false;
           // pictureBox2.Visible = false;
            //pictureBox3.Visible = false;
            //pictureBox4.Visible = false;

            if (adults == 1 && children == 0)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else if (adults == 2 && children == 0)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else if (adults == 1 && children == 1)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else if (adults >=2 || children >=1)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
            }
            else
            {
                //MessageBox.Show("Please Check your Info."); 
            }
        }

        private void ctrlBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHello_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picboxUser_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Downloads\Documents\GitHub\CRUD-Operations-App\SeasideSouthPark\SeasideDB.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "UPDATE tblRooms SET Checkin='" + chkin + "',Checkout='" + chkout + "',Adults='" + adults + "',Children='" + children + "',Username='" + usrname + "' WHERE Roomid='" + 2 + "'";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Booked");
            }
            catch
            {

            }
        }

        private void txtRoom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtChildren_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdults_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Downloads\Documents\GitHub\CRUD-Operations-App\SeasideSouthPark\SeasideDB.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "UPDATE tblRooms SET Checkin='" + chkin + "',Checkout='" + chkout + "',Adults='"+adults+"',Children='"+children+"',Username='"+usrname+"' WHERE Roomid='"+1+"'";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Booked");
            }
            catch
            {

            }
        }
    }
}
