using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInputManager manager;
    
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    
    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }
    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)       
        {
            Debug.LogWarning("Error");
        }
        instance = this;
        manager = player.GetComponent<PlayerInputManager>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        
        choicesText = new TextMeshProUGUI[choices.Length];
        var index = 0;
        foreach (var choice in choices) 
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update() 
    {
        if (!dialogueIsPlaying) 
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 && manager.GetSubmitPressed())
        {
            ContinueStory();
        }
    }
    
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        
        ContinueStory();
    }
    
    private void ExitDialogueMode() 
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        
        ContinueStory();
    }
    
    private void ContinueStory() 
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        } 
        else
        {
            ExitDialogueMode();
        }
    }
    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too much choices");
        }

        int index = 0;
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        
        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        manager.RegisterSubmitPressed();
        ContinueStory();
    }
}
