using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public Findings findingsToEdit;
    public Image resultingImage;
    public IngredientType resultingIngredientType;

    public void SwapImage()
    {
        findingsToEdit.image.sprite = resultingImage.sprite;
    }
    
    public void SwapIngredientType()
    {
        findingsToEdit.publishedType = resultingIngredientType;
    }
}
