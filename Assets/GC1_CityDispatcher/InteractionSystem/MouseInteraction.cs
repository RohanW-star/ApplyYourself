using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _selectedPoi;
    [SerializeField] private GameObject _selectedOptionsPanel;


    [SerializeField] private GameObject _summaryPanelPrefab;
    [SerializeField] private GameObject _summaryPanelContainer;

    private InputHandler _inputHandler => InputHandler.Instance;
    private EventSystem _eventSystem => EventSystem.current;

    private Vector2 _mousePosition;
    private void mousePosition(Vector2 vector) => _mousePosition = vector;


    private void Start()
    {
        _inputHandler.OnLeftMouseCanceled += AttemptPoiInteraction;
        _inputHandler.OnMousePositionPerformed += mousePosition;
    }

    private void AttemptPoiInteraction()
    {

        if (OverUIBLocker.IsPointerOverUI)
        {
            Debug.Log("Currently over UI");
            return;
        }

        if (_selectedPoi != null)
        {
            Debug.Log("Deselect POI?");
            return;
        }

        Debug.Log("Mouse button clicked");

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log("Hit object: " + objectHit.name);

            _selectedPoi = hit.transform.gameObject;
            CreateTemporaryOptionsPanel();
        }
    }

    private void CreateTemporaryOptionsPanel()
    {
        _selectedOptionsPanel = Instantiate(_summaryPanelPrefab);
        _selectedOptionsPanel.transform.SetParent(_summaryPanelContainer.transform);
        _selectedOptionsPanel.transform.position = _summaryPanelContainer.transform.position;
    }
}
