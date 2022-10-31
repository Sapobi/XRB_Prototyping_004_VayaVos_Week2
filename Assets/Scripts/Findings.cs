using UnityEngine;
using UnityEngine.UI;

public class Findings : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private GameObject optionsMenu;
	[SerializeField] private ChoiceManager choiceManager;

	public Image image;
	public IngredientType publishedType;

	private void Start()
	{
		button.onClick.AddListener(HandleSelection);
	}

	private void HandleSelection()
	{
		optionsMenu.SetActive(true);
		choiceManager.findingsToEdit = this;
	}
}