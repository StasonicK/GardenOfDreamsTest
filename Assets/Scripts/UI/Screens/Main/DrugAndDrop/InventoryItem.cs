using System.Collections.Generic;
using Data.InventoryItems.Ids;
using UI.Screens.Main.ItemViews;
using UI.Windows;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Screens.Main.DrugAndDrop
{
    public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private EmptyInventoryItemView _emptyInventoryItemView;
        [SerializeField] private AmmoInventoryItemView _ammoInventoryItemView;
        [SerializeField] private HeadgearInventoryItemView _headgearInventoryItemView;
        [SerializeField] private OuterwearInventoryItemView _outerwearInventoryItemView;
        [SerializeField] private MedicineInventoryItemView _medicineInventoryItemView;

        private CanvasGroup _canvasGroup;
        private bool _return;
        private bool _slow;

        public EmptyInventoryItemView EmptyInventoryItemView => _emptyInventoryItemView;
        public AmmoInventoryItemView AmmoInventoryItemView => _ammoInventoryItemView;
        public HeadgearInventoryItemView HeadgearInventoryItemView => _headgearInventoryItemView;
        public OuterwearInventoryItemView OuterwearInventoryItemView => _outerwearInventoryItemView;
        public MedicineInventoryItemView MedicineInventoryItemView => _medicineInventoryItemView;
        public Transform LastParent { private set; get; }
        public InventoryItemId InventoryItemId { private set; get; }

        private void Awake() =>
            _canvasGroup = GetComponent<CanvasGroup>();

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (InventoryItemId == InventoryItemId.Empty)
                return;

            ChangeBlocksRaycasts(false);
            _return = false;
            LastParent = transform.parent;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (InventoryItemId == InventoryItemId.Empty)
                return;

            transform.localPosition += (Vector3)eventData.delta;
            ChangeParent(transform.root);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (InventoryItemId == InventoryItemId.Empty)
                return;

            InventoryItem targetItem =
                GetFirstComponentUnderPointer<InventoryItem>(EventSystem.current, eventData);

            if (targetItem != null)
                TryStack(targetItem);
            else
                Return(true);

            if (_return)
            {
                if (_slow)
                {
                    LeanTween.move(transform.gameObject, LastParent.position, 0.2f)
                        .setOnComplete(() => ChangeParent(LastParent));
                }
                else
                {
                    transform.parent = LastParent;
                    transform.position = LastParent.position;
                }
            }

            ChangeBlocksRaycasts(true);
        }

        private void ChangeBlocksRaycasts(bool active) => _canvasGroup.blocksRaycasts = active;
        private void ChangeParent(Transform t) => transform.SetParent(t);

        private void TryStack(InventoryItem targetItem)
        {
            switch (targetItem.InventoryItemId)
            {
                case InventoryItemId.Empty:
                    _emptyInventoryItemView.TryStack(this, targetItem);
                    break;
                case InventoryItemId.Ammo:
                    _ammoInventoryItemView.TryStack(this, targetItem);
                    break;
                case InventoryItemId.Headgear:
                    _headgearInventoryItemView.TryStack(this, targetItem);
                    break;
                case InventoryItemId.Outerwear:
                    _outerwearInventoryItemView.TryStack(this, targetItem);
                    break;
                case InventoryItemId.Medicine:
                    _medicineInventoryItemView.TryStack(this, targetItem);
                    break;
            }
        }

        private T GetFirstComponentUnderPointer<T>(EventSystem eventSystem, PointerEventData eventData)
            where T : InventoryItem
        {
            var raycastResults = new List<RaycastResult>();
            eventSystem.RaycastAll(eventData, raycastResults);

            foreach (var raycastResult in raycastResults)
            {
                if (raycastResult.gameObject.TryGetComponent<T>(out T component))
                    return component;
            }

            return null;
        }

        public void ShowEmptyInventoryItem()
        {
            InventoryItemId = InventoryItemId.Empty;
            Show(InventoryItemId.Empty);
        }

        public void ShowAmmoInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            Sprite traitIcon, AmmoId ammoId, InventoryItemWindow inventoryItemWindow)
        {
            InventoryItemId = InventoryItemId.Ammo;
            _ammoInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, ammoId, this,
                inventoryItemWindow);
            Show(InventoryItemId.Ammo);
        }

        public void ShowHeadgearInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            float defense, Sprite traitIcon, HeadgearId headgearId, InventoryItemWindow inventoryItemWindow)
        {
            InventoryItemId = InventoryItemId.Headgear;
            _headgearInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, defense, traitIcon,
                headgearId, this, inventoryItemWindow);
            Show(InventoryItemId.Headgear);
        }

        public void ShowOuterwearInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount,
            float weight, float defense, Sprite traitIcon, OuterwearId outerwearId,
            InventoryItemWindow inventoryItemWindow)
        {
            InventoryItemId = InventoryItemId.Outerwear;
            _outerwearInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, defense,
                traitIcon, outerwearId, this, inventoryItemWindow);
            Show(InventoryItemId.Outerwear);
        }

        public void ShowMedicineInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            int heal, Sprite traitIcon, MedicineId medicineId, InventoryItemWindow inventoryItemWindow)
        {
            InventoryItemId = InventoryItemId.Medicine;
            _medicineInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, heal, traitIcon,
                medicineId, this, inventoryItemWindow);
            Show(InventoryItemId.Medicine);
        }

        private void Show(InventoryItemId inventoryItemId)
        {
            switch (inventoryItemId)
            {
                case InventoryItemId.Empty:
                    _emptyInventoryItemView.gameObject.SetActive(true);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Ammo:
                    _ammoInventoryItemView.gameObject.SetActive(true);
                    _emptyInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Headgear:
                    _headgearInventoryItemView.gameObject.SetActive(true);
                    _emptyInventoryItemView.gameObject.SetActive(false);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Outerwear:
                    _outerwearInventoryItemView.gameObject.SetActive(true);
                    _emptyInventoryItemView.gameObject.SetActive(false);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Medicine:
                    _medicineInventoryItemView.gameObject.SetActive(true);
                    _emptyInventoryItemView.gameObject.SetActive(false);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    break;
            }
        }

        public void Return(bool slow)
        {
            _return = true;
            _slow = slow;
        }
    }
}