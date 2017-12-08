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

    private int timeToWait = 3;
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
        yield return new WaitForSeconds(timeToWait);
    }

    public IEnumerator InstanciaCartaPlayer(Carta carta)
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject cartaTela = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerArea.transform);
        cardsPlayed.Add(carta, cartaTela);
        cartaTela.GetComponent<CartaController>().Init(carta, false);
        yield return new WaitForSeconds(timeToWait);
    }

    public IEnumerator InstanciaCartaEnemy(Carta carta)
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject cartaTela = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, enemyArea.transform);
        cardsPlayed.Add(carta, cartaTela);
        cartaTela.GetComponent<CartaController>().Init(carta, false);
        yield return new WaitForSeconds(timeToWait);
    }

    public IEnumerator JogaCarta(Carta card)
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject cardOnHand;
        if (cardsPlayed.TryGetValue(card, out cardOnHand))
        {
            cardOnHand.transform.SetParent(matchArea.transform);
        }
        yield return new WaitForSeconds(timeToWait);
    }

    public IEnumerator TerminaTurno()
    {
        yield return new WaitForSeconds(timeToWait);
        foreach (Transform child in matchArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(timeToWait);
    }
}