using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaController : MonoBehaviour
{
    public Image backImage;
    public Image naipeImage;
    public Text nameText;
    public Sprite backBackground;
    public Sprite background;
    public Sprite[] naipes;

    private Carta carta;

    public void Init(Carta carta, bool verso)
    {
        this.carta = carta;
        if (verso || this.carta == null)
        {
            backImage.overrideSprite = backBackground;
            nameText.enabled = false;
            naipeImage.enabled = false;
        }
        else
        {
            backImage.overrideSprite = background;
            nameText.enabled = true;
            naipeImage.enabled = true;
            nameText.text = this.carta.Nome.ToString();

            switch (this.carta.Naipe)
            {
                case Carta.Naipes.ESPADAS:
                    naipeImage.overrideSprite = naipes[0];
                    break;
                case Carta.Naipes.PAUS:
                    naipeImage.overrideSprite = naipes[1];
                    break;
                case Carta.Naipes.COPAS:
                    naipeImage.overrideSprite = naipes[2];
                    break;
                case Carta.Naipes.OUROS:
                    naipeImage.overrideSprite = naipes[3];
                    break;
            }
        }
    }
}
