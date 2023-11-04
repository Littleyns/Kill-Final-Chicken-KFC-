using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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
    public static bool isInInteractionZone;
    public bool isOpenPossible = false;

    private void Start()
    {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        buyDoorText.SetActive(false);
        doorRb = door.GetComponent<Rigidbody>();
        doorRb.isKinematic = true;
        price = 200;// + Random.Range(0, 50);
        buyDoorTextMesh.SetText(string.Format("Appuyez sur O pour ouvrir [Prix: {0}]", price));
        isInInteractionZone = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.transform.parent.gameObject.name != "BossDoor")
            {
                isOpenPossible = (pm.coins >= 200) ? true : false;
            }
            else
            {
                isOpenPossible = (pm.completedRoom >= ((pm.gameManager.Difficulty + 3) * (pm.gameManager.Difficulty + 3))) ? true : false;

            }

            if(isOpenPossible)
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
                            pm.completedRoom += 1;
                            Destroy(this.transform.parent.parent.Find("DoorCollider").gameObject);

                            //Augmente de sang de 10%
                            if(pm.health < 90)
                            {
                                pm.health += ((pm.health * 10) / 100);
                            }

                        }
                    }
                }
                // Si dans la zone d'interraction changer destination aux ennemies
                isInInteractionZone = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buyDoorText.SetActive(false);
        isInInteractionZone = false;
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
