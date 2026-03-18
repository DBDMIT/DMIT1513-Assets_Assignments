using UnityEngine;
using UnityEngine.Events;

public class dialogue_interaction : MonoBehaviour
{
    public DialogLine dialogLine;
    public dialogue_box dialogBox;
    public UnityEvent onDialogComplete;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == false) return;
        dialogBox.onMessageComplete += DialogComplete;
        dialogBox.InitiateDialog(dialogLine);
    }

    public void DialogComplete()
    {
        onDialogComplete?.Invoke();
    }
}
