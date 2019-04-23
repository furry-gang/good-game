
using UnityEngine;

public class EdgeWarp : MonoBehaviour {
    void Update ()
    {
        var onScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
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
        if (onScreenPosition.y > Screen.height)
        {
            newposition.y = 0;
        }

        var worldCoordinates = Camera.main.ScreenToWorldPoint(newposition);
        this.transform.position = new Vector3(worldCoordinates.x, 0, worldCoordinates.z);
        
    }

}