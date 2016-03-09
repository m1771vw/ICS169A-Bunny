using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource source;
    //public GameObject player, child, female, male;

    public void PlaySound(int soundIndex)
    {
        source.PlayOneShot(sounds[soundIndex]);
    }

	// Use this for initialization
	void Start () {
        source = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
    //GameObject.Find("Main Camera").GetComponent<SoundManager>().PlaySound(0);
     
	}
}
