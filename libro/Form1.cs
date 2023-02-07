using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;

namespace libro
{
    public partial class Form1 : Form
    {

        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        metodos p = new metodos();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dgvTabla.AllowUserToAddRows = false;
        }
        public void ciclo()
        {
            txtISBN.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtNúmero_de_páginas.Text = "";
            txtISBN.Focus();

            this.dgvTabla.Sort(this.dgvTabla.Columns["Número_de_páginas"], ListSortDirection.Descending);

        }
        public void codigo()
        {
            txtISBN.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtNúmero_de_páginas.Text = "";
            txtISBN.Focus();

            double Total2 = 0;
            double Total23 = 0;
            double Total21 = 0;
            double total1 = 0;
            double total = 0;

            foreach (DataGridViewRow row in dgvTabla.Rows)
            {
                Total2 += Convert.ToDouble(row.Cells["ISBN"].Value);

            }        
            foreach (DataGridViewRow row in dgvTabla.Rows)
            {
                Total21 += Convert.ToDouble(row.Cells["ISBN"].Value);

            }
            Total23=Total2;


            total = total + Total21;

            if (total != Total23)
            {

            }
            else
            {

                MessageBox.Show("el numero ya esta en la litsta");
                btnAgregar.Enabled = false;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string x = txtISBN.Text;
                string y = txtTitulo.Text, z = txtAutor.Text;
                string valoresA = "";
                string valoresAC = "";
                int w;
                w = int.Parse(txtNúmero_de_páginas.Text);

                if (w <= 0 )
                {

                }
                else
                {
                    valoresA = String.Format("{0}", x);
                    valoresAC = String.Format("{0}", w);
                }
                
                string[] fila = new string[4];

                fila[0] = valoresA;
                fila[1] = y;
                fila[2] = z;
                fila[3] = valoresAC;
                if (valoresA == "" || y == "" || z == "" || valoresAC == "")
                {
                    //MessageBox.Show("caracter no valido");
                }
                else
                {
                    ciclo();
                    dgvTabla.Rows.Add(fila);

                    txtInformacion.Text = "El libro " + y + " con ISBN " + x + " creado por el autor " + z + " tiene " + w + " páginas.";
                    p.limpiar(valoresA, y, z, w);

                }
            }
            catch
            {

                //"El libro <su_titulo>" con ISBN<su_ISBN> creado por el autor < su_autor > tiene < num_paginas > páginas."
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string x, y, z;
            int w;
            x = txtISBN.Text;
            y = txtTitulo.Text;
            z = txtAutor.Text;
            w = int.Parse(txtNúmero_de_páginas.Text);
            p.limpiar(x, y, z, w);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objExcel.Application objAplicacion = new objExcel.Application();
            Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

            objAplicacion.Visible = false;

            foreach (DataGridViewColumn columna in dgvTabla.Columns)
            {
                objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;
                foreach (DataGridViewRow fila in dgvTabla.Rows)
                {
                    objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
                }
            }

            objLibro.SaveAs(ruta + "\\tabla.xlsx");
            objLibro.Close();
            //objAplicacion.Quit();

            int f;
            f = dgvTabla.RowCount;
            for (int i = f - 1; i >= 0; i--)
            {
                dgvTabla.Rows.RemoveAt(i);
            }

            //btnAgregar.Enabled = Enabled;

            txtNúmero_de_páginas.Text = "0";
            txtISBN.Focus();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            ciclo();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                dgvTabla.DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                foreach (DataGridViewRow Row in dgvTabla.Rows)
                {
                    int strfila = Convert.ToInt32(Row.Index.ToString());
                    string valor = Convert.ToString(Row.Cells["ISBN"].Value);

                    if (valor == this.txtBuscar.Text)
                    {
                        dgvTabla.Rows[strfila].DefaultCellStyle.BackColor = Color.Green;
                        checkBox1.Checked = false;
                        txtBuscar.Enabled = false;
                    }
                }
            }
        }
        public void clean()
        {

            int f = dgvTabla.RowCount;
            for (int i = f - 1; i >= 0; i--)
            {
                dgvTabla.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            txtBuscar.Enabled = true;
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Enabled = true;
        }
    }
}
