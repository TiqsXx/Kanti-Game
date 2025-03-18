using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    private Dialogue dialogue;
    private int choiceIndex;

    public void SetChoice(Dialogue dialogueSystem, int dialogueIndex, int choice)
    {
        dialogue = dialogueSystem;
        choiceIndex = choice;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        dialogue.ChooseOption(choiceIndex);
    }
}
