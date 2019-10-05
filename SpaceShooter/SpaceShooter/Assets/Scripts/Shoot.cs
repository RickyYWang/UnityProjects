using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    Coroutine Firing;
    [SerializeField] float fireSpeed = 0.1f;
    [SerializeField] float playerOffset = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (Input.GetButtonDown("Fire1")) {
            Firing = StartCoroutine(ContinuousFire());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(Firing);
        }
    }
    IEnumerator ContinuousFire()
    {
        while (true)
        {
            Vector3 playerPosWOffset = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + playerOffset, gameObject.transform.position.z);
            GameObject bullet = Instantiate(laserPrefab, playerPosWOffset, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(fireSpeed);
        }
    }
}
