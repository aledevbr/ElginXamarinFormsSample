using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElginXamarinFormsSample
{
    public interface IElginPrinterService
    {
        int AvancaLinhas(int linesNumber);
        int cutPaper(int cut);
        int imprimeTexto(Dictionary<string, string> dictionary);
        int printerInternalImpStart();
        void printerStop();
    }
}
