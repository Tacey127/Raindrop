using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableSlot : MonoBehaviour
{
    [SerializeField]Image image;
    [SerializeField]Button button = null;

    [SerializeField]U_Base UnlockableInfo = null;

    private void OnEnable()
    {
        if(UnlockableInfo != null)
        {
            if(UnlockableInfo.locked)
            {
                button.interactable = false;
                Debug.Log("Locked!");
            }
            else if(UnlockableInfo.chosen)
            {
                //show as selected
                button.interactable = false;

                Debug.Log("Chosen!");
            }
            else
            {
                gameObject.SetActive(true);
                button.interactable = true;

                Debug.Log("Interactable!");
            }
            
        }
        else
        {
            Debug.Log("Unockable base not found!");
        }
    }

    public virtual void OnSelected()
    {
        StartMenu.instance.gameInfo.SetThemeSet(UnlockableInfo);
    }


}
