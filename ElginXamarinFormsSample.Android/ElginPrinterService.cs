using Android.App;

using Com.Elgin.E1.Impressora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

[assembly: Dependency(typeof(ElginXamarinFormsSample.Droid.ElginPrinterService))]
namespace ElginXamarinFormsSample.Droid
{
    public class ElginPrinterService : IElginPrinterService
    {
        private static Android.Views.View view;
        private static Activity mActivity;

        public ElginPrinterService()
        {
            if (view == null)
            {
                var activity = MainActivity.Instance;
                view = activity.FindViewById<Android.Views.View>(Android.Resource.Id.Content);
                mActivity = MainActivity.Instance;

                
                Termica.SetContext(mActivity);
            }
        }

        public int printerInternalImpStart()
        {
            printerStop();
            int result = Termica.AbreConexaoImpressora(6, "M8", "", 0);
            // int result = Termica.AbreConexaoImpressora(3, "i9", "192.168.2.160", 9100);
            return result;
        }

        public void printerStop()
        {
            Termica.FechaConexaoImpressora();
        }

        public int AvancaLinhas(int linesNumber)
        {
            return Termica.AvancaPapel(linesNumber);
        }

        public int cutPaper(int cut)
        {
            return Termica.Corte(cut);
        }

        public int imprimeTexto(Dictionary<string, string> dictionary)
        {
            String text = (String)dictionary["text"];
            String align = (String)dictionary["align"];
            String font = (String)dictionary["font"];
            int fontSize = (int)Int32.Parse(dictionary["fontSize"]);
            Boolean isBold = (Boolean)Convert.ToBoolean(dictionary["isBold"]);
            Boolean isUnderline = (Boolean)Convert.ToBoolean(dictionary["isUnderline"]);

            int result;

            int alignValue = 0;
            int styleValue = 0;

            // ALINHAMENTO VALUE
            if (align.Equals("Esquerda"))
            {
                alignValue = 0;
            }
            else if (align.Equals("Centralizado"))
            {
                alignValue = 1;
            }
            else
            {
                alignValue = 2;
            }
            //STILO VALUE
            if (font.Equals("FONT B"))
            {
                styleValue += 1;
            }
            if (isUnderline)
            {
                styleValue += 2;
            }
            if (isBold)
            {
                styleValue += 8;
            }

            result = Termica.ImpressaoTexto(text, alignValue, styleValue, fontSize);
            return result;
        }

    }
}
