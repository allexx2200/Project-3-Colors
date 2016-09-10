/*
 * @author: allexx2200
 * @date: 10/09/2016
 * @description: 
 */

using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent))]
public class ControllerScript : MonoBehaviour {
    //where we want to travel
    public Vector3 targetPosition;      
    
    const int LEFT_MUSE_BUTTON = 0;

    //object nav mesh agent
    NavMeshAgent agent;

    void Awake () {
        agent = GetComponent<NavMeshAgent>();
    }

	void Start () {
        // initialize target position with initial position
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(LEFT_MUSE_BUTTON)) {
            SetTargetPosition();
        }

        MovePlayer();

        
        if (isInRangeOfTarget(targetPosition)) {
            RotateTowards(targetPosition);
        }
	}

    void SetTargetPosition () {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);
    }

    void MovePlayer () {
        agent.SetDestination(targetPosition);

        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

    private bool isInRangeOfTarget (Vector3 target) {
        float distance = Vector3.Distance(transform.position, target);
        return distance < agent.stoppingDistance;
    }

    private void RotateTowards (Vector3 target) {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10.0f);
    }
}
