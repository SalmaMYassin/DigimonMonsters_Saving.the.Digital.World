using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    public int time = 3;
    public int scene = 0;
    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);


    }

    void Start()
    {
        StartCoroutine("Load", time);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Load(0);
        }
    }
    IEnumerator Load(float time)
    {
        yield return new WaitForSeconds(time);

        

        if (Application.loadedLevelName == "GameStart1")
        {
            ChangeToScene("GameStart2");


        }
        if (Application.loadedLevelName == "GameStart2")
        {
            ChangeToScene("GameStart3");


        }
        if (Application.loadedLevelName == "GameStart3")
        {
            ChangeToScene("GameStart4");


        }
        if (Application.loadedLevelName == "GameStart4")
        {
            ChangeToScene("GameStart5");


        }
        if (Application.loadedLevelName == "GameStart5")
        {
            ChangeToScene("GameStart6");


        }
        if (Application.loadedLevelName == "GameStart6")
        {
            ChangeToScene("GameStart7");


        }
        if (Application.loadedLevelName == "GameStart7")
        {
            ChangeToScene("GameStart8");


        }
        if (Application.loadedLevelName == "GameStart8")
        {
            ChangeToScene("GameStart9");


        }
        if (Application.loadedLevelName == "GameStart9")
        {
            ChangeToScene("GameStart10");


        }
        if (Application.loadedLevelName == "GameStart10")
        {
            ChangeToScene("GameStart11");


        }
        if (Application.loadedLevelName == "GameStart11")
        {
            ChangeToScene("GameStart12");


        }
        if (Application.loadedLevelName == "GameStart12")
        {
            ChangeToScene("GameStart13");


        }
        if (Application.loadedLevelName == "GameStart13")
        {
            PlayerPrefs.SetInt("scene", 1);
            ChangeToScene("charcterSelection");


        }
        if (Application.loadedLevelName == "AfterForest")
        {
            ChangeToScene("AfterForest2");


        }
        if (Application.loadedLevelName == "AfterForest2")
        {
            ChangeToScene("AfterForest3");


        }
        if (Application.loadedLevelName == "AfterForest2")
        {
            PlayerPrefs.SetInt("scene", 2);

            ChangeToScene("Loading");


        }
        if (Application.loadedLevelName == "AfterCave")
        {
            PlayerPrefs.SetInt("scene", 3);
            ChangeToScene("Loading");


        }
        if (Application.loadedLevelName == "BeforeDungeon")
        {
            PlayerPrefs.SetInt("scene", 4);
            ChangeToScene("Loading");


        }
        if (Application.loadedLevelName == "BeforeThrone")
        {
            PlayerPrefs.SetInt("scene", 5);
            ChangeToScene("Loading");


        }
        if (Application.loadedLevelName == "EndGame")
        {
            ChangeToScene("EndGame1");


        }
        if (Application.loadedLevelName == "EndGame1")
        {
            ChangeToScene("EndGame2");


        }
        if (Application.loadedLevelName == "EndGame2")
        {
            ChangeToScene("YouWon");


        }

    }

}
