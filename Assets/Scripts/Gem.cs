using UnityEngine;
using UnityEngine.EventSystems;

public class Gem : MonoBehaviour, IPointerClickHandler
{
    private ObjectMover _mover;
    private ObjectScaler _scaler;
    public GemType type;
    public Grid grid;

    private void Awake()
    {
        _mover = GetComponent<ObjectMover>();
        _mover.doMove = false;
        _scaler = GetComponent<ObjectScaler>();
        _scaler.doScale = false;
    }

    public void Move(Vector2 endPos)
    {
        _mover.endPos = endPos;
        _mover.doMove = true;
    }

    public void Scale(Vector3 endScale)
    {
        _scaler.endScale = endScale;
        _scaler.doScale = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        grid.OnClick(this);
    }
}