using UnityEngine;

public class MG_Obstacle : MonoBehaviour
{
    GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    public float minPosY = -1f;
    public float maxPosY = -5f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float randomPadding = Random.Range(18f, 25f);
        Vector3 placePosition = lastPosition + new Vector3(randomPadding, 0);
        placePosition.y = Random.Range(minPosY, maxPosY);

        transform.position = placePosition;

        return placePosition;
    }
}