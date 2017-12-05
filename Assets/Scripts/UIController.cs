using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject cartaPrefab;
    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject matchArea;
    public GameObject deckArea;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void InstanciaBaralho()
    {
        GameObject baralho = Instantiate(cartaPrefab, new Vector3(0, 0, 0), Quaternion.identity, deckArea.transform);
    }

    public void InstanciaCartaPlayer(Carta carta)
    {
        GameObject cartaTela = Instantiate(cartaPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerArea.transform);
        cartaTela.GetComponent<CartaController>().Init(carta);
    }

    public void InstanciaCartaEnemy(Carta carta)
    {
        GameObject cartaTela = Instantiate(cartaPrefab, new Vector3(0, 0, 0), Quaternion.identity, enemyArea.transform);
        cartaTela.GetComponent<CartaController>().Init(carta);
    }
}