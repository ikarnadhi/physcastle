using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation.Systems
{
    public class TipController : MonoBehaviour
    {
        [FormerlySerializedAs("movetip")]
        public GameObject moveTip;
        [FormerlySerializedAs("usetip")]
        public GameObject useTip;
        [FormerlySerializedAs("throwtip")]
        public GameObject throwTip;
        [FormerlySerializedAs("jumptip")]
        public GameObject jumpTip;
        [FormerlySerializedAs("flashtip")]
        public GameObject flashTip;
        static bool jumped = false;

        // Start is called before the first frame update
        private void Start()
        {
            throwTip.SetActive(false);
            jumpTip.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                moveTip.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                useTip.SetActive(false);
                throwTip.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                throwTip.SetActive(false);
            }

            if (jumped)
            {
                jumpTip.SetActive(true);
                if (Input.GetButtonDown("Jump"))
                {
                    jumpTip.SetActive(false);
                    jumped = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                flashTip.SetActive(false);
            }
        }

        public static void jumpingtip()
        {
            jumped = true;
        }
    }
}