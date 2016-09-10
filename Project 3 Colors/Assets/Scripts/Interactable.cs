using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
    public AudioClip hit;
    
    public enum InteractableType {
        HUMAN,
        DOOR,
        COIN
    }
    public InteractableType type;

    public string LevelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision collision) {
        if (collision.collider.name.CompareTo("Player") == 0) {
            if (type == InteractableType.COIN) {
                collision.collider.GetComponent<AudioSource>().PlayOneShot(hit, 1f);
                Debug.Log("Collected");
                Destroy(gameObject);
            } else {
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);
            }
        }
    }
}
