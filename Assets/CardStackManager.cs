using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStackManager : MonoBehaviour {
    public List<GameObject> cardsInTheStack = new List<GameObject>();
    private int lastIndexTotal = 0;
    private void Update() {
        if( cardsInTheStack.Count != lastIndexTotal ) {
            lastIndexTotal = cardsInTheStack.Count;
            foreach( GameObject go in cardsInTheStack ) {
                go.GetComponent<SpriteRenderer>().sortingOrder = cardsInTheStack[cardsInTheStack.Count - 1].GetComponent<SpriteRenderer>().sortingOrder++;
            }
        }
    }
}