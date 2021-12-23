using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int starsCollect;
    public int totalStart = 3;
    public int bottleCapsDestroied;
    public int totalBottleCaps;

    public Animator fader;
    public GameObject tutorialPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public GameObject woods;
    public GameObject boom_effect;
    public GameObject levelLoader;

    int levelNo;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if(starsCollect == totalStart)
        {
            starsCollect = 0;
            StartCoroutine(FadeOut());
            StartCoroutine(WinPanelOn());
        }
        
        //if(bottleCapsDestroied == totalBottleCaps && starsCollect > 3)
        //{
        //    StartCoroutine(FadeOut());
        //    StartCoroutine(GameOverPanelOn());
        //}
    }


    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        levelNo = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().name == "1")
        {
            StartCoroutine(TutorialPanelOn());
        }

        if (SceneManager.GetActiveScene().name == "11")
        {
            StartCoroutine(TutorialPanelOn());
        }

        levelLoader = Instantiate(Resources.Load("LeveLoader") as GameObject);
        
    }


    //------------------------- Buttons only -------------------------//

    public void VertFirstStartButton()
    {
        int level = PlayerPrefs.GetInt("LevelCount", 2);
        Level_Loader.instance.LoadLevelWithIndex(level);
        //SceneManager.LoadScene(level);
    }

    public void TutorialPanelOffButton()
    {
        tutorialPanel.SetActive(false);
    }

    public void Retry()
    {
       
        levelNo = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(levelNo);
        Level_Loader.instance.LoadLevelWithIndex(levelNo);
        AdmobAdmanager.Instance.ShowInterstitial();
    }

    public void NextLevel()
    {
        levelNo++;
        PlayerPrefs.SetInt("LevelCount", levelNo);
        Level_Loader.instance.LoadLevelWithIndex(levelNo);

        if (levelNo % 5 == 0 && Application.isMobilePlatform)
        {
            AdmobAdmanager.Instance.ShowInterstitial();
        }
        //SceneManager.LoadScene(levelNo);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    //------------------------- Buttons only -------------------------//

    //public void Privacypolicy()
    //{
    //    Application.OpenURL("https://hypercausualgamesfree.s3.ap-south-1.amazonaws.com/hypercausualgames/Satisfying.txt");
    //}

    //------------------------- Wait Here -------------------------//

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        fader.SetBool("FadeAway", true);
    }

    IEnumerator TutorialPanelOn()
    {
        yield return new WaitForSeconds(1f);
        tutorialPanel.SetActive(true);
    }

    IEnumerator GameOverPanelOn()
    {
        yield return new WaitForSeconds(2.6f);
        gameOverPanel.SetActive(true);

    }

    IEnumerator WinPanelOn()
    {
        woods = GameObject.Find("Woods");
        boom_effect = GameObject.Find("Canvas/boom_effect");   
        yield return new WaitForSeconds(3.6f);
        winPanel.SetActive(true);
        if (woods)   {    woods.SetActive(false);  }       
        if (boom_effect)   {   boom_effect.SetActive(false);    }
        AdmobAdmanager.Instance.ShowInterstitial();
    }
    //------------------------- Wait Here -------------------------//
}
