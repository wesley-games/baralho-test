using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    private Player player1, player2;
    private Player primeiroJogador, segundoJogador;
    private Carta primeiraCarta, segundaCarta;
    private bool alguemGanhou = false;

    private UIController uIController;
    private BaralhoController baralhoController;

    private void Awake()
    {
        uIController = GetComponent<UIController>();
        baralhoController = GetComponent<BaralhoController>();

        player1 = new Player("Fulano  ", baralhoController);
        player2 = new Player("Ciclano ", baralhoController);
        primeiroJogador = player1;
        segundoJogador = player2;
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            player1.PegaCarta();
            player2.PegaCarta();
        }
        while (!alguemGanhou)
        {
            List<Carta> primeirasCartasPescadas = new List<Carta>();
            primeiraCarta = primeiroJogador.Joga(null, out primeirasCartasPescadas);
            Debug.Log("PLAYER " + primeiroJogador.nome + " JOGA - " + primeiraCarta.ToString() + " (PESCA - " + primeirasCartasPescadas.Count + ")");

            List<Carta> segundasCartasPescadas = new List<Carta>();
            segundaCarta = segundoJogador.Joga(primeiraCarta, out segundasCartasPescadas);
            Debug.Log("PLAYER " + segundoJogador.nome + " JOGA - " + segundaCarta.ToString() + " (PESCA - " + segundasCartasPescadas.Count + ")");
            if (segundaCarta.Nome > primeiraCarta.Nome)
            {
                primeiroJogador = player2;
                segundoJogador = player1;
            }
            if (primeiroJogador.cartasPlayer.Count == 0 || segundoJogador.cartasPlayer.Count == 0)
            {
                alguemGanhou = true;
            }
        }
        Debug.Log("JOGO - E O JOGO ACABA AQUI");
        // StartCoroutine(Jogo());
    }

    private IEnumerator Jogo()
    {
        yield return 0;
    }

    private IEnumerator InicializaPlayers()
    {
        yield return 0;
    }

    private IEnumerator JogadaPlayer(Player player)
    {
        yield return 0;
    }

    private IEnumerator FinalizaTurno()
    {
        yield return 0;
    }

    // private IEnumerator Jogo()
    // {
    //     yield return StartCoroutine(uIController.InstanciaBaralho());
    //     for (int i = 0; i < 3; i++)
    //     {
    //         player1.PegaCarta();
    //         player2.PegaCarta();
    //     }
    //     while (!alguemGanhou)
    //     {
    //         yield return StartCoroutine(Turno(primeiroJogador, segundoJogador));
    //         yield return StartCoroutine(uIController.TerminaTurno());
    //     }
    //     Debug.Log("JOGO - E O JOGO ACABA AQUI");
    //     yield return 0;
    // }

    // private IEnumerator Turno(Player primeiroJogador, Player segundoJogador)
    // {
    //     yield return StartCoroutine(primeiroJogador.Joga(null, (carta) => primeiraCarta = carta));
    //     yield return StartCoroutine(uIController.JogaCarta(primeiraCarta));
    //     yield return StartCoroutine(segundoJogador.Joga(primeiraCarta, (carta) => segundaCarta = carta));
    //     yield return StartCoroutine(uIController.JogaCarta(segundaCarta));
    //     if (segundaCarta.Nome > primeiraCarta.Nome)
    //     {
    //         primeiroJogador = player2;
    //         segundoJogador = player1;
    //     }
    //     if (primeiroJogador.cartasPlayer.Count == 0 || segundoJogador.cartasPlayer.Count == 0)
    //     {
    //         alguemGanhou = true;
    //     }
    // }
}