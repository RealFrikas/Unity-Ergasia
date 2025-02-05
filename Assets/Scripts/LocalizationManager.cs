using UnityEngine;
using TMPro;
using System.Xml;
using System.Collections.Generic;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, string> localizedText;
    private string currentLanguage;


    public void LoadLanguage(string languageFileName)
    {
        localizedText = new Dictionary<string, string>();
        TextAsset xmlFile = Resources.Load<TextAsset>($"Localization/{languageFileName}");
        
        if (xmlFile != null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlFile.text);
            
            XmlNodeList entries = xmlDoc.GetElementsByTagName("Entry");
            foreach (XmlNode entry in entries)
            {
                string key = entry.Attributes["key"].Value;
                string value = entry.InnerText;
                localizedText.Add(key, value);
            }

            currentLanguage = languageFileName;

            //remember language
            PlayerPrefs.SetString("Language", currentLanguage);
            PlayerPrefs.Save();

            // After loading the language, update the UI elements
            UpdateUI();
        }
        else
        {
            Debug.LogError($"Language file '{languageFileName}' not found!");
        }


    }

    // Update all TextMeshProUGUI components
    public void UpdateUI()
    {
        // Find all TextMeshProUGUI components in the scene, including inactive ones
        TextMeshProUGUI[] allTextComponents = Object.FindObjectsOfType<TextMeshProUGUI>(true);
        foreach (TextMeshProUGUI textComponent in allTextComponents)
        {
            // Try to get the LocalizedText script attached to the same object
            LocalizedText localizedTextScript = textComponent.GetComponent<LocalizedText>();
            
            if (localizedTextScript != null)
            {
                // Call SetText() on the LocalizedText script
                localizedTextScript.SetText();
            }
        }
    }

    public string GetLocalizedText(string key)
    {
        if (localizedText.TryGetValue(key, out string value))
        {
            return value;
        }
        else
        {
            Debug.LogWarning($"Key '{key}' not found in language '{currentLanguage}'");
            return key; // Fallback to key if not found
        }
    }

    // Load language from PlayerPrefs on startup
    void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            string savedLanguage = PlayerPrefs.GetString("Language");
            LoadLanguage(savedLanguage);
        }
        else
        {
            LoadLanguage("English"); // Default language
        }
    }
}