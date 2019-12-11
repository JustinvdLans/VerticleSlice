using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == Constants.Tags.Player)
        {
            SceneManager.LoadScene(0);
        }
    }
}
