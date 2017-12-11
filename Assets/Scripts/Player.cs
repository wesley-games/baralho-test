using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string nome { get; set; }
    public List<Carta> cartasPlayer { get; set; }
    private BaralhoController baralho;

    public Player(string nome, BaralhoController baralho)
    {
        this.nome = nome;
        this.cartasPlayer = new List<Carta>();
        this.baralho = baralho;
    }

    /* Pega uma carta do baralho e adiciona às cartas do player, retorna nulo se o baralho acabou */
    public Carta PegaCarta()
    {
        if (baralho.GetNumeroCartas() > 0)
        {
            Carta carta = baralho.RemoveCartaRandom();
            cartasPlayer.Add(carta);
            return carta;
        }
        return null;
    }

    public Carta PegaCartaAteAchar(Carta cartaPraAchar, out List<Carta> cartasPescadas)
    {
        cartasPescadas = new List<Carta>();
        bool achou = false;
        Carta cartaRetorno = null;
        while (baralho.GetNumeroCartas() > 0 && !achou)
        {
            Carta carta = baralho.RemoveCartaRandom();
            cartasPlayer.Add(carta);
            cartasPescadas.Add(carta);
            if (carta.isMesmoNaipe(cartaPraAchar))
            {
                cartaRetorno = carta;
                achou = true;
            }
        }
        return cartaRetorno;
    }

    private Carta JogaCarta(Carta carta)
    {
        cartasPlayer.RemoveAt(cartasPlayer.IndexOf(carta));
        return carta;
    }

    // TODO a lista de cartasPossiveis é montada em todas as chamadas dessa função, mas não deveria,
    // ela só precisaria ser montada pra avaliar uma vez, nas próximas chamadas significa que não
    // havia nenhuma carta possível e o jogador foi obrigado a pescar, então ele só precisaria avaliar
    // a carta pescada.
    private Carta DecideCarta(Carta cartaJogada)
    {
        Carta cartaPraJogar = null;
        List<Carta> cartasPossiveis = new List<Carta>();
        foreach (Carta c in cartasPlayer)
        {
            if (c.isMesmoNaipe(cartaJogada))
            {
                cartasPossiveis.Add(c);
            }
        }
        if (cartasPossiveis.Count > 0)
        {
            Carta maior = cartasPossiveis[0];
            Carta menor = cartasPossiveis[0];
            foreach (Carta c in cartasPossiveis)
            {
                if (c.Nome > maior.Nome) maior = c;
                if (c.Nome < menor.Nome) menor = c;
            }
            if (maior.Nome > cartaJogada.Nome)
            {
                cartaPraJogar = maior;
            }
            else
            {
                cartaPraJogar = menor;
            }
        }
        return cartaPraJogar;
    }

    public Carta Joga(Carta cartaJogada, out List<Carta> cartasPescadas)
    {
        Carta cartaPraJogar = null;
        cartasPescadas = null;
        if (cartaJogada == null)
        {
            int index = UnityEngine.Random.Range(0, cartasPlayer.Count);
            cartaPraJogar = JogaCarta(cartasPlayer[index]);
        }
        else
        {
            cartaPraJogar = DecideCarta(cartaJogada);
            if (cartaPraJogar != null)
            {
                cartaPraJogar = JogaCarta(cartaPraJogar);
            }
            else
            {
                cartaPraJogar = PegaCartaAteAchar(cartaJogada, out cartasPescadas);
            }
        }
        return cartaPraJogar;
    }
}