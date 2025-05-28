using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class clickingbutton : MonoBehaviour
{
    //refering UIdocument as _document 
    private UIDocument _document;
    //same thing for button
    private Button _button;

    //calling this script when game is being loaded 
    private void Awake()
    {
        //_document is allowed to retrieve the object assigned to UIdocument
        _document = GetComponent<UIDocument>();
        //_button assigns whatever visual the document sees as starts and assigns it as a button
        _button = _document.rootVisualElement.Q("start") as Button;
        //when the start button is clicked it plays an event (refers to the debug)
        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);


    }
    //when start button is clicked, a message pops up signaling the event has occured 
    private void OnPlayGameClick(ClickEvent evt)

    {
        Debug.Log("You pressed the Start Button");
    }
}
