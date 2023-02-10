using System.Collections;
using UnityEngine;

public class CardStackPositionRecalculator : MonoBehaviour {
    [SerializeField] private float spacing;  // The spacing between the cards in the stack
    private int previousChildCount = 0;  // The number of children of the transform in the previous frame

    private void Update() {
        // Recalculate the positions only if there's a change in the number of children
        if( previousChildCount != transform.childCount ) {
            StartCoroutine(RecalculatePositions());
        }
    }

    private IEnumerator RecalculatePositions() {
        // Return early if there are no children in the transform
        if( transform.childCount <= 0 ) {
            yield break;
        }

        // Calculate the new positions for each card in the stack
        for( int i = 0; i < transform.childCount; i++ ) {
            float offset = i * spacing;
            transform.GetChild(i).localPosition = new Vector3(i * 0.2f, 0f, i * -spacing);
            yield return null;
        }

        previousChildCount = transform.childCount;
    }
}
