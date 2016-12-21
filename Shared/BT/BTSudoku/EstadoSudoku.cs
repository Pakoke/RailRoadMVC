using BTAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BTSudoku
{
    public class EstadoSudoku : StateBT<Dictionary<int?, Dictionary<int?, int?>>, int?>
    {
        private Dictionary<int?, HashSet<int?>> filas = null;
        private Dictionary<int?, HashSet<int?>> columnas = null;
        private Dictionary<int?, HashSet<int?>> cajas = null;

        private int? tamañoSudoku = 0;
        private List<CasillaSudoku> casillasVacias = null;
        private List<CasillaSudoku> casillasOcupadas = null;
        private int? siguienteCasillaVacia = 0;


        public EstadoSudoku()
        {
            EstadoSudokuConstructor(ProblemaSudoku.getCasillasVacias(), ProblemaSudoku.getCasillasOcupadas(), ProblemaSudoku.getTamaño());
            //this.casillasOcupadas = ProblemaSudoku.getCasillasOcupadas();
            //this.casillasVacias = ProblemaSudoku.getCasillasVacias();
            //this.tamañoSudoku = ProblemaSudoku.getTamaño();
        }

        private void EstadoSudokuConstructor(List<CasillaSudoku> casillasVacias, List<CasillaSudoku> casillasOcupadas, int? tamañoSudoku)
        {
            
            this.siguienteCasillaVacia = 0;
            this.tamañoSudoku = tamañoSudoku;
            this.casillasVacias = casillasVacias;
            this.casillasOcupadas = casillasOcupadas;

            this.filas = new Dictionary<int?, HashSet<int?>>();
            this.columnas = new Dictionary<int?, HashSet<int?>>();
            this.cajas = new Dictionary<int?, HashSet<int?>>();
            HashSet<int?> s = null;
            for (int? i = 0; i < tamañoSudoku; i++)
            {
                s = new HashSet<int?>();
                this.filas.Add(i, s);
                s = new HashSet<int?>();
                this.columnas.Add(i, s);
                s = new HashSet<int?>();
                this.cajas.Add(i, s);
            }

            foreach(CasillaSudoku c in casillasOcupadas)
            {
                this.filas[c.getFila()].Add(c.getValor());
                this.columnas[c.getColumna()].Add(c.getValor());
                this.cajas[c.getCaja()].Add(c.getValor());
            }
        }


        public void forward(int? valor)
        {
            CasillaSudoku cd = casillasVacias.ElementAt((int)siguienteCasillaVacia);
            cd.setValor(valor);
            filas[cd.getFila()].Add(cd.getValor());
            columnas[cd.getColumna()].Add(cd.getValor());
            cajas[cd.getCaja()].Add(cd.getValor());
            siguienteCasillaVacia++;

        }


        public IEnumerable<int?> getAlternatives()
        {
            List<int?> it = new List<int?>();
            for(int i=1;i<tamañoSudoku+1; i++){ it.Add(i); };
            CasillaSudoku cd = casillasVacias.ElementAt((int)siguienteCasillaVacia);
            Predicate<int?> pr =
                x => filas[cd.getFila()].Contains(x) 
                && columnas[cd.getColumna()].Contains(x) 
                && cajas[cd.getCaja()].Contains(x);
            it.RemoveAll(pr);
            return it;
        }

        public Dictionary<int?, Dictionary<int?, int?>> getSolution()
        {
            Dictionary<int?, Dictionary<int?, int?>> t = new Dictionary<int?, Dictionary<int?, int?>>();
            foreach(CasillaSudoku c in casillasOcupadas)
            {
                Dictionary<int?, int?> tt = new Dictionary<int?, int?>();
                tt.Add(c.getColumna(), c.getValor());
                if (t.ContainsKey(c.getFila()) && t[c.getFila()].ContainsKey(c.getColumna()))
                    t[c.getFila()][c.getColumna()] = c.getValor();
                else if (t.ContainsKey(c.getFila()) && !t[c.getFila()].ContainsKey(c.getColumna()))
                    t[c.getFila()].Add(c.getColumna(), c.getValor());
                else
                    t.Add(c.getFila(), tt);

            }
            foreach(CasillaSudoku c in casillasVacias)
            {
                if (c.getValor() != null)
                {
                    Dictionary<int?, int?> tt = new Dictionary<int?, int?>();
                    tt.Add(c.getColumna(), c.getValor());
                    if (t.ContainsKey(c.getFila()) && t[c.getFila()].ContainsKey(c.getColumna()))
                        t[c.getFila()][c.getColumna()] = c.getValor();
                    else if (t.ContainsKey(c.getFila()) && !t[c.getFila()].ContainsKey(c.getColumna()))
                        t[c.getFila()].Add(c.getColumna(), c.getValor());
                    else
                        t.Add(c.getFila(), tt);
                }
            }
            return t;
        }


        public bool isFinal()
        {
            return siguienteCasillaVacia == casillasVacias.Count;
        }

        public bool isNotFinal()
        {
            return false;
        }

        public void backforward(int? valor)
        {
            siguienteCasillaVacia--;
            CasillaSudoku cd = casillasVacias.ElementAt((int)siguienteCasillaVacia);
            filas[cd.getFila()].Remove(valor);
            columnas[cd.getColumna()].Remove(valor);
            cajas[(int)cd.getCaja()].Remove(valor);
            cd.setValor(null);

        }

        public int size()
        {
            return casillasVacias.Count - (int)siguienteCasillaVacia;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public StateBT<Dictionary<int?, Dictionary<int?, int?>>, int?> DeepClone()
        {
            throw new NotImplementedException();
        }
    }
}
