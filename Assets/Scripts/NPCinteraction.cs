using StarterAssets;
using UnityEngine;
using TMPro;


public class NPCinteraction : MonoBehaviour, IInteractable
{
    public FirstPersonController playermovement;
    public LogicScript logic;
    public TextMeshProUGUI textDisplay;
    [Multiline]
    public string speechtext;
    [Multiline]
    public string endgamespeechtext;
    public int chunkSize = 20; // How many words to print at once
    public float timer = 5.0f;

    private string[] words;
    private string[] endwords;
    private int index = 0;
    private int totalWords;
    private int totalendWords;
    private float temptimer;
    private bool isInteracting = false;

   void Start()
    {
        words = speechtext.Split(' '); // Split the sentence into words
        totalWords = words.Length;
        endwords = endgamespeechtext.Split(' '); // Split the sentence into words
        totalendWords = endwords.Length;
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

    private int wordsToPrint;
    private string chunk;
    void PrintNextChunk()
    {
        if (index < totalWords)
        {
            if(logic.endgame)
            {
                wordsToPrint = Mathf.Min(chunkSize, totalendWords - index);
                chunk = string.Join(" ", endwords, index, wordsToPrint);
            }
            else
            {
                wordsToPrint = Mathf.Min(chunkSize, totalWords - index);
                chunk = string.Join(" ", words, index, wordsToPrint);
            }

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