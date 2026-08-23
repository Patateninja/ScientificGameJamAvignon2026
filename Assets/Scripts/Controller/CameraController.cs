using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float camSpeed;

    [SerializeField]
    private UITileMenu ui;

    [SerializeField]
    private InputActionAsset actionAsset;

    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction zoomAction;

    bool hoveringUI;

    private void Awake()
    {
        if (actionAsset == null)
        {
            Debug.LogWarning("NO INPUT ACTION ASSET IN CAMERA");
            return;
        }
        if (ui == null)
        {
            Debug.LogWarning("NO UI IN CAMERA");
            return;
        }

        moveAction = actionAsset.FindAction("Controls/Move");
        interactAction = actionAsset.FindAction("Controls/Interact");
        zoomAction = actionAsset.FindAction("Controls/Zoom");

        interactAction.performed += Interact;
    }

    private void OnDestroy()
    {
        interactAction.performed -= Interact;
    }

    void Start()
    {
        if (ui)
        {
            ui.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        MoveCam();
        Zoom();
        hoveringUI = EventSystem.current.IsPointerOverGameObject();
    }

    private void MoveCam()
    {
        Vector2 movements = moveAction.ReadValue<Vector2>();
        Vector3 vec = new Vector3(movements.x, movements.y, 0f);

        transform.position += transform.rotation * vec * camSpeed * Time.deltaTime;
    }

    private void Zoom()
    {
        float zoom = zoomAction.ReadValue<Vector2>().y;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize -+ zoom, 1f, 10f);
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        if (hoveringUI)
        {
            return;
        }

        if (Physics.Raycast(cam.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Tile tile))
            {
                Debug.Log("Tile Clicked");
                ui.gameObject.SetActive(true);
                ui.transform.position = hit.transform.position - cam.transform.forward * 4f ;
                ui.SetTile(tile);
                ui.SetMode();
            }
        }
        else
        {
            Debug.Log("Test_NotHit");
            ui.gameObject.SetActive(false);
            ui.SetTile(null);
        }
    }
}
