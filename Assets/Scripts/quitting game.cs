using UnityEngine;
using UnityEngine.UIElements;

public class quittinggame : MonoBehaviour
{
    public UIDocument uiDocument;
    //automatic action when activated
    private void OnEnable()
    {
        //having root signify whatever ui elements used when recalled 
        var root = uiDocument.rootVisualElement;
        // quitButton is a button, in which represents the ui element under the name quit 
        Button quitButton = root.Q<Button>("quit");
        //when quit button is clicked small code runs for the button event, in which closes the application, as well as sending a debug mentioning it has quit
        quitButton.clicked += () =>
        {
            Debug.Log("You Quit the Game");

            Application.Quit();
        };

    }
   

}
