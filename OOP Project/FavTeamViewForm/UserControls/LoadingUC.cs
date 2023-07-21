using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Windows_Forms
{
    public partial class LoadingUC : UserControl
    {
        public LoadingUC(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            InitializeComponent();
        }
    }
}
