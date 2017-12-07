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
    private int rodadas = 0;

    private UIController uIController;
    private BaralhoController baralhoController;

    private void Awake()
    {
        uIController = GetComponent<UIController>();
        baralhoController = GetComponent<BaralhoController>();
    }

    private void Start()
    {
        uIController.InstanciaBaralho();

        player1 = new Player("Fulano  ", false, baralhoController);
        player2 = new Player("Ciclano ", true, baralhoController);
        primeiroJogador = player1;
        segundoJogador = player2;

        for (int i = 0; i < 3; i++)
        {
            player1.PegaCarta();
            player2.PegaCarta();
        }
    }

    private void FixedUpdate()
    {
        if (!alguemGanhou)
        // if (rodadas < 1)
        {
            turno(primeiroJogador, segundoJogador);
            if (segundaCarta.Nome > primeiraCarta.Nome)
            {
                primeiroJogador = player2;
                segundoJogador = player1;
            }
            if (primeiroJogador.cartasPlayer.Count == 0 || segundoJogador.cartasPlayer.Count == 0)
            {
                alguemGanhou = true;
            }
            rodadas++;
            uIController.TerminaTurno();
        }
    }

    private void turno(Player primeiroJogador, Player segundoJogador)
    {
        primeiraCarta = primeiroJogador.Joga(null);
        uIController.JogaCarta(primeiraCarta);
        segundaCarta = segundoJogador.Joga(primeiraCarta);
        uIController.JogaCarta(segundaCarta);
    }
}