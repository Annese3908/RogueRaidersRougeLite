using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

    //fireball
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    public float speed = 3f;
    public float obstacleRange = 5f;


    private bool isAlive;

    public const float _baseSpeed = 3f;

    private void OnEnable(){
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable(){
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value){
        speed = _baseSpeed * value;
    }

    private void Start(){
        isAlive = true;
    }

    // Update is called once per frame
    void Update() {

        // Move forward
        if(isAlive){
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        // Create a ray in the same direction as the game object's direction of movement
        Ray ray = new Ray(transform.position, transform.forward);

        // Perform a sphere cast
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            //gameobj hit
            GameObject hitObject = hit.transform.gameObject;

            //if objec hit was player, shoot fireball at player
            if(hitObject.GetComponent<PlayerCharacter>()){

                if(fireball == null){
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            } else if (hit.distance < obstacleRange) {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void  SetAlive(bool alive){
        isAlive = alive;
    }
}
