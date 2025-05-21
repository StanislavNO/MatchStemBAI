using System;
using Source.CodeBase.GameplayData;
using Source.CodeBase.GameplayData.ActionBar;
using Source.CodeBase.GameplayData.Items;
using Source.CodeBase.Infrastructure.Services.InputService;
using Source.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Logic.Controllers
{
    public class PlayerInputController : IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly ActionBarData _actionBarData;
        private readonly ViewActionBar _viewActionBar;
        private readonly UIParticleMover _uiParticleMover;
        private readonly Camera _camera;

        public bool IsEnable { get; set; }

        public PlayerInputController(
            IInputService inputService, 
            ActionBarData actionBarData, 
            ViewActionBar viewActionBar, 
            UIParticleMover uiParticleMover)
        {
            _inputService = inputService;
            _actionBarData = actionBarData;
            _viewActionBar = viewActionBar;
            _uiParticleMover = uiParticleMover;
            _camera = Camera.main;
        }

        public void Initialize()
        {
            _inputService.OnClicked += OnPlayerClicked;
        }

        public void Dispose()
        {
            _inputService.OnClicked -= OnPlayerClicked;
        }

        private void OnPlayerClicked(Vector3 position)
        {
            if (TryGetItemHit(position, out Item item) == false)
                return;

            if(_actionBarData.CanItemAdd == false)
                return;
            
            _actionBarData.Add(item);
            item.gameObject.SetActive(false);
            _uiParticleMover.Show(item.Position, _viewActionBar.PoolPosition, UpdateBar);
        }

        private void UpdateBar()
        {
            _actionBarData.CheckMatch();
            _viewActionBar.Show(_actionBarData.Items);
        }

        private bool TryGetItemHit(Vector3 position, out Item item)
        {
            item = null;
            Vector2 mousePos = _camera.ScreenToWorldPoint(position);
            var hit = Physics2D.Raycast(mousePos, Vector2.zero,0f);

            if (hit.collider == null)
                return false;
            
            if (hit.collider.TryGetComponent(out item))
                return item.gameObject.activeSelf;
            
            return false;
        }
    }
}