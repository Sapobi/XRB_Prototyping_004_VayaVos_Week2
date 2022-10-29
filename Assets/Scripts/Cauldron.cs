using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
	[SerializeField] private GameObject[] mixedPotionPrefabs;
	[SerializeField] private Transform mixedPotionSpawnTransform;

	private readonly List<(IngredientType, IngredientType)> _healingPotionMixes = new();
	private readonly List<(IngredientType, IngredientType)> _speedPotionMixes = new();
	private readonly List<(IngredientType, IngredientType)> _wisdomPotionMixes = new();
	private readonly List<(IngredientType, IngredientType)> _poisonPotionMixes = new();
	private readonly List<(IngredientType, IngredientType)> _paralysisPotionMixes = new();
	private readonly List<(IngredientType, IngredientType)> _insanityPotionMixes = new();

	[SerializeField] private List<GameObject> _insertedIngredients;
	[SerializeField] private PotionType _createdPotionType;

	private void Start()
	{
		SetPotionMixes();
		_insertedIngredients = new List<GameObject>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.GetComponent<Ingredient>()) return;
		ActivateCauldron();
		HandleInsertedIngredient(other.gameObject);
	}

	private void ActivateCauldron()
	{
		//start brewing animation
	}

	private void HandleInsertedIngredient(GameObject inserted)
	{
		_insertedIngredients.Add(inserted);
		//maybe hover them in hologram mode to show what's in the cauldron

		if (_insertedIngredients.Count == 2) CreatePotion();
	}

	private void CreatePotion()
	{
		var ingredientsList = new List<IngredientType> { _insertedIngredients[0].GetComponent<Ingredient>().type, _insertedIngredients[1].GetComponent<Ingredient>().type };
		ingredientsList.Sort();
		var ingredients = (ingredientsList[0], ingredientsList[1]);
		
		_createdPotionType = CalculatePotion(ingredients);

		Instantiate(mixedPotionPrefabs[(int)_createdPotionType], mixedPotionSpawnTransform.position, mixedPotionSpawnTransform.rotation);

		_insertedIngredients = new List<GameObject>();
	}

	private PotionType CalculatePotion((IngredientType, IngredientType) ingredients)
	{
		if (_healingPotionMixes.Contains(ingredients)) return PotionType.Healing;
		if (_speedPotionMixes.Contains(ingredients)) return PotionType.Speed;
		if (_wisdomPotionMixes.Contains(ingredients)) return PotionType.Wisdom;
		if (_poisonPotionMixes.Contains(ingredients)) return PotionType.Poison;
		if (_paralysisPotionMixes.Contains(ingredients)) return PotionType.Paralysis;
		if (_insanityPotionMixes.Contains(ingredients)) return PotionType.Insanity;
		return PotionType.Neutral;
	}

	private void SetPotionMixes()
	{
		_healingPotionMixes.Add((IngredientType.AllPlus, IngredientType.GreenMinusBlue));
		_healingPotionMixes.Add((IngredientType.AllPlus, IngredientType.BluePlusRed));
		_healingPotionMixes.Add((IngredientType.GreenMinusBlue, IngredientType.RedPlusGreen));
		_healingPotionMixes.Add((IngredientType.BluePlusRed, IngredientType.RedPlusGreen));
		
		_speedPotionMixes.Add((IngredientType.AllPlus, IngredientType.BlueMinusRed));
		_speedPotionMixes.Add((IngredientType.AllPlus, IngredientType.RedPlusGreen));
		_speedPotionMixes.Add((IngredientType.GreenPlusBlue, IngredientType.BlueMinusRed));
		_speedPotionMixes.Add((IngredientType.GreenPlusBlue, IngredientType.RedPlusGreen));

		_wisdomPotionMixes.Add((IngredientType.AllPlus, IngredientType.GreenPlusBlue));
		_wisdomPotionMixes.Add((IngredientType.AllPlus, IngredientType.RedMinusGreen));
		_wisdomPotionMixes.Add((IngredientType.GreenPlusBlue, IngredientType.BluePlusRed));
		_wisdomPotionMixes.Add((IngredientType.BluePlusRed, IngredientType.RedMinusGreen));

		_poisonPotionMixes.Add((IngredientType.AllMinus, IngredientType.GreenPlusBlue));
		_poisonPotionMixes.Add((IngredientType.AllMinus, IngredientType.BlueMinusRed));
		_poisonPotionMixes.Add((IngredientType.GreenPlusBlue, IngredientType.RedMinusGreen));
		_poisonPotionMixes.Add((IngredientType.BlueMinusRed, IngredientType.RedMinusGreen));

		_paralysisPotionMixes.Add((IngredientType.AllMinus, IngredientType.BluePlusRed));
		_paralysisPotionMixes.Add((IngredientType.AllMinus, IngredientType.RedMinusGreen));
		_paralysisPotionMixes.Add((IngredientType.GreenMinusBlue, IngredientType.BluePlusRed));
		_paralysisPotionMixes.Add((IngredientType.GreenMinusBlue, IngredientType.RedMinusGreen));

		_insanityPotionMixes.Add((IngredientType.AllMinus, IngredientType.GreenMinusBlue));
		_insanityPotionMixes.Add((IngredientType.AllMinus, IngredientType.RedPlusGreen));
		_insanityPotionMixes.Add((IngredientType.GreenMinusBlue, IngredientType.BlueMinusRed));
		_insanityPotionMixes.Add((IngredientType.BlueMinusRed, IngredientType.RedPlusGreen));
	}
}