using UnityEngine;

public class Branch : MonoBehaviour
{
    public float bottomY = -20f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
