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
    public partial class CreateType : Form
    {
        private PharmacyEntities _db;
        private ComboBox _cmb;
        public CreateType(ComboBox cmb)
        {
            InitializeComponent();
            _db = new PharmacyEntities();
            _cmb = cmb;
        }

        private async void btnCreateType_Click(object sender, EventArgs e)
        {
            string name = txtCreateTypeName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("Fill Out","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (_db.TypeOfDrug.Any(t => t.type.ToLower() == name.ToLower()))
            {
                MessageBox.Show($"{name} alrady exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TypeOfDrug type = new TypeOfDrug() { type = name };
            _db.TypeOfDrug.Add(type);
            await _db.SaveChangesAsync();
            MessageBox.Show("Done");
            txtCreateTypeName.Text = "";
            _cmb.Items.Clear();
            _cmb.Items.AddRange(_db.TypeOfDrug.Select(t => new CB_TypeOfDrug
            {
                id = t.id,
                type = t.type
            }).ToArray());
        }
    }
}
