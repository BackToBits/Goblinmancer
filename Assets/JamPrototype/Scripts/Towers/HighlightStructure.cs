using UnityEngine;

public class HighlightStructure : MonoBehaviour
{
    [SerializeField] private string outlineLayerName = "Outline";
    private int _originalLayer;
    private int _outlineLayer;
    private bool _isHiglighted;

    void Awake()
    {
        _originalLayer = gameObject.layer;
        _outlineLayer = LayerMask.NameToLayer(outlineLayerName);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        {
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.transform == transform ||
                hit.collider.transform.IsChildOf(transform) ||
                transform.IsChildOf(hit.collider.transform))
                {
                    if (!_isHiglighted)
                    {
                        _isHiglighted = true;
                        gameObject.layer = _outlineLayer;
                        foreach (Transform child in transform)
                        {
                            child.gameObject.layer = _outlineLayer;
                        }
 
                    }
                    return;
                    
                }
            }
            if (_isHiglighted)
            {
                
                _isHiglighted = false;
                gameObject.layer = _originalLayer;
                foreach (Transform child in transform)
                {
                    child.gameObject.layer = _originalLayer;
                }
            }
        }
    }
}
