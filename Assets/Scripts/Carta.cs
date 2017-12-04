using System;
using UnityEngine;

[Serializable]
public class Carta
{
    public enum Nomes { DOIS = 2, TRES, QUATRO, CINCO, SEIS, SETE, OITO, NOVE, DEZ, VALETE, DAMA, REI, AS }
    public enum Naipes { ESPADAS, OUROS, COPAS, PAUS }

    public Nomes Nome { get; set; }
    public Naipes Naipe { get; set; }

    public Carta(Nomes nome, Naipes naipe)
    {
        Nome = nome;
        Naipe = naipe;
    }
}
