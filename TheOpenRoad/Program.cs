using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenRoad
{
    internal class Program
    {
        //Inicialização do programa
        public static void Main(string[] args)
        {
            Console.Title = "The Open Road - Simulador";
            Menus menus = new Menus();
            menus.MenuInicial(new Veiculo("Golf", 230, 6));
        }
    }
}
