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

    public delegate void OnJogoTerminou();
    public event OnJogoTerminou JogoTerminou;

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
            if (segundaCarta != null)
                yield return StartCoroutine(uIController.JogaCarta(segundaCarta));

            if (segundaCarta != null)
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
        StopAllCoroutines();
        JogoTerminou();
        yield return 0;
    }
}