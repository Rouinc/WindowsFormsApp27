using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp27
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=DBD_10_XIBOBA"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan  atau menjadi penampung
        string sqlQuery;



        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = true;
        }

        private void ButtonLogin_Click_1(object sender, EventArgs e)
        {
            string datasql = "select kodebarista,namabarista from barista where kodebarista = '" + TextBoxPassword.Text + "' and namabarista = '" + TextBoxUser.Text + "' and delete_barista = '0'";
            MySqlCommand cmd = new MySqlCommand(datasql, sqlConnect);
            sqlConnect.Close();
            sqlConnect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            string idbar = "";
            string nmbar = "";
            while (reader.Read())
            {
                idbar = reader.GetString(0);
                nmbar = reader.GetString(1);
            };

            if (idbar != "")
            {
                FormDashboard frmpesan = new FormDashboard();
                frmpesan.Show();
            }
            else
            {
                MessageBox.Show("User/Password Salah" + "\n" + "atau user tidak aktif");
            }
            sqlConnect.Close();
        }

        private void ButtonAddLogin_Click_1(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = true;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;
        }

        private void ButtonEditLogin_Click_1(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = true;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;
        }

        private void ButtonBackAddBarista_Click_1(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = true;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            sqlConnect.Open();
            //button add barista
            string Gender;
            if (ComboBoxGender.Text == "Female")
            {
                Gender = "F";
            }
            else
            {
                Gender = "M";
            }
            string datasql = "insert into barista values('" + TextBoxID.Text + "','" + TextBoxAddNama.Text + "','" + Gender + "','0')";
            MySqlCommand cmd = new MySqlCommand(datasql, sqlConnect);
            MySqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("Data Sudah Terinput");
            TextBoxID.Text = "";
            TextBoxAddNama.Text = "";
            ComboBoxGender.Text = "";
            sqlConnect.Close();
        }

        private void ButtonBackDelete_Click_1(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = true;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;
        }

        private void ButtonBackAdd_Click_1(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = true;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;
        }


        private void ButtonDeleteAtas_Click(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = true;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;
        }

        private void ButtonAddAtas_Click(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = true;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;

            DataTable dtJenis = new DataTable();
            sqlQuery = "select namajenis from jenisminuman;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtJenis); // sampai sini

            ComboBoxAdd.DataSource = dtJenis;
            ComboBoxAdd.ValueMember = "namajenis";
            ComboBoxAdd.DisplayMember = "namajenis";
        }

        private void ButtonRestoreAtas_Click(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = true;
            PanelLogin.Visible = false;
        }

        private void ButtonBackAtas_Click(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            string datasql = "update barista set delete_barista = 1 where kodebarista = '" + TextBoxKodeDelete.Text + "';";

            MySqlCommand cmd = new MySqlCommand(datasql, sqlConnect);

            MySqlDataReader reader = cmd.ExecuteReader();
            sqlConnect.Close();

        }

        private void ButtonAdd_Click_1(object sender, EventArgs e)
        {
            sqlConnect.Open();
            string datasql = "insert into barista_jenis values ('" + ComboBoxAdd.Text + "', '" + TextBoxKodeAdd.Text + "', 0);";
            MySqlCommand cmd = new MySqlCommand(datasql, sqlConnect);
            MySqlDataReader reader = cmd.ExecuteReader();
            sqlConnect.Close();
        }


        private void ButtonRestoree_Click(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = false;
            PanelRestoreBarista.Visible = true;
            PanelLogin.Visible = false;
        }

        private void ButtonRestore_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            string datasql = "update barista set delete_barista = 0 where kodebarista = '" + TextBoxKodeDelete.Text + "';";
            MySqlCommand cmd = new MySqlCommand(datasql, sqlConnect);

            MySqlDataReader reader = cmd.ExecuteReader();
            sqlConnect.Close();
        }

        private void ButtonBackRestore_Click(object sender, EventArgs e)
        {
            PanelAddBarista.Visible = false;
            PanelAddSkill.Visible = false;
            PanelDeleteBarista.Visible = false;
            PanelEditBarista.Visible = true;
            PanelRestoreBarista.Visible = false;
            PanelLogin.Visible = false;
        }
    }
}

 
