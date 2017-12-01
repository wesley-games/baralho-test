using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public BoardController boardController;
    public UIController uIController;

    private void Start()
    {
    }

    private void Update()
    {
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