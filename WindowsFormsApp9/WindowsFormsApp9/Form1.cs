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
    public partial class Form1 : Form
    {
        private PharmacyEntities _db;
        public Form1()
        {
            InitializeComponent();
            _db = new PharmacyEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = _db.Drug.Select(d => new
            {
                d.id,
                d.name,
                d.price,
                Type = d.TypeOfDrug.type
            
            }).ToList();
            
            cmbTypeOfDrug.Items.AddRange(_db.TypeOfDrug.Where(t => t.Deleted==true).Select(t=>new CB_TypeOfDrug
            {
                id=t.id,
                type=t.type
            }).ToArray());
        }

        private void cmbTypeOfDrug_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = ((CB_TypeOfDrug)cmbTypeOfDrug.SelectedItem).id;
            dgv.DataSource = _db.Drug.Where(d => d.typeid == type).Select(d => new
            {
                d.id,
                d.name,
                d.price,
                Type = d.TypeOfDrug.type

            }).ToList();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateType type = new CreateType(cmbTypeOfDrug);
            type.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteType delete = new DeleteType(cmbTypeOfDrug);
            delete.ShowDialog();
        }
    }
}
