using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject matchArea;
    public GameObject deckArea;
    private Dictionary<Carta, GameObject> cardsPlayed;

    private void Awake()
    {
        cardsPlayed = new Dictionary<Carta, GameObject>();
    }

    private void Update()
    {
    }

    public void InstanciaBaralho()
    {
        GameObject baralho = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, deckArea.transform);
        baralho.GetComponent<CartaController>().Init(null, true);
    }

    public void InstanciaCartaPlayer(Carta carta)
    {
        GameObject cartaTela = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerArea.transform);
        cardsPlayed.Add(carta, cartaTela);
        cartaTela.GetComponent<CartaController>().Init(carta, false);
    }

    public void InstanciaCartaEnemy(Carta carta)
    {
        GameObject cartaTela = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, enemyArea.transform);
        cardsPlayed.Add(carta, cartaTela);
        cartaTela.GetComponent<CartaController>().Init(carta, false);
    }

    public void JogaCarta(Carta card)
    {
        GameObject cardOnHand;
        cardsPlayed.TryGetValue(card, out cardOnHand);
        if (cardOnHand != null) cardOnHand.transform.SetParent(matchArea.transform);
    }

    public void TerminaTurno()
    {
        // TODO pegar e destruir os filhos do matchArea
    }
}