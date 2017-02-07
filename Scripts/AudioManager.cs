using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioSource BG;
	public AudioSource sound;
	public float highPitch=0.95f;
	public float lowPitch=1.05f;
	public static AudioManager instance = null;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Awake() {
		
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
		
		
	}
	public void playSingle(AudioClip c) {
		
		sound.clip = c;
		sound.Play();
	}
	public void Randomize (params AudioClip[] c) {
		int RandomIndex = Random.Range(0, c.Length);
		int RandomPitch = Random.Range((int)lowPitch, (int)highPitch);
		sound.clip = c[RandomIndex];
		sound.pitch = RandomPitch;
		sound.Play();
		
	}
}
