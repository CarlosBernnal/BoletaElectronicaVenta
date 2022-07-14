using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boleta_electronica
{
    public partial class Form1 : Form
    {
        int codigo;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToLongDateString();
            txtHora.Text = DateTime.Now.ToShortTimeString();
        }
        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboMarca.Text)
            {
                case "Epson L3130":
                    txtPrecio.Text = "850.00";
                    break;
                case "HP Deskjet 100":
                    txtPrecio.Text = "750.00";
                    break;
                case "Costa":
                    txtPrecio.Text = "3.00";
                    break;
                case "Field":
                    txtPrecio.Text = "4.00";
                    break;
                case "Ikea":
                    txtPrecio.Text = "1000.00";
                    break;
                case "Del Bosque":
                    txtPrecio.Text = "700.00";
                    break;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cboProducto.Enabled = true;
            cboMarca.Enabled = true;
            txtCantidad.Enabled = true;
            txtPrecio.Enabled = true;
            txtSubtotal.Enabled = true;
            txtIgv.Enabled = true;
            txtTotal.Enabled = true;

            cboProducto.Text = "";
            cboMarca.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtSubtotal.Text = "";
            txtIgv.Text = "";
            txtTotal.Text = "";
            cboProducto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            codigo = codigo + 1;
            int c = 0;
            double p, st, igv, total;
            c = int.Parse(txtCantidad.Text);
            p = double.Parse(txtPrecio.Text);

            st = c * p;
            igv = (st * 18) / 100;
            total = st + igv;

            txtSubtotal.Text = st.ToString();
            txtIgv.Text = igv.ToString();
            txtTotal.Text = total.ToString();

            dgvVentas.Rows.Add("P-" + codigo.ToString("000"), Convert.ToString(lstCategorias.SelectedItem), cboProducto.SelectedItem.ToString(), cboMarca.SelectedItem.ToString(), txtCantidad.Text, txtPrecio.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {  
            cboProducto.Enabled = true;
            cboMarca.Enabled = true;
            txtCantidad.Enabled = true;
            txtPrecio.Enabled = true;
            txtSubtotal.Enabled = true;
            txtIgv.Enabled = true;
            txtTotal.Enabled = true;

            cboProducto.Text = "";
            cboMarca.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtSubtotal.Text = "";
            txtIgv.Text = "";
            txtTotal.Text = "";
            cboProducto.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(lstCategorias.SelectedItem) == "- ARTEFACTOS")
            {
                cboProducto.Items.Clear();
                cboMarca.Items.Clear();
                cboProducto.Text = "SELECCIONE EL PRODUCTO";
                cboMarca.Text = "SELECCIONE LA MARCA";
                cboProducto.Items.Add("Impresora");
                cboMarca.Items.Add("Epson L3130");
                cboMarca.Items.Add("HP Deskjet 100");
            }

            if (Convert.ToString(lstCategorias.SelectedItem) == "- DULCES")
            {
                cboProducto.Items.Clear();
                cboMarca.Items.Clear();
                cboProducto.Text = "SELECCIONE EL PRODUCTO";
                cboMarca.Text = "SELECCIONE LA MARCA";
                cboProducto.Items.Add("Galletas");
                cboMarca.Items.Add("Costa");
                cboMarca.Items.Add("Field");
            }

            if (Convert.ToString(lstCategorias.SelectedItem) == "- MUEBLES")
            {
                cboProducto.Items.Clear();
                cboMarca.Items.Clear();
                cboProducto.Text = "SELECCIONE EL PRODUCTO";
                cboMarca.Text = "SELECCIONE LA MARCA";
                cboProducto.Items.Add("Sofa-Cama");
                cboMarca.Items.Add("Ikea");
                cboMarca.Items.Add("Del Bosque");
            }

        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de borrar esta fila?",
                "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes) {
                dgvVentas.Rows.Remove(dgvVentas.CurrentRow);
            }
            else
            {
                this.Close();
            }
        }
    }
}
