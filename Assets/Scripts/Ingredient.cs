using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ingredient : MonoBehaviour
{
	[SerializeField] private XRGrabInteractable _xrGrabInteractable;
	[SerializeField] private Rigidbody _rb;
	
	public int prefabNr;
	public IngredientType type;
	
	private void Start()
	{
		_xrGrabInteractable.selectExited.AddListener(ActivatePhysics);
	}
	private void ActivatePhysics(SelectExitEventArgs arg0)
	{
		_rb.isKinematic = false;
	}
}