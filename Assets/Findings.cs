using UnityEngine;
using UnityEngine.UI;

public class Findings : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private Button button;
    [SerializeField] private GameObject potionOptionsMenu;
    [SerializeField] private PotionChoiceManager potionChoiceManager;
    
    private void Start()
    {
        button.onClick.AddListener(HandleSelection);
    }

    private void HandleSelection()
    {
        potionOptionsMenu.SetActive(true);
        potionChoiceManager.chosenFindings = sprite;
    }
}
