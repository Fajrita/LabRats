using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RatopedyButtonsManager : MonoBehaviour
{

    public Button right;
    public Button left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BackButton(int scene)
    {
        ScenesManager.Instance.ChangeScene(scene);
    }

    public void ChangeRat (InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            var value = (int)Mathf.Round(context.ReadValue<float>());
            if (value > 0)
            {
                right.GetComponent<Image>().color = right.colors.pressedColor;
                right.onClick.Invoke();
            }
            if (value < 0)
            {
                left.GetComponent<Image>().color = left.colors.pressedColor;
                left.onClick.Invoke();
            }
        }
        if (context.canceled)
        {
            right.GetComponent<Image>().color = Color.white;
            left.GetComponent<Image>().color = Color.white;
        }


    }
}
