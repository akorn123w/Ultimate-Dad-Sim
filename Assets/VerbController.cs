using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerbController : MonoBehaviour {
    public GameObject cardStackParent;
    public GameObject canv;
    public RectMask2D barRectMask;
    public GameObject cardPrefab;
    private bool isLoaded = false, loading = false;
    private float max = 24f;
    private float min = 0f;
    public float loadDuration;

    private void FixedUpdate() {
        canv.SetActive(loading);
        if( loading == true ) {
            if( isLoaded != true && barRectMask.padding.z > min ) {
                float difference = max - min;
                difference = (difference - min) / (max - min) * 100f;
                if( barRectMask.padding.z >= loadDuration * Time.deltaTime ) {
                    Vector4 tempOffset = barRectMask.padding;
                    tempOffset = new Vector4(barRectMask.padding.x, barRectMask.padding.y, barRectMask.padding.z - loadDuration * Time.deltaTime, barRectMask.padding.w);
                    barRectMask.padding = tempOffset;
                } else {
                    Vector4 tempOffset = barRectMask.padding;
                    tempOffset = new Vector4(barRectMask.padding.x, barRectMask.padding.y, min, barRectMask.padding.w);
                    barRectMask.padding = tempOffset;
                }
            } else {
                isLoaded = true;
            }
        } else {
            Reset();
        }
        if( isLoaded == true ) {
            loading = false;
            GameObject go = Instantiate(cardPrefab, cardStackParent.transform);
            cardStackParent.GetComponent<CardStackManager>().cardsInTheStack.Add(go);
            Reset();
            StartLoad();
        }
    }

    public void Reset() {
        loading = false;
        isLoaded = false;
        Vector4 tempOffset = barRectMask.padding;
        tempOffset = new Vector4(barRectMask.padding.x, barRectMask.padding.y, max, barRectMask.padding.w);
        barRectMask.padding = tempOffset;
    }

    public void StartLoad() {
        loading = true;
    }
}
