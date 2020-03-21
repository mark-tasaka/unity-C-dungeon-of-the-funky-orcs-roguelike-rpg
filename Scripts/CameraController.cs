/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public float moveSpeed;

    public Transform target;

    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

     //   target = PlayerController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        }

    }


    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }


}
