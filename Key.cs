using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Door doorToUnlock;
    [SerializeField] private float keyRorationSpeed;
    private GameObject player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * keyRorationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToUnlock.UnlockDoor();
            gameObject.SetActive(false);
        }
    }


    private void OnDrawGizmos()
    {
        if(doorToUnlock != null)
        {
            //set the gizmos color to green
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, doorToUnlock.transform.position - transform.position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.5f);


        }
    }

}
