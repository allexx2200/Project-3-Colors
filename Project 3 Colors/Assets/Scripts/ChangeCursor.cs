using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour {
    public Texture2D cashCursor;
    public Texture2D talkCursor;
    public Texture2D enterCursor;

    public Texture2D noGoCursor;
    public Texture2D goCursor;
    
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            //Debug.Log("It hit " + hit.collider.name);
            Interactable interactableComponent = hit.collider.GetComponent<Interactable>();
            if (interactableComponent != null) {
                if (interactableComponent.type == Interactable.InteractableType.COIN) {
                    Cursor.SetCursor(cashCursor, hotSpot, cursorMode);
                } else if (interactableComponent.type == Interactable.InteractableType.DOOR) {
                    Cursor.SetCursor(enterCursor, hotSpot, cursorMode);
                } else if (interactableComponent.type == Interactable.InteractableType.HUMAN) {
                    Cursor.SetCursor(talkCursor, hotSpot, cursorMode);
                }
            } else {
                Cursor.SetCursor(goCursor, hotSpot, cursorMode);
            }
        } else {
            Cursor.SetCursor(noGoCursor, hotSpot, cursorMode);
        }
	}
}
