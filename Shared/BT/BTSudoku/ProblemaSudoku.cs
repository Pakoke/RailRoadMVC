using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BTSudoku
{
    public class ProblemaSudoku
    {
        private static int tamaño;
        private static List<CasillaSudoku> casillasVacias;
        private static List<CasillaSudoku> casillasOcupadas;
        private static Dictionary<int?, Dictionary<int?, int?>> sudokuInicial;

        private ProblemaSudoku()
        {
        }

        public static void cargaDatos(String fichero)
        {
            sudokuInicial = new Dictionary<int?, Dictionary<int?, int?>>();
            IEnumerable<String> iss;
            try
            {
                iss = File.ReadAllLines(fichero);

            }
            catch (Exception e)
            {
                throw new Exception("Error taking the file");
            }
            

            foreach(String s in iss)
            {
                var saux = s.Trim();
                string[] stringSeparators = new string[] { " " };
                String[] split = saux.Split(stringSeparators,StringSplitOptions.None);
                if (split.Length == 1)
                {
                    tamaño = int.Parse(split[0]);
                }
                if (split.Length == 3)
                {
                    int fila = int.Parse(split[0]);
                    int columna = int.Parse(split[1]);
                    int valor = int.Parse(split[2]);
                    Dictionary<int?, int?> columnavalor = new Dictionary<int?, int?>();
                    columnavalor.Add(columna, valor);
                    sudokuInicial.Add(fila, columnavalor);
                }
            }
            casillasVacias = new List<CasillaSudoku>();
            casillasOcupadas = new List<CasillaSudoku>();

            int? tamCaja = tamaño / 3;
            int? caja = null;
            if (tamaño == 4) tamCaja = tamaño / 2;

            for (int f = 0; f < tamaño; f++)
            {
                for (int c = 0; c < tamaño; c++)
                {
                    if (!sudokuInicial.ContainsKey(f))
                    {
                        sudokuInicial.Add(f, new Dictionary<int?, int?>());
                    }
                    if (!sudokuInicial[f].ContainsKey(c))
                    {
                        Dictionary<int?, int?> entry = new Dictionary<int?, int?>();
                        entry.Add(c, null);
                        sudokuInicial[f].Add(c,null);
                    }

                    int? v = (int?)sudokuInicial[f][c];

                    caja = ((int)(f / tamCaja)) + tamCaja * ((int)(c / tamCaja));
                    if (v == null)
                    {
                        casillasVacias.Add(CasillaSudoku.create(f, c, caja));
                    }
                    else
                    {
                        casillasOcupadas.Add(CasillaSudoku.create(f, c, v, caja));
                    }
                }
            }

        }

        public static int getTamaño()
        {
            return tamaño;
        }

        public static List<CasillaSudoku> getCasillasVacias()
        {
            return casillasVacias;
        }

        public static List<CasillaSudoku> getCasillasOcupadas()
        {
            return casillasOcupadas;
        }

        public static Dictionary<int?, Dictionary<int?, int?>> getMatriz()
        {
            return sudokuInicial;
        }

        public static String toString(Dictionary<int?, Dictionary<int?, int?>> sudoku)
        {
            if (sudoku == null) return "Solución no encontrada";
            String s = "";
            for (int f = 0; f < tamaño; f++)
            {
                for (int c = 0; c < tamaño; c++)
                {
                    var v = sudoku[f][c];
                    if (tamaño == 4 && c != 0)
                    {
                        s = s + "|";
                    }
                    else
                    {
                        s = s + " ";
                    }
                    if (v != null)
                    {
                        s = s + v;
                    }
                    else
                    {
                        s = s + " ";
                    }
                }
                s = s + "\n";
            }
            return s;
        }
    }
}
