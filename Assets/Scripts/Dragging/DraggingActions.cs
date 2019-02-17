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
