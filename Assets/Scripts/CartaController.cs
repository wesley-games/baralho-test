using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaController : MonoBehaviour
{
    private Carta carta;

    public void Init(Carta carta)
    {
        this.carta = carta;
        Image image = GetComponentInChildren<Image>();
        Text text = GetComponentInChildren<Text>();
        text.text = carta.Nome.ToString();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
