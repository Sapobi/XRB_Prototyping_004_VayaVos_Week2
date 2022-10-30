using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionChoice : MonoBehaviour
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
        potionOptionsMenu.SetActive(false);
        potionChoiceManager.chosenPotion = sprite;
        potionChoiceManager.SwapPotionFindings();
    }
}
