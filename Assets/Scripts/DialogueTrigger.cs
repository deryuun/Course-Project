using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
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