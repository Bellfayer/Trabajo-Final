﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(String accion) 
        {
            objent.codigo = txtcodigo.Text;
            objent.nombre = txtnombre.Text;
            objent.edad = Convert.ToInt32(txtedad.Text);
            objent.telefono = Convert.ToInt32(txttelefono.Text);
            objent.accion = accion;
            String men = objneg.N_mantenimiento_cliente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar() 
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtedad.Text = "";
            txttelefono.Text = "";
            txtbuscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                objent.nombre = txtbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes(objent);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                dataGridView1.DataSource = objneg.N_listar_clientes();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtcodigo.Text = dataGridView1[0,fila].Value.ToString();
            txtnombre.Text = dataGridView1[1, fila].Value.ToString();
            txtedad.Text = dataGridView1[2, fila].Value.ToString();
            txttelefono.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
