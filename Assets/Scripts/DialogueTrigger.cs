using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInputManager manager;
    
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
        manager = player.GetComponent<PlayerInputManager>();
    }

    private void Update() 
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (manager.GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
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