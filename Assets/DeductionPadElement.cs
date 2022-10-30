using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeductionPadElement : MonoBehaviour
{
	[SerializeField] private Image sprite;
	[SerializeField] private Button button;

	private GameObject potionOptionsMenu;
	private GameObject myEventSystem;


	private void Start()
	{
		myEventSystem = GameObject.Find("EventSystem");
		potionOptionsMenu = GameObject.Find("PotionOptions");

		button.onClick.AddListener(ToggleSpriteAlpha);
		button.onClick.AddListener(ClosePotionOptions);
	}

	private void ToggleSpriteAlpha()
	{
		var a = (sprite.color.a + 1) % 2;
		var color = new Color(1, 1, 1, a);

		sprite.color = color;
		myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
	}

	private void ClosePotionOptions()
	{
		potionOptionsMenu.SetActive(false);
	}
}