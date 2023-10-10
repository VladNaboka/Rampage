using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBackGround : MonoBehaviour
{
    public Sprite chooseBackRed;
    public Sprite chooseBackViolet;
    public Sprite chooseBackTurquoise;

    public static Sprite mainChoose;

    private void Start()
    {
        mainChoose = chooseBackViolet;
    }
    public void Violet()
    {
        mainChoose = chooseBackViolet;
    }
    public void Red()
    {
        mainChoose = chooseBackRed;
    }
    public void Turquoise()
    {
        mainChoose = chooseBackTurquoise;
    }

}
