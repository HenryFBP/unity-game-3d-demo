using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool alive = true;

    void Die()
    {
        print("ded :3c");
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic= true;
        GetComponent<PlayerMovement>().enabled = false;
        this.alive = false;

        Invoke(nameof(ReloadLevel), 2f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (player.transform.position.y <= -1f)
            {
                print("Fell out da world!");
                Die();
            }

        }
    }

}
