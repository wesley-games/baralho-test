using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{

    public Baralho baralho { get; set; }
    private Player player1, player2;

    private Player primeiroJogador, segundoJogador;
    private Carta primeiraCarta, segundaCarta;
    private bool alguemGanhou = false;

    private UIController uIController;

    private void Start()
    {
        uIController = GetComponent<UIController>();
        baralho = new Baralho();
        uIController.InstanciaBaralho();

        player1 = new Player("Fulano  ", baralho);
        player2 = new Player("Ciclano ", baralho);
        primeiroJogador = player1;
        segundoJogador = player2;

        for (int i = 0; i < 3; i++)
        {
            Carta carta1 = player1.PegaCarta();
            uIController.InstanciaCartaPlayer(carta1);
            Carta carta2 = player2.PegaCarta();
            uIController.InstanciaCartaEnemy(carta2);
           
        }
    }

    private void FixedUpdate()
    {
        if (!alguemGanhou)
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
        }
    }

    private void turno(Player primeiroJogador, Player segundoJogador)
    {
        primeiraCarta = primeiroJogador.Joga(null);
        segundaCarta = segundoJogador.Joga(primeiraCarta);
    }
}