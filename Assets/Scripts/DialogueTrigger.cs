using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInputManager _inputManager;
    
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private DialogueManager _dialogManager;

    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
        _inputManager = player.GetComponent<PlayerInputManager>();
        _dialogManager = DialogueManager.GetInstance();
    }

    private void Update() 
    {
        if (playerInRange && !_dialogManager.dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (_inputManager.GetInteractPressed())
            {
                _dialogManager.EnterDialogueMode(inkJSON);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.CompareTag("Player")) 
        {
            playerInRange = true;
        }   
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.gameObject.CompareTag("Player")) 
        {
            playerInRange = false;
        }
    }
}