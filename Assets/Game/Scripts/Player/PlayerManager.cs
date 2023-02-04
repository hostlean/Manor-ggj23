using System;
using DG.Tweening;
using UnityEngine;

namespace Manor
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private Transform itemHolder;

        public bool isHoldingAnItem;

        private PlayerDetector _playerDetector;

        private InputController _inputController;

        public event Action<bool> OnHoldingAndItem;
        
        
        
        
        
        
        
        private void Awake()
        {
            _inputController = FindObjectOfType<InputController>();
            _playerDetector = GetComponentInChildren<PlayerDetector>();

            _inputController.OnInteractionInput += StartInteract;
            _inputController.OnBackInput += DropItem;

            OnHoldingAndItem += _playerDetector.SetHoldingStatus;
        }
        


        public void StartInteract()
        {
            HoldItem();
        }

        public void OpenInventory()
        {
            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_playerDetector.HasItem)
                {
                    _playerDetector.ThrowItem();
                }
            }
        }

        public void HoldItem()
        {
            if (_playerDetector.HasItem)
            {
                GetItemToTheHand(_playerDetector.CurrentItem);
            }
        }

        public void DropItem()
        {
            if(!isHoldingAnItem) return;
            OnHoldingAndItem?.Invoke(false);
            _holdTween?.Kill();
            _rotateTween?.Kill();
            
            HoldingItem.transform.SetParent(null);
            
            HoldingItem.GetDropped();
            isHoldingAnItem = false;
            OnHoldingAndItem?.Invoke(false);
        }

        private Item HoldingItem { get; set; }

        private Tween _holdTween;
        private Tween _rotateTween;

        private void GetItemToTheHand(Item item)
        {
            if(isHoldingAnItem) return;
            OnHoldingAndItem?.Invoke(true);
            isHoldingAnItem = true;
            HoldingItem = item;
            item.GetPicked();
            item.transform.SetParent(itemHolder);

            _holdTween = item.transform.DOLocalMove(Vector3.zero, .5f);
            _rotateTween = item.transform.DOLocalRotate(new Vector3(0, 180f, 0), .5f);
        }
        
    }
}