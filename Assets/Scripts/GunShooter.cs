using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class GunShooter : MonoBehaviour
{
    [Header("References")]
    public Transform muzzle;
    public Rigidbody projectilePrefab;

    [Header("Shoot Settings")]
    public float shootForce = 60f;
    public float cooldown = 0.2f;

    [Header("Input System (Quest Trigger)")]
    public InputActionReference rightShootAction; // XRI RightHand Interaction/Activate
    public InputActionReference leftShootAction;  // XRI LeftHand Interaction/Activate

    [Header("Game State")]
    public bool gameStarted = false;

    private float t;
    private XRGrabInteractable grab;
    private bool isHeld = false;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(_ => isHeld = true);
        grab.selectExited.AddListener(_ => isHeld = false);
    }

    private void OnEnable()
    {
        rightShootAction?.action.Enable();
        leftShootAction?.action.Enable();
    }

    private void OnDisable()
    {
        rightShootAction?.action.Disable();
        leftShootAction?.action.Disable();
    }

    private void Update()
    {
        if (!gameStarted) return;
        if (!isHeld) return;

        t -= Time.deltaTime;
        if (t > 0f) return;

        bool pressed =
            (rightShootAction != null && rightShootAction.action.WasPressedThisFrame()) ||
            (leftShootAction != null && leftShootAction.action.WasPressedThisFrame());

        if (pressed)
        {
            Shoot();
            t = cooldown;
        }
    }

    public void Shoot()
    {
        if (!muzzle || !projectilePrefab)
        {
            Debug.LogWarning("Missing muzzle/prefab");
            return;
        }

        var rb = Instantiate(projectilePrefab,
            muzzle.position + muzzle.forward * 0.15f,
            muzzle.rotation);

        rb.useGravity = false;
        rb.isKinematic = false;
        rb.detectCollisions = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        rb.linearVelocity = muzzle.forward * shootForce;

        // Ignore collisions with the gun itself so bullet won't instantly disappear
        var gunColliders = GetComponentsInChildren<Collider>();
        var projCollider = rb.GetComponent<Collider>();
        if (projCollider != null)
        {
            foreach (var c in gunColliders)
                Physics.IgnoreCollision(projCollider, c, true);
        }

        Debug.DrawRay(rb.position, rb.linearVelocity, Color.red, 2f);
        Debug.Log("Trigger pressed (shoot)!");
    }
}