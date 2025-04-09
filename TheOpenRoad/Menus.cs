using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenRoad
{
    public class Menus : FuncoesJogo
    {
        //Menu incial do simulador
        public void MenuInicial(Veiculo veiculo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("The Open Road - Bem Vindo");
                Console.WriteLine("Veiculo em uso: " + veiculo.Modelo);
                Console.WriteLine("1 - Entrar no veiculo");
                Console.WriteLine("2 - Inspecionar veiculo (Futura Atualização)");
                Console.WriteLine("3 - Manutenção do veiculo (Futura Atualização)");
                Console.WriteLine("4 - Selecionar Veiculo");
                Console.WriteLine("X - Sair");
                Console.Write("Digite aqui: ");
                string input = Console.ReadLine().ToLower();
                //menus disponíveis no menu incial
                switch (input)
                {
                    case "1": MenuDentroDoCarro(veiculo); break;
                    case "2": break;
                    case "3": break;
                    case "4": MenuParaEscolherVeiculo(veiculo); break;
                    case "x": Console.WriteLine("Obrigado por usar The Open Road..."); Environment.Exit(0); break;
                    default: Console.WriteLine("\a\nOpção inválida"); Console.ReadKey(); break;
                }
            }
        }
        //Menu para o usuario escolher o veiculo para jogar
        public void MenuParaEscolherVeiculo(Veiculo veiculo)
        {
            Adicionar adicionar = new Adicionar();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("The Open Road - Catalogo de veiculo");
                    Console.WriteLine("Veiculo Selecionado: " + veiculo.Modelo + "\n");
                    adicionar.Exibir();
                    Console.WriteLine("X - Sair");
                    Console.Write("Digite aqui: ");
                    string input = Console.ReadLine().ToLower();
                    if (input == "x") { return; }
                    else
                    {
                        int inputInt = Convert.ToInt32(input);
                        adicionar.Selecionar(inputInt, this);
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine("Erro: " + erro.Message);
                    Console.ReadKey();
                }
            }
        }
        //Menu que iria simular, como se estivese dentro do veiculo
        public void MenuDentroDoCarro(Veiculo veiculo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"The Open Road - Dentro Do {veiculo.Modelo}");
                Console.WriteLine(ExibirHoras());
                Console.WriteLine($"Carro {(CarroLigado ? "ligado":"desligado")}");
                Console.WriteLine($"Freio de mão {(FreioPuxado ? "levantado" : "abaixado")}");
                Console.WriteLine($"Marcha atual: {(MarchaAtual == 0 ? "neutro" : $"{MarchaAtual}")}");
                Console.WriteLine($"Cambio {(CambioManual ? "manual" : "automatico")}");
                Console.WriteLine($"Modo sport: {(ModoSport ? "ativo" : "desativado")}");
                Console.WriteLine($"Velocidade atual: {VelocidadeAtual}/Km");
                Console.WriteLine($"Farol {(FarolLigado ? "ligado" : "desligado")}");
                Console.WriteLine("\nFunções Disponiveis");
                Console.WriteLine($"1 - {(CarroLigado ? "Desligar" : "Ligar")} o carro");
                Console.WriteLine($"2 - {(FreioPuxado ? "Abaixar" : "Levantar")} o freio de mão");
                Console.WriteLine($"3 - {(FarolLigado ? "Desligar" : "Ligar")} os farol");
                Console.WriteLine($"4 - Colocar no cambio {(CambioManual ? "automatico" : "manual")}");
                Console.WriteLine($"5 - {(ModoSport ? "Desativar" : "Ativar")} modo sport");
                if (CambioManual)
                {
                    Console.WriteLine($"A - Aumentar marcha");
                    Console.WriteLine($"D - Diminuir marcha");
                }
                Console.WriteLine("W - Acerelar");
                Console.WriteLine("S - Desacelerar");
                Console.WriteLine("X - Sair do carro");
                Console.Write("Digite aqui: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1": CarroLigado = ModificarBooleano(CarroLigado); break;
                    case "2": 
                        FreioPuxado = ModificarBooleano(FreioPuxado);
                        if (FreioPuxado)
                            VelocidadeAtual = 0;
                        break;
                    case "3": FarolLigado = ModificarBooleano(FarolLigado); break;
                    case "4": CambioManual = ModificarBooleano(CambioManual); break;
                    case "5": ModoSport = ModificarBooleano(ModoSport); break;
                    case "a": if (CambioManual) { MudarMarcha("a", veiculo); } break;
                    case "d": if (CambioManual) { MudarMarcha("d", veiculo); } break;
                    case "w": VerificarCondicoes(veiculo); break;
                    case "s": Descelerar(veiculo); break;
                    case "x":
                        if (VelocidadeAtual > 0) { Console.WriteLine("\a\nDesacelere o carro antes de sair"); Console.ReadKey(); }
                        else{ return; }
                        break;
                    default: Console.WriteLine("\a\nOpção inválida"); Console.ReadKey(); break;
                }
            }
        }

    }
}
