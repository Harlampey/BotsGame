using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private ParticleSystem upgradePatricleEffect;
    [SerializeField] private Animator cameraAnimator;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    [Space]
    [SerializeField] private Image[] hearts;
    [SerializeField] private Color activeHeartColor, disableHeartColor;
    [SerializeField] private GameObject destroyedFloater, character;
    [SerializeField] private Rigidbody[] ragdollParts;
    [SerializeField] private float explodeForce;
    public int Heal = 3;

    private Animator animator;
    void Start() {
        if (!joystick) joystick = FindObjectOfType<DynamicJoystick>();
        if (!cameraAnimator) cameraAnimator = Camera.main.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        foreach (Rigidbody part in ragdollParts) {
            part.isKinematic = true;
        }
        animator = GetComponent<Animator>();
    }
    void Update() {
        if (controller.isGrounded) {
            moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            moveDirection = transform.TransformDirection(moveDirection) * speed;
        }

        moveDirection.y -= Time.deltaTime * 10f;
        controller.Move(moveDirection * Time.deltaTime);
    }
    public void ShowItemPickEffect() {
        upgradePatricleEffect.Play();
    }
    public void GetDamage() {
        cameraAnimator.Play("CameraHit");
        animator.Play("PlayerHit");
        Heal--;
        if (Heal <= 0) { 
            PushRagdoll();
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            
            Instantiate(destroyedFloater, pos, Quaternion.identity);
            Destroy(gameObject);
            Level.Lose();
        }
        hearts[Heal].color = disableHeartColor;
    }
    private void PushRagdoll() {
        character.transform.parent = null;
        foreach (Rigidbody part in ragdollParts) {
            part.isKinematic = false;
            part.AddForce(-part.transform.forward * explodeForce);
        }
    }

}

