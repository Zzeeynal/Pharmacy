using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp9.Models;

namespace WindowsFormsApp9
{
    public partial class DeleteType : Form
    {
        private PharmacyEntities _db;
        private ComboBox _cmb;
        public DeleteType(ComboBox cmb)
        {
            InitializeComponent();
            _db = new PharmacyEntities();
            _cmb = cmb;

        }

        private async void btnDeleteType_Click(object sender, EventArgs e)
        {
            int id = ((CB_TypeOfDrug)cmbDeleteType.SelectedItem).id;
            TypeOfDrug type = _db.TypeOfDrug.First(t => t.id == id);
            type.Deleted = false;
            //_db.TypeOfDrug.Remove(type);
            await _db.SaveChangesAsync();
            MessageBox.Show("Deleted");
            FillCmb(cmbDeleteType);
            FillCmb(_cmb);
        }

        private void DeleteType_Load(object sender, EventArgs e)
        {
            FillCmb(cmbDeleteType);
        }
        private void FillCmb(ComboBox cmb)
        {
            cmb.Text = "";
            cmb.Items.Clear();
            cmb.Items.AddRange(_db.TypeOfDrug.Where(t => t.Deleted == true).Select(t => new CB_TypeOfDrug
            {
                id = t.id,
                type = t.type
            }).ToArray());
        }
    }
}
