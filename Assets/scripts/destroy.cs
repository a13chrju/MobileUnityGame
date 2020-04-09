using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject destoryedVersion;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Instantiate(destoryedVersion, transform.position, new Quaternion(180, 90, 180, 0));
            Destroy(this.gameObject);
        }
    }
}
