using UnityEngine;
using TMPro;
public class DoorInteraction : MonoBehaviour
{
    public HingeJoint doorHinge; // Référence au Hinge Joint de la porte
    public float targetAngle = 90f; // Angle de rotation cible
    public Rigidbody doorRb;
    public GameObject door;
    private bool doorOpen = false;
    public GameObject buyDoorText;
    public TextMeshProUGUI buyDoorTextMesh;
    public PlayerManager pm;
    private int price;

    private void Start()
    {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        buyDoorText.SetActive(false);
        doorRb = door.GetComponent<Rigidbody>();
        doorRb.isKinematic = true;
        price = 200 + Random.Range(0, 50);
        buyDoorTextMesh.SetText(string.Format("Appuyez sur O pour ouvrir [Prix: {0}]", price));
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pm.coins >= price)
            {
                buyDoorTextMesh.color = new Color(0.0f, 1.0f, 0.0f);
            }
            else
            {
                buyDoorTextMesh.color = new Color(1.0f, 0.0f, 0.0f);
            }
            if (doorOpen == false)
            {
                buyDoorText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.O)) // Vous pouvez utiliser une étiquette spécifique pour les objets qui peuvent interagir
                {
                    if (pm.pay(price))
                    {
                        OpenDoor();
                    }

                    


                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buyDoorText.SetActive(false);
    }

    private void OpenDoor()
    {
        doorRb.isKinematic = false;
        doorHinge.useMotor = true;
        JointMotor motor = doorHinge.motor;
        motor.targetVelocity = 100f; // Vitesse de rotation
        motor.force = 100f; // Force appliquée pour la rotation
        doorHinge.motor = motor;

        doorOpen = true;
        
    }

    private void CloseDoor()
    {
        JointMotor motor = doorHinge.motor;
        motor.targetVelocity = -100f; // Vitesse de rotation dans le sens inverse
        motor.force = 100f;
        doorHinge.motor = motor;

        doorOpen = false;
    }
}
