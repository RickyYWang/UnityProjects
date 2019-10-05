using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<GameObject> WayPointList;
    int wayPointIndex = 1;
    float moveSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = WayPointList[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (wayPointIndex <= WayPointList.Count - 1)
        {
            Debug.Log(wayPointIndex);
            var targetPosition = WayPointList[wayPointIndex].transform.position;
            var moveSpeedThisFrame = moveSpeed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, moveSpeed);
            if (gameObject.transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
