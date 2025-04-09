using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenRoad
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public int VelocidadeMaxima { get; set; }
        public int MarchasMaxima { get; set; }

        public Veiculo(string modelo, int velocidade, int marcha)
        {
            this.Modelo = modelo;
            this.VelocidadeMaxima = velocidade;
            this.MarchasMaxima = marcha;
        }
    }

    public class Adicionar
    {
        public List<Veiculo> veiculos = new List<Veiculo>()
        {
            new Veiculo("Golf", 230, 6),
            new Veiculo("Jetta", 250, 6),
            new Veiculo("Civic", 250, 5),
            new Veiculo("Voyage", 180, 5),
            new Veiculo("Palio", 150, 5),
            new Veiculo("F-150", 140, 5),
            new Veiculo("F1", 400, 8)
        };

        public void Exibir()
        {

            for (int i = 0; i < veiculos.Count; i++)
            {
                var v = veiculos[i];
                Console.WriteLine($"{i + 1} - Modelo: {v.Modelo}\nVelocidade Maxima: {v.VelocidadeMaxima}");
                Console.WriteLine();
                for (int y = 0; y <= 20; y++)
                    Console.Write("-");
                Console.WriteLine("");
            }
        }

        public void Selecionar(int input,Menus menus)
        {
            Veiculo selecionado = veiculos[input - 1];
            menus.MenuInicial(selecionado);
        }

    }

} 
