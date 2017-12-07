using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaController : MonoBehaviour
{
    public Image backImage;
    public Image numberImage;
    public Image naipeImage;
    public Sprite backBackground;
    public Sprite background;
    public Sprite[] numbers;
    public Sprite[] naipes;

    private Carta carta;

    public void Init(Carta carta, bool verso)
    {
        this.carta = carta;
        if (verso || this.carta == null)
        {
            backImage.overrideSprite = backBackground;
            numberImage.enabled = false;
            naipeImage.enabled = false;
        }
        else
        {
            backImage.overrideSprite = background;
            numberImage.enabled = true;
            naipeImage.enabled = true;

            switch (this.carta.Nome)
            {
                case Carta.Nomes.DOIS:
                    numberImage.overrideSprite = numbers[0];
                    break;
                case Carta.Nomes.TRES:
                    numberImage.overrideSprite = numbers[1];
                    break;
                case Carta.Nomes.QUATRO:
                    numberImage.overrideSprite = numbers[2];
                    break;
                case Carta.Nomes.CINCO:
                    numberImage.overrideSprite = numbers[3];
                    break;
                case Carta.Nomes.SEIS:
                    numberImage.overrideSprite = numbers[4];
                    break;
                case Carta.Nomes.SETE:
                    numberImage.overrideSprite = numbers[5];
                    break;
                case Carta.Nomes.OITO:
                    numberImage.overrideSprite = numbers[6];
                    break;
                case Carta.Nomes.NOVE:
                    numberImage.overrideSprite = numbers[7];
                    break;
                case Carta.Nomes.DEZ:
                    numberImage.overrideSprite = numbers[8];
                    break;
                case Carta.Nomes.AS:
                    numberImage.overrideSprite = numbers[9];
                    break;
                case Carta.Nomes.VALETE:
                    numberImage.overrideSprite = numbers[10];
                    break;
                case Carta.Nomes.DAMA:
                    numberImage.overrideSprite = numbers[11];
                    break;
                case Carta.Nomes.REI:
                    numberImage.overrideSprite = numbers[12];
                    break;
            }

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
