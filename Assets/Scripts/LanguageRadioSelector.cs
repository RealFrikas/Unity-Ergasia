using UnityEngine;
using UnityEngine.UI;

public class SetToggleByLanguage : MonoBehaviour
{
    public ToggleGroup toggleGroup; // Reference to the ToggleGroup

    private void Start()
    {
        string savedLanguage = PlayerPrefs.GetString("Language");

        // Iterate through all toggles in the group
        foreach (var toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            // Match toggle name with saved language
            if (toggle.name == savedLanguage)
            {
                toggle.isOn = true; // Set the matching toggle as active
                break;
            }
        }
    }
}

