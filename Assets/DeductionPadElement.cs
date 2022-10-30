using UnityEngine;
using UnityEngine.UI;

public class DeductionPadElement : MonoBehaviour
{
	[SerializeField] private Image sprite;
	[SerializeField] private Button button;

	private GameObject myEventSystem;


	private void Start()
	{
		myEventSystem = GameObject.Find("EventSystem");
		button.onClick.AddListener(ToggleSpriteAlpha);
	}

	private void ToggleSpriteAlpha()
	{
		var a = (sprite.color.a + 1) % 2;
		var color = new Color(1, 1, 1, a);

		sprite.color = color;
		myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
	}
}