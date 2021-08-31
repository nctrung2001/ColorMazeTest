using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneM : MonoBehaviour
{
    private GameObject checkCount;
    [SerializeField] private int y, nextLevel;

    private void Awake()
    {
        checkCount = GameObject.FindGameObjectWithTag("check");

        y = SceneManager.GetActiveScene().buildIndex;
        if(y<6)
        {
            nextLevel = y+1;
        }
        else if(y == 6)
        {
            nextLevel = 0;
        }
    }

    private void Update()
    {
        if(checkCount != null)
        {
            if(checkCount.transform.childCount == 0)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
        
    }

    public void Play()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
