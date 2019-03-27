using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DraggingActions : MonoBehaviour
{
    private Vector3 savedPos;

    public void OnStartDrag() {
        savedPos = transform.position;
    }

    public void OnEndDrag() {
        //transform.DOMove(savedPos, 1f); 
        //transform.DOMove(savedPos, 1f).SetEase(Ease.OutBounce, 0.5f, 0.1f);
        transform.DOMove(savedPos, 1f).SetEase(Ease.OutQuint);//, 0.5f, 0.1f);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 10000f);

        foreach (RaycastHit objectHit in hits) {

            if(objectHit.collider.gameObject.GetComponent<CardArea>() != null) {
                Debug.Log("++++++here+++++++++++");
            } else {
                //return card to previous position
                // Set old sorting order 
                //whereIsCard.SetHandSortingOrder();
                //whereIsCard.VisualState = tempState;
                // Move this card back to its slot position
                //HandVisual PlayerHand = playerOwner.PArea.handVisual;
                //Vector3 oldCardPos = PlayerHand.slots.Children[savedHandSlot].transform.localPosition;
                //transform.DOLocalMove(oldCardPos, 1f);
            }

        }
    }

    public void OnDraggingInUpdate() {

    }

    public virtual bool CanDrag
    {
        get
        {
            return Settings.Instance.CanPlayerDrag(playerOwner, gameObject.GetComponentInParent(typeof(CardArea)) as CardArea);
        }
    }

    protected virtual Player playerOwner
    {
        get
        {
            Player player = gameObject.GetComponentInParent(typeof(Player)) as Player;

            if (player) {
                return player;
            } else {
                return null;
            }
        }
    }

    protected bool DragSuccessful() {
        return true;
    }
}
