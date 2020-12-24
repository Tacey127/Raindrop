using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSingleSelect : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    public void OnButtonSelected(Button _button)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (buttons[i] != _button);
        }
    }


}
