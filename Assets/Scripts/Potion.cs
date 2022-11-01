using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Potion : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable _xrGrabInteractable;
    [SerializeField] private Rigidbody _rb;
    
    private bool floating = true;
    private Vector3 _axis = new (0,1,0.2f);
    private float _speed = 20;

    private void Start()
    {
        _xrGrabInteractable.selectExited.AddListener(ActivatePhysics);
    }

    private void Update()
    {
        if (!floating) return;

        Spin();
    }

    private void Spin()
    {
        transform.Rotate(_axis, _speed*Time.deltaTime);
    }

    private void ActivatePhysics(SelectExitEventArgs arg0)
    {
        _rb.isKinematic = false;
        floating = false;
    }
}
