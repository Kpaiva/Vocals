using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Vocals {
    public partial class FormAction : Form {
        Keys[] keyDataSource;

        public float selectedTimer { get; set; }

        public Keys selectedKey { get; set; }

        public string selectedType { get; set; }

        public Keys modifier { get; set; }
        public List<Keys> newList { get; set; }
        
        public FormAction() {

            InitializeComponent();

            newList = new List<Keys>();

            keyDataSource = (Keys[])Enum.GetValues(typeof(Keys)).Cast<Keys>();

            comboBox2.DataSource = keyDataSource;
          
            comboBox1.DataSource = new string[]{"Key press","Timer"};

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = 0.1M;
        }

        public FormAction(Actions a) {
            InitializeComponent();
            keyDataSource = (Keys[])Enum.GetValues(typeof(Keys)).Cast<Keys>();
            newList = new List<Keys>();

            comboBox2.DataSource = keyDataSource;

            comboBox1.DataSource = new string[] { "Key press", "Timer" };

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = 0.1M;

            comboBox2.SelectedItem = a.keys;
            numericUpDown1.Value = Convert.ToDecimal(a.timer);
            comboBox1.SelectedItem = a.type;

            foreach (Keys x in a.modifiers)
            {
                if (x == Keys.ControlKey)
                {
                    checkBox1.Checked = true;
                    SaveChecks();
                }
                else if (x == Keys.LShiftKey)
                {
                    checkBox2.Checked = true;
                    SaveChecks();
                }
                else if (x == Keys.LMenu)
                {
                    checkBox3.Checked = true;
                    SaveChecks();
                }
            }
        }

        private void FormAction_Load(object sender, System.EventArgs e) {
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            selectedType = (string)comboBox1.SelectedItem;
            switch (selectedType) {
                case "Key press" :
                    numericUpDown1.Enabled = false;
                    comboBox2.Enabled = true;
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    break;
                case "Timer":
                    numericUpDown1.Enabled = true;
                    comboBox2.Enabled = false;
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox3.Enabled = false;
                    break;
                default :
                    break;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            selectedTimer = (float)numericUpDown1.Value;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            selectedKey = (Keys)comboBox2.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e) {
            SaveChecks();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            selectedType = "";
            selectedTimer = 0;
            selectedKey = Keys.None;
            this.Close();
        }

        private void SaveChecks()
        {
            newList.Clear();
            if (checkBox1.Checked)
            {
                newList.Add(Keys.ControlKey);
            }
            if (checkBox2.Checked)
            {
                newList.Add(Keys.LShiftKey);
            }
            if (checkBox3.Checked)
            {
                newList.Add(Keys.LMenu);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
                SaveChecks();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
                SaveChecks();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
                SaveChecks();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }





    }
}
