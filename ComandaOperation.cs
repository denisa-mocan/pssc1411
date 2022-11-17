using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PSSC_S3.StareCos;

namespace PSSC_S3
{
    public static class ComandaOperation
    {
        public static IStarecos ValidareComanda(Func<int, bool> checkProdusExists, NevalidatStareCos comanda)
        {
            List<Produs> produse1 = new();
           foreach(var Produs in comanda.Produse)
           {
            produse1.Add(Produs);

           }
          return new ValidatStareCos(comanda.Client, produse1);
        }
    }

}                            