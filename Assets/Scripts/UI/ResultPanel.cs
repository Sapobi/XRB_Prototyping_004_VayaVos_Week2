using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private GameObject publishPanel;
	[SerializeField] private List<Findings> userInput;
	[SerializeField] private Image resultImage;
	[SerializeField] private Sprite success, failed;

	private void OnEnable()
	{
		publishPanel.SetActive(false);
		CalculateResult();
	}

	private void CalculateResult()
	{
		for (var i = 0; i < userInput.Count; i++)
		{
			Debug.Log("Game: " + gameManager.ingredientPrefabs[i].type + " Publish: " + userInput[i].publishedType);
			if (gameManager.ingredientPrefabs[i].type == userInput[i].publishedType) continue;
			resultImage.sprite = failed;
			return;
		}

		resultImage.sprite = success;
	}
}