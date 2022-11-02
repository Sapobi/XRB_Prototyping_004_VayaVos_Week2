using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public Findings findingsToEdit;
    public Image resultingImage;
    public IngredientType resultingIngredientType;
    [SerializeField] private AudioSource imageChangedSound;

    public void SwapImage()
    {
        findingsToEdit.image.sprite = resultingImage.sprite;
        imageChangedSound.Play();
    }
    
    public void SwapIngredientType()
    {
        findingsToEdit.publishedType = resultingIngredientType;
    }
}
