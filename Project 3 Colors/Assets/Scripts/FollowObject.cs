using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {
    public Transform objectToFollow;
    public Vector3 DistanceToKeep;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = objectToFollow.position + DistanceToKeep;
	}
}
