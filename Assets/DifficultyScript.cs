//Create a new Dropdown GameObject by going to the Hierarchy and clicking Create>UI>Dropdown. Attach this script to the Dropdown GameObject.
//Set your own Text in the Inspector window

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DifficultyScript : MonoBehaviour
{
    Dropdown m_Dropdown;


    void Start()
    {


    }

    //Ouput the new value of the Dropdown into Text
    public void DropdownValueChanged(TMPro.TMP_Dropdown change)
    {
        Debug.Log(change.options[change.value].text);
    }
}