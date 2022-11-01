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

	public List<int> ingredientsDeck = new()
	{
		0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7
	};

	public List<int> ingredientsDiscard = new();

	private void Awake()
	{
		ingredientsDeck.Shuffle();
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

	public GameObject GetNextIngredient()
	{
		switch (ingredientsDeck.Count)
		{
			case 0 when ingredientsDiscard.Count == 0:
				return null; // all ingredients in play
			case 0:
				RestockIngredients();
				break;
		}
		var nextPrefabNr = ingredientsDeck[0];
		ingredientsDeck.RemoveAt(0);
		
		return ingredientPrefabs[nextPrefabNr].gameObject;
	}
	private void RestockIngredients()
	{
		ingredientsDeck = ingredientsDiscard;
		ingredientsDiscard = new List<int>();
		ingredientsDeck.Shuffle();
	}
}