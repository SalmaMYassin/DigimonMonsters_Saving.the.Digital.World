using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	int character;
    public int time = 3;

    void Start()
    {
        StartCoroutine("sceneToChangeTo", time);
    }

    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
        
        
    }

    public void Quit()
    {
        Application.Quit();
    }

	
	
	public void selectCharacter(int ch) {
		int h = 100;
		int l = 5;
		int z = 0;
        int e = 1;
        PlayerPrefs.SetInt("Health",h);
		PlayerPrefs.SetInt("Lives",l);
		PlayerPrefs.SetInt("Evidence",z) ;
		PlayerPrefs.SetInt("collectible",z) ;
		PlayerPrefs.SetInt("Thunder",z) ;
		PlayerPrefs.SetInt("exp",z);
        PlayerPrefs.SetInt("Score", z);
        PlayerPrefs.SetInt("evolved", e);

        Application.LoadLevel("Loading");
        PlayerPrefs.SetInt("Character",ch);
	}

    IEnumerator sceneToChangeTo(float time)
    {
        yield return new WaitForSeconds(time);

        if (PlayerPrefs.GetInt("scene") == 1)
        {
            ChangeToScene("Forest");
        }

        if (PlayerPrefs.GetInt("scene") == 2)
        {
            ChangeToScene("Cave");


        }
        if (PlayerPrefs.GetInt("scene") == 3)
        {
            ChangeToScene("Castel");
        }

        if (PlayerPrefs.GetInt("scene") == 4)
        {
            ChangeToScene("new dun");


        }

        if (PlayerPrefs.GetInt("scene") == 5)
        {
            ChangeToScene("ThroneRoom");

        }
    }
 }
