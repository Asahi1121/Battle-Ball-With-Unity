using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private float restartDelay = 2f;
    private bool isRestarting = false;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.transform.position.y < -7f && !isRestarting)
        {
            StartCoroutine(RestartAfterDelay());
            isRestarting = true;
        }
    }

    private IEnumerator RestartAfterDelay()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(restartDelay);

        Time.timeScale = 1;
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
