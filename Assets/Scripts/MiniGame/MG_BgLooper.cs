using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_BgLooper : MonoBehaviour
{
    private float lastBackgroundX = 0f;
    private float lastFakeFloorX = 0f;
    private float lastGroundX = 0f;

    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {

        MG_Obstacle[] obstacles = GameObject.FindObjectsOfType<MG_Obstacle>();
        obstacleLastPosition = Vector3.zero;

        if (obstacles.Length > 0)
        {
            obstacleCount = obstacles.Length;
            for (int i = 0; i < obstacleCount; i++)
            {
                obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
            }
        }


        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("BackGround"))
                lastBackgroundX = Mathf.Max(lastBackgroundX, obj.transform.position.x);
            else if (obj.CompareTag("FakeFloor"))
                lastFakeFloorX = Mathf.Max(lastFakeFloorX, obj.transform.position.x);
            else if (obj.CompareTag("Ground"))
                lastGroundX = Mathf.Max(lastGroundX, obj.transform.position.x);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveBackgroundObject(collision);

        MG_Obstacle obstacle = collision.GetComponent<MG_Obstacle>();
        if (obstacle != null)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void MoveBackgroundObject(Collider2D col)
    {
        BoxCollider2D box = col.GetComponent<BoxCollider2D>();
        if (box == null) return;

        float width = box.size.x * col.transform.lossyScale.x;
        Vector3 pos = col.transform.position;

        // 배경 처리
        if (col.CompareTag("BackGround"))
        {
            lastBackgroundX += width;
            pos.x = lastBackgroundX;
        }
        // 가짜 바닥 처리
        else if (col.CompareTag("FakeFloor"))
        {
            lastFakeFloorX += width;
            pos.x = lastFakeFloorX;
        }
        // 충돌용 바닥 처리
        else if (col.CompareTag("Ground"))
        {
            lastGroundX += width;
            pos.x = lastGroundX;
        }

        Rigidbody2D obsrb = col.GetComponent<Rigidbody2D>();
        if (obsrb != null && obsrb.bodyType == RigidbodyType2D.Kinematic)
        {
            obsrb.MovePosition(pos);
        }
        else
        {
            col.transform.position = pos;
        }
    }
}
