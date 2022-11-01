using UnityEngine;

public class IngredientSpawnPoint : MonoBehaviour
{
	[SerializeField] private float respawnTime = 2f;
	[SerializeField] private GameManager gameManager;
	[SerializeField] private GameObject plantedIngredient;

	// Start is called before the first frame update
	void Start()
	{
		PlantNextIngredient();
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != plantedIngredient) return;
		
		plantedIngredient = null;
		Invoke(nameof(PlantNextIngredient),respawnTime);
	}

	private void PlantNextIngredient()
	{
		var nextIngredient = gameManager.GetNextIngredient();
		if (nextIngredient == null) return;
		
		plantedIngredient = Instantiate(nextIngredient, transform.position, transform.rotation);
	}
}