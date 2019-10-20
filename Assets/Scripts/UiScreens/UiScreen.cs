using UnityEngine;

public abstract class UiScreen : MonoBehaviour
{
    public virtual void Show(UiScreen caller = null)
    {
        gameObject.SetActive(true);
        if(caller != null)
        {
            caller.Hide();
        }
    }

    protected virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
