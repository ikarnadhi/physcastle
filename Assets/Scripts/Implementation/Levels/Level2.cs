using UnityEngine;
using UnityEngine.Serialization;

public class Level2 : MonoBehaviour
{
    public WeightMeasure weighter1;
    public WeightMeasure weighter2;
    public float mass1 = 0;
    public float mass2 = 0;
    public float targetmass = 0;
    public bool win = false;
    public GameObject winLight;
    public TextMesh comparerText;
    public GameObject door;
    private OpenDoor doorController;
    public Vector2 doorTranslate;
    string showtext;
    // Start is called before the first frame update
    void Start()
    {
        winLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mass1 = weighter1.mass;
        mass2 = weighter2.mass;
        showtext = mass1 + " kg & " + mass2 + " kg";
        comparerText.text = showtext;
        if(mass1 == targetmass && mass2 == targetmass && !win)
        {
            winLight.SetActive(true);
            win = true;
            doorController.Open();
        }
    }
}
