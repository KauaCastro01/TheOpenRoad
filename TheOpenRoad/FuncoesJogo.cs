using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenRoad
{
    public class FuncoesJogo
    {
        public DateTime data = DateTime.Now;
        public bool CarroLigado = false;
        public bool FreioPuxado = true;
        public int MarchaAtual = 0;
        public int VelocidadeAtual = 0;
        public bool FarolLigado = false;
        public bool CambioManual = true;
        public bool ModoSport = false;

        //Metodo para exibição das horas
        public string ExibirHoras()
        {
            if(data.Hour > 5 && data.Hour <= 11) { return $"Horario: {data.Hour}:{data.Minute} - Manhã"; }
            if (data.Hour > 12  && data.Hour <= 18) { return $"Horario: {data.Hour}:{data.Minute} - Tarde"; }
            else { return $"Horario: {data.Hour}:{data.Minute} - Noite"; }
        }
        //Metodo para variaveis booleanas
        public bool ModificarBooleano(bool valor) { return !valor; }
        //Aumnetar ou diminuir a marcha
        public void MudarMarcha(string input, Veiculo veiculo)
        {
            switch (input)
            {
                case "a": 
                    if(MarchaAtual >= veiculo.MarchasMaxima)
                        MarchaAtual = veiculo.MarchasMaxima;
                    else 
                        MarchaAtual++;
                    break;
                case "d":
                    if (MarchaAtual <= 0)
                        MarchaAtual = -1;
                    else
                        MarchaAtual--;
                    break;
            }
        }

        //Verificar as condiçoes para acelerar
        public void VerificarCondicoes(Veiculo veiculo)
        {
            if (!CarroLigado) { Console.WriteLine("\n\aO carro está desligado"); Console.ReadKey(); }
            else if (FreioPuxado) { Console.WriteLine("\n\aO freio de mão está levantado"); Console.ReadKey(); }
            else if (CambioManual && MarchaAtual == 0) { Console.WriteLine("\n\aMarcha não engatada"); Console.ReadKey(); }
            else { Acelerar(veiculo); }
        }
        //acelerar o carro
        public void Acelerar(Veiculo veiculo)
        {
            if(!CambioManual && MarchaAtual == 0) { MarchaAtual++; }
            if (ModoSport) { VelocidadeAtual += 12; }
            else { VelocidadeAtual += 4; }
            switch (MarchaAtual)
            {
                //1° Marcha
                case 1:
                    if (CambioManual) { if (VelocidadeAtual > 20) { VelocidadeAtual = 20; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                    else { if (VelocidadeAtual > 20) { MudarMarcha("a", veiculo); } }
                        break;
                //2° Marcha
                case 2:
                    if (CambioManual) { if (VelocidadeAtual > 40) VelocidadeAtual = 40; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); }
                    else { if (VelocidadeAtual > 40) { MudarMarcha("a", veiculo); } }
                    break;
                //3° Marcha
                case 3:
                    if (CambioManual) { if (VelocidadeAtual > 70) { VelocidadeAtual = 70; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                    else { if (VelocidadeAtual > 70) { MudarMarcha("a", veiculo); } }
                    break;
                //4° Marcha
                case 4:
                    if (CambioManual) { if (VelocidadeAtual > 100) { VelocidadeAtual = 100; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                    else { if (VelocidadeAtual > 90) { MudarMarcha("a", veiculo); } }
                    break;
                //5° Marcha
                case 5:
                    if(MarchaAtual < veiculo.MarchasMaxima)
                    {
                        if (CambioManual) { if (VelocidadeAtual > 150) { VelocidadeAtual = 150; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                        else { if (VelocidadeAtual > 150) { MudarMarcha("a", veiculo); } }
                    }
                    else
                    {
                        if (VelocidadeAtual > veiculo.VelocidadeMaxima) { VelocidadeAtual = veiculo.VelocidadeMaxima; Console.WriteLine("\a\nVelocidade maxima atingida"); Console.ReadKey(); }
                    }
                        break;
                //6° Marcha
                case 6:
                    if (MarchaAtual < veiculo.MarchasMaxima)
                    {
                        if (CambioManual) { if (VelocidadeAtual > 200) { VelocidadeAtual = 200; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                        else { if (VelocidadeAtual > 200) { MudarMarcha("a", veiculo); } }
                    }
                    else
                    {
                        if (VelocidadeAtual > veiculo.VelocidadeMaxima) { VelocidadeAtual = veiculo.VelocidadeMaxima; Console.WriteLine("\a\nVelocidade maxima atingida"); Console.ReadKey(); }
                    }
                    break;
                //7° Marcha
                case 7:
                    if (MarchaAtual < veiculo.MarchasMaxima)
                    {
                        if (CambioManual) { if (VelocidadeAtual > 250) { VelocidadeAtual = 250; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                        else { if (VelocidadeAtual > 250) { MudarMarcha("a", veiculo); } }
                    }
                    else
                    {
                        if (VelocidadeAtual >= veiculo.VelocidadeMaxima) { VelocidadeAtual = veiculo.VelocidadeMaxima; Console.WriteLine("\a\nVelocidade maxima atingida"); Console.ReadKey(); }
                    }
                    break;
                //Caso a marcha maxima ja estja acionada
                default:
                        if (VelocidadeAtual >= veiculo.VelocidadeMaxima)
                        {
                            VelocidadeAtual = veiculo.VelocidadeMaxima; VelocidadeAtual = veiculo.VelocidadeMaxima; Console.WriteLine("\a\nVelocidade maxima atingida"); Console.ReadKey();
                    }
                    break;
            }
        }
        //Desacerelar o carro
        public void Descelerar(Veiculo veiculo)
        {
            if (ModoSport) { VelocidadeAtual -= 24; }
            else { VelocidadeAtual -= 8; }
            switch (MarchaAtual)
            {
                //Neutro
                case 0:
                    VelocidadeAtual = 0; Console.WriteLine("\a\nVeiculo parado");
                    break;
                //1° Marcha
                case 1:
                    if (CambioManual) { if (VelocidadeAtual <= 0) { VelocidadeAtual = 0; Console.WriteLine("\a\nVeiculo parado"); Console.ReadKey(); } }
                    else { VelocidadeAtual = 0; Console.WriteLine("\a\nVeiculo parado"); Console.ReadKey(); }
                break;
                //2° Marcha
                case 2:
                    if (CambioManual) { if (VelocidadeAtual <= 20) VelocidadeAtual = 20; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); }
                    else { if (VelocidadeAtual <= 20) { MudarMarcha("d", veiculo); } }
                    break;
                //3° Marcha
                case 3:
                    if (CambioManual) { if (VelocidadeAtual <= 40) { VelocidadeAtual = 40; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                    else { if (VelocidadeAtual <= 40) { MudarMarcha("d", veiculo); } }
                    break;
                //4° Marcha
                case 4:
                    if (CambioManual) { if (VelocidadeAtual <= 70) { VelocidadeAtual = 70; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                    else { if (VelocidadeAtual <= 70) { MudarMarcha("d", veiculo); } }
                    break;
                //5° Marcha
                case 5:
                        if (CambioManual) { if (VelocidadeAtual <= 90) { VelocidadeAtual = 90; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                        else { if (VelocidadeAtual <= 90) { MudarMarcha("d", veiculo); } }
                    break;
                //6° Marcha
                case 6:
                        if (CambioManual) { if (VelocidadeAtual <= 150) { VelocidadeAtual = 150; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                        else { if (VelocidadeAtual <= 150) { MudarMarcha("d", veiculo); } }
                    break;
                //7° Marcha
                case 7:
                        if (CambioManual) { if (VelocidadeAtual <= 200) { VelocidadeAtual = 200; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                        else { if (VelocidadeAtual <= 200) { MudarMarcha("d", veiculo); } }
                    break;
                //Caso a marcha maxima ja estja acionada
                default:
                    if (CambioManual) { if (VelocidadeAtual <= 250) { VelocidadeAtual = 250; Console.WriteLine("\a\nTroque de marcha"); Console.ReadKey(); } }
                    else { if (VelocidadeAtual <= 250) { MudarMarcha("d", veiculo); } }
                    break;
            }
            
        }
    }
}
