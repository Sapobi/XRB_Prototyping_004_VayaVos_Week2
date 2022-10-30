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
		_healingPotionMixes.Add((IngredientType.AllPlus, IngredientType.GreenMinus));
		_healingPotionMixes.Add((IngredientType.AllPlus, IngredientType.BluePlus));
		_healingPotionMixes.Add((IngredientType.GreenMinus, IngredientType.RedPlus));
		_healingPotionMixes.Add((IngredientType.BluePlus, IngredientType.RedPlus));
		
		_speedPotionMixes.Add((IngredientType.AllPlus, IngredientType.BlueMinus));
		_speedPotionMixes.Add((IngredientType.AllPlus, IngredientType.RedPlus));
		_speedPotionMixes.Add((IngredientType.GreenPlus, IngredientType.BlueMinus));
		_speedPotionMixes.Add((IngredientType.GreenPlus, IngredientType.RedPlus));

		_wisdomPotionMixes.Add((IngredientType.AllPlus, IngredientType.GreenPlus));
		_wisdomPotionMixes.Add((IngredientType.AllPlus, IngredientType.RedMinus));
		_wisdomPotionMixes.Add((IngredientType.GreenPlus, IngredientType.BluePlus));
		_wisdomPotionMixes.Add((IngredientType.BluePlus, IngredientType.RedMinus));

		_poisonPotionMixes.Add((IngredientType.AllMinus, IngredientType.GreenPlus));
		_poisonPotionMixes.Add((IngredientType.AllMinus, IngredientType.BlueMinus));
		_poisonPotionMixes.Add((IngredientType.GreenPlus, IngredientType.RedMinus));
		_poisonPotionMixes.Add((IngredientType.BlueMinus, IngredientType.RedMinus));

		_paralysisPotionMixes.Add((IngredientType.AllMinus, IngredientType.BluePlus));
		_paralysisPotionMixes.Add((IngredientType.AllMinus, IngredientType.RedMinus));
		_paralysisPotionMixes.Add((IngredientType.GreenMinus, IngredientType.BluePlus));
		_paralysisPotionMixes.Add((IngredientType.GreenMinus, IngredientType.RedMinus));

		_insanityPotionMixes.Add((IngredientType.AllMinus, IngredientType.GreenMinus));
		_insanityPotionMixes.Add((IngredientType.AllMinus, IngredientType.RedPlus));
		_insanityPotionMixes.Add((IngredientType.GreenMinus, IngredientType.BlueMinus));
		_insanityPotionMixes.Add((IngredientType.BlueMinus, IngredientType.RedPlus));
	}
}