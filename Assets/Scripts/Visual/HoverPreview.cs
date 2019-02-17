using System.Collections;
using UnityEngine;
using DG.Tweening;

public class HoverPreview : MonoBehaviour {

    public float TargetScale;
    public Canvas Canvas;
    public const string ABOVE_ALL_LAYER = "AboveAll";

    private string OriginalLayer;

    // Use this for initialization
    void Start () {
        Canvas.overrideSorting = true;
        OriginalLayer = Canvas.sortingLayerName;	
	}

    private void OnMouseEnter() {
        Canvas.sortingLayerName = ABOVE_ALL_LAYER;
        gameObject.transform.DOScale(TargetScale, 1f).SetEase(Ease.OutQuint);
    }

    private void OnMouseExit() {
        Canvas.sortingLayerName = OriginalLayer;
        gameObject.transform.DOScale(1, 1f).SetEase(Ease.OutQuint);
    }

    private void PreviewThisCard() {
 
    }
}
