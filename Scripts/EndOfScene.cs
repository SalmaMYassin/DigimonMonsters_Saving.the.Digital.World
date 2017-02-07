using UnityEngine;
using System.Collections;

public class EndOfScene : MonoBehaviour {
    public bool key = false;

    void OnTriggerEnter2D(Collider2D other){

		if(other.tag=="Player"){
			if(this.gameObject.tag=="caveDoor"){
				if(FindObjectOfType<playerStats>().Evidence>=5){
					Application.LoadLevel("AfterCave");
                    PlayerPrefs.GetInt("eveloved", 1);

			}
			else{
					Application.LoadLevel("Cave");
                    PlayerPrefs.GetInt("eveloved", 1);
                }


		}
		if(Application.loadedLevelName == "Forest"){

				Application.LoadLevel("AfterForest");
                PlayerPrefs.GetInt("eveloved", 1);
            }

		if(Application.loadedLevelName == "new dun")
            {

				Application.LoadLevel("BeforeThrone");
                PlayerPrefs.GetInt("eveloved", 1);
            }
		if(Application.loadedLevelName=="Castel"){
				if(PlayerPrefs.GetInt("Score") >= 200 && PlayerPrefs.GetInt("collectible") >= 4)
                {
					Application.LoadLevel("BeforeDungeon");
                    PlayerPrefs.GetInt("eveloved", 1);
                }
                else { 
					Application.LoadLevel("BeforeThrone");
                    PlayerPrefs.GetInt("eveloved", 1);
                }

		}
		if(Application.loadedLevelName=="ThroneRoom"){
                if (key == true)
                    Destroy(this.gameObject);
                Wait(2);
               
		}
		}


	}

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Application.LoadLevel("EndGame");
        PlayerPrefs.GetInt("eveloved", 1);
    }
    }
