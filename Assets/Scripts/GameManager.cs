using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private List<Ingredient> ingredientPrefabs;

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
	}

	private void SetIngredientType()
	{
		for (var i = 0; i < ingredientPrefabs.Count; i++)
		{
			ingredientPrefabs[i].type = _ingredientTypes[i];
		}
	}

}