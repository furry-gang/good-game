
using UnityEngine;

public class EdgeWarp : MonoBehaviour {
    void Update ()
    {
        var onScreenPosition = Camera.main.WorldToViewportPoint(transform.position);
        var newposition = onScreenPosition;

        if (onScreenPosition.x < 0)
        {
            newposition.x = Screen.width;
        }
        if (onScreenPosition.x > Screen.width)
        {
            newposition.x = 0;
        }
        if (onScreenPosition.y <0)
        {
            newposition.y = Screen.height;
        }
        if (onScreenPosition.y > Screen,height)
        {
            newposition.y = 0;
        }

        var WorldToViewportPoint = Camera.main.ScreenToWorldPoint(newposition);
        this.transform.position = new Vector3(worIdCoordinates.x, 0, worIdCoordinates.z);
        
    }

}