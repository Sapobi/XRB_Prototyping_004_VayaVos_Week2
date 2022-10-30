using UnityEngine;
using UnityEngine.UI;

public class PotionChoiceManager : MonoBehaviour
{
    public Image chosenFindings, chosenPotion;

    public void SwapPotionFindings()
    {
        chosenFindings.sprite = chosenPotion.sprite;
    }
}
