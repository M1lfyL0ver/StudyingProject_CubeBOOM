using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _clickAction;

    private void Awake()
    {
        _clickAction.action.performed += OnClick;
        _clickAction.action.Enable();
    }

    private void OnDisable()
    {
        _clickAction.action.performed -= OnClick;
        _clickAction.action.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit) && (hit.collider.TryGetComponent<Multiplier>(out var multiplier)))
        {
            multiplier.HandleMultiply();
        }
    }
}