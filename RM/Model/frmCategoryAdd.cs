﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.Model
{
    public partial class frmCategoryAdd : SampleAdd
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)

        {

            if (txtName.Text == "")
            {
                MessageBox.Show("Preencha todos os campos antes de guardar");
                return;
            }
            try
            {
                MainClass.isFieldValid(txtName.Text, "Nome");
            }
            catch (InvalidDataException)
            {
                return;
            }

            string qry = "";
            if (id == 0) //inserir
            {
                qry = "Insert into category Values(@Name)";
            }
            else  //update
            {
                qry = "Update category Set catName = @Name where catID = @id ";
            }


            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Salvo com sucesso");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }
        }
    }
}
