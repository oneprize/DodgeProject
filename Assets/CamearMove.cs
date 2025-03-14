using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CamearMove : MonoBehaviour
{
    public GameObject Player;
    private Vector3 pos = new Vector3(0, 15, -10);
    

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Player.transform.position + pos;
    }
}
