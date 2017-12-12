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

        player1 = new Jogador("Jogador  ", baralhoController);
        player2 = new Inimigo("Inimigo  ", baralhoController);
        primeiroJogador = player1;
        segundoJogador = player2;
    }

    private void Start()
    {
        StartCoroutine(Jogo());
    }

    private IEnumerator Jogo()
    {
        yield return StartCoroutine(uIController.InstanciaBaralho());

        for (int i = 0; i < 3; i++)
        {
            Carta carta;
            carta = player1.PegaCarta();
            yield return StartCoroutine(uIController.InstanciaCartaPlayer(carta));
            carta = player2.PegaCarta();
            yield return StartCoroutine(uIController.InstanciaCartaEnemy(carta));
        }

        while (!alguemGanhou)
        {
            List<Carta> primeirasCartasPescadas = new List<Carta>();
            primeiraCarta = primeiroJogador.Joga(null, out primeirasCartasPescadas);
            if (primeirasCartasPescadas.Count > 0)
            {
                foreach (Carta carta in primeirasCartasPescadas)
                {
                    if (primeiroJogador is Jogador)
                        yield return StartCoroutine(uIController.InstanciaCartaPlayer(carta));
                    else
                        yield return StartCoroutine(uIController.InstanciaCartaEnemy(carta));
                }
            }
            yield return StartCoroutine(uIController.JogaCarta(primeiraCarta));

            List<Carta> segundasCartasPescadas = new List<Carta>();
            segundaCarta = segundoJogador.Joga(primeiraCarta, out segundasCartasPescadas);
            if (segundasCartasPescadas.Count > 0)
            {
                foreach (Carta carta in segundasCartasPescadas)
                {
                    if (segundoJogador is Jogador)
                        yield return StartCoroutine(uIController.InstanciaCartaPlayer(carta));
                    else
                        yield return StartCoroutine(uIController.InstanciaCartaEnemy(carta));
                }
            }
            yield return StartCoroutine(uIController.JogaCarta(segundaCarta));

            if (segundaCarta.Nome > primeiraCarta.Nome)
            {
                Player aux = primeiroJogador;
                primeiroJogador = segundoJogador;
                segundoJogador = aux;
            }
            if (primeiroJogador.cartasPlayer.Count == 0 || segundoJogador.cartasPlayer.Count == 0)
            {
                alguemGanhou = true;
            }
            yield return StartCoroutine(uIController.TerminaTurno());
        }

        Debug.Log("JOGO - E O JOGO ACABA AQUI");
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