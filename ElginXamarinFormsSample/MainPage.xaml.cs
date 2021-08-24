using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ElginXamarinFormsSample
{
    public partial class MainPage : ContentPage
    {
        private readonly IElginPrinterService printerService = DependencyService.Get<IElginPrinterService>();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
        }

        private void ImprimirTexto_Clicked(object sender, EventArgs e)
        {
            printerService.printerInternalImpStart();
            System.Threading.Thread.Sleep(3000);
            var parametros = new Dictionary<string, string>();

            parametros.Add("text", "Alesil Tecnologia");
            parametros.Add("align", "Centralizado");
            parametros.Add("font", "FONT A");
            parametros.Add("fontSize", "0");
            parametros.Add("isBold", "true");
            parametros.Add("isUnderline", "false");

            printerService.imprimeTexto(parametros);
            printerService.AvancaLinhas(10);
            printerService.cutPaper(10);
        }
    }
}
