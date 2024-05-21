using StaffManagers.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class SettingsUC : UserControl
    {
        public SettingsUC()
        {
            InitializeComponent();

            this.Load += SettingsUC_Load;
        }

        private void SettingsUC_Load(object sender, EventArgs e)
        {
            label1.Font = FontLoader.LoadFontToMemory(20.0F);
        }
    }
}
