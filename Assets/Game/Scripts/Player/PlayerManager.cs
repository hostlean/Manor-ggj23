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
        
        
        
        
        
        
        
        private void Awake()
        {
            _inputController = FindObjectOfType<InputController>();
            _playerDetector = GetComponentInChildren<PlayerDetector>();

            _inputController.OnInteractionInput += StartInteract;
            _inputController.OnBackInput += DropItem;

        }
        


        public void StartInteract()
        {
            HoldItem();
        }

        public void OpenInventory()
        {
            
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
            _holdTween?.Kill();
            _rotateTween?.Kill();
            
            HoldingItem.transform.SetParent(null);
            
            HoldingItem.GetDropped();
            
        }

        private Item HoldingItem { get; set; }

        private Tween _holdTween;
        private Tween _rotateTween;

        private void GetItemToTheHand(Item item)
        {
            isHoldingAnItem = true;
            HoldingItem = item;
            item.GetPicked();
            item.transform.SetParent(itemHolder);

            _holdTween = item.transform.DOLocalMove(Vector3.zero, .5f);
            _rotateTween = item.transform.DORotate(new Vector3(0, 359, 0), .5f);
        }
        
    }
}