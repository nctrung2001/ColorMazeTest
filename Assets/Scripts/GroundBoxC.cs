using UnityEngine;

public class GroundBoxC : MonoBehaviour
{
    [SerializeField] private Material greenMaterial;
    private GameObject sceneMng;

    private void Awake()
    {
        sceneMng = GameObject.FindGameObjectWithTag("SceneManager");
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            ChangeColor();
        }
    }

    void ChangeColor(){
        gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        
    }
}
