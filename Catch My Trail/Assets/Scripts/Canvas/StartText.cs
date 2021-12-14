using UnityEngine;
using TMPro;

    public class StartText : MonoBehaviour
    {
        public TextMeshProUGUI txtmesh;

        [SerializeField] private float changeVal = 5f;

        [SerializeField]
        private int upperLimit;
        [SerializeField]
        private int lowerLimit;
        bool goUP = true;

        private void Update()
        {
            
            if (goUP)
            {
                txtmesh.fontSize += changeVal * Time.deltaTime;

                ChangeValueBetweenNumbers(upperLimit, lowerLimit, txtmesh.fontSize );
            }
            else
            {
                txtmesh.fontSize -= changeVal * Time.deltaTime;

                ChangeValueBetweenNumbers(upperLimit, lowerLimit, txtmesh.fontSize );
            }
        }
        public void ChangeValueBetweenNumbers(int minPoint, int maxPoint, float value)
        {
            if (value > maxPoint)
            {
                goUP = false;
            }
            else if (value < minPoint)
            {
                goUP = true;
            }

        }
    }

