using Implementation.Systems;
using UnityEngine;

namespace Implementation.Levels
{
    public class Level2 : MonoBehaviour
    {
        public WeightMeasure weighter1;
        public WeightMeasure weighter2;
        public int mass1 = 0;
        public int mass2 = 0;
        public float targetmass = 0;
        public bool win = false;
        public GameObject winLight;
        public TextMesh comparerText;
        private OpenDoor _doorController;

        string showtext;

        // Start is called before the first frame update
        private void Start()
        {
            winLight.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            mass1 = weighter1.totalMass;
            mass2 = weighter2.totalMass;
            showtext = mass1 + " kg & " + mass2 + " kg";
            comparerText.text = showtext;
            if (mass1 == mass2 && !win)
            {
                winLight.SetActive(true);
                win = true;
                _doorController.Open();
            }
        }
    }
}