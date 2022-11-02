using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ingredient : MonoBehaviour
{
	[SerializeField] private XRGrabInteractable _xrGrabInteractable;
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private AudioSource grabSound;
	
	public int prefabNr;
	public IngredientType type;

	private bool firstGrab = true;
	
	private void Start()
	{
		_xrGrabInteractable.selectEntered.AddListener(PlaySound);
		_xrGrabInteractable.selectExited.AddListener(ActivatePhysics);
	}

	private void PlaySound(SelectEnterEventArgs arg0)
	{
		if(firstGrab) grabSound.Play();
		firstGrab = false;
	}

	private void ActivatePhysics(SelectExitEventArgs arg0)
	{
		_rb.isKinematic = false;
	}
}