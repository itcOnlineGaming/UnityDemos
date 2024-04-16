Demo 1

This shows how a custom button is created entirely programmatically and shows how a callback can be done in Unity:

The key lines:

(i) UnityAction used to pass the callback
```
void CreateButton(string buttonText, UnityEngine.Events.UnityAction onClickAction)
```
(ii) The callback
```
private void CustomButtonAction()
```
(iii) Passing the callback.
```
ButtonCreator.CreateButton("Click Me!", CustomButtonAction);
```