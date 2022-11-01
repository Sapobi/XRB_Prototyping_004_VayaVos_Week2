using UnityEngine;

public class PropertyOptions : MonoBehaviour
{
	[SerializeField] private GameObject publishPanel, resultPanel;
	private void OnEnable()
	{
		publishPanel.SetActive(false);
		resultPanel.SetActive(false);
	}

	private void OnDisable()
	{
		publishPanel.SetActive(true);
	}
}