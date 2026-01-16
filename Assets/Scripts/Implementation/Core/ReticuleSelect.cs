using Core;
using UnityEngine;

namespace Implementation.Core
{
    public class ReticuleSelect : MonoBehaviour
    {
        private IInteractable _current;
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, 2f)) return; // ignore if hit fails

            Debug.Log($"Raycast hit: {hit.transform}");
            Debug.Log($"Raycast hit: {hit.transform.name}");
            
            if (!hit.transform.TryGetComponent(out IInteractable interactable))
            {
                ClearSelection();
                return;
            }

            if (_current == interactable) return;
            
            ClearSelection();
            _current = interactable;
            _current.OnReticuleEnter();
        }

        private void ClearSelection()
        {
            _current?.OnReticuleExit();
            _current = null;
        }
    }
}