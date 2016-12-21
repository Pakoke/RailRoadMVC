
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAlgorithms
{
    public class AlgorithmBT<S, A, T > : AbstractAlgorithm //where T:Comparer<T>
    {
        /**
	 * Max: Maximizar, Min: Minimizar,Otro: No se pretende optimizar
	 *
	 */
        
        /**
         * El type del algoritmo según se pretenda optimizar o no
         */
        public static Type type;
        /**
         * Solución obtenida si es única
         */
        public S solucion = default(S);
        /**
         * Conjunto de solutions encontradas
         */
        public HashSet<S> solutions;
        /**
         * Número de solutions que se buscan
         */
        public static int numeroDeSoluciones = 1;
        /**
         * Si se quiere aplicar la técnica aleatoria para escoger una de las alternativas
         */
        public static bool isRandomize = false;
        /**
         * Tamaño umbral a partir del cual se escoge aleatoriamente una de las alternativas
         */
        public static int sizeRef = 10;
        /**
         * Si se quiere aplicar la técnica con filtro. En ese caso el Problema debe implementar adicionalmente el interface StateBTF
         */
        public static bool conFiltro = false;
        /**
         * Si solo se busca una solución
         */
        public static bool soloLaPrimeraSolucion = true;

        private ProblemBT<S, A> problem;
        private StateBT<S, A> state;
        private StateBTF<S, A, T> stateF;
        private bool exito = false;
        private T mejorValor;
        private int numberOfSolutions = 10;

        /**
         * @param p - El problema a resolver
         */
        public AlgorithmBT(ProblemBT<S, A> p)
        {
            problem = p;
            mejorValor = default(T);
        }

    /**
     * Ejecución del algoritmo
     */
    

    public void ejecuta()
        {
            solutions = new HashSet<S>();
            do
            {
                state = problem.getInitialState();
                if (conFiltro) stateF = (StateBTF<S, A, T>)state;
                bt();
            } while (isRandomize && solutions.Count < numeroDeSoluciones);
        }

        private IEnumerable<A> filtraRandomize(StateBT<S, A> p, IEnumerable<A> alternativas)
        {
            IEnumerable<A> alt;
            if (isRandomize && p.size() > sizeRef)
            {
                List<A> ls = new List<A>();
                ls.AddRange(alternativas);
                List<A> r = new List<A>();
                if (!(ls.Count <= 0))
                {
                    int e = Math2.getRandomInt(0, ls.Count);
                    r.Add(ls.ElementAt(e));
                }
                alt = r;
            }
            else
            {
                alt = alternativas;
            }
            return alt;
        }

        private void actualizaSoluciones()
        {
            if (conFiltro)
            {
                T objetive = stateF.getObjetive();
                if (mejorValor == null ||
                        AlgorithmBT<S, A, T>.type == Type.Max && new ComparatorBT<T>().Compare(objetive,mejorValor) > 0 ||
                        AlgorithmBT<S,A,T>.type == Type.Min && new ComparatorBT<T>().Compare(objetive,mejorValor) < 0)
                {
                    StateBT<S,A> copy = (StateBT<S,A>)state.DeepClone();
                    solucion = copy.getSolution();
                    solutions.Add(solucion);
                    mejorValor = objetive;
                }
            }
            else
            {
                StateBT<S, A> copy = (StateBT<S, A>)state.DeepClone();
                
                solucion = copy.getSolution();
                solutions.Add(solucion);
            }
        }

        private void bt()
        {
            if (state.isFinal())
            {
                actualizaSoluciones();
                if (soloLaPrimeraSolucion && solucion != null) exito = true;
                if (!soloLaPrimeraSolucion && solutions.Count >= numberOfSolutions) exito = true;
            }
            else
            {
                if (state.isNotFinal())
                {
                    actualizaSoluciones();
                }
                List<A> alternativasElegidas = new List<A>();
                foreach (A a in filtraRandomize(state, state.getAlternatives()))
                {
                    if (conFiltro && !pasaFiltro(a)) { continue; }
                    alternativasElegidas.Add(a);
                    state.forward(a);
                    bt();
                    state.backforward(a);
                    if (exito) break;
                }
            }
        }

        private bool pasaFiltro(A a)
        {
            bool r = true;
            if (conFiltro)
            {
                r = mejorValor == null ||
                        type == Type.Max && new ComparatorBT<T>().Compare(stateF.getEstimateObjective(a),mejorValor) > 0 ||
                        type == Type.Min && new ComparatorBT<T>().Compare(stateF.getEstimateObjective(a),mejorValor) < 0;
            }
            return r;
        }

        /**
         * @param p - Predicado con las propiedades de las solcuiones buscadas
         * @return Conjunto de solutions con las propiedades requeridas
         */
        public HashSet<S> getSolucionesFiltradas(Func<S,bool> p)
        {
            HashSet<S> newSet = new HashSet<S>();
            newSet = (HashSet<S>)solutions.Where(p);
            return newSet;
        }
    }
    internal class ComparatorBT<T> : Comparer<T>
    {
        public ComparatorBT() { }

        public override int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }
    }
}
