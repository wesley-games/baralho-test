using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public string nome { get; set; }
    private Baralho baralho;
    public List<Carta> cartasPlayer { get; set; }

    public Player(string nome, Baralho baralho)
    {
        this.nome = nome;
        this.baralho = baralho;
        this.cartasPlayer = new List<Carta>();
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

    private Carta JogaCarta(Carta carta)
    {
        cartasPlayer.RemoveAt(cartasPlayer.IndexOf(carta));
        return carta;
    }

    private Carta DecideCarta(Carta cartaJogada)
    {
        Carta cartaPraJogar = null;
        List<Carta> cartasPossiveis = new List<Carta>();
        foreach (Carta c in cartasPlayer)
        {
            if (c.Naipe == cartaJogada.Naipe)
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
        else
        {
            if (PegaCarta() != null)
            {
                cartaPraJogar = DecideCarta(cartaJogada);
            }
        }
        return cartaPraJogar;
    }

    public Carta Joga(Carta cartaJogada)
    {
        Carta carta = null;
        if (cartaJogada == null)
        {
            int index = UnityEngine.Random.Range(0, cartasPlayer.Count);
            carta = JogaCarta(cartasPlayer[index]);
        }
        else
        {
            Carta cartaPraJogar = DecideCarta(cartaJogada);
            if (cartaPraJogar != null)
            {
                carta = JogaCarta(cartaPraJogar);
            }
        }
        return carta;
    }
}