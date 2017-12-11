using System.Collections.Generic;
using System;
using UnityEngine;

public class BaralhoController : MonoBehaviour
{
    public List<Carta> Cartas { get; set; }

    void Awake()
    {
        Cartas = new List<Carta>();
        foreach (Carta.Nomes nome in Enum.GetValues(typeof(Carta.Nomes)))
        {
            foreach (Carta.Naipes naipe in Enum.GetValues(typeof(Carta.Naipes)))
            {
                Cartas.Add(new Carta(nome, naipe));
            }
        }
    }

    public int GetNumeroCartas()
    {
        return Cartas.Count;
    }

    public Carta RemoveCartaRandom()
    {
        int id = UnityEngine.Random.Range(0, GetNumeroCartas());
        Carta carta = Cartas[id];
        Cartas.RemoveAt(id);
        return carta;
    }
}