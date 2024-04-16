using UnityEngine;
using UnityEngine.UI; // Required for UI components
using UnityEngine.EventSystems; 

public static class ButtonCreator
{
    // Static method to create a button with specific text and an event listener
    public static void CreateButton(string buttonText, UnityEngine.Events.UnityAction onClickAction)
    {
        // Ensure there's a Canvas in the scene
        Canvas canvas = getCanvas();
        
        // Ensure there's an EventSystem in the scene
        addEventSystem();

        // Create a new GameObject for the button
        GameObject buttonObj = new GameObject("DynamicButton");

        // Add the Image component
        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = Color.yellow; // Set button color

        // Add and setup the Button component
        Button button = buttonObj.AddComponent<Button>();
        button.transform.SetParent(canvas.transform, false); // Set parent to Canvas
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0); // Set position
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 50); // Set size

        // Add the specified listener to the button's click event
        button.onClick.AddListener(onClickAction);

        // Add text to the button
        AddTextToButton(buttonObj, buttonText);
    }

    // Private helper method to add text to the button
    private static void AddTextToButton(GameObject buttonObj, string text)
    {
        GameObject textObj = new GameObject("ButtonText");
        Text buttonText = textObj.AddComponent<Text>();
        buttonText.transform.SetParent(buttonObj.transform, false);
        buttonText.text = text;
        buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.color = Color.black;
        buttonText.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        buttonText.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 50);
    }

    private static Canvas getCanvas()
    {
        Canvas canvas = Object.FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }
        return canvas;
    }

    private static void addEventSystem()
    {
        if (Object.FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }
}
