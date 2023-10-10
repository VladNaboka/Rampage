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
        // �������� ������������ ������������� �����
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    private void Update()
    {
        maxTextScore.text = maxScore.ToString();
        // �������� �������� ����� � ���������� ������������� �����
        if (ScoreController.scoreCount > maxScore)
        {
            maxScore = ScoreController.scoreCount;
            // ���������� ������ ������������� �����
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.Save();
        }
    }
}
