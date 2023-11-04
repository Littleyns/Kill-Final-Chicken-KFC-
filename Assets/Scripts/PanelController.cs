//Create a new Dropdown GameObject by going to the Hierarchy and clicking Create>UI>Dropdown. Attach this script to the Dropdown GameObject.
//Set your own Text in the Inspector window

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PanelController : MonoBehaviour
{
    Dropdown m_Dropdown;
    Button m_button;
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("Map").GetComponent<GameManager>();

    }

    //Ouput the new value of the Dropdown into Text
    public void DropdownValueChanged(TMPro.TMP_Dropdown change)
    {
        Debug.Log(change.value);
        gameManager.Difficulty = change.value;
    }

    public void OnStartClick(Button b)
    {
        gameManager.StartGame();

    }
}