using UnityEngine;

public class RandomManager : MonoBehaviour
{
    public Vector2 GetRandomPosition()
    {
        int randomEdgeOfScreen = Random.Range(1, 4);
        switch (randomEdgeOfScreen)
        {
            case 1:
                return RandomLeftEdge();
            case 2:
                return RandomRightEdge();
            case 3:
                return RandomTopEdge();
            case 4:
                return RandomBottomEdge();
            default:
                return RandomTopEdge();
        }
    }

    private Vector2 RandomLeftEdge()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), 0));
    }

    private Vector2 RandomRightEdge()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0, Screen.height), 0));
    }

    private Vector2 RandomTopEdge()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, 0));
    }

    private Vector2 RandomBottomEdge()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0, 0));
    }
}
