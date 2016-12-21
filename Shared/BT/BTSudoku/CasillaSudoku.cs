using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSudoku
{
    public class CasillaSudoku
    {
        private int? caja;
        private int? fila;
        private int? columna;
        private int? valor;

        public static CasillaSudoku create(int? fila, int? columna, int? valor, int? caja)
        {
            return new CasillaSudoku(fila, columna, valor, caja);
        }

        public static CasillaSudoku create(int? fila, int? columna, int? caja)
        {
            return create(fila, columna, null, caja);
        }

        private CasillaSudoku(int? fila, int? columna, int? valor, int? caja)
        {
            
            this.fila = fila;
            this.columna = columna;
            this.caja = caja;
            this.valor = valor;
        }

        private CasillaSudoku(int? fila, int? columna, int? caja)
        {
            this.fila = fila;
            this.columna = columna;
            this.valor = null;
            this.caja = caja;
        }

        public int? getValor()
        {
            return valor;
        }

        public void setValor(int? valor)
        {
            this.valor = valor;
        }

        public int? getFila()
        {
            return fila;
        }

        public int? getColumna()
        {
            return columna;
        }

        public int? getCaja()
        {
            return caja;
        }


        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + ((columna == null) ? 0 : columna.GetHashCode());
            result = prime * result + ((fila == null) ? 0 : fila.GetHashCode());
            result = prime * result + ((caja == null) ? 0 : caja.GetHashCode());
            return result;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;

            CasillaSudoku other = (CasillaSudoku)obj;
            if (columna == null)
            {
                if (other.columna != null)
                    return false;
            }
            else if (!columna.Equals(other.columna))
                return false;
            if (fila == null)
            {
                if (other.fila != null)
                    return false;
            }
            else if (!fila.Equals(other.fila))
                return false;
            if (caja == null)
            {
                if (other.caja != null)
                    return false;
            }
            else if (!caja.Equals(other.caja))
                return false;
            return true;
        }

        public String toString()
        {
            return "(" + fila + ", " + columna + "," + valor + ")";
        }
    }
}
