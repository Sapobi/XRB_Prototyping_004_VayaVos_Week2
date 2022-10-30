using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public Image imageToEdit, resultingImage;

    public void SwapImage()
    {
        imageToEdit.sprite = resultingImage.sprite;
    }
}
