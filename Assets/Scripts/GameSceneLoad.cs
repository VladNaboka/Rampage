using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GameSceneLoad : MonoBehaviour
{
    public GameObject loading;
    public GameObject gameObj;
    public PixelPerfectCamera cameraPixel;
    private static GameSceneLoad _instance;
    public static GameSceneLoad Instance { get { return _instance; } }
    void Awake()
    {
        _instance = this;
        cameraPixel.assetsPPU = (int)((float)cameraPixel.assetsPPU / 1080 * Screen.width);
    }

    public void GameStart()
    {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        gameObj.SetActive(true);
        loading.SetActive(false);
    }
}
