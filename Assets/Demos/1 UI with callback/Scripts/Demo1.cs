using UnityEngine;

public class Demo1 : MonoBehaviour
{
    void Start()
    {
        ButtonCreator.CreateButton("Click Me!", CustomButtonAction);
    }

    private void CustomButtonAction()
    {
        Debug.Log("Custom button was clicked!");
    }
}
