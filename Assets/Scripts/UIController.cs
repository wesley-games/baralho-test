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

    private int timeToWait = 1;
    private Dictionary<Carta, GameObject> cardsPlayed;

    private void Awake()
    {
        cardsPlayed = new Dictionary<Carta, GameObject>();
    }

    public IEnumerator InstanciaBaralho()
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject baralho = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, deckArea.transform);
        baralho.GetComponent<CartaController>().Init(null, true);
    }

    public IEnumerator InstanciaCartaPlayer(Carta carta)
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject cartaTela = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerArea.transform);
        cardsPlayed.Add(carta, cartaTela);
        cartaTela.GetComponent<CartaController>().Init(carta, false);
    }

    public IEnumerator InstanciaCartaEnemy(Carta carta)
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject cartaTela = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, enemyArea.transform);
        cardsPlayed.Add(carta, cartaTela);
        cartaTela.GetComponent<CartaController>().Init(carta, false);
    }

    public IEnumerator JogaCarta(Carta card)
    {
        Debug.Log("Jogando - " + (card != null ? card.ToString() : "null"));
        yield return new WaitForSeconds(timeToWait);
        GameObject cardOnHand;
        if (cardsPlayed.TryGetValue(card, out cardOnHand))
        {
            cardsPlayed.Remove(card);
            cardOnHand.transform.SetParent(matchArea.transform);
        }
    }

    public IEnumerator TerminaTurno()
    {
        yield return new WaitForSeconds(timeToWait);
        matchArea.transform.DetachChildren();
        // foreach (Transform child in matchArea.transform)
        // {
        //     GameObject.Destroy(child.gameObject);
        // }
    }
}