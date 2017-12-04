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
}