using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	[SerializeField] public List<Ingredient> ingredientPrefabs;
	[SerializeField] private InputActionReference helpActionReference, knowledgeActionReference;
	[SerializeField] private GameObject helpMenu, knowledgeMenu, potionOptions;

	private readonly List<IngredientType> _ingredientTypes = new()
	{
		IngredientType.AllPlus, IngredientType.AllMinus, IngredientType.GreenMinus, IngredientType.GreenPlus,
		IngredientType.BluePlus, IngredientType.BlueMinus, IngredientType.RedPlus, IngredientType.RedMinus
	};
	//private List<GameObject> ingredientsDeck, ingredientsDiscard;

	private void Awake()
	{
		_ingredientTypes.Shuffle();
		SetIngredientType();

		helpActionReference.action.performed += arg => ToggleHelpMenu();
		knowledgeActionReference.action.performed += arg => ToggleKnowledgeMenu();
	}

	private void Start()
	{
		potionOptions.SetActive(false);
		knowledgeMenu.SetActive(false);
	}

	private void SetIngredientType()
	{
		for (var i = 0; i < ingredientPrefabs.Count; i++)
		{
			ingredientPrefabs[i].type = _ingredientTypes[i];
		}
	}

	private void ToggleHelpMenu()
	{
		helpMenu.SetActive(!helpMenu.activeSelf);
	}

	private void ToggleKnowledgeMenu()
	{
		knowledgeMenu.SetActive(!knowledgeMenu.activeSelf);
	}
}