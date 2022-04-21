using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameManager : MonoBehaviour
{
    private static int score;

    private TMPro.TextMeshProUGUI scoreValue;

    public static void setScore(int value)
    {
        score = value;
    }

    private void Awake()
    {
        scoreValue = gameObject.transform.Find("Score/ScoreValue").GetComponent<TMPro.TextMeshProUGUI>();
        scoreValue.text = score.ToString();
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
