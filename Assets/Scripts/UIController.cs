using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject baralhoPrefab;
    public GameObject cartaPrefab;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void InstanciaBaralho()
    {
        GameObject baralho = Instantiate(baralhoPrefab);
    }

    public void InstanciaCarta(Carta carta)
    {
        GameObject cartaTela = Instantiate(cartaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // private void InstanciaCartaPlayer(Carta carta)
    // {
    //     GameObject cartaTela = Instantiate(cartaPrefab, new Vector3(-11 + (2 * CartasPlayer.Count), -4, 0), Quaternion.identity);
    //     cartaTela.GetComponent<CartaController>().setValor(carta);
    // }

    // private void InstanciaCartaInimigo(Carta carta)
    // {
    //     GameObject cartaTela = Instantiate(cartaPrefab, new Vector3(-11 + (2 * CartasInimigo.Count), 5, 0), Quaternion.identity);
    //     cartaTela.GetComponent<CartaController>().setValor(carta);
    // }
}