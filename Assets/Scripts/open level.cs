using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
     
    public UIDocument uiDocument;
    //using void so that it preforms the actions automatically when active 
    void OnEnable()
    {
        //root equals to all the ui elements added in the document (easier use for later)
        var root = uiDocument.rootVisualElement;

        //within the ui document whatever is named as start will be considered the startButton 
        Button startButton = root.Q<Button>("start");

        //when the startbutton is clicked it loads the savanna level / += () => used to add some code to run the button click event 
        startButton.clicked += () =>
        {

            SceneManager.LoadScene("Savanna Level");
        };
    }
}
