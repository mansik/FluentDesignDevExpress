using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using FluentDesignDevExpress.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluentDesignDevExpress
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        async Task LoadModuleAsync(ModuleInfo module)
        {
            await Task.Factory.StartNew(() =>
            {
                if (!fluentDesignFormContainer.Controls.ContainsKey(module.Name))
                {
                    TutorialControlBase control = module.TModule as TutorialControlBase;
                    if (control != null)
                    {
                        control.Dock = DockStyle.Fill;
                        control.CreateWaitDialog();
                        fluentDesignFormContainer.Invoke(new MethodInvoker(delegate ()
                        {
                            fluentDesignFormContainer.Controls.Add(control);
                            control.BringToFront();
                        }));
                    }
                }
                else
                {
                    var control = fluentDesignFormContainer.Controls.Find(module.Name, true);
                    if (control.Length == 1)
                        fluentDesignFormContainer.Invoke(new MethodInvoker(delegate () { control[0].BringToFront(); }));
                }
            });
        }

        private async void cashBookaccordionControlElement_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{cashBookaccordionControlElement.Text}";
            if (ModulesInfo.GetItem("CashBookModule") == null)
                ModulesInfo.Add(new ModuleInfo("CashBookModule", "FluentForm.UI.Modules.CashBookModule"));
            await LoadModuleAsync(ModulesInfo.GetItem("CashBookModule"));
        }

        private async void accordionControlElement2_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElement2.Text}";
            if (ModulesInfo.GetItem("XtraUserControl1") == null)
                ModulesInfo.Add(new ModuleInfo("XtraUserControl1", "FluentForm.UI.Modules.XtraUserControl1"));
            await LoadModuleAsync(ModulesInfo.GetItem("XtraUserControl1"));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer.Controls.Add(new CashBookModule() { Dock = DockStyle.Fill });
        }
    }
}
