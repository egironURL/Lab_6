using System;
using System.Collections.Generic;
using System.Text;
using Cifrado.Clases;

namespace Cifrado.Interfaces
{
    public interface ICifrado
    {
        void GenerarLlave(int _p, int _q);

        List<byte> Cifrar(int n, int e);

        List<byte> Descifrar(int n, int d);

    }
}
