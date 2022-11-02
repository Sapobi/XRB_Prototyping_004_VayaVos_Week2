using UnityEngine;
using UnityEngine.EventSystems;

public class UINavigationManager : MonoBehaviour
{
	[SerializeField] private GameObject[] pages;
	
	private GameObject myEventSystem;

	private void Start()
	{
		myEventSystem = GameObject.Find("EventSystem");
		OpenPage(1);
		
	}

	public void OpenPage(int index)
	{
		CloseAllPages();
		pages[index].SetActive(true);
		
		myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
	}

	private void CloseAllPages()
	{
		foreach (var page in pages)
		{
			page.SetActive(false);
		}
	}
}