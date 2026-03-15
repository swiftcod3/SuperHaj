using UnityEngine;

public class followMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        catch
        {

        }

    }
}
