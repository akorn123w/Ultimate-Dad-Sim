using UnityEngine;

public class Draggable : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 startPosition;
    private GameObject colorChanged;

    private void Start() {
        startPosition = this.gameObject.transform.position;
    }

    private void OnMouseDown() {
        startPosition = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if( colorChanged ) {
            colorChanged.GetComponent<VerbController>().Reset();
        }
    }

    private void OnMouseDrag() {
        if( colorChanged ) {
            colorChanged.GetComponent<VerbController>().Reset();
        }
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        this.transform.position = currentPosition;
    }

    private void OnMouseUp() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        for( int i = 0; i < hits.Length; i++ ) {
            if( hits[i].collider.tag == "Verb" ) {
                colorChanged = hits[i].collider.gameObject;
                this.gameObject.transform.position = hits[i].collider.transform.position;
                hits[i].collider.GetComponent<VerbController>().StartLoad();
                break;
            }
        }
    }
}
