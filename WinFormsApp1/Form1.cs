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
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //arraylist to getter and setter data  
        private static ArrayList ListDocId = new ArrayList(); //Doc ID (Primary keye
        private static ArrayList ListWorkId = new ArrayList();
        private static ArrayList ListWorkcenter = new ArrayList();
        private static ArrayList ListDocpath = new ArrayList();
        private static ArrayList ListDocname = new ArrayList();
        private static ArrayList ListDescription = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void updateDatagrid()
        {
            /* dataGridView1.Rows.Clear();
             for (int i = 0; i < ListID.Count; i++)
             {
                 DataGridViewRow newRow = new DataGridViewRow();

                 newRow.CreateCells(dataGridView1);
                 newRow.Cells[0].Value = ListID[i];
                 newRow.Cells[1].Value = ListFirstname[i];
                 newRow.Cells[2].Value = ListLastname[i];
                 newRow.Cells[3].Value = ListTelephone[i];
                 newRow.Cells[4].Value = ListAddress[i];
                 dataGridView1.Rows.Add(newRow);
             }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string cs = "server=localhost;user=root;database=paperless;port=3306;password=Java2020";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM doctable";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader row = cmd.ExecuteReader();

            // dataGrid1 = new DataGrid();
            //LayoutRoot.Children.Add(dataGrid1);
            List<DocTblView> dockTbls = new List<DocTblView>();


            while (row.Read())
            {
                ListDocId.Add(row["id"].ToString());
                ListWorkId.Add(row["workid"].ToString());
                ListWorkcenter.Add(row["workcenter"].ToString());
                ListDocpath.Add(row["docpath"].ToString());
                ListDocname.Add(row["docname"].ToString());
                ListDescription.Add(row["description"].ToString());
                DocTblView dt = new DocTblView();
                dt.Description = row["description"].ToString();
                dt.WorkCenter = row["workcenter"].ToString();
                dt.DocPath = row["docpath"].ToString();
                dt.DocName = row["docname"].ToString();
                dockTbls.Add(dt);
            }
            dataGridView1.DataSource = dockTbls;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Width = 160;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 400;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToResizeColumns = true;
            //DataGridViewCellS

        }
    }
}
