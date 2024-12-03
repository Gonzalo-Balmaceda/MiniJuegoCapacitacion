using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject backgroundGameOver;
    [SerializeField] private GameObject speedBoostActivePanel;
    [SerializeField] private GameObject speedBoostInactivePanel;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.MuerteJugador += ActivarMenu;
        playerControllerScript.ActivarSpeedBoostPanel += ActivarPanelSpeedBoost;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        backgroundGameOver.SetActive(true);
    }

    private void ActivarPanelSpeedBoost(object sender, EventArgs e)
    {
        if (!playerControllerScript.speedBoostPanel)
        {
            StartCoroutine("ActivarPanelSpeedBoostCorrountine");
        }
    }

    private IEnumerator ActivarPanelSpeedBoostCorrountine()
    {
        playerControllerScript.speedBoostPanel = true;
        speedBoostActivePanel.SetActive(true);

        yield return new WaitForSeconds(1.5F);

        playerControllerScript.speedBoostPanel = false;
        speedBoostActivePanel.SetActive(false);
    }

    public void reinicar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recargamos la escena activa que seria la actual.
    }

    public void salir()
    {
        UnityEditor.EditorApplication.isPlaying = false; // Si estamos en modo juego parará la ejecución.
        Application.Quit();
    }
}
