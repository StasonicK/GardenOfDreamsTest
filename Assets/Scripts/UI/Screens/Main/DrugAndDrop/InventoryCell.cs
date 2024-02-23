using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Screens.Main.DrugAndDrop
{
    public class InventoryCell : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            // if (eventData.pointerDrag)
            // {
            //     Transform pointerDragTransform = eventData.pointerDrag.transform;
            //     InventoryItem inventoryItem = pointerDragTransform.GetComponent<InventoryItem>();
            //
            //     if (transform.childCount == 0)
            //     {
            //         pointerDragTransform.SetParent(transform);
            //         pointerDragTransform.localPosition = Vector3.zero;
            //     }
            //     else
            //     {
            //         // CardSwap(inventoryItem);
            //     }
            //
            //     inventoryItem.Dropped();
            // }
        }

        private void CardSwap(InventoryItem inventoryItem)
        {
            inventoryItem.transform.SetParent(transform.GetChild(0).parent);
            LeanTween.move(transform.GetChild(0).gameObject, inventoryItem.LastParent.position, 0.2f).setOnComplete(
                () => transform.GetChild(0).SetParent(inventoryItem.LastParent)
            );
            inventoryItem.transform.localPosition = Vector3.zero;
        }
    }
}