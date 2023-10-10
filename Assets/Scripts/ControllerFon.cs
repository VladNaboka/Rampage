using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerFon : MonoBehaviour
{
    public Image fonGame;

    private void OnEnable()
    {
        fonGame.sprite = ChooseBackGround.mainChoose;
    }
}
