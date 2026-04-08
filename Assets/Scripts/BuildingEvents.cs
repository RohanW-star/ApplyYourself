using System.Collections;
using UnityEngine;

public class BuildingEvents : MonoBehaviour
{
    public Canvas canvas;
    private ClickOnBuildings ClickOnBuildings;
    private AudioSource audioSource;

    private void Start()
    {
        ClickOnBuildings = Object.FindFirstObjectByType<ClickOnBuildings>();
        GameObject obj = GameObject.FindGameObjectWithTag("Audio");
        audioSource = obj.GetComponent<AudioSource>();
    }
    public void SpawnCanvas()
    {
        Instantiate(canvas, canvas.transform.position, Quaternion.identity);
        ClickOnBuildings.enabled = false;
        audioSource.PlayOneShot(audioSource.clip);
        Destroy(this.gameObject);
    }
}
