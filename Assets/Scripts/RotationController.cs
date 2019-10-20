using UnityEngine;

public class RotationController : MonoBehaviour
{
    public bool enable = true;

    private Touch touch;
    private Vector2 touchPostition;
    private Quaternion rotation;
    private float rotateSpeed = 1;



    Vector3 currentPositon;
    Vector3 deltaPositon;
    Vector3 lastPositon;


    private void Update()
    {
        if(enable)
#if UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {

            currentPositon = Input.mousePosition;
            deltaPositon = currentPositon - lastPositon;
            lastPositon = currentPositon;



            rotation = Quaternion.Euler(new Vector3(0, 0, deltaPositon.x * rotateSpeed));
            //  Quaternion.Euler(new Vector3(0, 0, Input.mousePosition.x * _sensitivity));
            transform.rotation *= rotation;
        }

#else

                if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotation = Quaternion.Euler(0, 0, touch.deltaPosition.x * rotateSpeed);
                transform.rotation *= rotation;
            }
        }
#endif

    }


}
