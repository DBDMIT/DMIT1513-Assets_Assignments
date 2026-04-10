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

    private controller_playermovement playerMovement;
    private float initialSpeed;
    private float initialJumpForce;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        playerMovement = other.GetComponent<controller_playermovement>();
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
        }
    }
    public void DisableMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.movementSpeed = 0;
            playerMovement.jumpForce = 0;
        }
    }
}
