using UnityEngine;
using UnityEngine.UI;

public class Findings : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private Button button;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private ChoiceManager choiceManager;
    
    private void Start()
    {
        button.onClick.AddListener(HandleSelection);
    }

    private void HandleSelection()
    {
        optionsMenu.SetActive(true);
        choiceManager.imageToEdit = sprite;
    }
}