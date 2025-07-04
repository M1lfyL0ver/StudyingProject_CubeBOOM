using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
    [SerializeField] private InputActionReference _clickAction;

    public event Action<Cube> CubeHitDetected;

    private void Awake()
    {
        _clickAction.action.performed += OnClick;
        _clickAction.action.Enable();
    }

    private void OnDestroy()
    {
        _clickAction.action.performed -= OnClick;
        _clickAction.action.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit) && (hit.collider.TryGetComponent<Cube>(out Cube hitCube)))
        {
            CubeHitDetected.Invoke(hitCube);
        }
    }
}
