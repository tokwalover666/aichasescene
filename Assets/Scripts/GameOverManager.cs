using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public bool gameOver;
    [SerializeField] private GameObject gameOverTmp;
    [SerializeField] private Transform enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, enemy.position);
        if (distance < 1.2f)
        {
            gameOver = true;
        }
        GameOverScreen();
    }

    void GameOverScreen()
    {
        if (gameOver)
        {
            gameOverTmp.SetActive(true);
            StartCoroutine(gameOverDelay());
        }
    }

    IEnumerator gameOverDelay()
    {
        yield return new WaitForSeconds(3f);
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

   
}
