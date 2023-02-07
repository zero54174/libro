using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libro
{
    public class metodos
    {

        string isbn;
        string titulo;
        string autor;
        int n;

        public metodos()
        {

        }
        public metodos(string isbn, string titulo, string autor, int n)
        {
            this.Isbn = isbn;
            this.Titulo = titulo;
            this.Autor = autor;
            this.N = n;
        }

        public string Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int N { get => n; set => n = value; }
    
        public void limpiar(string isbn, string titulo, string autor, int n)
        {
            isbn = string.Empty;
            titulo = string.Empty;
            autor = string.Empty;
            n = 0;

        }
        //public void ciclo()
        //{
        //    .Text = "";
        //    txtValorActivo.Text = "";
        //    txtCuentaPasivo.Text = "";
        //    txtValorPasivo.Text = "";
        //    txtCuentasActivo.Focus();

        //    double Total2 = 0;
        //    double Total = 0;
        //    foreach (DataGridViewRow row in dgvTabla.Rows)
        //    {
        //        Total2 += Convert.ToDouble(row.Cells["Valores_Activos"].Value);
        //    }


        //    Total = Total + Total2;

        //    if(Total < Total2)
        //    {
                
        //    }
        //    txtTotalActivo.Text = Total.ToString();

        //    txtTotal.Text = Total21.ToString();


        //}

    }
}
