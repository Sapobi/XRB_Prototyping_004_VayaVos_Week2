using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private IngredientType ingredientType;
    [SerializeField] private Button button;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private ChoiceManager choiceManager;
    
    private void Start()
    {
        button.onClick.AddListener(HandleSelection);
    }

    private void HandleSelection()
    {
        optionsMenu.SetActive(false);
        choiceManager.resultingImage = sprite;
        choiceManager.SwapImage();

        choiceManager.resultingIngredientType = ingredientType;
        choiceManager.SwapIngredientType();
    }
}
