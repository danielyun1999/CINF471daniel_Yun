using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winText;
    private int enemyCount;

    void Start()
    {
        Time.timeScale = 1f;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (winText != null)
        {
            winText.SetActive(false);
        }
    }

    public void EnemyDefeated()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (winText != null)
        {
            winText.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}
