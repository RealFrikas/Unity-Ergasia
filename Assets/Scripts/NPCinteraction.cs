using StarterAssets;
using UnityEngine;
using TMPro;


public class NPCinteraction : MonoBehaviour, IInteractable
{
    public FirstPersonController playermovement;
    public TextMeshProUGUI textDisplay;
    [Multiline]
    public string speechtext;
    public int chunkSize = 20; // How many words to print at once
    public float timer = 5.0f;

    private string[] words;
    private int index = 0;
    private int totalWords;
    private float temptimer;
    private bool isInteracting = false;

   void Start()
    {
        words = speechtext.Split(' '); // Split the sentence into words
        totalWords = words.Length;
    }

void Update()
    {
        if (isInteracting)
        {
            // Countdown timer
            if (temptimer > 0)
            {
                temptimer -= Time.deltaTime;
            }
            else
            {
                // Print next chunk
                PrintNextChunk();
            }
        }
    }

    public void Interact()
    {
        playermovement.enabled = false; // Disable movement
        isInteracting = true;
        index = 0;
        PrintNextChunk(); // Start displaying text
    }

    void PrintNextChunk()
    {
        if (index < totalWords)
        {
            int wordsToPrint = Mathf.Min(chunkSize, totalWords - index);
            string chunk = string.Join(" ", words, index, wordsToPrint);

            textDisplay.text = chunk; // Show text
            index += wordsToPrint; // Move index forward
            temptimer = timer; // Reset timer
        }
        else
        {
            // End interaction
            isInteracting = false;
            textDisplay.text = "";
            playermovement.enabled = true; // Re-enable movement
        }
    }
}