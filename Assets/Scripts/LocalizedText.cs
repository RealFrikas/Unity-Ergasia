using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    public string key;

    public void SetText()
    {
        TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>();
        LocalizationManager locManager = FindObjectOfType<LocalizationManager>();
        textComponent.text = locManager.GetLocalizedText(key);
    }
}
