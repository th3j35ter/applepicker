using UnityEngine;

public class Apple : MonoBehaviour
{
    public float bottomY = -20f;
    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y < bottomY )
        {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
        }
    }
}
