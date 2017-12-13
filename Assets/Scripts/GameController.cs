using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public BaralhoController baralhoController;
    public BoardController boardController;
    public UIController uIController;
    public Button reiniciarButton;

    void Awake()
    {
        reiniciarButton.gameObject.SetActive(false);
        boardController.JogoTerminou += OnJogoTerminou;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnJogoTerminou()
    {
        reiniciarButton.gameObject.SetActive(true);
    }

    void Destroy()
    {
        boardController.JogoTerminou -= OnJogoTerminou;
    }
}