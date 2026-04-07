using UnityEngine;
using UnityEngine.Events;

public class dialogue_interaction : MonoBehaviour
{
    public DialogLine dialogLine;
    public string dialogeTextNext;
    public string dialogeTextFinished;

    public dialogue_box dialogBox;
    public UnityEvent onDialogComplete;
    public UnityEvent onQuestComplete;

    public bool talkedTo = false;

    private shooter_player_movement playerMovement;
    private Animator animator;
    private float initialSpeed;
    private float initialJumpForce;

    private GameObject secondPanel;

    private void Awake()
    {
        secondPanel = dialogBox.transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        secondPanel.SetActive(true);

        playerMovement = other.GetComponent<shooter_player_movement>();
        animator = other.GetComponent<Animator>();
        initialSpeed = playerMovement.movementSpeed;
        initialJumpForce = playerMovement.jumpForce;

        if (!talkedTo)
        {
            dialogBox.onMessageComplete += DialogComplete;
            dialogBox.InitiateDialog(dialogLine);
            DisableMovement();
            dialogLine.dialogText = dialogeTextNext;
        }
        else if (talkedTo && dialogLine.dialogText == dialogeTextNext)
        {
            dialogBox.onMessageComplete += QuestComplete;
            dialogBox.InitiateDialog(dialogLine);
            DisableMovement();
            dialogLine.dialogText = dialogeTextFinished;
        }
        else
        {
            dialogBox.InitiateDialog(dialogLine);
            DisableMovement();
        }
    }

    public void DialogComplete()
    {
        EnableMovement();
        onDialogComplete?.Invoke();
        dialogBox.onMessageComplete -= DialogComplete;
        talkedTo = true;
    }

    public void QuestComplete()
    {
        EnableMovement();
        onQuestComplete?.Invoke();
        dialogBox.onMessageComplete -= DialogComplete;
        Debug.Log("this is where the quest should end");
    }

    public void EnableMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.movementSpeed = initialSpeed;
            playerMovement.jumpForce = initialJumpForce;
            animator.enabled = true;
        }
    }
    public void DisableMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.movementSpeed = 0;
            playerMovement.jumpForce = 0;
            animator.enabled = false;
        }
    }

    public void DisableInstructions()
    {
        secondPanel.SetActive(false);
    }
}
