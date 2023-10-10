using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int scoreCount;
    [SerializeField] private Text textScoreCount;
    private void Update()
    {
        textScoreCount.text = scoreCount.ToString();
    }

}
