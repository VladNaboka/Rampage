using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScores : MonoBehaviour
{
    public Text maxTextScore;
    public static int maxScore;
    void Start()
    {
        // «агрузка сохраненного максимального числа
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    private void Update()
    {
        maxTextScore.text = maxScore.ToString();
        // ѕроверка текущего счета и обновление максимального числа
        if (ScoreController.scoreCount > maxScore)
        {
            maxScore = ScoreController.scoreCount;
            // —охранение нового максимального числа
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.Save();
        }
    }
}
