using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario {
    public partial class FrmCalculadoraCientifica : Form {
        public bool Virgula { get; private set; }
        public bool Claro { get; private set; }

        public FrmCalculadoraCientifica() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }
    }
}
