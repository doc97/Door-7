using UnityEngine;

public abstract class RoomController : MonoBehaviour
{
    private bool _isActive;
    public bool IsActive {
        get { return _isActive; }
    }

    public void Activate()
    {
        _isActive = true;
        OnActivate();
    }

    public void Deactivate()
    {
        _isActive = false;
        OnDeactivate();
    }

    void Update()
    {
        if (!IsActive)
            return;
        OnUpdate();
    }

    protected abstract void OnActivate();
    protected abstract void OnDeactivate();
    protected abstract void OnUpdate();
}