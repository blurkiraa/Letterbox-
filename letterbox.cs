using System;
using System.Collections.Generic;
using System.Linq;

public class Filme
{
    public string Titulo { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

    public double MediaPontuacao
    {
        get
        {
            if (Avaliacoes.Count == 0) return 0;
            return Avaliacoes.Average(av => av.Nota);
        }
    }

    public Filme(string titulo)
    {
        Titulo = titulo;
    }

    public void AdicionarAvaliacao(Avaliacao avaliacao)
    {
        Avaliacoes.Add(avaliacao);
    }

    public void MostrarAvaliacoes()
    {
        Console.WriteLine($"Avaliações para o filme: {Titulo}");
        foreach (var avaliacao in Avaliacoes)
        {
            Console.WriteLine($"Nota: {avaliacao.Nota}, Comentário: {avaliacao.Comentario}, Indicado para crianças: {(avaliacao.IndicadoParaCriancas ? "Sim" : "Não")}");
        }
        Console.WriteLine($"Média de Pontuação: {MediaPontuacao:F2}");
    }
}

public class Avaliacao
{
    public int Nota { get; set; }
    public string Comentario { get; set; }
    public bool IndicadoParaCriancas { get; set; }

    public Avaliacao(int nota, string comentario, bool indicadoParaCriancas)
    {
        Nota = nota;
        Comentario = comentario;
        IndicadoParaCriancas = indicadoParaCriancas;
    }
}

public class Program
{
    public static void Main()
    {
        List<Filme> filmes = new List<Filme>();

        while (true)
        {
            Console.WriteLine("1. Adicionar Filme");
            Console.WriteLine("2. Avaliar Filme");
            Console.WriteLine("3. Mostrar Avaliações");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Write("Digite o título do filme: ");
                string titulo = Console.ReadLine();
                filmes.Add(new Filme(titulo));
            }
            else if (opcao == "2")
            {
                Console.Write("Digite o título do filme para avaliar: ");
                string titulo = Console.ReadLine();
                var filme = filmes.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
                if (filme == null)
                {
                    Console.WriteLine("Filme não encontrado.");
                    continue;
                }

                Console.Write("Digite a nota (0-10): ");
                int nota = int.Parse(Console.ReadLine());

                Console.Write("Digite seu comentário: ");
                string comentario = Console.ReadLine();

                Console.Write("O filme é indicado para crianças (s/n): ");
                bool indicadoParaCriancas = Console.ReadLine().Trim().ToLower() == "s";

                filme.AdicionarAvaliacao(new Avaliacao(nota, comentario, indicadoParaCriancas));
            }
            else if (opcao == "3")
            {
                Console.Write("Digite o título do filme para mostrar avaliações: ");
                string titulo = Console.ReadLine();
                var filme = filmes.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
                if (filme == null)
                {
                    Console.WriteLine("Filme não encontrado.");
                    continue;
                }
                filme.MostrarAvaliacoes();
            }
            else if (opcao == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}