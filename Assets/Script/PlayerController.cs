// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class PlayerController : MonoBehaviour
// {
//     private float time = 30;
//     private float speed = 10f;
//     [SerializeField] AudioClip goldSound;
//     [SerializeField] AudioClip fallSound;
//     [SerializeField] Text timeText;
//     Vector3 movementVector;

//     void Update()
//     {
//         if (GameControl.instance.IsGamePlayable())
//         {
//             time -= Time.deltaTime;
//             timeText.text = "S�re:" + (int)time;

//             movementInput();

//             transform.Translate(CalculateMovementVector(movementVector.x, movementVector.z, speed, Time.deltaTime));
//         }
//         else if (gControl.countGold == 4)
//         {
//             gControl.Victory();
//         }
//         if (gControl.gameFin && Input.GetKeyDown(KeyCode.Space))
//         {
//             enabled = false;
//             SceneManager.LoadScene("Bolum1");
//         }
//         if (time <= 0)
//         {
//             gControl.finalText.text = "Maalesef s�reniz bitti kaybettiniz.Tekrar oynamak i�in space tu�una bas�n";
//             gControl.gameRunning = false;
//             gControl.gameFin = true;
//         }
//     }

//     void movementInput()
//     {
//         movementVector.x = Input.GetAxis("Horizontal");
//         movementVector.z = Input.GetAxis("Vertical");
//     }

//     public Vector3 CalculateMovementVector(float _horizontal, float _vertical, float _moveSpeed, float deltaTime)
//     {
//         float x = _horizontal * _moveSpeed * deltaTime;
//         float y = _vertical * _moveSpeed * deltaTime;

//         return new Vector3(x, 0f, y);
//     }

//     private void OnCollisionEnter(Collision cls)
//     {
//         if (cls.gameObject.tag.Equals("altin"))
//         {
//             GetComponent<AudioSource>().PlayOneShot(goldSound, 1f);
//             gControl.IncreaseGold();
//             Destroy(cls.gameObject);
//         }
//         else if (cls.gameObject.tag.Equals("dusman"))
//         {
//             GetComponent<AudioSource>().PlayOneShot(fallSound, 1f);
//             gControl.Eliminated();
//         }
//     }
// }
