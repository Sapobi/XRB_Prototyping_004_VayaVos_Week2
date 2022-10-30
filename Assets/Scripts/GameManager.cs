using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	[SerializeField] private List<Ingredient> ingredientPrefabs;
	[SerializeField] private InputActionReference helpActionReference, knowledgeActionReference;
	[SerializeField] private GameObject helpMenu, knowledgeMenu;

	private readonly List<IngredientType> _ingredientTypes = new()
	{
		IngredientType.AllPlus, IngredientType.AllMinus, IngredientType.GreenMinusBlue, IngredientType.GreenPlusBlue,
		IngredientType.BluePlusRed, IngredientType.BlueMinusRed, IngredientType.RedPlusGreen, IngredientType.RedMinusGreen
	};
	//private List<GameObject> ingredientsDeck, ingredientsDiscard;

	private void Awake()
	{
		_ingredientTypes.Shuffle();
		SetIngredientType();

		helpActionReference.action.performed += arg => ToggleHelpMenu();
		knowledgeActionReference.action.performed += arg => ToggleKnowledgeMenu();
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