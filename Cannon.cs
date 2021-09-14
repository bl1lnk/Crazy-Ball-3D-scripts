using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField] private Transform cannonTip;
    [SerializeField] private float shootingCoolDown = 3f;
    [SerializeField] private float laserPower = 100f;


    private bool isPlayingInRange = false;
    private GameObject player;
    private float timeLeftToShoot = 0;
    private LineRenderer cannonLaser;


    // Start is called before the first frame update
    void Start()
    {
        cannonLaser = GetComponent<LineRenderer>();
        cannonLaser.sharedMaterial.color = Color.green;
        cannonLaser.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        timeLeftToShoot = shootingCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayingInRange)
        {
            cannonHead.transform.LookAt(player.transform);

            cannonLaser.SetPosition(0, cannonTip.transform.position);
            cannonLaser.SetPosition(1, player.transform.position);
            timeLeftToShoot -= Time.deltaTime;
        }

        if (timeLeftToShoot <= shootingCoolDown * 0.5)
        {
            cannonLaser.sharedMaterial.color = Color.red;
        }

        if(timeLeftToShoot <= 0)
        {
            Vector3 directionToPushBack = player.transform.position - cannonTip.transform.position;
            player.GetComponent<Rigidbody>().AddForce(directionToPushBack * laserPower, ForceMode.Impulse);
            timeLeftToShoot = shootingCoolDown;
            cannonLaser.sharedMaterial.color = Color.green;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayingInRange = true;
            cannonLaser.enabled = true;
        }

      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayingInRange = false;
            cannonLaser.enabled = false;

            timeLeftToShoot = shootingCoolDown;

            cannonLaser.sharedMaterial.color = Color.green;
        }
    }
}
