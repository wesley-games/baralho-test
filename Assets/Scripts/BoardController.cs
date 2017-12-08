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

        player1 = new Player("Fulano  ", false, baralhoController);
        player2 = new Player("Ciclano ", true, baralhoController);
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
            player1.PegaCarta();
            player2.PegaCarta();
        }

        while (!alguemGanhou)
        {
            yield return StartCoroutine(Turno(primeiroJogador, segundoJogador));

            if (segundaCarta.Nome > primeiraCarta.Nome)
            {
                primeiroJogador = player2;
                segundoJogador = player1;
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

    private IEnumerator Turno(Player primeiroJogador, Player segundoJogador)
    {
        primeiraCarta = primeiroJogador.Joga(null);
        yield return StartCoroutine(uIController.JogaCarta(primeiraCarta));
        segundaCarta = segundoJogador.Joga(primeiraCarta);
        yield return StartCoroutine(uIController.JogaCarta(segundaCarta));
    }
}